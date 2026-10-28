using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;
using ArcGIS.Core.Geometry;
using ArcGIS.Desktop.Framework.Contracts;
using ArcGIS.Desktop.Framework.Threading.Tasks;
using ArcGIS.Desktop.Mapping;
using ArcGIS.Desktop.Framework;

namespace StreetViewAddin.Buttons
{
    internal class OpenStreetViewTool : MapTool
    {
        private void RestorePreviousTool()
        {
            var toolToRestore = Module1.Current.ToolToRestoreId;
            if (string.IsNullOrWhiteSpace(toolToRestore) ||
                toolToRestore == "StreetViewAddin_OpenStreetViewTool")
            {
                toolToRestore = "esri_mapping_exploreTool";
            }

            Module1.Current.ToolToRestoreId = "esri_mapping_exploreTool";
            _ = FrameworkApplication.SetCurrentToolAsync(toolToRestore);
        }

        public OpenStreetViewTool()
        {
            IsSketchTool = false;
            SketchType = SketchGeometryType.None;
        }

        protected override void OnToolMouseDown(MapViewMouseButtonEventArgs e)
        {
            e.Handled = true;
        }

        protected override async Task HandleMouseDownAsync(MapViewMouseButtonEventArgs e)
        {
            try
            {
                if (e.ChangedButton != System.Windows.Input.MouseButton.Left)
                    return;

                var mapPoint = await QueuedTask.Run(() =>
                {
                    if (MapView.Active == null)
                        return null;

                    var clickedPoint = MapView.Active.ClientToMap(e.ClientPoint);
                    if (clickedPoint == null)
                        return null;

                    return GeometryEngine.Instance.Project(clickedPoint, SpatialReferences.WGS84) as MapPoint;
                });

                if (mapPoint == null)
                    return;

                var latitude = mapPoint.Y.ToString(CultureInfo.InvariantCulture);
                var longitude = mapPoint.X.ToString(CultureInfo.InvariantCulture);
                //var viewpoint = Uri.EscapeDataString(`${latitude},${longitude}`);
                var url =
                    $"https://maps.google.com/maps?q=&layer=c&cbll={latitude},{longitude}&cbp=11,0,0,0,0";
                    //$"https://www.google.com/maps/@?api=1&map_action=pano&viewpoint={latitude},{longitude}" +
                    //"&utm_source=street_scene_launcher&utm_campaign=open_street_view";

                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            finally
            {
                if (Module1.Current.IsSingleUseStreetView)
                {
                    Module1.Current.IsSingleUseStreetView = false;
                    RestorePreviousTool();
                }
            }
        }
    }
}
