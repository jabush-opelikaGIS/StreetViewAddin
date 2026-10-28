using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;

namespace StreetViewAddin.Buttons
{
    internal class OpenStreetViewToggleButton : Button
    {
        protected override async void OnClick()
        {
            const string streetViewToolId = "StreetViewAddin_OpenStreetViewTool";
            const string exploreToolId = "esri_mapping_exploreTool";

            var currentTool = FrameworkApplication.CurrentTool;
            if (currentTool == streetViewToolId)
            {
                var toolToRestore = Module1.Current.ToolToRestoreId;
                if (string.IsNullOrWhiteSpace(toolToRestore) || toolToRestore == streetViewToolId)
                    toolToRestore = exploreToolId;

                Module1.Current.ToolToRestoreId = exploreToolId;
                Module1.Current.IsSingleUseStreetView = false;
                await FrameworkApplication.SetCurrentToolAsync(toolToRestore);
                return;
            }

            Module1.Current.ToolToRestoreId =
                string.IsNullOrWhiteSpace(currentTool) || currentTool == streetViewToolId
                    ? exploreToolId
                    : currentTool;
            Module1.Current.IsSingleUseStreetView = false;

            await FrameworkApplication.SetCurrentToolAsync(streetViewToolId);
        }
    }
}
