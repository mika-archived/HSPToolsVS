using System.ComponentModel.Composition;
using System.Runtime.InteropServices;

using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudioTools.Project;

namespace HSPToolsVS.Project
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [Guid(HSPToolsConstants.ProjectPackageGuid)]
    // Register project templates.
    [ProvideProjectFactory(typeof(HSPProjectFactory), null,
        HSPToolsConstants.ProjectFileFormatFilter, HSPToolsConstants.ProjectFileExtension,
        HSPToolsConstants.ProjectFileExtension, @".\NullPath",
        LanguageVsTemplate = HSPToolsConstants.LanguageName)]
    [ProvideProjectItem(typeof(HSPProjectFactory), HSPToolsConstants.LanguageName, @".\NullPath", 500)]
    [Export]
    // ReSharper disable once InconsistentNaming
    public sealed class HSPProjectPackage : CommonProjectPackage
    {
        #region Overrides of CommonProjectPackage

        public override ProjectFactory CreateProjectFactory() => new HSPProjectFactory(this);

        public override CommonEditorFactory CreateEditorFactory() => null; // Do not need.

        public override uint GetIconIdForAboutBox() => 0; // IconId is not defined.

        public override uint GetIconIdForSplashScreen() => 0; // IconID is not defined;

        public override string GetProductName() => HSPToolsConstants.LanguageName;

        public override string GetProductDescription() => HSPToolsConstants.LanguageName;

        public override string GetProductVersion() => GetType().Assembly.GetName().Version.ToString();

        #endregion
    }
}