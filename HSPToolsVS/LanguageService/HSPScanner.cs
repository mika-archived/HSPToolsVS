using Microsoft.VisualStudio.Package;
using Microsoft.VisualStudio.TextManager.Interop;

namespace HSPToolsVS.LanguageService
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
            // Debug.WriteLine("--- NEWLINE ---");
        }

        public bool ScanTokenAndProvideInfoAboutIt(TokenInfo tokenInfo, ref int state)
        {
            var token = _lexer.GetNextToken(ref state);
            if (token == null)
                return false;
            // Debug.WriteLine(token.ToString());
            tokenInfo.StartIndex = token.StartIndex;
            tokenInfo.EndIndex = token.EndIndex;
            tokenInfo.Type = token.Type.ToTokenType();
            tokenInfo.Color = token.Type.ToColor();
            tokenInfo.Token = (int) token.Type;
            return true;
        }
    }
}