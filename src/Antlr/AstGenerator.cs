using System;
using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime.Misc;
using Lolc.Asts;
using LolCode.Internal;
using static Lolc.Asts.AstOperator;
using static Lolc.Asts.ValueType;

namespace Lolc.Antlr
{
    public class AstGenerator : LolCodeBaseVisitor<AbstractAstNode>
    {
        private Dictionary<string, AstOperator> opMap = new()
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
                Identifier = context.ID().GetText(),
                VarType = context.lolType().GetText() switch
                {
                    "NUMBR" => TInt,
                    "NUMBAR" => TFloat,
                    "YARN" => TString,
                    _ => TUnknown
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
    }
}