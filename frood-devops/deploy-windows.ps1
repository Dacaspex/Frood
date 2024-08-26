
$cwd = Get-Location
$webappLocation = "$PSScriptRoot/../frood-webapp"
$serverLocation = "$PSScriptRoot/../frood-server/FroodServer"
$outputLocation = "$PSScriptRoot/../frood-build"
$serverWwwRootLocation = "$serverLocation/wwwroot"
$serverProjectName = "FroodServer.csproj"
$serverBuildConfiguration = "Release"
$serverBuildArch = "x64"
$serverBuildOs = "win"
$serverBuildOutput = $outputLocation

try
{
    # Build webapp
    Write-Host "Building webapp"
    Set-Location $webappLocation
    npm run build
    Move-Item -Path ./dist/* -Destination $serverWwwRootLocation -Force

    # Build server
    # Write-Host "Building server"
    # Set-Location $serverLocation
    # dotnet build $serverProjectName `
    #     --configuration $serverBuildConfiguration `
    #     --arch $serverBuildArch `
    #     --os $serverBuildOs

    # dotnet publish $serverProjectName `
    #     --no-build `
    #     --configuration $serverBuildConfiguration `
    #     --arch $serverBuildArch `
    #     --os $serverBuildOs `
    #     --output $serverBuildOutput
}
finally
{
    Set-Location $cwd
}