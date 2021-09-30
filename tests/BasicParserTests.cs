using Antlr4.Runtime;
using Lolc.Antlr;
using LolCode.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lolc.Tests
{
    [TestClass]
    public class BasicParserTests
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
            parser.program();
            return !(listener_lexer.HadError || listener_parser.HadError);
        }

        [DataTestMethod]
        [DynamicData(nameof(TestSources.GetSources), typeof(TestSources), DynamicDataSourceType.Method)]
        public void CanParseSampleProgramsToCil(string source, string label)
        {
            Assert.IsTrue(ParseProgram(source), label);
        }
    }
}
