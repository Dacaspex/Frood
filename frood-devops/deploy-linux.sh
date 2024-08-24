scriptRoot="$( cd -- "$(dirname "$0")" >/dev/null 2>&1 ; pwd -P )"
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
npm ci
npm run build
mv -f ./dist/* $serverWwwRootLocation

# Build server
echo "Building server"
cd $serverLocation

dotnet publish $serverProjectName \
    --configuration $serverBuildConfiguration \
    --runtime linux-arm64 \
    --self-contained \
    --output $serverBuildOutput
