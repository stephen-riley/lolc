using Antlr4.Runtime;
using Lolc.Antlr;
using Lolc.Emitters;
using LolCode.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lolc.Tests
{
    [TestClass]
    public class BasicCilEmitterTests
    {
        public static bool CompileProgram(string source)
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
            var okay = !(listener_lexer.HadError || listener_parser.HadError);

            if (okay)
            {
                var ast = new AstGenerator().VisitProgram(tree);
                new CilEmitter(ast).Process().Emit(System.Console.Out);
            }

            return okay;
        }

        [DataTestMethod]
        [DynamicData(nameof(TestSources.GetSources), typeof(TestSources), DynamicDataSourceType.Method)]
        public void CanCompileSamplePrograms(string source, string label)
        {
            Assert.IsTrue(CompileProgram(source), label);
        }
    }
}
