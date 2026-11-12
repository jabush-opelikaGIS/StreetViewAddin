using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;

namespace StreetViewAddin
{
    internal class Module1 : Module
    {
        private static Module1 _this;

        internal string ToolToRestoreId { get; set; } = "esri_mapping_exploreTool";

        internal bool IsSingleUseStreetView { get; set; }

        public static Module1 Current =>
            _this ??= (Module1)FrameworkApplication.FindModule("StreetViewAddin_Module");

        protected override bool CanUnload()
        {
            return true;
        }
    }
}
