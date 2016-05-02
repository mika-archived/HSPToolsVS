using Microsoft.VisualStudio.Package;
using Microsoft.VisualStudio.TextManager.Interop;

namespace HSPToolsVS.LanguageService
{
    // ReSharper disable once InconsistentNaming
    internal class HSPLanguageService : Microsoft.VisualStudio.Package.LanguageService
    {
        private LanguagePreferences _languagePreferences;
        private HSPScanner _scanner;

        public override string Name => HSPToolsConstants.LanguageName;

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
            return new HSPAuthoringScope(_scanner.Tokens);
        }

        public override Source CreateSource(IVsTextLines buffer)
        {
            return new HSPSource(this, buffer, GetColorizer(buffer));
        }

        // Cache system ?
        public override Colorizer GetColorizer(IVsTextLines buffer)
        {
            return new HSPColorizer(this, buffer, GetScanner(buffer));
        }

        public override string GetFormatFilterList() => HSPToolsConstants.FileFormatFilter;
    }
}