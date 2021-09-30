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
            // Try(@"
            //     O HAI

            //     I SEZ (""hello, world!"")
            //     I SEZ ""all done!""
            // ");

            Try(@"
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
            if (listener_lexer.had_error || listener_parser.had_error)
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
