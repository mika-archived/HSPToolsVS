using Microsoft.VisualStudio.Package;
using Microsoft.VisualStudio.TextManager.Interop;

namespace HSPToolsVS.Language
{
    // ReSharper disable once InconsistentNaming
    // Line-based syntax scanner
    internal class HSPScanner : IScanner
    {
        private readonly HSPLexer _lexer;
        private IVsTextBuffer _textBuffer;

        public HSPScanner(IVsTextBuffer textBuffer)
        {
            _textBuffer = textBuffer;
            _lexer = new HSPLexer();
        }

        public void SetSource(string source, int offset)
        {
            _lexer.SetCurLine(source, offset);
        }

        public bool ScanTokenAndProvideInfoAboutIt(TokenInfo tokenInfo, ref int state)
        {
            var token = _lexer.GetNextToken(ref state);
            if (token == null)
                return false;
            tokenInfo.StartIndex = token.StartIndex;
            tokenInfo.EndIndex = token.EndIndex;
            tokenInfo.Type = token.Type.ToTokenType();
            tokenInfo.Color = token.Type.ToColor();
            return true;
        }
    }
}