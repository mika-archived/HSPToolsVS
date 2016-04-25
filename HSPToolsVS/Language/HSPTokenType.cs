using Microsoft.VisualStudio.Package;

namespace HSPToolsVS.Language
{
    // ReSharper disable once InconsistentNaming
    internal enum HSPTokenType
    {
        /// <summary>
        ///     Comments - Line comment as //, ; and Block comment as /* ~ */
        /// </summary>
        Comment,

        /// <summary>
        ///     Keywords - mes, input and others.
        /// </summary>
        Keyword,

        /// <summary>
        ///     Numeric - 12345, 10 and number identifier.
        /// </summary>
        Numeric,

        /// <summary>
        ///     String - Characters is surrounded by ".
        /// </summary>
        String,

        /// <summary>
        ///     Preprocessor - "#define", "#defcfunc" and others that start "#".
        /// </summary>
        Preprocessor,

        /// <summary>
        ///     Operator - +, -, * and others.
        /// </summary>
        Operator,

        /// <summary>
        ///     Separator - (), {} and others.
        /// </summary>
        Sepatator,

        /// <summary>
        ///     Identifier - Variables, user functions. Max 60 char.
        /// </summary>
        Idenfitier,

        /// <summary>
        ///     Char - Character is surrounded by '.
        /// </summary>
        Char,

        /// <summary>
        ///     Macro - Defined by hsp3def.as
        /// </summary>
        Macro,

        /// <summary>
        ///     Flags - Start with "*".
        /// </summary>
        Flag
    }

    // ReSharper disable once InconsistentNaming
    internal static class HSPTokenTypeExt
    {
        public static TokenType ToTokenType(this HSPTokenType tokentype)
        {
            switch (tokentype)
            {
                case HSPTokenType.Char:
                case HSPTokenType.String:
                    return TokenType.String;

                case HSPTokenType.Comment:
                    return TokenType.Comment;

                case HSPTokenType.Flag:
                case HSPTokenType.Numeric:
                    return TokenType.Literal; // Literal?

                case HSPTokenType.Idenfitier:
                    return TokenType.Identifier;

                case HSPTokenType.Keyword:
                case HSPTokenType.Macro:
                case HSPTokenType.Preprocessor:
                    return TokenType.Keyword;

                case HSPTokenType.Operator:
                    return TokenType.Operator;

                case HSPTokenType.Sepatator:
                    return TokenType.Delimiter;

                default:
                    return TokenType.Unknown;
            }
        }

        public static TokenColor ToColor(this HSPTokenType tokentype)
        {
            switch (tokentype)
            {
                case HSPTokenType.Char:
                case HSPTokenType.String:
                    return TokenColor.String;

                case HSPTokenType.Comment:
                    return TokenColor.Comment;

                case HSPTokenType.Numeric:
                case HSPTokenType.Macro:
                case HSPTokenType.Flag:
                    return TokenColor.Number; // Literal?

                case HSPTokenType.Idenfitier:
                    return TokenColor.Identifier;

                case HSPTokenType.Keyword:
                case HSPTokenType.Preprocessor:
                    return TokenColor.Keyword;

                default:
                    return TokenColor.Text;
            }
        }
    }
}