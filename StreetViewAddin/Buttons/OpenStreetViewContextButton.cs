using ArcGIS.Desktop.Framework;
using ArcGIS.Desktop.Framework.Contracts;

namespace StreetViewAddin.Buttons
{
    internal class OpenStreetViewContextButton : Button
    {
        protected override async void OnClick()
        {
            var currentTool = FrameworkApplication.CurrentTool;
            Module1.Current.ToolToRestoreId =
                string.IsNullOrWhiteSpace(currentTool) ||
                currentTool == "StreetViewAddin_OpenStreetViewTool"
                    ? "esri_mapping_exploreTool"
                    : currentTool;
            Module1.Current.IsSingleUseStreetView = true;

            await FrameworkApplication.SetCurrentToolAsync(
                "StreetViewAddin_OpenStreetViewTool");
        }
    }
}