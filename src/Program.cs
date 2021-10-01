// Template generated code from Antlr4BuildTasks.Template v 8.14
using System;
using Antlr4.Runtime;
using Lolc.Antlr;
using Lolc.Emitters;
using LolCode.Internal;

namespace Lolc
{
    public class Program
    {
        static void Main(string[] _)
        {
            Try(@"
                O HAI
                IM IN YR LOOP1
                    IM IN YR LOOP2
                        I SEZ ""about to jump out of loop 2 to the end of loop1""
                        GTFO LOOP1
                    IM OUTTA YR LOOP2
                IM OUTTA YR LOOP1
                I SEZ ""outside of all loops""
            ");
        }

        static void Try(string input)
        {
            var str = new AntlrInputStream(input);
            var lexer = new LolCodeLexer(str);
            var tokens = new CommonTokenStream(lexer);
            var parser = new LolCodeParser(tokens);
            var listener_lexer = new ErrorListener<int>();
            var listener_parser = new ErrorListener<IToken>();
            lexer.AddErrorListener(listener_lexer);
            parser.AddErrorListener(listener_parser);
            var tree = parser.program();
            if (listener_lexer.HadError || listener_parser.HadError)
            {
                Console.Error.WriteLine("error in parse.");
            }
            else
            {
                Console.Error.WriteLine(tree.ToStringTree(parser));
                Console.Error.WriteLine("parse completed.");
                var ast = new AstGenerator().VisitProgram(tree);
                new CilEmitter(ast).Process().Emit(Console.Out);
                Console.Error.WriteLine("done.");
            }
        }
    }
}
