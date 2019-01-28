An Unofficial PBS Kids provider for PlayOn. It is currently in development, doesn't show all shows and has other issues. Use at your own risk. This plugin is not affiliate with PBS Kids or PlayOn in any way.

# Compiling Source
- Load up the Solution file in Visual Studio.
- Select "Release (separate)" as your build configuration. (Note: You may need to update the hint path if you have a non-standard PlayOn installation folder.)
- Build
- Copy the dist/PBSKids.plugin file into your PlayOn plugins folder. This folder is likely C:\Program Files (x86)\MediaMall\plugins.
- Copy the src/bin/Release/Newtownsoft.Json.dll into your PlayOn plugins folder if it is not there already.

# How to Use (without Building)
At this time, this is not a recommended way of using this plugin. In order to use this plugin, drop the dist/PBSKids.plugin into your PlayOn plugins folder. This folder is likely C:\Program Files (x86)\MediaMall\plugins. You will also need the Newtownsoft.Json.dll for Json.NET for .NET 2.0.

# Known Issues
- Doesn't show all shows
- Doesn't show clips
- 20 seconds of black on the end of the videos
