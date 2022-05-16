# FF6PRE 1.0.3
FF6 Pixel Remaster Editor

## Usage
You first need to extract the game assets with [Memoria](https://github.com/Albeoris/Memoria.FFPR). After that open the editor and select the extracted "Assets" path. The path will be saved in `settings.json`. You can also specify another path but the folder structure must be the same as the extracted one. You should then be able to load, edit and save AI scripts.

## Requirements
This application require .NET Core 3.1. You can find the latest .NET Desktop Runtime to install [here](https://dotnet.microsoft.com/en-us/download/dotnet/3.1).

## Features
- Can edit AI script mnemonic, type, label, comment, iValues, rValues and sValues. The total number of mnemonics written in the script is adjusted at saving.
- Can insert new mnemonics or delete the selected one.
- Restore script button to put the script in its state at the last saving.
- Clean script button to have a blank script.
- The Act mnemonics (Act, CounterAct, FinalAttackAct, etc.) have their own User Control. It consist for each action of a combobox to select the action and a textbox to enter the percentage. When mouse focused on a combobox, you can press F1 to toggle between regular combobox and searcheable combobox.
- Different validations for the Act mnemonics, if you have a warning it will appear when you switch mnemonic within the same script.

## Images
![AI Editor 1](/images/screenshot1.png)

![AI Editor 2](/images/screenshot2.png)

## Questions, bugs, feedbacks
If you have anything you want to ask me regarding this editor, please [open an issue](https://github.com/madsiur/FF6PRE/issues).
