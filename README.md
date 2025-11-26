# [RSBot](https://sdclowen.github.io/RSBot)

Free, open source Silkroad Online bot for everyone to use!

Feel free to edit the code, create pull requests for any and all improvements, create issues and request features. [Supported clients](#supported-clients) that are listed below are a result of prolonged community work, do not hesitate to accompany us!

To join the conversation, get recent updates/announcements, join our [Discord server](https://discord.gg/MuY5ejEU3r).

[![GitHub Issues](https://img.shields.io/github/issues/sdclowen/rsbot?label=Open%20Issues)](https://github.com/sdclowen/rsbot/issues)
[![downloads](https://img.shields.io/github/downloads/SDClowen/RSBot/total?label=Total%20Downloads)](https://github.com/SDClowen/RSBot/releases)
[![downloads-latest](https://img.shields.io/github/downloads/SDClowen/RSBot/latest/total?label=Latest%20release)](https://github.com/SDClowen/RSBot/releases/latest)

[![GitHub Repo](https://img.shields.io/badge/GitHub-SDClowen/RSBot-green?style=social)](https://github.com/SDClowen/RSBot)
[![Discord](https://img.shields.io/discord/454345032846016515?label=Discord%20Server)](https://discord.gg/rmd96aus9A)

[![Coffee](https://img.shields.io/badge/Donate_@_Buy_Me_A_Coffee-FFDD00?style=for-the-badge&logo=buy-me-a-coffee&logoColor=black)](https://buymeacoffee.com/sdclowen)

| Links                                                                                                                                                                    |                                            |
| ------------------------------------------------------------------------------------------------------------------------------------------------------------------------ | ------------------------------------------ |
| [![release-latest](https://img.shields.io/github/v/release/SDClowen/RSBot?label=Latest%20Stable&style=for-the-badge)](https://github.com/SDClowen/RSBot/releases/latest) | Latest stable release                      |
| [![release-all](https://img.shields.io/badge/Latest%20Release-Nightly-FF0000?style=for-the-badge)](https://github.com/SDClowen/RSBot/releases)                           | Nightly releases for most recent features  |
| [![release-manager](https://img.shields.io/badge/Latest%20Release-Manager-00DD00?style=for-the-badge)](https://github.com/warofmine/Rsbot-Manager/releases/latest)       | Manager for multiple bot profiles          |
| [![docs](https://img.shields.io/badge/RSBot-Docs-FF00FF?style=for-the-badge)](https://sdclowen.github.io/RSBot)                                                          | Documentation, tips & tricks and tutorials |

## Building the project

- Clone the repository with the command `git clone --recursive https://github.com/SDClowen/RSBot.git`)

### Visual Studio

- Open the project in [Visual Studio 2026](https://visualstudio.microsoft.com/downloads/) (Required workloads are `.NET desktop development` and `Desktop development with C++`)
- Build the project (<kbd>Ctrl+Shift+B</kbd>)
- Run the compiled executable from `Build\RSBot.exe`

### Other

Run the commands below (You still need MSBuild tooling via Visual Studio):

- `dotnet restore`
- `powershell -ExecutionPolicy Bypass .\build.ps1`

## Supported clients

| Region          | Version                       |
| :-------------- | :---------------------------- |
| Chinese         | ICCGame                       |
| Chinese Old     | cSRO/-R                       |
| Global          | iSRO (International Silkroad) |
| Japanese        | JSRO                          |
| Japanese Old    | JSRO_SL                       |
| Korean          | KSRO                          |
| Rigid           | iSRO 2015                     |
| Russia          | RuSro                         |
| Taiwan          | Digeam                        |
| Taiwan Old      | TSRO 110                      |
| Thailand        | Blackrogue 100                |
| Thailand        | Blackrogue 110                |
| Turkey          | TRSRO                         |
| Vietnam         | vSRO 188                      |
| Vietnam         | vSRO 193                      |
| Vietnam         | vSRO 274                      |
| Vietnam         | VTC Game                      |
| ~~Chinese Old~~ | ~~MHTC~~                      |
| ~~Japanese-R~~  |                               |

## Project info

![Language](https://img.shields.io/badge/language-CSharp-blue)
[![GitHub License](https://img.shields.io/badge/License-GPLv3-blue)](https://github.com/SDClowen/RSBot/blob/master/LICENSE)
[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2FSDClowen%2FRSBot.svg?type=shield)](https://app.fossa.com/projects/git%2Bgithub.com%2FSDClowen%2FRSBot?ref=badge_shield)

[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2FSDClowen%2FRSBot.svg?type=large)](https://app.fossa.com/projects/git%2Bgithub.com%2FSDClowen%2FRSBot?ref=badge_large)
