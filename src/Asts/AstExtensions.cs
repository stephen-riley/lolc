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
                TVoid => "void",
                _ => throw new InvalidOperationException()
            };
        }

        public static ValueType ToValueType(this string type)
        {
            return type switch
            {
                "NUMBR" => TInt,
                "NUMBAR" => TFloat,
                "YARN" => TString,
                _ => TUnknown
            };
        }
    }
}