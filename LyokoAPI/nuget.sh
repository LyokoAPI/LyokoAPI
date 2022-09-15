#!/usr/bin/env sh
msbuild -p:Configuration=Release
nuget pack LyokoAPI.nuspec  -properties Configuration=Release