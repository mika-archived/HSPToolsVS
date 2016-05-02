using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.Package;

namespace HSPToolsVS.IntelliSense
{
    // ReSharper disable once InconsistentNaming
    internal class HSPDeclarations : Declarations
    {
        private readonly IList<string> _declarations;

        public HSPDeclarations(IList<string> declarations)
        {
            _declarations = declarations;
        }

        #region Overrides of Declarations

        public override int GetCount() => _declarations.Count;

        public override string GetDisplayText(int index) => _declarations[index];

        public override string GetName(int index) => _declarations[index];

        public override string GetDescription(int index)
        {
            var word = _declarations[index];
            return HSPDocs.Documents.SingleOrDefault(w => w.Name == word)?.Summary;
        }

        public override int GetGlyph(int index) => 1;

        #endregion
    }
}