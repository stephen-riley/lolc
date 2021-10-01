using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using Lolc.Asts;
using Lolc.Scopes;
using static Lolc.Asts.AstOperator;
using static Lolc.Asts.ValueType;

namespace Lolc.Emitters
{
    public class CilEmitter
    {
        private readonly ProgramScope ProgramScope = new();

        private int DestLabelCounter = 0;

        private AbstractScope CurrentScope;

        private readonly AbstractAstNode node;

        private readonly LinkedList<(string loopIdentifier, string endLabel)> loopIdentifiers = new();

        public CilEmitter(AbstractAstNode node)
        {
            this.node = node;
        }

        public CilEmitter Process()
        {
            CurrentScope = ProgramScope.GlobalScope;
            Visit((dynamic)node);
            return this;
        }

        private string GetDestLabel()
        {
            var label = $"l_{DestLabelCounter.ToString().PadLeft(4, '0')}";
            DestLabelCounter++;
            return label;
        }

        public void Emit(TextWriter outStream)
        {
            ProgramScope.Emit(outStream);
        }

        [SuppressMessage("Performance", "CA1822")]
        private void Visit(AbstractAstNode node)
        {
            Console.Error.WriteLine($"ERROR: unsupported node type {node.NodeType}");
        }

        private void Visit(ProgramNode node)
        {
            foreach (var stat in node.Statements)
            {
                Visit((dynamic)stat);
            }
        }

        private void Visit(PrintNode node)
        {
            Visit((dynamic)node.Expression);

            var exprType = TypeEvaluator.GetExpressionType(CurrentScope, node.Expression);

            switch (exprType)
            {
                case TString:
                    CurrentScope.Body.WriteLine($"    call void [mscorlib]System.Console::WriteLine(string)");
                    break;

                case TInt:
                    CurrentScope.Body.WriteLine($"    call void [mscorlib]System.Console::WriteLine(int32)");
                    break;

                case TFloat:
                    CurrentScope.Body.WriteLine($"    call void [mscorlib]System.Console::WriteLine(float64)");
                    break;

                default:
                    throw new NotImplementedException();
            }
        }

        private void Visit(StringNode node)
        {
            CurrentScope.Body.WriteLine($"    ldstr {node.StringValue}");
        }

        private void Visit(IntNode node)
        {
            CurrentScope.Body.WriteLine($"    ldc.i4.s {node.IntValue}");
        }

        private void Visit(DoubleNode node)
        {
            CurrentScope.Body.WriteLine($"    ldc.r8 {node.DoubleValue}");
        }

        private void Visit(IdentifierNode node)
        {
            var symbol = CurrentScope.GetSymbol(node.Identifier);
            if (CurrentScope.IsGlobal)
            {
                CurrentScope.Body.WriteLine("    ldarg.0");
                CurrentScope.Body.WriteLine($"    ldfld {symbol.ValueType.ToCilType()} Program::{symbol.Identifier}");
            }
        }

        private void Visit(VarDeclNode node)
        {
            CurrentScope.AddSymbol(node.Identifier, node.VarType);
        }

        private void Visit(AssignmentNode node)
        {
            var exprType = TypeEvaluator.GetExpressionType(CurrentScope, node.Expression);
            if (exprType is TString or TInt or TFloat)
            {
                if (CurrentScope.IsGlobal)
                {
                    CurrentScope.Body.WriteLine("    ldarg.0");
                    Visit((dynamic)node.Expression);
                    CurrentScope.Body.WriteLine($"    stfld {exprType.ToCilType()} Program::{node.Identifier}");
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        private void Visit(IfThenElseNode node)
        {
            Visit((dynamic)node.Conditional);
            var elseLabel = GetDestLabel();
            var endLabel = GetDestLabel();
            CurrentScope.Body.WriteLine($"    brfalse.s {elseLabel}");
            Visit((dynamic)node.ThenBlock);
            CurrentScope.Body.WriteLine($"    br.s {endLabel}");
            CurrentScope.Body.WriteLine($"{elseLabel}:");
            if (node.ElseBlock != null)
            {
                Visit((dynamic)node.ElseBlock);
            }
            CurrentScope.Body.WriteLine($"{endLabel}:");
        }

        private void Visit(BinaryOperatorNode node)
        {
            Visit((dynamic)node.LeftExpr);
            Visit((dynamic)node.RightExpr);
            var instr = node.Operator switch
            {
                Eq => "ceq",
                Neq => "TODO",
                Gt => "cgt.un",
                Lt => "clt.un",
                Add => "add",
                Subtract => "sub",
                Multiply => "mul",
                Divide => "div",
                _ => throw new NotImplementedException(),
            };
            CurrentScope.Body.WriteLine($"    {instr}");
        }

        // TODO: open a new local scope for a loop
        //  for later dead-code detection
        private void Visit(LoopNode node)
        {
            var loopIdentifier = node.Identifier;
            var loopStartLabel = GetDestLabel();
            var loopEndLabel = GetDestLabel();

            loopIdentifiers.AddFirst((loopIdentifier, loopEndLabel));

            CurrentScope.Body.WriteLine($"{loopStartLabel}:");
            foreach (var stat in node.Statements)
            {
                Visit((dynamic)stat);
            }
            CurrentScope.Body.WriteLine($"    br {loopStartLabel}");
            CurrentScope.Body.WriteLine($"{loopEndLabel}:");

            if (loopIdentifiers.First.Value.loopIdentifier == loopIdentifier)
            {
                loopIdentifiers.RemoveFirst();
            }
            else
            {
                throw new InvalidOperationException($"invalid loop structure--thought I was closing loop {loopIdentifier}, but see {loopIdentifiers.First.Value.loopIdentifier} as the most current loop");
            }
        }

        private void Visit(LoopExitNode node)
        {
            var loopIdentifier = node.Identifier;

            if (loopIdentifier is null)
            {
                if (loopIdentifiers.Any())
                {
                    CurrentScope.Body.WriteLine($"    br {loopIdentifiers.First.Value.endLabel}");
                    return;
                }
            }
            else
            {
                foreach (var el in loopIdentifiers)
                {
                    if (el.loopIdentifier == loopIdentifier)
                    {
                        CurrentScope.Body.WriteLine($"    br {el.endLabel}");
                        return;
                    }
                }
            }

            throw new InvalidOperationException($"invalid loop break label {loopIdentifier}");
        }
    }
}