# RSBot

This repository contains an automation software (bot) for the game "Silkroad Online".

## Build system, tool usage

The project is built using  MSBuild. The generic path is `C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe`.

- For debug: `/p:Configuration=Debug /p:Platform=x86`
- For release: `/p:Configuration=Release /p:Platform=x86`
- The solution to build is `.\RSBot.sln`
- Output build logs to `\build.log`

- If you fail to make a build ask the user to build it. Check the `.\build.log` for any errors.
- Under PowerShell shells you may need to add a `&` or `Start-Process` before the command.
- Never use `dotnet` for builds. Only for package management purposes via `dotnet restore`, `dotnet add` etc.

An example: `C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe /p:Configuration=Debug /p:Platform=x86 RSBot.sln > build.log`

## Project information

Project has a modular system.

| Path                  | Description                            |
| --------------------- | -------------------------------------- |
| `.\Application\RSBot` | Initialization, the main window        |
| `.\Botbases`          | The behavior for doing automated tasks |
| `.\Library`           | Generic behavior                       |
| `.\Plugins`           | Rest of the miscellaneous behavior     |

Desired executable is placed at `.\Build\RSBot.exe`

UI is handled by the submodule `.\SDUI`. If you encounter any issues where it doesn't exist, run `git submodule update --init --recursive` to pull it.

## Instructions

- Never edit `.csproj`, `.Designer.cs` and other auto-generated files without explicit confirmation from the user.
