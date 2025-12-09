### System.Device

Entiat Update 2025-12-09 - this fork now builds in VS2026 for target framework: net10.0-windows10.0.20348.0. As mentioned below, this project is a wrapper of older, deprecated, Windows COM APIs. This still works on Win10 and Win11, and does what I need done (read basic position and status information from internal GPS from Windows PCs/tablets). My main app code that references this "port" of System.Device is debugged, is brain dead simple, and has been running around the planet for years. I'll keep keep this project up to date based on the latest dotnet and C# until Windows, some day, finally kills the backing COM APIs, and I have to pivot. Until then, enjoy this simple set of methods.

Entiat Update 2022-06-12 - this fork now builds in VS2022 for target framework: net6.0-windows, analyzer messages for new language features, etc. and other IDE recommendations applied.

Original dotMorten README follows:
===========================

.NET Core 3.0 port of System.Device.Location APIs from .NET Reference Source.

Based on commit: https://github.com/microsoft/referencesource/commit/bf498ea2b1a6270a2fe5cb122acf4b1c5b45c21d

Original source code is MIT. See: https://github.com/microsoft/referencesource/blob/master/LICENSE.txt

### Note:
The GeoCoordinate APIs are wrapping the Location COM APIs. Those were deprecated in Windows 8. 
If you don't need Windows 7 support, I'd encourage you to port your code to use the WinRT GeoLocation APIs instead. You can get these by adding a reference to [Microsoft.Windows.SDK.Contracts](https://www.nuget.org/packages/Microsoft.Windows.SDK.Contracts/).

Old `System.Device.Location` code:
```cs
var watcher = new System.Device.Location.GeoCoordinateWatcher(System.Device.Location.GeoPositionAccuracy.High);
watcher.StatusChanged += (s, e) => Debug.WriteLine($"Status changed: {e.Status}");
watcher.PositionChanged += (s, e) => Debug.WriteLine($"Position changed: {e.Position.Location.Latitude} , {e.Position.Location.Longitude} , {e.Position.Location.Altitude}  ");
watcher.Start();
```
New `Windows.Devices.Geolocation` equivalent code:
```cs
var locator = new Windows.Devices.Geolocation.Geolocator() { DesiredAccuracy = Windows.Devices.Geolocation.PositionAccuracy.High };
locator.StatusChanged += (s, e) => Debug.WriteLine($"Status changed: {e.Status}");
locator.PositionChanged += (s, e) => Debug.WriteLine($"Position changed: {e.Position.Coordinate.Point.Position.Latitude} , {e.Position.Coordinate.Point.Position.Longitude} , {e.Position.Coordinate.Point.Position.Altitude}  ");
```
