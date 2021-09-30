using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Lolc.Asts;
using Lolc.Scopes;
using static Lolc.Asts.ValueType;

namespace Lolc.Emitters
{
    public class CilEmitter
    {
        private readonly ProgramScope ProgramScope = new();

        private AbstractScope CurrentScope;

        private readonly AbstractAstNode node;

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
    }
}