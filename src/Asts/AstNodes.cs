using System.Collections.Generic;
using Lolc.Scopes;

namespace Lolc.Asts
{
    public abstract class AbstractAstNode
    {
        public abstract string NodeType { get; }
    }

    public class ProgramNode : AbstractAstNode
    {
        public override string NodeType => "ProgramStart";

        public IList<AbstractAstNode> Statements { get; set; }
    }

    public abstract class StatementNode : AbstractAstNode
    {
        public override string NodeType => "Statement";
    }

    public class PrintNode : StatementNode
    {
        public override string NodeType => "Print";

        public AbstractAstNode Expression { get; set; }
    }

    public class ExpressionNode : AbstractAstNode
    {
        public override string NodeType => "Expression";

        public AbstractAstNode Expression { get; set; }
    }

    public class StringNode : AbstractAstNode
    {
        public override string NodeType => "String";

        public string StringValue { get; set; }
    }

    public class IntNode : AbstractAstNode
    {
        public override string NodeType => "Int";

        public int IntValue { get; set; }
    }

    public class DoubleNode : AbstractAstNode
    {
        public override string NodeType => "Double";

        public double DoubleValue { get; set; }
    }

    public class VarDeclNode : AbstractAstNode
    {
        public override string NodeType => "VarDecl";

        public IdentifierTypePair IdType { get; set; }
    }

    public class AssignmentNode : AbstractAstNode
    {
        public override string NodeType => "Assignment";

        public string Identifier { get; set; }

        public AbstractAstNode Expression { get; set; }
    }

    public class IdentifierNode : AbstractAstNode
    {
        public override string NodeType => "Identifier";

        public string Identifier { get; set; }
    }

    public class IfThenElseNode : AbstractAstNode
    {
        public override string NodeType => "IfThenElse";

        public AbstractAstNode Conditional { get; set; }

        public AbstractAstNode ThenBlock { get; set; }

        // TODO: else if blocks (MEBBE)

        public AbstractAstNode ElseBlock { get; set; }
    }

    public class BinaryOperatorNode : AbstractAstNode
    {
        public override string NodeType => "BinaryOperator";

        public AbstractAstNode LeftExpr { get; set; }

        public AbstractAstNode RightExpr { get; set; }

        public AstOperator Operator { get; set; }
    }

    public class LoopNode : AbstractAstNode
    {
        public override string NodeType => "Loop";

        public string Identifier { get; set; }

        public IList<AbstractAstNode> Statements = new List<AbstractAstNode>();
    }

    public class LoopExitNode : AbstractAstNode
    {
        public override string NodeType => "LoopExit";

        public string Identifier { get; set; }
    }

    public class FuncDeclNode : AbstractAstNode
    {
        public override string NodeType => "FuncDecl";

        public string Identifier { get; set; }

        public IList<Symbol> ParamsList { get; set; }

        public IList<AbstractAstNode> Statements { get; set; }

        public ValueType ReturnType { get; set; }
    }

    public class FuncCallNode : AbstractAstNode
    {
        public override string NodeType => "FuncCall";

        public string Identifier { get; set; }

        public IList<AbstractAstNode> ParamExpressionsList { get; set; }
    }
}