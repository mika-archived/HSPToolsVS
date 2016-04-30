using System;
using System.Runtime.InteropServices;

using Microsoft.VisualStudioTools.Project;

using IOleServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;

namespace HSPToolsVS.Project
{
    [Guid(HSPToolsConstants.ProjectFactoryGuid)]
    // ReSharper disable once InconsistentNaming
    internal class HSPProjectFactory : ProjectFactory
    {
        private readonly CommonProjectPackage _package;

        public HSPProjectFactory(CommonProjectPackage package) : base((IServiceProvider) package)
        {
            _package = package;
        }

        #region Overrides of ProjectFactory

        internal override ProjectNode CreateProject()
        {
            var stream = GetType().Assembly.GetManifestResourceStream("HSPToolsVS.Project.Resources.imagelis.bmp");
            var project = new HSPProjectNode(Site, Utilities.GetImageList(stream));
            var package = ((IServiceProvider) _package).GetService(typeof(IOleServiceProvider));
            project.SetSite((IOleServiceProvider) package);
            return project;
        }

        #endregion
    }
}