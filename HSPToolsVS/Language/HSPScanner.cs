using Microsoft.VisualStudio.Package;
using Microsoft.VisualStudio.TextManager.Interop;

namespace HSPToolsVS.Language
{
    // ReSharper disable once InconsistentNaming
    internal class HSPScanner : IScanner
    {
        private readonly HSPLexer _lexer;
        private string _source;
        private IVsTextBuffer _textBuffer;

        public HSPScanner(IVsTextBuffer textBuffer)
        {
            _textBuffer = textBuffer;
            _lexer = new HSPLexer();
        }

        public void SetSource(string source, int offset)
        {
            _source = source.Substring(offset);
            _lexer.SetCurLine(source, offset);
            _lexer.Tokenize();
        }

        public bool ScanTokenAndProvideInfoAboutIt(TokenInfo tokenInfo, ref int state)
        {
            var foundToken = false;
            var token = _lexer.GetNextToken();
            if (token != null)
            {
                switch (token.Type)
                {
                    case HSPTokenType.Preprocessor:
                        tokenInfo.Color = TokenColor.Comment;
                        tokenInfo.Type = TokenType.Unknown;
                        foundToken = true;
                        break;

                    case HSPTokenType.Keyword:
                        tokenInfo.Color = TokenColor.Keyword;
                        tokenInfo.Type = TokenType.Keyword;
                        foundToken = true;
                        break;
                }
            }
            return foundToken;
        }
    }
}