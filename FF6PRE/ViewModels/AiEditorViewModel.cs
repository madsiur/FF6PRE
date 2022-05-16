using FF6PRE.Models;
using FF6PRE.MVVM;
using FF6PRE.UC;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static FF6PRE.Enums;

namespace FF6PRE.ViewModels
{
    public class AiEditorViewModel: ObservableObject
    {
        #region VIEWMODEL ELEMENTS

        private MainMenuViewModel _mainMenuVM;
        public MainMenuViewModel MainMenuVM
        {
            get { return _mainMenuVM; }
            set { OnPropertyChanged(ref _mainMenuVM, value); }
        }

        private ActViewModel _actVM;
        public ActViewModel ActVM
        {
            get { return _actVM; }
            set { OnPropertyChanged(ref _actVM, value); }
        }

        private MultiDefaultValuesViewModel _multiDefaultValuesVM;
        public MultiDefaultValuesViewModel MultiDefaultValuesVM
        {
            get { return _multiDefaultValuesVM; }
            set { OnPropertyChanged(ref _multiDefaultValuesVM, value); }
        }

        private object _currentAiValVM;
        public object CurrentAiValVM
        {
            get { return _currentAiValVM; }
            set { OnPropertyChanged(ref _currentAiValVM, value); }
        }

        private List<AiScript> _aiScripts;
        public List<AiScript> AiScripts
        {
            get { return _aiScripts; }
            set { OnPropertyChanged(ref _aiScripts, value); }
        }

        private AiScript _selectedAiScript;
        public AiScript SelectedAiScript
        {
            get { return _selectedAiScript; }
            set 
            {
                OnPropertyChanged(ref _selectedAiScript, value);

                _selectedAiScript.buildDescriptions();

                AiMnemonics = new ObservableCollection<Mnemonic>(_selectedAiScript.Mnemonics);

                if (CurrentAiMnemonic == null)
                {
                    CurrentAiMnemonic = AiMnemonics[0];
                }
                else
                {
                    CurrentAiMnemonic = AiMnemonics[AiMnemonics.IndexOf(CurrentAiMnemonic)];
                }
            }
        }

        private List<string> _availableMnemonics;
        public List<string> AvailableMnemonics
        {
            get { return _availableMnemonics; }
            set { OnPropertyChanged(ref _availableMnemonics, value); }
        }

        private List<int> _availableTypes;
        public List<int> AvailableTypes
        {
            get { return _availableTypes; }
            set { OnPropertyChanged(ref _availableTypes, value); }
        }

        private ObservableCollection<Mnemonic> _aiMnemonics;
        public ObservableCollection<Mnemonic> AiMnemonics
        {
            get { return _aiMnemonics; }
            set { OnPropertyChanged(ref _aiMnemonics, value); }
        }

        private Mnemonic _currentAiMnemonic;
        public Mnemonic CurrentAiMnemonic
        {
            get { return _currentAiMnemonic; }
            set
            {
                if (_currentAiMnemonic != null && !isChangingProperty && !isRestoringScript)
                {
                    if (Utils.isActMnemonic(_currentAiMnemonic) && !(CurrentAiValVM as ActViewModel).IsButtonPressed)
                    {
                        validateAct(_currentAiMnemonic);
                    }
                }

                OnPropertyChanged(ref _currentAiMnemonic, value);

                if (_currentAiMnemonic != null)
                {
                    isInitMnemonic = true;
                    if (!isChangingProperty)
                    {
                        CurrentMnemonicName = _currentAiMnemonic.MnemonicName;
                        CurrentType = _currentAiMnemonic.Type;
                        CurrentLabel = _currentAiMnemonic.Label;
                        CurrentComment = _currentAiMnemonic.Comment;
                    }
                    if (Utils.isActMnemonic(_currentAiMnemonic))
                    {
                        if (!(CurrentAiValVM is ActViewModel))
                        {
                            CurrentAiValVM = new ActViewModel(this);
                        }
                        (CurrentAiValVM as ActViewModel).refreshAct(_currentAiMnemonic);
                    }
                    else
                    {
                        if (!(CurrentAiValVM is MultiDefaultValuesViewModel))
                        {
                            CurrentAiValVM = new MultiDefaultValuesViewModel(this);
                        }
                        (CurrentAiValVM as MultiDefaultValuesViewModel).refreshValues(_currentAiMnemonic);
                    }
                    isInitMnemonic = false;
                }
            }
        }

