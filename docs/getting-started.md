# Getting started

!!! tip
    If you need support or want some questions answered [join the Discord server](https://discord.gg/Cf6sspj).

!!! warning
    PatchMyPath does not supports pirate copies of Red Dead Redemption 2 and Grand Theft Auto V.

## Installation

Before installing PatchMyPath, make sure that [.NET Framework 4.5.2](https://dotnet.microsoft.com/download/dotnet-framework/net452) is installed on your computer.

1. Download the compressed file from [GitHub Releases][releases-url] or [5mods][5mods-url]
2. Extracts the contents of the compressed file somewhere on your PC
3. Launch `PatchMyPath.exe` and select the `Settings` tab
4. Click the respective `Detect` buttons for the game that you plan to use
    * If the button was unable to detect your game original location, you can enter the game location manually

    ??? tip "Click here for Steam instructions"
        ![RGL](../images/getting-started/steam.png)

        1. Right click the game that you want to get the location from
        2. At the bottom of the menu, click `Properties...`
        3. Select the `Local Files` tab
        4. Click the `Browse Local Files...` button
        5. On Windows Explorer, right click the address bar at the top
        6. Select `Copy address as text` and paste it on the PatchMyPath Location field

    ??? tip "Click here for Rockstar Games Launcher instructions"
        ![RGL](../images/getting-started/rgsc.png)

        1. At the top left of the application, click `Settings`
        2. Select the game that you want to get the location from in `My installed games`
        3. On `View installation folder`, click `Open`
        4. On Windows Explorer, right click the address bar at the top
        5. Select `Copy address as text` and paste it on the PatchMyPath Location field

5. Click `Save` to store the original location of the game
6. If this is the orignal folder of the game, you will be asked to rename it to prevent future problems, click `Yes`
7. Optional: Use the [Install Duplicator](duplicator/getting-started.md) to reduce the size of your existing installs or create new ones

## Usage

To use PatchMyPath, you just need to run `PatchMyPath.exe`, enter an install number and press enter. Then, the application is going to close the Rockstar Games Launcher and Steam (if is required) to change the install location to then launch the game from the selected install.

[releases-url]: https://github.com/justalemon/PatchMyPath/releases
[5mods-url]: https://www.gta5-mods.com/tools/patchmypath
