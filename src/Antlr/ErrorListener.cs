// Template generated code from Antlr4BuildTasks.Template v 8.14
namespace Lolc.Antlr
{
    using Antlr4.Runtime;
    using System.Collections.Generic;
    using System.IO;

    public class ErrorListener<S> : ConsoleErrorListener<S>
    {
        public bool HadError { get; private set; }
        public List<string> Errors { get; } = new();

        public override void SyntaxError(TextWriter output, IRecognizer recognizer, S offendingSymbol, int line,
            int col, string msg, RecognitionException e)
        {
            HadError = true;
            Errors.Add(msg);

            base.SyntaxError(output, recognizer, offendingSymbol, line, col, msg, e);
        }
    }
}