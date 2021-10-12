using System.Diagnostics.CodeAnalysis;
using Lolc.Scopes;
using static Lolc.Asts.ValueType;

namespace Lolc.Asts
{
    [SuppressMessage("Performance", "CA1822", Justification = "Dynamic dispatch requires instance methods")]
    public class TypeEvaluator
    {
        private readonly AbstractScope scope;

        public TypeEvaluator(AbstractScope scope)
        {
            this.scope = scope;
        }

        public static ValueType GetExpressionType(AbstractScope scope, AbstractAstNode node)
        {
            return new TypeEvaluator(scope).Visit((dynamic)node);
        }

        private ValueType Visit(AbstractAstNode _) => TUnknown;

        private ValueType Visit(StringNode _) => TString;
        private ValueType Visit(IntNode _) => TInt;
        private ValueType Visit(DoubleNode _) => TFloat;

        private ValueType Visit(IdentifierNode node)
        {
            var sym = scope.GetSymbol(node.Identifier);
            return sym.ValueType;
        }
    }
}