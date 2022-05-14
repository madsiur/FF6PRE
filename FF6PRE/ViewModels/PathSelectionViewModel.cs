using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Forms;
using FF6PRE.MVVM;
using FF6PRE.Models;
using System.IO;

namespace FF6PRE.ViewModels
{
    public class PathSelectionViewModel: ObservableObject
    {
        private MainMenuViewModel _mainMenuVM;
        public MainMenuViewModel MainMenuVM
        {
            get { return _mainMenuVM; }
            set { OnPropertyChanged(ref _mainMenuVM, value); }
        }

        private string _ff6Path;
        public string FF6Path
        {
            get { return _ff6Path; }
            set { OnPropertyChanged(ref _ff6Path, value); }
        }

        public ICommand ChooseDirectory { get; private set; }

        private Settings? settings;

        public PathSelectionViewModel(MainMenuViewModel mainMenuVM, Settings settings)
        {
            MainMenuVM = mainMenuVM;
            this.settings = settings;

            ChooseDirectory = new RelayCommand(OpenDialog);

            showPath(settings.FF6Path);
        }

        private void showPath(string path)
        {
            if (path.Length > 110 && path != string.Empty)
            {
                FF6Path = "..." + path.Substring(path.Length - 107);
            }
            else
            {
                FF6Path = path;
            }
        }

        private void OpenDialog()
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Select Assets folder";
            dialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
            dialog.ShowNewFolderButton = true;

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                settings.FF6Path = dialog.SelectedPath;
                string jsonSettings =  JsonSerializer.Serialize(settings);
                File.WriteAllText(Constants.SETTINGS_FILE, jsonSettings);

                showPath(dialog.SelectedPath);

                MainMenuVM.IsAiEnabled = true;
            }
        }
    }
}
