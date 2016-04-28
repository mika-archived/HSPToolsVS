using System.ComponentModel.Composition;
using System.Runtime.InteropServices;

using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudioTools.Project;

namespace HSPToolsVS.Project
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [Guid("6B824039-8F0F-4439-BCEB-70E14D1D9C15")]
    // Register project templates.
    [ProvideProjectFactory(typeof(HSPProjectFactory), "HSP", "HSP Project Files(*.hsproj);*.hsproj", "hsproj", "hsproj",
        @"ProjectTemplates", LanguageVsTemplate = "HSP")]
    [ProvideProjectItem(typeof(HSPProjectFactory), "HSP", @"ItemTemplates", 500)]
    [Export]
    // ReSharper disable once InconsistentNaming
    public sealed class HSPProjectPackage : CommonProjectPackage
    {
        #region Overrides of CommonProjectPackage

        public override ProjectFactory CreateProjectFactory() => new HSPProjectFactory(this);

        public override CommonEditorFactory CreateEditorFactory() => null; // Do not need.

        public override uint GetIconIdForAboutBox() => 0; // IconId is not defined.

        public override uint GetIconIdForSplashScreen() => 0; // IconID is not defined;

        public override string GetProductName() => "HSP";

        public override string GetProductDescription() => "HSP";

        public override string GetProductVersion() => GetType().Assembly.GetName().Version.ToString();

        #endregion
    }
}