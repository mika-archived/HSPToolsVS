using System.IO;

using Microsoft.VisualStudioTools.Project;

namespace HSPToolsVS.Project
{
    // ReSharper disable once InconsistentNaming
    internal class HSPFileNode : CommonFileNode
    {
        private readonly ProjectNode _project;

        #region Overrides of CommonFileNode

        public override int ImageIndex
        {
            get
            {
                if (ItemNode.IsExcluded)
                    return (int) ProjectNode.ImageName.ExcludedFile;
                if (!File.Exists(Url))
                    return (int) ProjectNode.ImageName.MissingFile;
                if (!ProjectMgr.IsCodeFile(FileName))
                    return base.ImageIndex;
                if (FileName.EndsWith(HSPToolsConstants.ModuleExtension))
                    return _project.ImageIndex + 3;
                if (FileName.EndsWith(HSPToolsConstants.ScriptExtension))
                    return _project.ImageIndex + 1;
                return base.ImageIndex;
            }
        }

        #endregion

        public HSPFileNode(CommonProjectNode root, ProjectElement e) : base(root, e)
        {
            _project = root;
        }
    }
}