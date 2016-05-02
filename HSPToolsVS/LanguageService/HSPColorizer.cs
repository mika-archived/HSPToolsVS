using System;
using System.Runtime.InteropServices;

using Microsoft.VisualStudio.Package;
using Microsoft.VisualStudio.TextManager.Interop;

using VSLanguageService = Microsoft.VisualStudio.Package.LanguageService;

namespace HSPToolsVS.LanguageService
{
    [ComVisible(true)]
    // ReSharper disable once InconsistentNaming
    internal class HSPColorizer : Colorizer
    {
        public HSPColorizer(VSLanguageService svc, IVsTextLines buffer, IScanner scanner) : base(svc, buffer, scanner)
        {

        }

        #region Overrides of Colorizer

        public override int ColorizeLine(int line, int length, IntPtr ptr, int state, uint[] attrs)
        {
            (Scanner as HSPScanner)?.SetLineNumber(line);
            return base.ColorizeLine(line, length, ptr, state, attrs);
        }

        // Cannot pass line number.
        /*
        public override int GetColorInfo(string line, int length, int state)
        {
            return base.GetColorInfo(line, length, state);
        }
        */

        public override TokenInfo[] GetLineInfo(IVsTextLines buffer, int line, IVsTextColorState colorState)
        {
            (Scanner as HSPScanner)?.SetLineNumber(line);
            return base.GetLineInfo(buffer, line, colorState);
        }

        #endregion
    }
}