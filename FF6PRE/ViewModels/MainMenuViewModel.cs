using FF6PRE.Models;
using FF6PRE.MVVM;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Windows.Input;
using System.Windows;

namespace FF6PRE.ViewModels
{
    public class MainMenuViewModel : ObservableObject
    {
        private MainWindowViewModel _mainWindowVM;
        public MainWindowViewModel MainWindowVM
        {
            get { return _mainWindowVM; }
            set { OnPropertyChanged(ref _mainWindowVM, value); }
        }

        private PathSelectionViewModel _pathSelectionVM;
        public PathSelectionViewModel PathSelectionVM
        {
            get { return _pathSelectionVM; }
            set { OnPropertyChanged(ref _pathSelectionVM, value); }
        }

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { OnPropertyChanged(ref _currentView, value); }
        }

        private bool _isAiEnabled;
        public bool IsAiEnabled
        {
            get { return _isAiEnabled; }
            set { OnPropertyChanged(ref _isAiEnabled, value); }
        }

        private bool _isSaveEnabled;
        public bool IsSaveEnabled
        {
            get { return _isSaveEnabled; }
            set { OnPropertyChanged(ref _isSaveEnabled, value); }
        }

        public ICommand GoToPathSelection { get; private set; }
        public ICommand GoToAiEditor { get; private set; }
        public ICommand SaveFiles { get; private set; }
        public ICommand ExitProgram { get; private set; }

        private Settings? settings;

        private List<AiScript> aiScripts;

        public MainMenuViewModel(MainWindowViewModel MainWindowVM)
        {
            this.MainWindowVM = MainWindowVM;

            GoToPathSelection = new RelayCommand(PathSelection);
            GoToAiEditor = new RelayCommand(AiEditor);
            SaveFiles = new RelayCommand(Save);
            ExitProgram = new RelayCommand(Exit);

            loadSettings();

            CurrentView = new PathSelectionViewModel(this, settings);

            enableOptions();
            IsSaveEnabled = false;

            aiScripts = null;
        }

        private void enableOptions()
        {
            if(settings.FF6Path != string.Empty)
            {
                IsAiEnabled = true;
            }
        }

        private void loadSettings()
        {
            if(File.Exists(Constants.SETTINGS_FILE))
            {
                settings = JsonSerializer.Deserialize<Settings>(File.ReadAllText(Constants.SETTINGS_FILE));

                if(settings == null)
                {
                    settings =new Settings();
                }
            }
            else
            {
                settings = new Settings();
            }
        }

        private void PathSelection()
        {
            if(!(CurrentView is PathSelectionViewModel))
            {
                CurrentView = new PathSelectionViewModel(this, settings);
            }
        }

        private void AiEditor()
        {
            if (!(CurrentView is AiEditorViewModel)) 
            { 
                string aiPath = Path.Combine(settings.FF6Path, Constants.AI_PATH);

                if (Utils.DirectoryExists(aiPath))
                {
                    if (aiScripts == null)
                    {
                        loadAiScripts(aiPath);
                    }
                    IsSaveEnabled = true;
                    CurrentView = new AiEditorViewModel(this, ref aiScripts);
                }
            }
        }

        private void loadAiScripts(string aiPath)
        {
            aiScripts = new List<AiScript>();

            // get ai filepaths
            List<string> filePaths = Directory.GetFiles(aiPath).ToList();
            filePaths.Sort();
            int id = 0;

            foreach (string filePath in filePaths)
            {
                if (Utils.FileExists(filePath))
                {
                    // deserialize scripts
                    StreamReader srs = new StreamReader(filePath);
                    string strJsonAiScript = srs.ReadToEnd();
                    JsonScript? jsonAiScript = JsonSerializer.Deserialize<JsonScript>(strJsonAiScript);
                    aiScripts.Add(new AiScript(id, jsonAiScript, filePath));
                    id++;
                }
            }
        }

        private void Save()
        {
            if(aiScripts != null)
            {
                var options = new JsonSerializerOptions()
                {
                    WriteIndented = true,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };

                foreach (AiScript s in aiScripts)
                {
                    s.save();
                    try
                    {
                        StreamWriter sw = new StreamWriter(s.filePath);
                        string ps = JsonSerializer.Serialize(s.script, options);
                        sw.Write(ps);
                        sw.Flush();
                        sw.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Error", "Cannot save script " + s.name + ". Scripts saving will stop now.", MessageBoxButton.OK, MessageBoxImage.Error);
                        break;
                    }
                }
            }
        }

        private void Exit()
        {
            Application.Current.Shutdown();
        }
    }
}
