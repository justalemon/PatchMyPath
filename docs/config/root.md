# Base Configuration

The configuration file is called `PatchMyPath.json` and is located on the root folder of the program.

## use_steam

* Type: [bool]
* Default Value: [false]

Enables or Disables the usage of Steam to launch the game.

## appid

* Type: [int]
* Default Value: `271590`

The Steam appid if you want to launch the game from it. By default, it uses the id of the official Steam version, but you can change it to launch the Rockstar Games Launcher version from Steam.

## check_sig

* Type: [bool]
* Default Value: [true]

If the application should ensure the integrity of the GTA V executables during the type checks. Leave this on [true] unless you know what you are doing.

## destination

* Type: [string]
* Default Value: `C:\\Program Files\\Grand Theft Auto V`

The location where Steam or the Rockstar Games Launcher expects the game to be installed. **You need to change this option prior to using PatchMyPath**.

## installs

* Type: [install](install.md) objects
* Default Value:

```js
{
    "path": "C:\\Program Files\\Grand Theft Auto V - Clean",
    "type": 0
}
```

The different installs that you are allowed to switch from and to on PatchMyPath. **You need to change this option prior to using PatchMyPath**.

[bool]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/bool
[true]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/true-literal
[false]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/false-literal
[int]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/int
[string]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/string
