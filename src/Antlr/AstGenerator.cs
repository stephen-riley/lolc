using System;
using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime.Misc;
using Lolc.Asts;
using Lolc.Scopes;
using LolCode.Internal;
using static Lolc.Asts.AstOperator;
using static Lolc.Asts.ValueType;

namespace Lolc.Antlr
{
    public class AstGenerator : LolCodeBaseVisitor<AbstractAstNode>
    {
        private readonly Dictionary<string, AstOperator> opMap = new()
        {
            ["UP"] = Add,
            ["NERF"] = Subtract,
            ["TIEMZ"] = Multiply,
            ["OVAR"] = Divide,
            ["BIGR THAN"] = Gt,
            ["SMALR THAN"] = Lt,
            ["LIEK"] = Eq,
            ["NOTS"] = Neq
        };

        public override AbstractAstNode VisitProgram([NotNull] LolCodeParser.ProgramContext context)
        {
            return new ProgramNode()
            {
                Statements = context._stats.Select(stat => VisitStatement(stat)).ToList()
            };
        }

        public override AbstractAstNode VisitPrint([NotNull] LolCodeParser.PrintContext context)
        {
            return new PrintNode()
            {
                Expression = VisitExpression(context.expr)
            };
        }

        public override AbstractAstNode VisitExpression([NotNull] LolCodeParser.ExpressionContext context)
        {
            if (context.atom() != null)
            {
                return VisitAtom(context.atom());
            }
            else if (context.inner != null)
            {
                return VisitExpression(context.inner);
            }
            else if (context.func_call() != null)
            {
                return VisitFunc_call(context.func_call());
            }
            else
            {
                return new BinaryOperatorNode()
                {
                    LeftExpr = VisitExpression(context.left),
                    RightExpr = VisitExpression(context.right),
                    Operator = opMap[context.op.GetText()]
                };
            }
        }

        public override AbstractAstNode VisitAtom([NotNull] LolCodeParser.AtomContext context)
        {
            if (context.STRING() != null)
            {
                return new StringNode() { StringValue = context.STRING().GetText() };
            }
            else if (context.INT() != null)
            {
                return new IntNode() { IntValue = Int32.Parse(context.INT().GetText()) };
            }
            else if (context.FLOAT() != null)
            {
                return new DoubleNode() { DoubleValue = Double.Parse(context.FLOAT().GetText()) };
            }
            else if (context.ID() != null)
            {
                return new IdentifierNode() { Identifier = context.ID().GetText() };
            }
            else
            {
                return null;
            }
        }

        public override AbstractAstNode VisitVarDecl([NotNull] LolCodeParser.VarDeclContext context)
        {
            return new VarDeclNode()
            {
                IdType = new IdentifierTypePair
                {
                    Identifier = context.ID().GetText(),
                    Type = context.lolType().GetText().ToValueType()
                }
            };
        }

        public override AbstractAstNode VisitAssignment([NotNull] LolCodeParser.AssignmentContext context)
        {
            return new AssignmentNode()
            {
                Identifier = context.ID().GetText(),
                Expression = VisitExpression(context.expression())
            };
        }

        public override AbstractAstNode VisitIf_stat([NotNull] LolCodeParser.If_statContext context)
        {
            return new IfThenElseNode()
            {
                Conditional = VisitExpression(context.expr),
                ThenBlock = VisitIf_true_clause(context.if_true_clause()),
                ElseBlock = VisitIf_false_clause(context.if_false_clause())
            };
        }

        public override AbstractAstNode VisitLoop_stat([NotNull] LolCodeParser.Loop_statContext context)
        {
            if (context.openingId.Text != context.closingId.Text)
            {
                throw new InvalidOperationException($"loop closing identifier {context.closingId.Text} doesn't match opening identifier {context.openingId.Text}");
            }

            return new LoopNode()
            {
                Identifier = context.openingId.Text,
                Statements = context._stats.Select(stat => VisitStatement(stat)).ToList()
            };
        }

        public override AbstractAstNode VisitLoop_exit([NotNull] LolCodeParser.Loop_exitContext context)
        {
            return new LoopExitNode()
            {
                Identifier = context.breakId?.Text
            };
        }

        public override AbstractAstNode VisitFunc_decl([NotNull] LolCodeParser.Func_declContext context)
        {
            var paramsListDecl = context.func_param_list_decl();
            var paramsList = paramsListDecl?._paramsList
                             .Select(pl => new Symbol()
                             {
                                 Identifier = pl.name.Text,
                                 ValueType = pl.type.GetText().ToValueType(),
                                 SymbolType = SymbolType.Parameter,
                             }).ToList();

            var astNode = new FuncDeclNode()
            {
                Identifier = context.name.Text,
                ParamsList = paramsList ?? new List<Symbol>(),
                Statements = context._stats.Select(stat => VisitStatement(stat)).ToList(),
                ReturnType = context.funcType?.GetText().ToValueType() ?? TVoid
            };

            return astNode;
        }

        public override AbstractAstNode VisitFunc_call([NotNull] LolCodeParser.Func_callContext context)
        {
            return new FuncCallNode()
            {
                Identifier = context.funcName.Text,
                ParamExpressionsList = context._paramsList.Select(p => VisitExpression(p)).ToList()
            };
        }
    }
}