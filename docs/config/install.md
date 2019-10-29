# Install Objects

The install objects can only be used on the `installs` array at the root of the configuration file.

## destination

* Type: [string]
* Default Value: `C:\\Program Files\\Grand Theft Auto V - Clean`

The location of this specific game install. **You need to change this option prior to using PatchMyPath**.

## type

* Type: [int]
* Default Value: `0`

A number specificating the type of this game install, where:

* `0` auto detects the install type
* `1` is a normal install, where the game should be launched using `GTAVLauncher.exe`
* `2` is an install that has Unknown's [Launcher Bypass](https://www.gta5-mods.com/tools/gtavlauncherbypass) installed, and uses `GTA5.exe` to launch the game
* `3`  is for installs that use Rage Plugin Hook, and the game is launched from `RAGEPluginHook.exe`

[int]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/int
[string]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/string
