using System;
using System.IO;
using System.Linq;
using Lolc.Asts;
using static Lolc.Scopes.SymbolType;

namespace Lolc.Scopes
{
    // TODO: rename this to FunctionScope
    public class LocalScope : AbstractScope
    {
        public string FunctionName { get; init; }
        public Asts.ValueType ReturnType { get; init; }

        public LocalScope(string funcName, Asts.ValueType returnType, AbstractScope parent) : base(parent)
        {
            FunctionName = funcName;
            ReturnType = returnType;
        }

        public override void Emit(TextWriter outStream)
        {
            outStream.WriteLine($@"
.method private hidebysig 
    instance void {FunctionName} (");

            var paramSymbols = Symbols.Where(s => s.SymbolType == Parameter);

            if (paramSymbols.Any())
            {
                outStream.Write("        ");
                outStream.WriteLine(string.Join(",\n        ", paramSymbols.Select(sym => $"{sym.ValueType.ToCilType()} {sym.Identifier}")));
            }

            outStream.WriteLine(@"    ) cil managed
{");

            outStream.WriteLine(Body);

            outStream.WriteLine("    ret");
            outStream.WriteLine("}");
        }

        public override Symbol GetSymbol(string identifier)
        {
            try
            {
                return base.GetSymbol(identifier);
            }
            catch (InvalidOperationException)
            {
                var symbol = Symbols.FirstOrDefault(sym => sym.SymbolType == Parameter && sym.Identifier == identifier);

                if (symbol is not null)
                {
                    return symbol;
                }
                else
                {
                    throw;
                }
            }
        }
    }
}