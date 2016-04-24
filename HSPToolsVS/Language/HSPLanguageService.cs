﻿using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Package;
using Microsoft.VisualStudio.TextManager.Interop;

namespace HSPToolsVS.Language
{
    // ReSharper disable once InconsistentNaming
    internal class HSPLanguageService : LanguageService
    {
        private LanguagePreferences _languagePreferences;
        private IScanner _scanner;

        public override string Name => "HSP";

        public override LanguagePreferences GetLanguagePreferences()
        {
            if (_languagePreferences != null)
                return _languagePreferences;
            _languagePreferences = new HSPLanguagePreferences(Site, typeof(HSPLanguageService).GUID, Name);
            _languagePreferences.Init();
            return _languagePreferences;
        }

        public override IScanner GetScanner(IVsTextLines buffer)
        {
            return _scanner ?? (_scanner = new HSPScanner(buffer));
        }

        public override AuthoringScope ParseSource(ParseRequest req)
        {
            return new HSPAuthoringScope();
        }

        public override Source CreateSource(IVsTextLines buffer)
        {
            return new HSPSource(this, buffer, new Colorizer(this, buffer, GetScanner(buffer)));
        }

        public override string GetFormatFilterList() => "HSP Script Files(*.hsp,*.as)|*.hsp;*.as";

        public override int GetItemCount(out int count)
        {
            count = HSPColorable.ColorableItems.Length;
            return VSConstants.S_OK;
        }

        public override int GetColorableItem(int index, out IVsColorableItem item)
        {
            item = HSPColorable.ColorableItems[index];
            return VSConstants.S_OK;
        }
    }
}