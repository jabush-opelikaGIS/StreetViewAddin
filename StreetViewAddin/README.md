# Street Scene Launcher

An independently developed ArcGIS Pro add-in that opens Google Maps Street View in the user's default browser from a clicked map location.

## Features

- Adds a `Street Scene Launcher` tab in ArcGIS Pro
- Adds an `Open Street View` map tool
- Projects the clicked location to WGS84
- Opens the closest available panorama in Google Maps
- Does not embed, download, cache, scrape, modify, or redistribute Google imagery
- Does not require a Google Maps API key

## Tested Environment

- ArcGIS Pro 3.x
- Windows
- Browser-based Google Maps launch

## Installation

1. Build or download `GoogleStreetView.esriAddinX`.
2. Copy it to:

```text
%USERPROFILE%\Documents\ArcGIS\AddIns\ArcGISPro
```

3. Start or restart ArcGIS Pro.

## Usage

1. Open ArcGIS Pro and activate a map view.
2. Open the `Street Scene Launcher` tab.
3. Select `Open Street View`.
4. Click a location on the map.
5. Google Maps opens in the default browser at the nearest available Street View panorama.

Street View availability and the selected panorama depend on Google coverage and may change as imagery is updated.

## Google Maps usage

The add-in constructs a documented Google Maps URL and launches Google Maps as a separate browser experience. Google supplies its own interface, attribution, and imagery. The add-in does not call the Street View Static API or transfer Google Maps content into ArcGIS Pro.

Use of Google Maps is subject to Google's applicable terms and policies:

- [Google Maps URLs documentation](https://developers.google.com/maps/documentation/urls/get-started)
- [Google Maps and Google Earth Additional Terms](https://maps.google.com/help/terms_maps/)
- [Google Brand Resource Center](https://about.google/brand-resource-center/)

## Trademark and affiliation notice

Google Maps and Google Street View are trademarks of Google LLC. ArcGIS and ArcGIS Pro are trademarks of Esri. This independent project is not endorsed by, affiliated with, or sponsored by Google LLC or Esri.

## Source

The primary project files are:

- `Config.daml`
- `Module1.cs`
- `Buttons/OpenStreetViewTool.cs`

## Credits

James Bush

## License

MIT
