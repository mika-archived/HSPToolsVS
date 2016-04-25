namespace HSPToolsVS.Language
{
    internal class Token
    {
        public string Text { get; }
        public int StartIndex { get; }
        public int Length { get; }
        public int EndIndex => StartIndex + Length - 1;
        public HSPTokenType Type { get; }

        public Token(string text, int startIndex, HSPTokenType type)
        {
            Text = text;
            StartIndex = startIndex;
            Length = Text.Length;
            Type = type;
        }

        #region Overrides of Object

        public override string ToString()
        {
            return $"{{Text: {Text}}}, {{StartIndex: {StartIndex}}}, {{EndIndex: {EndIndex}}}";
        }

        #endregion
    }
}