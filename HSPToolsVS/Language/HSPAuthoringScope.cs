using System;

using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Package;
using Microsoft.VisualStudio.TextManager.Interop;

namespace HSPToolsVS.Language
{
    // ReSharper disable once InconsistentNaming
    internal class HSPAuthoringScope : AuthoringScope
    {
        public override string GetDataTipText(int line, int col, out TextSpan span)
        {
            throw new NotImplementedException();
        }

        public override Declarations GetDeclarations(IVsTextView view, int line, int col, TokenInfo info,
                                                     ParseReason reason)
        {
            throw new NotImplementedException();
        }

        public override Methods GetMethods(int line, int col, string name)
        {
            throw new NotImplementedException();
        }

        public override string Goto(VSConstants.VSStd97CmdID cmd, IVsTextView textView, int line, int col,
                                    out TextSpan span)
        {
            throw new NotImplementedException();
        }
    }
}