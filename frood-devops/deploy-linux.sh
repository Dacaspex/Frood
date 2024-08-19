#!/bin/bash

$cwd = Get-Location

scriptRoot=dirname "$0"
webappLocation=${scriptRoot}/../frood-webapp
serverLocation=${scriptRoot}/../frood-server/FroodServer
outputLocation=${scriptRoot}/../frood-build
serverWwwRootLocation=${serverLocation}/wwwroot
serverProjectName="FroodServer.csproj"
serverBuildConfiguration="Release"
serverBuildArch="x64"
serverBuildOs="linux"
serverBuildOutput=$outputLocation

# Build webapp
echo "Building webapp"
cd $webappLocation
npm run build
mv -f ./build $serverWwwRootLocation

# Build server
echo "Building server"
cd $serverLocation
dotnet build $serverProjectName \
    --configuration $serverBuildConfiguration \
    --arch $serverBuildArch \
    --os $serverBuildOs

dotnet publish $serverProjectName \
    --no-build \
    --configuration $serverBuildConfiguration \
    --arch $serverBuildArch \
    --os $serverBuildOs \
    --output $serverBuildOutput
