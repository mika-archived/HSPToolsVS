using System.Drawing;

using Microsoft.VisualStudio.Package;
using Microsoft.VisualStudio.TextManager.Interop;

namespace HSPToolsVS.Language
{
    // ReSharper disable once InconsistentNaming
    internal class HSPColorableItem : ColorableItem
    {
        public HSPColorableItem(string name, COLORINDEX foreColor, COLORINDEX backColor, FONTFLAGS flags)
            : base($"HSP - {name}", name, foreColor, backColor, Color.Empty, Color.Empty, flags) {}

        // ReSharper disable once IntroduceOptionalParameters.Global
        public HSPColorableItem(string name, COLORINDEX foreColor, COLORINDEX backColor)
            : this(name, foreColor, backColor, FONTFLAGS.FF_DEFAULT) {}
    }
}