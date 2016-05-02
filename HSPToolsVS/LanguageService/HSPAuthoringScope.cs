using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using HSPToolsVS.IntelliSense;

using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Package;
using Microsoft.VisualStudio.TextManager.Interop;

namespace HSPToolsVS.LanguageService
{
    // ReSharper disable once InconsistentNaming
    internal class HSPAuthoringScope : AuthoringScope
    {
        private readonly IEnumerable<Token> _tokens;
        private readonly Regex _upperCharRegex = new Regex(@"[^A-Z0-9]");

        public HSPAuthoringScope(IEnumerable<Token> tokens)
        {
            _tokens = tokens;
        }

        public override string GetDataTipText(int line, int col, out TextSpan span)
        {
            span = new TextSpan();
            var token = GetTokenFromLineAndCol(line, col);
            if (token == null || token.Type == HSPTokenType.Comment || token.Type == HSPTokenType.Numeric)
                return null;

            span.iStartLine = line;
            span.iEndLine = line;
            span.iStartIndex = token.StartIndex;
            span.iEndIndex = token.EndIndex;
            return $"{token.Type} : {token.Text}";
        }

        public override Declarations GetDeclarations(IVsTextView view, int line, int col, TokenInfo info,
                                                     ParseReason reason)
        {
            var token = GetTokenFromLineAndCol(line, col - 1);
            if (token == null || token.Type == HSPTokenType.Comment || token.Type == HSPTokenType.Numeric)
                return null;

            return new HSPDeclarations(GetWordCandidatesFromIdentifier(token.Text));
        }

        public override Methods GetMethods(int line, int col, string name)
        {
            return null;
        }

        public override string Goto(VSConstants.VSStd97CmdID cmd, IVsTextView textView, int line, int col,
                                    out TextSpan span)
        {
            span = new TextSpan();
            return null;
        }

        private Token GetTokenFromLineAndCol(int line, int col)
        {
            return _tokens.SingleOrDefault(w => w.Line == line && w.StartIndex <= col && col <= w.EndIndex);
        }

        private IList<string> GetWordCandidatesFromIdentifier(string text)
        {
            var temp =
                _tokens.Where(w => w.Type == HSPTokenType.Idenfitier && w.Text != text)
                       .Select(w => w.Text)
                       .Distinct()
                       .Concat(HSPTokens.AllKeywords.ToList());
            return temp.Where(w => w.StartsWith(text) || text.ToUpper() == _upperCharRegex.Replace(w, "")).ToList();
        }
    }
}