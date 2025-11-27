# Usage:
# `build.ps1
# -Clean[False, optional]
# -DoNotStart[False, optional]
# -Configuration[Debug, optional]`

param(
    [string]$Configuration = "Debug",
    [switch]$Clean,
    [switch]$DoNotStart
)

if (-not (Test-Path ".\SDUI")) {
    Write-Output "SDUI submodule is missing. Initializing and updating submodules..."
    git submodule update --init --recursive
}

taskkill /F /IM RSBot.exe
taskkill /F /IM sro_client.exe

if ($Clean) {
    Write-Output "Performing a clean build..."
    New-Item  -ItemType Directory ".\temp" -ErrorAction SilentlyContinue > $null
    Move-Item ".\Build\User" ".\temp" -ErrorAction SilentlyContinue > $null
    Remove-Item -Recurse -Force ".\Build" -ErrorAction SilentlyContinue > $null
}

Write-Output "Building with '$Configuration' configuration..."
$vsPath = & "${env:ProgramFiles(x86)}\Microsoft Visual Studio\Installer\vswhere.exe" -latest -property installationPath
$msBuildPath = Join-Path $vsPath "MSBuild\Current\Bin\MSBuild.exe"
& $msBuildPath /p:Configuration=$Configuration /p:Platform=x86 RSBot.sln > build.log
Write-Output "NOTE: This is a truncated view of the build logs. For the full log, refer to .\build.log"
Get-Content -Path "build.log" -Tail 100

if ($Clean) {
    Move-Item ".\temp\User" ".\Build\User" -ErrorAction SilentlyContinue > $null
    Remove-Item -Recurse -Force ".\temp" -ErrorAction SilentlyContinue > $null
}

if (!$DoNotStart) {
    Write-Output "Starting RSBot..."
    & ".\Build\RSBot.exe"
}