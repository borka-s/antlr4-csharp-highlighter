using System.IO;
using CSharpHighlighter.Antlr;

namespace CSharpHighlighter
{
    public class CSharpSyntaxHighlighter : CSharpParserBaseListener
    {
        private readonly StringWriter _writter;

        public CSharpSyntaxHighlighter(StringWriter writter)
        {
            _writter = writter;
        }

        public override void EnterProg(CSharpParser.ProgContext context)
        {
            _writter.Write("<html><head><meta charset='UTF-8'/><title>Generated</title></head><body style=' overflow: auto; background-color: #1e1e1e; color: #dcdcdc; '><pre><code>");
        }

        public override void EnterKeyword(CSharpParser.KeywordContext context)
        {
            _writter.Write("<span style='color: #569CD6'>");
            _writter.Write(context.GetText().Trim());
        }

        public override void EnterNumeric_literal(CSharpParser.Numeric_literalContext context)
        {
            _writter.Write("<span style='color: #B5CEA8'>");
            _writter.Write(context.GetText().Trim());
        }

        public override void EnterString_literal(CSharpParser.String_literalContext context)
        {
            _writter.Write("<span style='color: #D69D85'>");
            _writter.Write(context.GetText().Trim());
        }

        public override void EnterComment(CSharpParser.CommentContext context)
        {
            _writter.Write("<span style='color: #57A64A'>");
            _writter.Write(context.GetText().Trim());
        }

        public override void EnterRest(CSharpParser.RestContext context)
        {
            _writter.Write(context.GetText());
        }

        public override void ExitKeyword(CSharpParser.KeywordContext context)
        {
            _writter.Write("</span>");
        }

        public override void ExitNumeric_literal(CSharpParser.Numeric_literalContext context)
        {
            _writter.Write("</span>");
        }

        public override void ExitString_literal(CSharpParser.String_literalContext context)
        {
            _writter.Write("</span>");
        }

        public override void ExitComment(CSharpParser.CommentContext context)
        {
            _writter.Write("</span>");
        }

        public override void ExitProg(CSharpParser.ProgContext context)
        {
            _writter.Write("</code></pre></body></html>");
        }
    }
}