        private string _currentMnemonicName;
        public string CurrentMnemonicName
        {
            get { return _currentMnemonicName; }
            set 
            { 
                OnPropertyChanged(ref _currentMnemonicName, value);
                
                if(!isInitMnemonic)
                {
                    isChangingProperty = true;
                    AiScripts[ScriptIndex].Mnemonics[AiScripts[ScriptIndex].Mnemonics.IndexOf(CurrentAiMnemonic)].MnemonicName = _currentMnemonicName;
                    AiScripts[ScriptIndex].Mnemonics[AiScripts[ScriptIndex].Mnemonics.IndexOf(CurrentAiMnemonic)].AiMnemon = Utils.getAiMnemonic(_currentMnemonicName);
                    setSelectedAiScript();
                    isChangingProperty = false;
                }

            }
        }

        private int _currentType;
        public int CurrentType
        {
            get { return _currentType; }
            set 
            { 
                OnPropertyChanged(ref _currentType, value);

                if (!isInitMnemonic)
                {
                    isChangingProperty = true;
                    AiScripts[ScriptIndex].Mnemonics[AiScripts[ScriptIndex].Mnemonics.IndexOf(CurrentAiMnemonic)].Type = _currentType;
                    setSelectedAiScript();
                    isChangingProperty = false;
                }
            }
        }

        private string _currentlabel;
        public string CurrentLabel
        {
            get { return _currentlabel; }
            set 
            { 
                OnPropertyChanged(ref _currentlabel, value);

                if (!isInitMnemonic)
                {
                    isChangingProperty = true;
                    AiScripts[ScriptIndex].Mnemonics[AiScripts[ScriptIndex].Mnemonics.IndexOf(CurrentAiMnemonic)].Label = _currentlabel;
                    setSelectedAiScript();
                    isChangingProperty = false;
                }
            }
        }

        private string _currentComment;
        public string CurrentComment
        {
            get { return _currentComment; }
            set 
            { 
                OnPropertyChanged(ref _currentComment, value);

                if (!isInitMnemonic)
                {
                    isChangingProperty = true;
                    AiScripts[ScriptIndex].Mnemonics[AiScripts[ScriptIndex].Mnemonics.IndexOf(CurrentAiMnemonic)].Comment = _currentComment;
                    setSelectedAiScript();
                    isChangingProperty = false;
                }
            }
        }

        private ICommand _addMnemonicCommand;
        public ICommand AddMnemonicCommand
        {
            get { return _addMnemonicCommand; }
            set { OnPropertyChanged(ref _addMnemonicCommand, value); }
        }

        private ICommand _deleteMnemonicCommand;
        public ICommand DeleteMnemonicCommand
        {
            get { return _deleteMnemonicCommand; }
            set { OnPropertyChanged(ref _deleteMnemonicCommand, value); }
        }

        private ICommand _restoreScriptCommand;
        public ICommand RestoreScriptCommand
        {
            get { return _restoreScriptCommand; }
            set { OnPropertyChanged(ref _restoreScriptCommand, value); }
        }

        private ICommand _clearScriptCommand;
        public ICommand ClearScriptCommand
        {
            get { return _clearScriptCommand; }
            set { OnPropertyChanged(ref _clearScriptCommand, value); }
        }

        #endregion

        public bool isInitMnemonic = false;
        public bool isRestoringScript = false;
        public bool isChangingProperty = false;
        private List<AiScript> aiScriptsBackups;

