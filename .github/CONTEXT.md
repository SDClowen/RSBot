# RSBot

This repository contains an automation software (bot) for the game "Silkroad Online".

The project is built using  MSBuild. The generic path is `C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe`.

- For debug: `/p:Configuration=Debug /p:Platform="x86"`
- For release: `/p:Configuration=Release /p:Platform="x86"`
- If not already done, copy the contents of `Dependencies` directory to `Build\Data`
- Output build logs to `/build.log`
