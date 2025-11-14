# RSBot

This repository contains an automation software (bot) for the game "Silkroad Online".

## Build system, tool usage

The project is built using  MSBuild. The generic path is `C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe`.

- For debug: `/p:Configuration=Debug /p:Platform="x86"`
- For release: `/p:Configuration=Release /p:Platform="x86"`
- The solution to build is `.\RSBot.sln`
- Output build logs to `\build.log`

If you fail to make a build ask the user to build it. Check the `.\build.log` for any errors.

An example: `C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe /p:Configuration=Debug /p:Platform="x86" RSBot.sln > build.log`

Never use `dotnet` for builds. Only for package management purposes via `dotnet restore`, `dotnet add` etc.

## Project information

Project has a modular system.

| Path                  | Description                            |
| --------------------- | -------------------------------------- |
| `.\Application\RSBot` | Initialization, the main window        |
| `.\Botbases`          | The behavior for doing automated tasks |
| `.\Library`           | Generic behavior                       |
| `.\Plugins`           | Rest of the miscellaneous behavior     |
