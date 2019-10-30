# First Steps for running PatchMyPath

!!! tip
    If you have questions about PatchMyPath or you are having problems setting it up, [join the Discord server](https://discord.gg/Cf6sspj). You can get help directly from me or other community members.

!!! warning
    PatchMyPath does not supports pirate copies of Grand Theft Auto V, the only versions supported are the ones from Steam and the Rockstar Games Launcher (previously called Rockstar Warehouse).

## Duplicating your Install

If you want, you use the [Install Duplicator](tutorials/duplicating.md) to reduce the size of your existing modded or create new ones without wasting space.

## Changing the basics

Go ahead and open the configuration file called `PatchMyPath.json` with any text editor (I recommend Visual Studio Code). You should see this:

```js
{
    "use_steam": false,
    "appid": 271590,
    "check_sig": true,
    "destination": "C:\\Program Files\\Grand Theft Auto V",
    "installs": [
        {
            "path": "C:\\Program Files\\Grand Theft Auto V - Clean",
            "type": 0
        }
    ]
}
```

The values that you might want to change are:

* `use_steam` to `true` if you have the Steam edition of the game
* `destination` needs to have the original Grand Theft Auto V location
* on `installs`, you need to change the existing example install and/or new ones

To add new installs, you need to copy the sample install and paste it under, like so:

```js
        {
            "path": "C:\\Program Files\\Grand Theft Auto V - Clean",
            "type": 0
        },
        {
            "path": "C:\\Program Files\\Grand Theft Auto V - Mods",
            "type": 0
        }
```

!!! warning
    The format used for the configuration, called JSON, expects a coma between the installs listed on the configuration. Please, make sure that there is a coma between all installs.

    If you are using Visual Studio Code, is going to warn you automatically when there is a coma missing.
