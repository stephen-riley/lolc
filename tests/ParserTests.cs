using System;
using Antlr4.Runtime;
using Lolc.Antlr;
using Lolc.Emitters;
using LolCode.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lolc.Tests
{
    [TestClass]
    public class ParserTests
    {
        public static bool ParseProgram(string source)
        {
            var str = new AntlrInputStream(source);
            var lexer = new LolCodeLexer(str);
            var tokens = new CommonTokenStream(lexer);
            var parser = new LolCodeParser(tokens);
            var listener_lexer = new ErrorListener<int>();
            var listener_parser = new ErrorListener<IToken>();
            lexer.AddErrorListener(listener_lexer);
            parser.AddErrorListener(listener_parser);
            var tree = parser.program();
            return tree != null;
        }

        [TestMethod]
        public void CanParseDegenerateProgram()
        {
            ParseProgram(@"
                O HAI
            ");
        }

        [TestMethod]
        public void CanParseEmptyProgram()
        {
            ParseProgram(@"
                O HAI
                KTHXBYE
            ");
        }

        [TestMethod]
        public void CanDoPrintStringLiteral()
        {
            ParseProgram(@"
                O HAI
                I SEZ ""Hello, World!""
                KTHXBYE
            ");
        }

        [TestMethod]
        public void CanDoAssignStringLiteral()
        {
            ParseProgram(@"
                O HAI
                I HAZ A YARN ITZ BOB
                LOL BOB R ""Hello, World!""
            ");
        }

        [TestMethod]
        public void CanDoAssignIntLiteral()
        {
            ParseProgram(@"
                O HAI
                I HAZ A NUMBR ITZ BOB
                LOL BOB R 1
            ");
        }

        [TestMethod]
        public void CanDoIfThen()
        {
            ParseProgram(@"
                O HAI
                I HAZ A NUMBR ITZ BOB
                LOL BOB R 1
                IZ BOB LIEK 1 ?
                YARLY!
                    I SEZ ""TROOF""
                NOWAI!
                    I SEZ ""LIEZ!""
                KTHX
            ");
        }
    }
}
