using System.Collections.Generic;
using System.Drawing;

using Microsoft.VisualStudio.Package;
using Microsoft.VisualStudio.TextManager.Interop;

namespace HSPToolsVS.Language
{
    // ReSharper disable once InconsistentNaming
    internal class HSPColorize
    {
        public static ColorableItem[] ColorableItems { get; }

        static HSPColorize()
        {
            var items = new List<ColorableItem>
            {
                new ColorableItem("HSP - Text",
                                  "Text",
                                  COLORINDEX.CI_SYSPLAINTEXT_FG,
                                  COLORINDEX.CI_SYSPLAINTEXT_BK,
                                  Color.Empty,
                                  Color.Empty,
                                  FONTFLAGS.FF_DEFAULT),
                new ColorableItem("HSP - Delimiter",
                                  "Delimiter",
                                  COLORINDEX.CI_GREEN,
                                  COLORINDEX.CI_SYSPLAINTEXT_BK,
                                  Color.FromArgb(192, 32, 32),
                                  Color.Empty, FONTFLAGS.FF_BOLD),
                new ColorableItem("HSP - Keyword",
                                  "Keyword",
                                  COLORINDEX.CI_DARKBLUE,
                                  COLORINDEX.CI_SYSPLAINTEXT_BK,
                                  Color.FromArgb(192, 32, 32),
                                  Color.Empty, FONTFLAGS.FF_BOLD)
            };
            ColorableItems = items.ToArray();
        }
    }
}