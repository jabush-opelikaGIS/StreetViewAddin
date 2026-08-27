using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;
using ArcGIS.Core.Geometry;
using ArcGIS.Desktop.Framework.Contracts;
using ArcGIS.Desktop.Framework.Threading.Tasks;
using ArcGIS.Desktop.Mapping;

namespace StreetViewAddin.Buttons
{
    internal class OpenStreetViewTool : MapTool
    {
        public OpenStreetViewTool()
        {
            IsSketchTool = false;
            SketchType = SketchGeometryType.None;
        }

        protected override void OnToolMouseDown(MapViewMouseButtonEventArgs e)
        {
            if (e.ChangedButton == System.Windows.Input.MouseButton.Left)
                e.Handled = true;
        }

        protected override async Task HandleMouseDownAsync(MapViewMouseButtonEventArgs e)
        {
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
            var viewpoint = Uri.EscapeDataString(`${latitude},${longitude}`);
            var url =
                $"https://www.google.com/maps/@?api=1&map_action=pano&viewpoint={viewpoint}" +
                "&utm_source=street_scene_launcher&utm_campaign=open_street_view";

            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }
    }
}
