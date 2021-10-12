namespace Lolc.Scopes
{
    public class Symbol
    {
        public string Identifier { get; set; }
        public SymbolType SymbolType { get; set; } = SymbolType.Global;
        public int Ordinal { get; set; }
        public Asts.ValueType ValueType { get; set; }
    }
}