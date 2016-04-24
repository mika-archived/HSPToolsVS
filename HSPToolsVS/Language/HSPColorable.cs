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
                new HSPColorableItem("Unknown",
                                     COLORINDEX.CI_SYSPLAINTEXT_FG,
                                     COLORINDEX.CI_SYSPLAINTEXT_BK),
                new HSPColorableItem("Text",
                                     COLORINDEX.CI_SYSPLAINTEXT_FG,
                                     COLORINDEX.CI_SYSPLAINTEXT_BK),
                new HSPColorableItem("Keyword",
                                     COLORINDEX.CI_DARKBLUE,
                                     COLORINDEX.CI_SYSPLAINTEXT_BK,
                                     FONTFLAGS.FF_BOLD)
            };
            ColorableItems = items.ToArray();
        }
    }
}