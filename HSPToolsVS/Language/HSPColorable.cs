using System.Collections.Generic;

using Microsoft.VisualStudio.Package;
using Microsoft.VisualStudio.TextManager.Interop;

namespace HSPToolsVS.Language
{
    // ReSharper disable once InconsistentNaming
    internal static class HSPColorable
    {
        public static ColorableItem[] ColorableItems { get; }

        static HSPColorable()
        {
            var items = new List<ColorableItem>
            {
                new HSPColorableItem("Text",
                                     COLORINDEX.CI_SYSPLAINTEXT_FG,
                                     COLORINDEX.CI_SYSPLAINTEXT_BK),
                new HSPColorableItem("Keyword",
                                     COLORINDEX.CI_DARKBLUE,
                                     COLORINDEX.CI_SYSPLAINTEXT_BK,
                                     FONTFLAGS.FF_BOLD),
                new HSPColorableItem("Comment",
                                     COLORINDEX.CI_DARKGREEN,
                                     COLORINDEX.CI_SYSPLAINTEXT_BK),
                new HSPColorableItem("Identifier",
                                     COLORINDEX.CI_SYSPLAINTEXT_FG,
                                     COLORINDEX.CI_SYSPLAINTEXT_BK),
                new HSPColorableItem("String",
                                     COLORINDEX.CI_BROWN,
                                     COLORINDEX.CI_SYSPLAINTEXT_BK),
                new HSPColorableItem("Number",
                                     COLORINDEX.CI_SYSPLAINTEXT_FG,
                                     COLORINDEX.CI_SYSPLAINTEXT_BK)
            };
            ColorableItems = items.ToArray();
        }
    }
}