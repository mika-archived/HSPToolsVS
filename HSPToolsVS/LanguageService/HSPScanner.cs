using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Microsoft.VisualStudio.Package;
using Microsoft.VisualStudio.TextManager.Interop;

namespace HSPToolsVS.LanguageService
{
    // ReSharper disable once InconsistentNaming
    // Line-based syntax scanner
    internal class HSPScanner : IScanner
    {
        private readonly HSPLexer _lexer;
        private readonly IVsTextLines _textLines;
        private readonly List<Token> _tokens;
        private int _line;

        public ReadOnlyCollection<Token> Tokens => new ReadOnlyCollection<Token>(_tokens);

        public HSPScanner(IVsTextLines textBuffer)
        {
            _textLines = textBuffer;
            _lexer = new HSPLexer();
            _tokens = new List<Token>();
            _line = 0;
        }

        public void SetSource(string source, int offset)
        {
            _lexer.SetCurLine(source, _line, offset);
            var t = _tokens.Where(w => w.Line == _line).ToArray();
            foreach (var token in t)
                _tokens.Remove(token);
        }

        public bool ScanTokenAndProvideInfoAboutIt(TokenInfo tokenInfo, ref int state)
        {
            var token = _lexer.GetNextToken(ref state);
            if (token == null)
                return false;
            _tokens.Add(token);
            tokenInfo.StartIndex = token.StartIndex;
            tokenInfo.EndIndex = token.EndIndex;
            tokenInfo.Type = token.Type.ToTokenType();
            tokenInfo.Color = token.Type.ToColor();
            tokenInfo.Token = (int) token.Type;
            tokenInfo.Trigger |= token.Type == HSPTokenType.Idenfitier ? TokenTriggers.MemberSelect : TokenTriggers.None;
            return true;
        }

        public void SetLineNumber(int line)
        {
            _line = line;
        }
    }
}