        #region INIT

        public AiEditorViewModel(MainMenuViewModel mainMenuVM, ref List<AiScript> aiScripts)
        {
            aiScriptsBackups = aiScripts.Select(item => item.Clone()).ToList();
            this.MainMenuVM = mainMenuVM;
            this.AiScripts = aiScripts;
            SelectedAiScript = AiScripts[0];
            AvailableMnemonics = buildMnemonicList();
            buildTypes();
            setCommands();
        }

        private void buildTypes()
        {
            AvailableTypes = new List<int>();
            AvailableTypes.Add(0);
            AvailableTypes.Add(1);
        }

        private List<string> buildMnemonicList()
        {
            List<string> mnemonics = new List<string>();
            foreach (AiScript s in AiScripts)
            {
                foreach (Mnemonic m in s.Mnemonics)
                {
                    string mn = m.MnemonicName.Trim();
                    if (!mnemonics.Contains(mn) && mn != string.Empty)
                    {
                        mnemonics.Add(mn);
                    }
                }
            }
            mnemonics.Sort();
            return mnemonics;
        }

        private void setCommands()
        {
            AddMnemonicCommand = new RelayCommand(AddMnemonic);
            DeleteMnemonicCommand = new RelayCommand(DeleteMnemonic);
            RestoreScriptCommand = new RelayCommand(RestoreScript);
            ClearScriptCommand = new RelayCommand(ClearScript);
        }

        #endregion

        #region BUTTON COMMANDS

        private void AddMnemonic()
        {
            int index = AiScripts[ScriptIndex].Mnemonics.IndexOf(CurrentAiMnemonic) + 1;
            JsonOperands op = new JsonOperands();
            op.iValues = new List<int>();
            op.rValues = new List<float>();
            op.sValues = new List<string>();
            Mnemonic m = new Mnemonic(index + 1, string.Empty, "Nop", 1, string.Empty, op);
            AiScripts[ScriptIndex].Mnemonics.Insert(index, m);
            for (int i = index + 1; i < AiScripts[ScriptIndex].Mnemonics.Count; i++)
            {
                AiScripts[ScriptIndex].Mnemonics[i].Id++;
            }
            setSelectedAiScript();
            CurrentAiMnemonic = AiScripts[ScriptIndex].Mnemonics[index];
        }

        private void DeleteMnemonic()
        {
            if (SelectedAiScript.Mnemonics.Count > 2)
            {
                int index = AiScripts[ScriptIndex].Mnemonics.IndexOf(CurrentAiMnemonic);
                for (int i = index + 1; i < AiScripts[ScriptIndex].Mnemonics.Count; i++)
                {
                    AiScripts[ScriptIndex].Mnemonics[i].Id--;
                }
                AiScripts[ScriptIndex].Mnemonics.RemoveAt(index);
                setSelectedAiScript();
                CurrentAiMnemonic = AiScripts[ScriptIndex].Mnemonics[index - 1];
            }
        }

        private void RestoreScript()
        {
            isRestoringScript = true;
            int index = ScriptIndex;
            AiScripts[index] = aiScriptsBackups[index].Clone();
            SelectedAiScript = AiScripts[index];
            isRestoringScript = false;
        }

        private void ClearScript()
        {
            AiScripts[ScriptIndex].Mnemonics = new List<Mnemonic>();
            AiScripts[ScriptIndex].Mnemonics.Add(new Mnemonic(1, "Main", "Nop", 1, string.Empty));
            AiScripts[ScriptIndex].Mnemonics.Add(new Mnemonic(2, string.Empty, "Exit", 1, string.Empty));
            AiScripts[ScriptIndex].Mnemonics[1].fillValues();
            setSelectedAiScript();
        }

        #endregion

        #region FUNCTIONS

