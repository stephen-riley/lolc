using System.Collections.Generic;

namespace Lolc.Tests
{
    public class TestSources
    {
        public static IEnumerable<object[]> GetSources()
        {
            yield return new object[] { @"
                O HAI
            ", "degenerate program" };

            yield return new object[] { @"
                O HAI
                KTHXBYE
            ", "empty program" };

            yield return new object[] { @"
                O HAI
                I SEZ ""Hello, World!""
                KTHXBYE
            ", "print string literal" };

            yield return new object[] { @"
                O HAI
                I HAZ A YARN ITZ BOB
                LOL BOB R ""Hello, World!""
            ", "assign string literal" };

            yield return new object[] { @"
                O HAI
                I HAZ A NUMBR ITZ BOB
                LOL BOB R 1
            ", "assign int literal" };

            yield return new object[] { @"
                O HAI
                I HAZ A NUMBR ITZ BOB
                LOL BOB R 1
                IZ BOB LIEK 1 ?
                YARLY!
                    I SEZ ""TROOF""
                NOWAI!
                    I SEZ ""LIEZ!""
                KTHX
            ", "basic if-then-else" };
        }
    }
}