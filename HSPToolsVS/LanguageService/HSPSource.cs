using Microsoft.VisualStudio.Package;
using Microsoft.VisualStudio.TextManager.Interop;

namespace HSPToolsVS.LanguageService
{
    // ReSharper disable once InconsistentNaming
    internal class HSPSource : Source
    {
        public HSPSource(Microsoft.VisualStudio.Package.LanguageService service, IVsTextLines textLines,
                         Colorizer colorizer)
            : base(service, textLines, colorizer) {}

        #region Overrides of Source

        public override CommentInfo GetCommentFormat()
        {
            var info = new CommentInfo
            {
                UseLineComments = true,
                LineStart = ";",
                BlockStart = "/*",
                BlockEnd = "*/"
            };
            return info;
        }

        #endregion
    }
}