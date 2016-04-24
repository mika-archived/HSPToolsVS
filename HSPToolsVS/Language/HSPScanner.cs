using System;

using Microsoft.VisualStudio.Package;
using Microsoft.VisualStudio.TextManager.Interop;

namespace HSPToolsVS.Language
{
    // ReSharper disable once InconsistentNaming
    internal class HSPScanner : IScanner
    {
        private string _source;
        private IVsTextBuffer _textBuffer;

        public HSPScanner(IVsTextBuffer textBuffer)
        {
            _textBuffer = textBuffer;
        }

        public void SetSource(string source, int offset)
        {
            _source = source.Substring(offset);
        }

        public bool ScanTokenAndProvideInfoAboutIt(TokenInfo tokenInfo, ref int state)
        {
            throw new NotImplementedException();
        }
    }
}