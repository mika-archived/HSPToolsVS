using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using Microsoft.VisualStudioTools.Project;

namespace HSPToolsVS.Project
{
    [Guid(HSPToolsConstants.ProjectNodeGuid)]
    // ReSharper disable once InconsistentNaming
    internal class HSPProjectNode : CommonProjectNode
    {
        public HSPProjectNode(IServiceProvider serviceProvider, ImageList imageList) : base(serviceProvider, imageList)
        {
            ImageIndex = ImageHandler.ImageList.Images.Count;
            foreach (var image in Utilities.GetImageList(ProjectIconsImageStripStream).Images)
            {
                ImageHandler.AddImage((Image) image);
            }
        }

        #region Overrides of ProjectNode

        internal override string IssueTrackerUrl => "https://github.com/fuyuno/HSPToolsVS/issues";

        protected sealed override Stream ProjectIconsImageStripStream
            => GetType().Assembly.GetManifestResourceStream("HSPToolsVS.Project.Resources.hspimagelist.png");

        public override bool IsCodeFile(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return false;
            var extension = Path.GetExtension(fileName);
            return extension == HSPToolsConstants.ScriptExtension || extension == HSPToolsConstants.ModuleExtension;
        }

        #endregion

        #region Overrides of CommonProjectNode

        public override Type GetProjectFactoryType() => typeof(HSPProjectFactory);

        public override Type GetEditorFactoryType() => null;

        public override string GetProjectName() => HSPToolsConstants.LanguageName;

        public override string GetFormatList() => HSPToolsConstants.FileFormatFilter;

        public override Type GetGeneralPropertyPageType() => null;

        public override Type GetLibraryManagerType() => typeof(HSPLibraryManager);

        public override IProjectLauncher GetLauncher() => null;

        public override int ImageIndex { get; }

        public override FileNode CreateFileNode(ProjectElement item) => new HSPFileNode(this, item);

        #endregion
    }
}