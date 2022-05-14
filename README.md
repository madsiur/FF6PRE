# FF6PRE 1.0.1
FF6 Pixel Remaster Editor

## Usage
You first need to extract the game assets with [Memoria](https://github.com/Albeoris/Memoria.FFPR). After that open the editor and select the extracted "Assets" path. The path will be saved in `settings.json`. You can also specify another path but the folder structure must be the same as the extracted one. You should then be able to load, edit and save AI scripts.

## Requirements
This application require .NET Core 3.1. You can find the latest .NET Desktop Runtime to install [here](https://dotnet.microsoft.com/en-us/download/dotnet/3.1).

## Future development
Here's a few things I'd like to add for the AI editor:

- Add custom user controls for specific mnemonics instead of generic 8 textboxes user control (e.g. spells selection from lists for the `Act` mnemonic)
- improve descriptions (e.g. spells names instead of "i1: 100, i2: 231")

Once this is done, I could start supporting event scripts and battle scripts since they have the same structures as AI scripts.

## Images
![AI Editor](/images/screenshot1.png)

## Questions, bugs, feedbacks
If you have anything you want to ask me regarding this editor, please [open an issue](https://github.com/madsiur/FF6PRE/issues).
