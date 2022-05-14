# FF6PRE 1.0
FF6 Pixel Remaster Editor

## Usage
You first need to extract the game assets with [Memoria](https://github.com/Albeoris/Memoria.FFPR). After that open the editor and select the extracted "Assets" path. The path will be saved in `settings.json`. You can also specify another path but the folder structure must be the same as the extracted one. You should then be able to load and edit AI scripts.

## Requirements
This application require .NET Core 3.1.

## Future development
Here's a few things I'd like to add for the AI editor:

- addition/removal of mnemonics in the script (probably with two buttons that will add/remove relatively to where you are in the script)
- Add "restore script to original" feature (will restore to state when editor was opened)
- Add custom user controls for specific mnemonics instead of generic 8 textboxes user control (e.g. spells selection from lists for the Act mnemonic)
- improve descriptions (e.g. spells names instead of "i1: 100, i2: 231")
- change the button icons to something that look better than traffic lights :P

Once this is done, I could start supporting event scripts and battle scripts since they have the same structures as AI scripts.

## Questions, bugs, feedbacks
If you have anything you want to ask me regarding this editor, please [open an issue](https://github.com/madsiur/FF6PRE/issues).
