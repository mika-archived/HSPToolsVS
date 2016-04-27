namespace HSPToolsVS.LanguageService
{
    internal enum ParseState : uint
    {
        InNormal = 0,

        InBlockComment = 1
    }
}