using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace HSPToolsVS.Language
{
    // ReSharper disable once InconsistentNaming
    internal class HSPLexer
    {
        private int _offset;
        private string _source;

        public void SetCurLine(string source, int offset)
        {
            _source = source.Substring(offset);
            _offset = offset;
        }

        public Token GetNextToken(ref int state)
        {
            // InComment?
            var source = _source.Substring(_offset);
            if (state == (int) ParseState.InBlockComment)
            {
                if (!source.Contains("*/"))
                    return new Token(source, _offset, HSPTokenType.Comment);
                state = (int) ParseState.InNormal;
                var index = _offset + source.IndexOf("*/", StringComparison.Ordinal);
                _offset += source.IndexOf("*/", StringComparison.Ordinal);
                return new Token(source.Substring(index, _offset), index, HSPTokenType.Comment);
            }
            if (source == "")
                return null;

            var charHistory = new List<char>();
            foreach (var c in source)
            {
                if (char.IsWhiteSpace(c))
                {
                    if (charHistory.Count != 0)
                        return ProduceToken(charHistory, ref _offset, true);
                    _offset++;
                    return new Token("", _offset - 1, HSPTokenType.Sepatator);
                }
                charHistory.Add(c);
                if (string.Join(string.Empty, charHistory) == "/*")
                {
                    state = (int) ParseState.InBlockComment;
                    return new Token(source.Substring(_offset), _offset, HSPTokenType.Comment);
                }
                var token = ProduceToken(charHistory, ref _offset);
                if (token != null)
                    return token;
            }
            return ProduceToken(charHistory, ref _offset, true); // Last
        }

        private Token ProduceToken(List<char> charHistory, ref int startIndex, bool isForce = false)
        {
            var str = string.Join(string.Empty, charHistory);
            var index = startIndex;
            // TODO: *flag の判定(* -> Operator, flag -> Identifier を *flag -> Flag にする)
            if (IsContainsInList(str, HSPTokens.Operators1Char, HSPTokens.Operators2Chars,
                                 HSPTokens.Operators3Chars))
            {
                charHistory.Clear();
                startIndex += str.Length;
                return new Token(str, index, HSPTokenType.Operator);
            }
            if (IsEndsWithInList(str, HSPTokens.Separators))
            {
                charHistory.RemoveRange(0, charHistory.Count - 1);
                return ProduceToken(charHistory, ref startIndex, true);
            }
            if (IsContainsInList(str, HSPTokens.Separators))
            {
                charHistory.Clear();
                startIndex += str.Length;
                return new Token(str, index, HSPTokenType.Sepatator);
            }
            if (IsContainsInList(str, HSPTokens.Keywords))
            {
                charHistory.Clear();
                startIndex += str.Length;
                return new Token(str, index, HSPTokenType.Keyword);
            }
            if (IsContainsInList(str, HSPTokens.Macros))
            {
                charHistory.Clear();
                startIndex += str.Length;
                return new Token(str, index, HSPTokenType.Macro);
            }
            if (IsContainsInList(str, HSPTokens.Preprocessors))
            {
                charHistory.Clear();
                startIndex += str.Length;
                return new Token(str, index, HSPTokenType.Preprocessor);
            }
            if (IsMatch(str, "\".*?\""))
            {
                charHistory.Clear();
                startIndex += str.Length;
                return new Token(str, index, HSPTokenType.String);
            }
            if (IsMatch(str, "'.*?'")) // HSP allows 'foo' (return 'f' char code).
            {
                charHistory.Clear();
                startIndex += str.Length;
                return new Token(str, index, HSPTokenType.Char);
            }

            if (!isForce)
                return null;
            charHistory.Clear();
            return ParseIdentifierOrNumericOrFlag(str, ref startIndex);
        }

        private Token ParseIdentifierOrNumericOrFlag(string str, ref int startIndex)
        {
            double d;
            var index = startIndex;
            startIndex += str.Length;
            if (double.TryParse(str, out d))
                return new Token(str, index, HSPTokenType.Numeric);
            return str.StartsWith("*")
                ? new Token(str, index, HSPTokenType.Flag)
                : new Token(str, index, HSPTokenType.Idenfitier);
        }

        private bool IsContainsInList(string str, params List<string>[] lists)
        {
            return lists.Any(list => list.Contains(str));
        }

        private bool IsEndsWithInList(string str, List<string> list)
        {
            return list.All(str.EndsWith);
        }

        private bool IsMatch(string str, string regex)
        {
            return Regex.IsMatch(str, regex);
        }
    }
}