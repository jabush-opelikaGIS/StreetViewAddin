using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;

namespace StreetViewAddin.Buttons
{
    internal class OpenStreetViewToggleButton : Button
    {
        private const string StreetViewToolId = "StreetViewAddin_OpenStreetViewTool";
        private const string ExploreToolId = "esri_mapping_exploreTool";

        protected override void OnUpdate()
        {
            IsChecked = FrameworkApplication.CurrentTool == StreetViewToolId;
        }

        protected override async void OnClick()
        {
            var currentTool = FrameworkApplication.CurrentTool;
            if (currentTool == StreetViewToolId)
            {
                var toolToRestore = Module1.Current.ToolToRestoreId;
                if (string.IsNullOrWhiteSpace(toolToRestore) || toolToRestore == StreetViewToolId)
                    toolToRestore = ExploreToolId;

                Module1.Current.ToolToRestoreId = ExploreToolId;
                Module1.Current.IsSingleUseStreetView = false;
                await FrameworkApplication.SetCurrentToolAsync(toolToRestore);
                return;
            }

            Module1.Current.ToolToRestoreId =
                string.IsNullOrWhiteSpace(currentTool) || currentTool == StreetViewToolId
                    ? ExploreToolId
                    : currentTool;
            Module1.Current.IsSingleUseStreetView = false;

            await FrameworkApplication.SetCurrentToolAsync(StreetViewToolId);
        }
    }
}
