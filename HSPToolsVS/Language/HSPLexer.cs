using System.Collections.Generic;
using System.IO;

namespace HSPToolsVS.Language
{
    // ReSharper disable once InconsistentNaming

    // HSP ソースファイルを、行ごとに解析します。
    internal class HSPLexer
    {
        private int _curTokenIndex;
        private int _offset;
        private string _source;
        private List<Token> _tokens;

        public void SetCurLine(string source, int offset)
        {
            _source = source;
            _offset = offset;
            _curTokenIndex = 0;
            _tokens = new List<Token>();
        }

        public void Tokenize()
        {
            var reader = new StringReader(_source);
            var inBlockComment = false;
            var inLineComment = false;
            const int charLimit = 10; // HSP keywords max char length ("sarrayconv").
            var charHistory = new List<char>(charLimit);
            var offset = 0;
            while (reader.Peek() != -1)
            {
                var c = (char) reader.Read();
                if (!inBlockComment && !inLineComment && (c == ' ' || c == '　' || c == '\t'))
                {
                    ProduceToken(charHistory, offset);
                    offset++;
                    continue;
                }

                // Save history
                if (charHistory.Count >= charLimit)
                    charHistory.RemoveAt(0);
                charHistory.Add(c);

                // Comment?
                ProduceCommentToken(charHistory, ref inLineComment, ref inBlockComment);

                if (inBlockComment || inLineComment)
                    continue;

                // Identifier split by operators?
                ProduceToken(charHistory, offset);
                offset++;
            }
        }

        private void ProduceCommentToken(ICollection<char> charHistory, ref bool inLComment, ref bool inBComment)
        {
            var str = string.Join("", charHistory);

            // Line comment
            switch (str)
            {
                case ";":
                case "//":
                    inLComment = true;
                    return;

                case "/*":
                    inBComment = true;
                    charHistory.Clear();
                    return;
            }
            // Block comment
            if (!inBComment || !str.EndsWith("*/"))
                return;
            inBComment = false;
            charHistory.Clear();
        }

        private void ProduceToken(List<char> charHistory, int offset)
        {
            // Priority: Operator1 -> Operator2 -> Operator3 -> Keyword -> Macro -> Preprocessor // -> String -> Char -> Numeric -> Identifier
            var str = string.Join("", charHistory);
            if (HSPTokens.Operators1Char.Contains(str) || HSPTokens.Operators2Chars.Contains(str) ||
                HSPTokens.Operators3Chars.Contains(str))
            {
                charHistory.Clear();
                _tokens.Add(new Token(str, offset, HSPTokenType.Operator));
                return;
            }
            if (HSPTokens.Keywords.Contains(str))
            {
                charHistory.Clear();
                _tokens.Add(new Token(str, offset, HSPTokenType.Keyword));
                return;
            }
            if (HSPTokens.Macros.Contains(str))
            {
                charHistory.Clear();
                _tokens.Add(new Token(str, offset, HSPTokenType.Macro));
                return;
            }
            if (HSPTokens.Preprocessors.Contains(str))
            {
                charHistory.Clear();
                _tokens.Add(new Token(str, offset, HSPTokenType.Preprocessor));
            }
        }

        public Token GetNextToken()
        {
            return _tokens.Count <= _curTokenIndex ? null : _tokens[_curTokenIndex++];
        }
    }
}