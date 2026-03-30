#!/bin/bash

echo "Building QuickFile..."
cd src/QuickFile && dotnet publish -r osx-arm64 -c Release --self-contained true -p:PublishSingleFile=true

echo "Installing QuickFile..."
cp -r bin/Release/net10.0/osx-arm64/publish/ /usr/local/bin/QuickFile-files/

echo "Setting permissions..."
chmod +x /usr/local/bin/QuickFile-files/QuickFile
chmod +x /usr/local/bin/QuickFile-files/libAvaloniaNative.dylib
chmod +x /usr/local/bin/QuickFile-files/libHarfBuzzSharp.dylib
chmod +x /usr/local/bin/QuickFile-files/libSkiaSharp.dylib
xattr -cr /usr/local/bin/QuickFile-files/

echo "Done! QuickFile is installed at /usr/local/bin/QuickFile-files/QuickFile"