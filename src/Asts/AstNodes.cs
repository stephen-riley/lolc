using System.Collections.Generic;

namespace Lolc.Asts
{
    public abstract class AbstractAstNode
    {
        public abstract string NodeType { get; }
    }

    public class ProgramNode : AbstractAstNode
    {
        public override string NodeType => "ProgramStart";

        public IList<AbstractAstNode> Statements = new List<AbstractAstNode>();
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

        public ValueType VarType { get; set; }

        public string Identifier { get; set; }
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
}