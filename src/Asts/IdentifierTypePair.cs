namespace Lolc.Asts
{
    public struct IdentifierTypePair
    {
        public string Identifier { get; set; }

        public ValueType Type { get; set; }

        public string ToCilDeclString()
        {
            return $"{Type.ToCilType()} {Identifier}";
        }
    }
}