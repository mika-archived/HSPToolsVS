using Microsoft.VisualStudio.Package;
using Microsoft.VisualStudio.TextManager.Interop;

namespace HSPToolsVS.Language
{
    // ReSharper disable once InconsistentNaming
    internal class HSPSource : Source
    {
        public HSPSource(LanguageService service, IVsTextLines textLines, Colorizer colorizer)
            : base(service, textLines, colorizer) {}
    }
}