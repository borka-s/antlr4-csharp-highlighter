using System.IO;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using CSharpHighlighter.Antlr;

namespace CSharpHighlighter
{
    internal class Program
    {
        private static void Main()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "../../..");
            Directory.SetCurrentDirectory(Path.GetFullPath(path));

            var input = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "input.txt"));

            var inputStream = new AntlrInputStream(input);
            var lexer = new CSharpLexer(inputStream);
            var commonTokenStream = new CommonTokenStream(lexer);
            var parser = new CSharpParser(commonTokenStream);
            var walker = new ParseTreeWalker();

            var writter = new StringWriter();
            var highlighter = new CSharpSyntaxHighlighter(writter);

            walker.Walk(highlighter, parser.prog());

            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Html", "output"));
            File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "Html", "output", "generated.html"), writter.ToString());
        }
    }
}