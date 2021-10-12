using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lolc.Scopes
{
    public abstract class AbstractScope
    {
        public List<Symbol> Symbols { get; } = new();

        public StringWriter Body { get; } = new();

        public AbstractScope Parent { get; init; }

        public virtual bool IsGlobal { get; } = false;

        public AbstractScope(AbstractScope parent)
        {
            Parent = parent;
        }

        public Symbol AddSymbol(string name, Asts.ValueType valueType)
        {
            var symbol = new Symbol { Identifier = name, ValueType = valueType, Ordinal = Symbols.Count };
            Symbols.Add(symbol);
            return symbol;
        }

        public virtual Symbol GetSymbol(string identifier)
        {
            var symbol = Symbols.FirstOrDefault(sym => sym.Identifier == identifier);
            if (symbol is not null)
            {
                return symbol;
            }
            else
            {
                throw new InvalidOperationException($"No such symbol {identifier}");
            }
        }

        public abstract void Emit(TextWriter outStream);
    }
}