using System;
using System.Runtime.InteropServices;

using Microsoft.VisualStudioTools.Project;

using IOleServiceProvider = Microsoft.VisualStudio.OLE.Interop.IServiceProvider;

namespace HSPToolsVS.Project
{
    [Guid("6FF3FD2E-8172-48B0-8DA3-333FB5115DA2")]
    // ReSharper disable once InconsistentNaming
    internal class HSPProjectFactory : ProjectFactory
    {
        public HSPProjectFactory(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        #region Overrides of ProjectFactory

        internal override ProjectNode CreateProject()
        {
            return new HSPProjectNode(Site);
        }

        #endregion
    }
}