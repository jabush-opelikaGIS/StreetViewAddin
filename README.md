# Street View Launcher for ArcGIS Pro

A lightweight ArcGIS Pro add-in that opens Google Street View from a clicked map location.
This add-in does not store, download, or process Google Street View imagery and only opens Google Maps in a web browser in accordance with Google Maps Platform Terms of Service.

## Features

- Adds a `Google Street View` tab in ArcGIS Pro
- Adds an `Open Street View` map tool
- Click a location on the map to open Google Street View in your default browser
- Keeps the workflow simple and fast for map review

## Tested Environment

- ArcGIS Pro 3.x
- Windows
- Browser-based Google Street View launch

## Installation

### Option 1: Use the release package
1. Download `GoogleStreetView-PublicRelease.zip`
2. Extract the zip
3. Run `Install-GoogleStreetViewAddin.ps1`
4. Restart ArcGIS Pro if it is open

### Option 2: Manual install
1. Download `GoogleStreetView.esriAddinX`
2. Copy it to:

```text
%USERPROFILE%\Documents\ArcGIS\AddIns\ArcGISPro

