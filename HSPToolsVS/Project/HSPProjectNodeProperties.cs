using System.Runtime.InteropServices;

using Microsoft.VisualStudioTools;
using Microsoft.VisualStudioTools.Project;

namespace HSPToolsVS.Project
{
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [Guid(CommonConstants.ProjectNodePropertiesGuid)]
    // ReSharper disable once InconsistentNaming
    public class HSPProjectNodeProperties : CommonProjectNodeProperties
    {
        internal HSPProjectNodeProperties(ProjectNode node) : base(node)
        {

        }
    }
}