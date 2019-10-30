# Customization

## Adding new game installs

Adding new installs is easy, you just need to copy the following snippet:

```js
        {
            "path": "Game Install Here",
            "type": 0
        }
```

And paste it under the existing ones. Just remember to change the `path` and `type`, like so:

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

!!! danger
    The format used for the configuration, called JSON, expects a coma between the installs listed on the configuration. Please, make sure that there is a coma between all installs.

    If you are using Visual Studio Code, you are going to be notified automatically when there is a coma missing.

## Enabling support for Steam copies

To enable the launching of the game from Steam, you need to open `PatchMyPath.json` and change `"use_steam": false` to `"use_steam": true`.
