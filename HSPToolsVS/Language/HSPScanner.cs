using System;

using Microsoft.VisualStudio.Package;
using Microsoft.VisualStudio.TextManager.Interop;

namespace HSPToolsVS.Language
{
    // ReSharper disable once InconsistentNaming
    internal class HSPScanner : IScanner
    {
        private IVsTextBuffer _textBuffer;

        public HSPScanner(IVsTextBuffer textBuffer)
        {
            _textBuffer = textBuffer;
        }

        public void SetSource(string source, int offset)
        {
            throw new NotImplementedException();
        }

        public bool ScanTokenAndProvideInfoAboutIt(TokenInfo tokenInfo, ref int state)
        {
            throw new NotImplementedException();
        }
    }
}