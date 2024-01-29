### Palworld Appearance Transfer
--------

![example](https://github.com/arenasys/PalworldAppearanceTransfer/raw/master/screenshot.png)

Discord: [Arena Systems](https://discord.gg/WdjKqUGefU).

## About
Small tool using [Palworld UESave](https://github.com/DKingAlpha/palworld-uesave-rs) to transfer the player appearance from one save file to another. Automatically backs up saves before editing (but manual backups are still recommended).

Download [here](https://github.com/arenasys/palworld-appearance-transfer/releases/download/v1.0/PalTransfer.zip), extract and run. Dont run as Admin.

## Notes
Only the name for the main player of a world can be extracted (UESave limitation?), other players in the world will use their hexadecimal file names.
Looks for a save folder in the usual `AppData\Local\Pal\Saved\SavedGames` or if there is a `SavedGames` folder next to the exe it uses that instead.
Backups are stored in `AppData\Local\PalTransfer`.

## Backups
Select the source world to be `Backup` and source player to be the specific backup file. Then find the correct destination and press Apply. Backups are the full original file and will replace the destination save file completely (not just appearance).