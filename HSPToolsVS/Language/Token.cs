namespace HSPToolsVS.Language
{
    internal class Token
    {
        public string Text { get; }
        public int StartIndex { get; }
        public int Length { get; }
        public int EndIndex => StartIndex + Length;
        public TokenType Type { get; }

        public Token(string text, int startIndex, TokenType type)
        {
            Text = text;
            StartIndex = startIndex;
            Length = Text.Length;
            Type = type;
        }
    }
}