        private void validateAct(Mnemonic m)
        {
            if(m.Operands.iValues.Count > m.Operands.rValues.Count)
            {
                Utils.showWarning("One or more abilities have no percentage assigned.");
                return;
            }
            else if (m.Operands.iValues.Count < m.Operands.rValues.Count)
            {
                Utils.showWarning("One or more percentages have no ability assigned.");
                return;
            }

            for (int i = 0; i < m.Operands.iValues.Count; i++)
            {
                if (m.Operands.iValues[i] == 0)
                {
                    Utils.showWarning("Ability iValue" + (i + 1).ToString() + " is 0.");
                    return;
                }
            }

            int total = 0;
            for(int i = 0; i < m.Operands.rValues.Count; i++)
            {
                int result;
                string val = m.Operands.rValues[i].ToString();
                if (!int.TryParse(val, out result))
                {
                    Utils.showWarning("Percentage rValue " + val + " is not an integer.");
                    return;
                }
                total += result;
            }
            if(total != 100)
            {
                Utils.showWarning("Total percentage (" + total + ") is not 100.");
            }
        }

        public int ScriptIndex
        {
            get { return AiScripts.IndexOf(SelectedAiScript); }
        }

        public void setSelectedAiScript()
        {
            SelectedAiScript = AiScripts[ScriptIndex];
        }

        public string getDescriptionValue(int key)
        {
            return Utils.AbilityKeyValues.Where(x => x.Key == key).First().Value;
        }

        public int getDescriptionKey(string desc)
        {
            return Utils.AbilityKeyValues.Where(x => x.Value == desc).First().Key;
        }

        public JsonOperands getOperands()
        {
            return AiScripts[ScriptIndex].Mnemonics[AiScripts[ScriptIndex].Mnemonics.IndexOf(CurrentAiMnemonic)].Operands;
        }

        public void initOperands()
        {
            if (AiScripts[ScriptIndex].Mnemonics[AiScripts[ScriptIndex].Mnemonics.IndexOf(CurrentAiMnemonic)].Operands == null)
            {
                AiScripts[ScriptIndex].Mnemonics[AiScripts[ScriptIndex].Mnemonics.IndexOf(CurrentAiMnemonic)].Operands = new JsonOperands();
            }
        }

        public void initIValues()
        {
            AiScripts[ScriptIndex].Mnemonics[AiScripts[ScriptIndex].Mnemonics.IndexOf(CurrentAiMnemonic)].Operands.iValues = new List<int>();
        }

        public void initRValues()
        {
            AiScripts[ScriptIndex].Mnemonics[AiScripts[ScriptIndex].Mnemonics.IndexOf(CurrentAiMnemonic)].Operands.rValues = new List<float>();
        }

        public void initSValues()
        {
            AiScripts[ScriptIndex].Mnemonics[AiScripts[ScriptIndex].Mnemonics.IndexOf(CurrentAiMnemonic)].Operands.sValues = new List<string>();
        }

        public void addIValue(int value)
        {
            AiScripts[ScriptIndex].Mnemonics[AiScripts[ScriptIndex].Mnemonics.IndexOf(CurrentAiMnemonic)].Operands.iValues.Add(value);
        }

        public void addRValue(float value)
        {
            AiScripts[ScriptIndex].Mnemonics[AiScripts[ScriptIndex].Mnemonics.IndexOf(CurrentAiMnemonic)].Operands.rValues.Add(value);
        }

        public void addSValue(string value)
        {
            AiScripts[ScriptIndex].Mnemonics[AiScripts[ScriptIndex].Mnemonics.IndexOf(CurrentAiMnemonic)].Operands.sValues.Add(value);
        }

        public void addStrIValue(string value)
        {
            if(value == string.Empty)
            {
                addIValue(0);
            }
            else
            {
                addIValue(int.Parse(value));
            }
        }

        public void addStrRValue(string value)
        {
            if (value == string.Empty)
            {
                addRValue(0);
            }
            else
            {
                addRValue(float.Parse(value));
            }
        }

        #endregion
    }
}
