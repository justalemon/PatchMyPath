# Getting started

!!! danger
    If you move the original vanilla GTA V folder after creating a duplicated install, you need to repeat this process again. Please note that doing the process on an existing install is safe because only game files are replaced.
!!! info
    To create [Symbolic](https://en.wikipedia.org/wiki/Symbolic_link) or [Hard Links](https://en.wikipedia.org/wiki/Hard_link), you need to run the application as administrator or enable the Windows 10 Developer Mode.

## Usage

First, you need a working Grand Theft Auto V install for the new copy that is going to be created. Please note that we do not recommend using an existing modded/dirty install to be used as a base.

??? example "List of Vanilla Files"
    Please note that the files marked are optional are not required for Grand Theft Auto V to run, but they might be required for other functions like Grand Theft Auto Online and the installation wizard.

    **Folders**

    * ReadMe (optional)
    * Redistributables (optional)
    * update
    * x64

    **Files**

    * GTA5.exe
    * GTAVLanguageSelect.exe (optional)
    * GTAVLauncher.exe
    * PlayGTAV.exe (optional)
    * bink2w64.dll
    * d3dcompiler_46.dll
    * d3dcsx_46.dll
    * GFSDK_ShadowLib.win64.dll
    * GFSDK_TXAA.win64.dll
    * GFSDK_TXAA_AlphaResolve.win64.dll
    * GPUPerfAPIDX11-x64.dll
    * NvPmApi.Core.win64.dll
    * index.bin (optional)
    * common.rpf
    * x64a.rpf
    * x64b.rpf
    * x64c.rpf
    * x64d.rpf
    * x64e.rpf
    * x64f.rpf
    * x64g.rpf
    * x64h.rpf
    * x64i.rpf
    * x64j.rpf
    * x64k.rpf
    * x64l.rpf
    * x64m.rpf
    * x64n.rpf
    * x64o.rpf
    * x64p.rpf
    * x64q.rpf
    * x64r.rpf
    * x64s.rpf
    * x64t.rpf
    * x64u.rpf
    * x64v.rpf
    * x64w.rpf
    * version.txt (optional)

!!! tip
    If you want to make sure that the game install is clean, follow the instructions for your game copy:

    * Rockstar Games Launcher: Go to `Settings > My installed games > Grand Theft Auto V` and click `Verify Integrity` to ensure that all of the files are on their vanilla state

    ![RGL](../images/duplicating/01.png)

    * Steam: Right Click the game and select `Properties`. Then, go to the `Local Files` tab and click `Verify Integrity of Local Files...`

    ![Steam](../images/duplicating/02.png)

1. Close the Rockstar Games Launcher and Steam (if you have a Steam copy)
2. Change the location of the existing vanilla GTA V Folder. Let's say that your game install is located at `C:\Program Files\Grand Theft Auto V`, you can either:
    * Rename it (for example, `C:\Program Files\Grand Theft Auto V - Clean`)
    * Move it (for example, `C:\Games\Grand Theft Auto V - Clean`)
3. **Important**: Remember the original location of the game, you need it for PatchMyPath
4. Open `InstallDuplicator.exe`
5. Click the `Select` button near `Origin` and select the existing vanilla folder

    ![Selecting the Vanilla Folder](../images/duplicating/03.png)

6. Repeat the same process but with the second `Select` button near `Destination` to pick where the duplicated copy should be saved

    ![Selecting the Destination Folder](../images/duplicating/04.png)

7. Click `Duplicate GTA V Folder` to start the process

!!! info
    If the directory that you selected contains files or folders, you will be asked if you want to check for game files and remove them if they are present. Please note that the application will not delete any mods or scripts installed, only game files that will be linked against the original install to save storage.

    ![Message about Duplicated Files](../images/duplicating/05.png)

If you get the following message, congratulations! The entire duplication process has been completed. You will be asked if you want to open the folder on the Windows File Explorer, and that is up to you.

![Completion](../images/duplicating/06.png)
