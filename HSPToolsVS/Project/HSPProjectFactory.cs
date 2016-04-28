using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

using Microsoft.VisualStudioTools.Project;

namespace HSPToolsVS.Project
{
    [Guid("6FF3FD2E-8172-48B0-8DA3-333FB5115DA2")]
    // ReSharper disable once InconsistentNaming
    internal class HSPProjectFactory : ProjectFactory
    {
        public HSPProjectFactory(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            Debug.WriteLine("HSPProjectFactory");
        }

        #region Overrides of ProjectFactory

        internal override ProjectNode CreateProject()
        {
            var stream = GetType().Assembly.GetManifestResourceStream("HSPToolsVS.Project.Resources.imagelis.bmp");
            return new HSPProjectNode(Site, Utilities.GetImageList(stream));
        }

        #endregion
    }
}