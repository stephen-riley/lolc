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

            yield return new object[] { @"
                O HAI
                IM IN YR LOOPZ
                IM OUTTA YR LOOPZ
            ", "basic infinite loop" };

            yield return new object[] { @"
                O HAI
                IM IN YR LOOPZ
                    GTFO
                IM OUTTA YR LOOPZ
            ", "anonymous loop exit" };

            yield return new object[] { @"
                O HAI
                IM IN YR LOOPZ
                    GTFO LOOPZ
                IM OUTTA YR LOOPZ
            ", "named loop exit" };

            yield return new object[] { @"
                O HAI
                IM IN YR LOOP1
                    IM IN YR LOOP2
                        GTFO LOOP1
                    IM OUTTA YR LOOP2
                IM OUTTA YR LOOP1
            ", "named outer loop exit" };
        }
    }
}