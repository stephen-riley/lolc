using System;
using static Lolc.Asts.ValueType;

namespace Lolc.Asts
{
    public static class AstExtensions
    {
        public static string ToCilType(this ValueType valueType)
        {
            return valueType switch
            {
                TInt => "int32",
                TFloat => "float64",
                TString => "string",
                _ => throw new InvalidOperationException()
            };
        }
    }
}