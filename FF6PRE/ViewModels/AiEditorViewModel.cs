﻿using FF6PRE.Models;
using FF6PRE.MVVM;
using FF6PRE.UC;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FF6PRE.ViewModels
{
    public class AiEditorViewModel: ObservableObject
    {
        private MainMenuViewModel _mainMenuVM;
        public MainMenuViewModel MainMenuVM
        {
            get { return _mainMenuVM; }
            set { OnPropertyChanged(ref _mainMenuVM, value); }
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
                OnPropertyChanged(ref _currentAiMnemonic, value);

                if (_currentAiMnemonic != null && !isChangingProperty)
                {
                    refreshMnemonic();
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

        private int ScriptIndex
        {
            get { return AiScripts.IndexOf(SelectedAiScript); }
        }

        private bool isInitMnemonic = false;
        private bool isChangingProperty = false;
        private bool isChangingEnabled = false;

        private Uri redButtonUri = new Uri("pack://application:,,,/Images/red_button.png");
        private Uri greenButtonUri = new Uri("pack://application:,,,/Images/green_button.png");
        private ImageSource redButtonImage;
        private ImageSource greenButtonImage;

        public AiEditorViewModel(MainMenuViewModel mainMenuVM, ref List<AiScript> aiScripts)
        {
            redButtonImage = buildImageSource(redButtonUri);
            greenButtonImage = buildImageSource(greenButtonUri);
            this.MainMenuVM = mainMenuVM;
            this.AiScripts = aiScripts;
            SelectedAiScript = AiScripts[0];
            AvailableMnemonics = buildMnemonicList();
            buildTypes();
            setCCommands();
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

        private ImageSource buildImageSource(Uri uri)
        {
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = uri;
            bitmapImage.EndInit();
            ImageSource imgsrc = bitmapImage as ImageSource;
            return imgsrc;
        }

        #region REFRESH FUNCTION

        private void refreshMnemonic()
        {
            isInitMnemonic = true;
            isChangingEnabled = false;
            CurrentMnemonicName = _currentAiMnemonic.MnemonicName;
            CurrentType = _currentAiMnemonic.Type;
            CurrentLabel = _currentAiMnemonic.Label;
            CurrentComment = _currentAiMnemonic.Comment;
            IValue1 = string.Empty;
            IValue2 = string.Empty;
            IValue3 = string.Empty;
            IValue4 = string.Empty;
            IValue5 = string.Empty;
            IValue6 = string.Empty;
            IValue7 = string.Empty;
            IValue8 = string.Empty;
            RValue1 = string.Empty;
            RValue2 = string.Empty;
            RValue3 = string.Empty;
            RValue4 = string.Empty;
            RValue5 = string.Empty;
            RValue6 = string.Empty;
            RValue7 = string.Empty;
            RValue8 = string.Empty;
            SValue1 = string.Empty;
            SValue2 = string.Empty;
            SValue3 = string.Empty;
            SValue4 = string.Empty;
            SValue5 = string.Empty;
            SValue6 = string.Empty;
            SValue7 = string.Empty;
            SValue8 = string.Empty;
            IsEnabledIValue1 = false;
            IsEnabledIValue2 = false;
            IsEnabledIValue3 = false;
            IsEnabledIValue4 = false;
            IsEnabledIValue5 = false;
            IsEnabledIValue6 = false;
            IsEnabledIValue7 = false;
            IsEnabledIValue8 = false;
            IsEnabledRValue1 = false;
            IsEnabledRValue2 = false;
            IsEnabledRValue3 = false;
            IsEnabledRValue4 = false;
            IsEnabledRValue5 = false;
            IsEnabledRValue6 = false;
            IsEnabledRValue7 = false;
            IsEnabledRValue8 = false;
            IsEnabledSValue1 = false;
            IsEnabledSValue2 = false;
            IsEnabledSValue3 = false;
            IsEnabledSValue4 = false;
            IsEnabledSValue5 = false;
            IsEnabledSValue6 = false;
            IsEnabledSValue7 = false;
            IsEnabledSValue8 = false;

            if (_currentAiMnemonic.Operands != null)
            {
                if (_currentAiMnemonic.Operands.iValues != null)
                {
                    IList<int> iValues = _currentAiMnemonic.Operands.iValues;
                    if (iValues.Count > 0)
                    {
                        IsEnabledIValue1 = true;
                        IValue1 = iValues[0].ToString();
                        if (iValues.Count > 1)
                        {
                            IsEnabledIValue2 = true;
                            IValue2 = iValues[1].ToString();
                            if (iValues.Count > 2)
                            {
                                IsEnabledIValue3 = true;
                                IValue3 = iValues[2].ToString();
                                if (iValues.Count > 3)
                                {
                                    IsEnabledIValue4 = true;
                                    IValue4 = iValues[3].ToString();
                                    if (iValues.Count > 4)
                                    {
                                        IsEnabledIValue5 = true;
                                        IValue5 = iValues[4].ToString();
                                        if (iValues.Count > 5)
                                        {
                                            IsEnabledIValue6 = true;
                                            IValue6 = iValues[5].ToString();
                                            if (iValues.Count > 6)
                                            {
                                                IsEnabledIValue7 = true;
                                                IValue7 = iValues[6].ToString();
                                                if (iValues.Count > 7)
                                                {
                                                    IsEnabledIValue8 = true;
                                                    IValue8 = iValues[7].ToString();
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                if (_currentAiMnemonic.Operands.rValues != null)
                {
                    IList<float> rValues = _currentAiMnemonic.Operands.rValues;
                    if (rValues.Count > 0)
                    {
                        IsEnabledRValue1 = true;
                        RValue1 = rValues[0].ToString();
                        if (rValues.Count > 1)
                        {
                            IsEnabledRValue2 = true;
                            RValue2 = rValues[1].ToString();
                            if (rValues.Count > 2)
                            {
                                IsEnabledRValue3 = true;
                                RValue3 = rValues[2].ToString();
                                if (rValues.Count > 3)
                                {
                                    IsEnabledRValue4 = true;
                                    RValue4 = rValues[3].ToString();
                                    if (rValues.Count > 4)
                                    {
                                        IsEnabledRValue5 = true;
                                        RValue5 = rValues[4].ToString();
                                        if (rValues.Count > 5)
                                        {
                                            IsEnabledRValue6 = true;
                                            RValue6 = rValues[5].ToString();
                                            if (rValues.Count > 6)
                                            {
                                                IsEnabledRValue7 = true;
                                                RValue7 = rValues[6].ToString();
                                                if (rValues.Count > 7)
                                                {
                                                    IsEnabledRValue8 = true;
                                                    RValue8 = rValues[7].ToString();
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                if (_currentAiMnemonic.Operands.sValues != null)
                {
                    IList<string> sValues = _currentAiMnemonic.Operands.sValues;
                    if (sValues.Count > 0)
                    {
                        IsEnabledSValue1 = true;
                        SValue1 = sValues[0].ToString();
                        if (sValues.Count > 1)
                        {
                            IsEnabledSValue2 = true;
                            SValue2 = sValues[1].ToString();
                            if (sValues.Count > 2)
                            {
                                IsEnabledSValue3 = true;
                                SValue3 = sValues[2].ToString();
                                if (sValues.Count > 3)
                                {
                                    IsEnabledSValue4 = true;
                                    SValue4 = sValues[3].ToString();
                                    if (sValues.Count > 4)
                                    {
                                        IsEnabledSValue5 = true;
                                        SValue5 = sValues[4].ToString();
                                        if (sValues.Count > 5)
                                        {
                                            IsEnabledSValue6 = true;
                                            SValue6 = sValues[5].ToString();
                                            if (sValues.Count > 6)
                                            {
                                                IsEnabledSValue7 = true;
                                                SValue7 = sValues[6].ToString();
                                                if (sValues.Count > 7)
                                                {
                                                    IsEnabledSValue8 = true;
                                                    SValue8 = sValues[7].ToString();
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            isInitMnemonic = false;
            isChangingEnabled = true;
        }

        #endregion

        private void setIValue(int opVal, int index)
        {
            if (!isInitMnemonic)
            {
                JsonOperands operands = getOperands();

                if (operands != null)
                {
                    if (operands.iValues != null && operands.iValues.Count > index)
                    {
                        isChangingProperty = true;
                        AiScripts[ScriptIndex].Mnemonics[AiScripts[ScriptIndex].Mnemonics.IndexOf(CurrentAiMnemonic)].Operands.iValues[index] = opVal;
                        setSelectedAiScript();
                        isChangingProperty = false;
                    }
                }
            }
        }

        private void setRValue(float opVal, int index)
        {
            if (!isInitMnemonic)
            {
                JsonOperands operands = getOperands();

                if (operands != null)
                {
                    if (operands.rValues != null && operands.rValues.Count > index)
                    {
                        isChangingProperty = true;
                        AiScripts[ScriptIndex].Mnemonics[AiScripts[ScriptIndex].Mnemonics.IndexOf(CurrentAiMnemonic)].Operands.rValues[index] = opVal;
                        setSelectedAiScript();
                        isChangingProperty = false;
                    }
                }
            }
        }

        private void setSValue(string opVal, int index)
        {
            if (!isInitMnemonic)
            {
                JsonOperands operands = getOperands();

                if (operands != null)
                {
                    if (operands.sValues != null && operands.sValues.Count > index)
                    {
                        isChangingProperty = true;
                        AiScripts[ScriptIndex].Mnemonics[AiScripts[ScriptIndex].Mnemonics.IndexOf(CurrentAiMnemonic)].Operands.sValues[index] = opVal;
                        setSelectedAiScript();
                        isChangingProperty = false;
                    }
                }
            }
        }

        private JsonOperands getOperands()
        {
            return AiScripts[ScriptIndex].Mnemonics[AiScripts[ScriptIndex].Mnemonics.IndexOf(CurrentAiMnemonic)].Operands;
        }

        private void initOperands()
        {
            if (AiScripts[ScriptIndex].Mnemonics[AiScripts[ScriptIndex].Mnemonics.IndexOf(CurrentAiMnemonic)].Operands == null)
            {
                AiScripts[ScriptIndex].Mnemonics[AiScripts[ScriptIndex].Mnemonics.IndexOf(CurrentAiMnemonic)].Operands = new JsonOperands();
            }
        }

        private void initIValues()
        {
            AiScripts[ScriptIndex].Mnemonics[AiScripts[ScriptIndex].Mnemonics.IndexOf(CurrentAiMnemonic)].Operands.iValues = new List<int>();
        }

        private void initRValues()
        {
            AiScripts[ScriptIndex].Mnemonics[AiScripts[ScriptIndex].Mnemonics.IndexOf(CurrentAiMnemonic)].Operands.rValues = new List<float>();
        }

        private void initSValues()
        {
            AiScripts[ScriptIndex].Mnemonics[AiScripts[ScriptIndex].Mnemonics.IndexOf(CurrentAiMnemonic)].Operands.sValues = new List<string>();
        }

        private void addIValue(int value)
        {
            AiScripts[ScriptIndex].Mnemonics[AiScripts[ScriptIndex].Mnemonics.IndexOf(CurrentAiMnemonic)].Operands.iValues.Add(value);
        }

        private void addRValue(float value)
        {
            AiScripts[ScriptIndex].Mnemonics[AiScripts[ScriptIndex].Mnemonics.IndexOf(CurrentAiMnemonic)].Operands.rValues.Add(value);
        }

        private void addSValue(string value)
        {
            AiScripts[ScriptIndex].Mnemonics[AiScripts[ScriptIndex].Mnemonics.IndexOf(CurrentAiMnemonic)].Operands.sValues.Add(value);
        }

        private void setSelectedAiScript()
        {
            SelectedAiScript = AiScripts[ScriptIndex];
        }

        private void addStrIValue(string value)
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

        private void addStrRValue(string value)
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

        private void addStrSValue(string value)
        {
                addSValue(value);
        }

        private void setCCommands()
        {
            IValue1ButtonClick = new RelayCommand(ClickIValue1Button);
            IValue2ButtonClick = new RelayCommand(ClickIValue2Button);
            IValue3ButtonClick = new RelayCommand(ClickIValue3Button);
            IValue4ButtonClick = new RelayCommand(ClickIValue4Button);
            IValue5ButtonClick = new RelayCommand(ClickIValue5Button);
            IValue6ButtonClick = new RelayCommand(ClickIValue6Button);
            IValue7ButtonClick = new RelayCommand(ClickIValue7Button);
            IValue8ButtonClick = new RelayCommand(ClickIValue8Button);

            RValue1ButtonClick = new RelayCommand(ClickRValue1Button);
            RValue2ButtonClick = new RelayCommand(ClickRValue2Button);
            RValue3ButtonClick = new RelayCommand(ClickRValue3Button);
            RValue4ButtonClick = new RelayCommand(ClickRValue4Button);
            RValue5ButtonClick = new RelayCommand(ClickRValue5Button);
            RValue6ButtonClick = new RelayCommand(ClickRValue6Button);
            RValue7ButtonClick = new RelayCommand(ClickRValue7Button);
            RValue8ButtonClick = new RelayCommand(ClickRValue8Button);

            SValue1ButtonClick = new RelayCommand(ClickSValue1Button);
            SValue2ButtonClick = new RelayCommand(ClickSValue2Button);
            SValue3ButtonClick = new RelayCommand(ClickSValue3Button);
            SValue4ButtonClick = new RelayCommand(ClickSValue4Button);
            SValue5ButtonClick = new RelayCommand(ClickSValue5Button);
            SValue6ButtonClick = new RelayCommand(ClickSValue6Button);
            SValue7ButtonClick = new RelayCommand(ClickSValue7Button);
            SValue8ButtonClick = new RelayCommand(ClickSValue8Button);
        }

        #region CLICK FUNCTIONS

        private void ClickIValue1Button()
        {
            if (IsEnabledIValue1 == false)
            {
                IsEnabledIValue1 = true;
                initOperands();
                initIValues();
                addIValue(0);
            }
            else
            {
                initIValues();
                IsEnabledIValue1 = false;
                IsEnabledIValue2 = false;
                IsEnabledIValue3 = false;
                IsEnabledIValue4 = false;
                IsEnabledIValue5 = false;
                IsEnabledIValue6 = false;
                IsEnabledIValue7 = false;
                IsEnabledIValue8 = false;
            }
            setSelectedAiScript();
        }

        private void ClickIValue2Button()
        {
            if (IsEnabledIValue2 == false)
            {
                IsEnabledIValue1 = true;
                IsEnabledIValue2 = true;
                initOperands();
                initIValues();
                addStrIValue(IValue1);
                addIValue(0);
            }
            else
            {
                initIValues();
                addStrIValue(IValue1);
                IsEnabledIValue2 = false;
                IsEnabledIValue3 = false;
                IsEnabledIValue4 = false;
                IsEnabledIValue5 = false;
                IsEnabledIValue6 = false;
                IsEnabledIValue7 = false;
                IsEnabledIValue8 = false;
            }
            setSelectedAiScript();
        }

        private void ClickIValue3Button()
        {
            if (IsEnabledIValue3 == false)
            {
                IsEnabledIValue1 = true;
                IsEnabledIValue2 = true;
                IsEnabledIValue3 = true;
                initOperands();
                initIValues();
                addStrIValue(IValue1);
                addStrIValue(IValue2);
                addIValue(0);
            }
            else
            {
                initIValues();
                addStrIValue(IValue1);
                addStrIValue(IValue2);
                IsEnabledIValue3 = false;
                IsEnabledIValue4 = false;
                IsEnabledIValue5 = false;
                IsEnabledIValue6 = false;
                IsEnabledIValue7 = false;
                IsEnabledIValue8 = false;
            }
            setSelectedAiScript();
        }

        private void ClickIValue4Button()
        {
            if (IsEnabledIValue4 == false)
            {
                IsEnabledIValue1 = true;
                IsEnabledIValue2 = true;
                IsEnabledIValue3 = true;
                IsEnabledIValue4 = true;
                initOperands();
                initIValues();
                addStrIValue(IValue1);
                addStrIValue(IValue2);
                addStrIValue(IValue3);
                addIValue(0);
            }
            else
            {
                initIValues();
                addStrIValue(IValue1);
                addStrIValue(IValue2);
                addStrIValue(IValue3);
                IsEnabledIValue4 = false;
                IsEnabledIValue5 = false;
                IsEnabledIValue6 = false;
                IsEnabledIValue7 = false;
                IsEnabledIValue8 = false;
            }
            setSelectedAiScript();
        }

        private void ClickIValue5Button()
        {
            if (IsEnabledIValue5 == false)
            {
                IsEnabledIValue1 = true;
                IsEnabledIValue2 = true;
                IsEnabledIValue3 = true;
                IsEnabledIValue4 = true;
                IsEnabledIValue5 = true;
                initOperands();
                initIValues();
                addStrIValue(IValue1);
                addStrIValue(IValue2);
                addStrIValue(IValue3);
                addStrIValue(IValue4);
                addIValue(0);
            }
            else
            {
                initIValues();
                addStrIValue(IValue1);
                addStrIValue(IValue2);
                addStrIValue(IValue3);
                addStrIValue(IValue4);
                IsEnabledIValue5 = false;
                IsEnabledIValue6 = false;
                IsEnabledIValue7 = false;
                IsEnabledIValue8 = false;
            }
            setSelectedAiScript();
        }

        private void ClickIValue6Button()
        {
            if (IsEnabledIValue6 == false)
            {
                IsEnabledIValue1 = true;
                IsEnabledIValue2 = true;
                IsEnabledIValue3 = true;
                IsEnabledIValue4 = true;
                IsEnabledIValue5 = true;
                IsEnabledIValue6 = true;
                initOperands();
                initIValues();
                addStrIValue(IValue1);
                addStrIValue(IValue2);
                addStrIValue(IValue3);
                addStrIValue(IValue4);
                addStrIValue(IValue5);
                addIValue(0);
            }
            else
            {
                initIValues();
                addStrIValue(IValue1);
                addStrIValue(IValue2);
                addStrIValue(IValue3);
                addStrIValue(IValue4);
                addStrIValue(IValue5);
                IsEnabledIValue6 = false;
                IsEnabledIValue7 = false;
                IsEnabledIValue8 = false;
            }
            setSelectedAiScript();
        }

        private void ClickIValue7Button()
        {
            if (IsEnabledIValue7 == false)
            {
                IsEnabledIValue1 = true;
                IsEnabledIValue2 = true;
                IsEnabledIValue3 = true;
                IsEnabledIValue4 = true;
                IsEnabledIValue5 = true;
                IsEnabledIValue6 = true;
                IsEnabledIValue7 = true;
                initOperands();
                initIValues();
                addStrIValue(IValue1);
                addStrIValue(IValue2);
                addStrIValue(IValue3);
                addStrIValue(IValue4);
                addStrIValue(IValue5);
                addStrIValue(IValue6);
                addIValue(0);
            }
            else
            {
                initIValues();
                addStrIValue(IValue1);
                addStrIValue(IValue2);
                addStrIValue(IValue3);
                addStrIValue(IValue4);
                addStrIValue(IValue5);
                addStrIValue(IValue6);
                IsEnabledIValue7 = false;
                IsEnabledIValue8 = false;
            }
            setSelectedAiScript();
        }

        private void ClickIValue8Button()
        {
            if (IsEnabledIValue8 == false)
            {
                IsEnabledIValue1 = true;
                IsEnabledIValue2 = true;
                IsEnabledIValue3 = true;
                IsEnabledIValue4 = true;
                IsEnabledIValue5 = true;
                IsEnabledIValue6 = true;
                IsEnabledIValue7 = true;
                IsEnabledIValue8 = true;
                initOperands();
                initIValues();
                addStrIValue(IValue1);
                addStrIValue(IValue2);
                addStrIValue(IValue3);
                addStrIValue(IValue4);
                addStrIValue(IValue5);
                addStrIValue(IValue6);
                addStrIValue(IValue7);
                addIValue(0);
            }
            else
            {
                initIValues();
                addStrIValue(IValue1);
                addStrIValue(IValue2);
                addStrIValue(IValue3);
                addStrIValue(IValue4);
                addStrIValue(IValue5);
                addStrIValue(IValue6);
                addStrIValue(IValue7);
                IsEnabledIValue8 = false;
            }
            setSelectedAiScript();
        }

        private void ClickRValue1Button()
        {
            if (IsEnabledRValue1 == false)
            {
                IsEnabledRValue1 = true;
                initOperands();
                initRValues();
                addRValue(0);
            }
            else
            {
                initRValues();
                IsEnabledRValue1 = false;
                IsEnabledRValue2 = false;
                IsEnabledRValue3 = false;
                IsEnabledRValue4 = false;
                IsEnabledRValue5 = false;
                IsEnabledRValue6 = false;
                IsEnabledRValue7 = false;
                IsEnabledRValue8 = false;
            }
            setSelectedAiScript();
        }

        private void ClickRValue2Button()
        {
            if (IsEnabledRValue2 == false)
            {
                IsEnabledRValue1 = true;
                IsEnabledRValue2 = true;
                initOperands();
                initRValues();
                addStrRValue(RValue1);
                addRValue(0);
            }
            else
            {
                initRValues();
                addStrRValue(RValue1);
                IsEnabledRValue2 = false;
                IsEnabledRValue3 = false;
                IsEnabledRValue4 = false;
                IsEnabledRValue5 = false;
                IsEnabledRValue6 = false;
                IsEnabledRValue7 = false;
                IsEnabledRValue8 = false;
            }
            setSelectedAiScript();
        }

        private void ClickRValue3Button()
        {
            if (IsEnabledRValue3 == false)
            {
                IsEnabledRValue1 = true;
                IsEnabledRValue2 = true;
                IsEnabledRValue3 = true;
                initOperands();
                initRValues();
                addStrRValue(RValue1);
                addStrRValue(RValue2);
                addRValue(0);
            }
            else
            {
                initRValues();
                addStrRValue(RValue1);
                addStrRValue(RValue2);
                IsEnabledRValue3 = false;
                IsEnabledRValue4 = false;
                IsEnabledRValue5 = false;
                IsEnabledRValue6 = false;
                IsEnabledRValue7 = false;
                IsEnabledRValue8 = false;
            }
            setSelectedAiScript();
        }

        private void ClickRValue4Button()
        {
            if (IsEnabledRValue4 == false)
            {
                IsEnabledRValue1 = true;
                IsEnabledRValue2 = true;
                IsEnabledRValue3 = true;
                IsEnabledRValue4 = true;
                initOperands();
                initRValues();
                addStrRValue(RValue1);
                addStrRValue(RValue2);
                addStrRValue(RValue3);
                addRValue(0);
            }
            else
            {
                initRValues();
                addStrRValue(RValue1);
                addStrRValue(RValue2);
                addStrRValue(RValue3);
                IsEnabledRValue4 = false;
                IsEnabledRValue5 = false;
                IsEnabledRValue6 = false;
                IsEnabledRValue7 = false;
                IsEnabledRValue8 = false;
            }
            setSelectedAiScript();
        }

        private void ClickRValue5Button()
        {
            if (IsEnabledRValue5 == false)
            {
                IsEnabledRValue1 = true;
                IsEnabledRValue2 = true;
                IsEnabledRValue3 = true;
                IsEnabledRValue4 = true;
                IsEnabledRValue5 = true;
                initOperands();
                initRValues();
                addStrRValue(RValue1);
                addStrRValue(RValue2);
                addStrRValue(RValue3);
                addStrRValue(RValue4);
                addRValue(0);
            }
            else
            {
                initRValues();
                addStrRValue(RValue1);
                addStrRValue(RValue2);
                addStrRValue(RValue3);
                addStrRValue(RValue4);
                IsEnabledRValue5 = false;
                IsEnabledRValue6 = false;
                IsEnabledRValue7 = false;
                IsEnabledRValue8 = false;
            }
            setSelectedAiScript();
        }

        private void ClickRValue6Button()
        {
            if (IsEnabledRValue6 == false)
            {
                IsEnabledRValue1 = true;
                IsEnabledRValue2 = true;
                IsEnabledRValue3 = true;
                IsEnabledRValue4 = true;
                IsEnabledRValue5 = true;
                IsEnabledRValue6 = true;
                initOperands();
                initRValues();
                addStrRValue(RValue1);
                addStrRValue(RValue2);
                addStrRValue(RValue3);
                addStrRValue(RValue4);
                addStrRValue(RValue5);
                addRValue(0);
            }
            else
            {
                initRValues();
                addStrRValue(RValue1);
                addStrRValue(RValue2);
                addStrRValue(RValue3);
                addStrRValue(RValue4);
                addStrRValue(RValue5);
                IsEnabledRValue6 = false;
                IsEnabledRValue7 = false;
                IsEnabledRValue8 = false;
            }
            setSelectedAiScript();
        }

        private void ClickRValue7Button()
        {
            if (IsEnabledRValue7 == false)
            {
                IsEnabledRValue1 = true;
                IsEnabledRValue2 = true;
                IsEnabledRValue3 = true;
                IsEnabledRValue4 = true;
                IsEnabledRValue5 = true;
                IsEnabledRValue6 = true;
                IsEnabledRValue7 = true;
                initOperands();
                initRValues();
                addStrRValue(RValue1);
                addStrRValue(RValue2);
                addStrRValue(RValue3);
                addStrRValue(RValue4);
                addStrRValue(RValue5);
                addStrRValue(RValue6);
                addRValue(0);
            }
            else
            {
                initRValues();
                addStrRValue(RValue1);
                addStrRValue(RValue2);
                addStrRValue(RValue3);
                addStrRValue(RValue4);
                addStrRValue(RValue5);
                addStrRValue(RValue6);
                IsEnabledRValue7 = false;
                IsEnabledRValue8 = false;
            }
            setSelectedAiScript();
        }

        private void ClickRValue8Button()
        {
            if (IsEnabledRValue8 == false)
            {
                IsEnabledRValue1 = true;
                IsEnabledRValue2 = true;
                IsEnabledRValue3 = true;
                IsEnabledRValue4 = true;
                IsEnabledRValue5 = true;
                IsEnabledRValue6 = true;
                IsEnabledRValue7 = true;
                IsEnabledRValue8 = true;
                initOperands();
                initRValues();
                addStrRValue(RValue1);
                addStrRValue(RValue2);
                addStrRValue(RValue3);
                addStrRValue(RValue4);
                addStrRValue(RValue5);
                addStrRValue(RValue6);
                addStrRValue(RValue7);
                addRValue(0);
            }
            else
            {
                initRValues();
                addStrRValue(RValue1);
                addStrRValue(RValue2);
                addStrRValue(RValue3);
                addStrRValue(RValue4);
                addStrRValue(RValue5);
                addStrRValue(RValue6);
                addStrRValue(RValue7);
                IsEnabledRValue8 = false;
            }
            setSelectedAiScript();
        }

        private void ClickSValue1Button()
        {
            if (IsEnabledSValue1 == false)
            {
                IsEnabledSValue1 = true;
                initOperands();
                initSValues();
                addSValue(string.Empty);
            }
            else
            {
                initSValues();
                IsEnabledSValue1 = false;
                IsEnabledSValue2 = false;
                IsEnabledSValue3 = false;
                IsEnabledSValue4 = false;
                IsEnabledSValue5 = false;
                IsEnabledSValue6 = false;
                IsEnabledSValue7 = false;
                IsEnabledSValue8 = false;
            }
            setSelectedAiScript();
        }

        private void ClickSValue2Button()
        {
            if (IsEnabledSValue2 == false)
            {
                IsEnabledSValue1 = true;
                IsEnabledSValue2 = true;
                initOperands();
                initSValues();
                addStrSValue(SValue1);
                addSValue(string.Empty);
            }
            else
            {
                initSValues();
                addStrSValue(SValue1);
                IsEnabledSValue2 = false;
                IsEnabledSValue3 = false;
                IsEnabledSValue4 = false;
                IsEnabledSValue5 = false;
                IsEnabledSValue6 = false;
                IsEnabledSValue7 = false;
                IsEnabledSValue8 = false;
            }
            setSelectedAiScript();
        }

        private void ClickSValue3Button()
        {
            if (IsEnabledSValue3 == false)
            {
                IsEnabledSValue1 = true;
                IsEnabledSValue2 = true;
                IsEnabledSValue3 = true;
                initOperands();
                initSValues();
                addStrSValue(SValue1);
                addStrSValue(SValue2);
                addSValue(string.Empty);
            }
            else
            {
                initSValues();
                addStrSValue(SValue1);
                addStrSValue(SValue2);
                IsEnabledSValue3 = false;
                IsEnabledSValue4 = false;
                IsEnabledSValue5 = false;
                IsEnabledSValue6 = false;
                IsEnabledSValue7 = false;
                IsEnabledSValue8 = false;
            }
            setSelectedAiScript();
        }

        private void ClickSValue4Button()
        {
            if (IsEnabledSValue4 == false)
            {
                IsEnabledSValue1 = true;
                IsEnabledSValue2 = true;
                IsEnabledSValue3 = true;
                IsEnabledSValue4 = true;
                initOperands();
                initSValues();
                addStrSValue(SValue1);
                addStrSValue(SValue2);
                addStrSValue(SValue3);
                addSValue(string.Empty);
            }
            else
            {
                initSValues();
                addStrSValue(SValue1);
                addStrSValue(SValue2);
                addStrSValue(SValue3);
                IsEnabledSValue4 = false;
                IsEnabledSValue5 = false;
                IsEnabledSValue6 = false;
                IsEnabledSValue7 = false;
                IsEnabledSValue8 = false;
            }
            setSelectedAiScript();
        }

        private void ClickSValue5Button()
        {
            if (IsEnabledSValue5 == false)
            {
                IsEnabledSValue1 = true;
                IsEnabledSValue2 = true;
                IsEnabledSValue3 = true;
                IsEnabledSValue4 = true;
                IsEnabledSValue5 = true;
                initOperands();
                initSValues();
                addStrSValue(SValue1);
                addStrSValue(SValue2);
                addStrSValue(SValue3);
                addStrSValue(SValue4);
                addSValue(string.Empty);
            }
            else
            {
                initSValues();
                addStrSValue(SValue1);
                addStrSValue(SValue2);
                addStrSValue(SValue3);
                addStrSValue(SValue4);
                IsEnabledSValue5 = false;
                IsEnabledSValue6 = false;
                IsEnabledSValue7 = false;
                IsEnabledSValue8 = false;
            }
            setSelectedAiScript();
        }

        private void ClickSValue6Button()
        {
            if (IsEnabledSValue6 == false)
            {
                IsEnabledSValue1 = true;
                IsEnabledSValue2 = true;
                IsEnabledSValue3 = true;
                IsEnabledSValue4 = true;
                IsEnabledSValue5 = true;
                IsEnabledSValue6 = true;
                initOperands();
                initSValues();
                addStrSValue(SValue1);
                addStrSValue(SValue2);
                addStrSValue(SValue3);
                addStrSValue(SValue4);
                addStrSValue(SValue5);
                addSValue(string.Empty);
            }
            else
            {
                initSValues();
                addStrSValue(SValue1);
                addStrSValue(SValue2);
                addStrSValue(SValue3);
                addStrSValue(SValue4);
                addStrSValue(SValue5);
                IsEnabledSValue6 = false;
                IsEnabledSValue7 = false;
                IsEnabledSValue8 = false;
            }
            setSelectedAiScript();
        }

        private void ClickSValue7Button()
        {
            if (IsEnabledSValue7 == false)
            {
                IsEnabledSValue1 = true;
                IsEnabledSValue2 = true;
                IsEnabledSValue3 = true;
                IsEnabledSValue4 = true;
                IsEnabledSValue5 = true;
                IsEnabledSValue6 = true;
                IsEnabledSValue7 = true;
                initOperands();
                initSValues();
                addStrSValue(SValue1);
                addStrSValue(SValue2);
                addStrSValue(SValue3);
                addStrSValue(SValue4);
                addStrSValue(SValue5);
                addStrSValue(SValue6);
                addSValue(string.Empty);
            }
            else
            {
                initSValues();
                addStrSValue(SValue1);
                addStrSValue(SValue2);
                addStrSValue(SValue3);
                addStrSValue(SValue4);
                addStrSValue(SValue5);
                addStrSValue(SValue6);
                IsEnabledSValue7 = false;
                IsEnabledSValue8 = false;
            }
            setSelectedAiScript();
        }

        private void ClickSValue8Button()
        {
            if (IsEnabledSValue8 == false)
            {
                IsEnabledSValue1 = true;
                IsEnabledSValue2 = true;
                IsEnabledSValue3 = true;
                IsEnabledSValue4 = true;
                IsEnabledSValue5 = true;
                IsEnabledSValue6 = true;
                IsEnabledSValue7 = true;
                IsEnabledSValue8 = true;
                initOperands();
                initSValues();
                addStrSValue(SValue1);
                addStrSValue(SValue2);
                addStrSValue(SValue3);
                addStrSValue(SValue4);
                addStrSValue(SValue5);
                addStrSValue(SValue6);
                addStrSValue(SValue7);
                addSValue(string.Empty);
            }
            else
            {
                initSValues();
                addStrSValue(SValue1);
                addStrSValue(SValue2);
                addStrSValue(SValue3);
                addStrSValue(SValue4);
                addStrSValue(SValue5);
                addStrSValue(SValue6);
                addStrSValue(SValue7);
                IsEnabledSValue8 = false;
            }
            setSelectedAiScript();
        }

        #endregion

        #region OPERANDS

        private string _iValue1;
        public string IValue1
        {
            get { return _iValue1; }
            set
            {
                OnPropertyChanged(ref _iValue1, value);

                int opVal;
                if (int.TryParse(value, out opVal))
                {
                    setIValue(opVal, 0);
                }
            }
        }

        private string _iValue2;
        public string IValue2
        {
            get { return _iValue2; }
            set
            {
                OnPropertyChanged(ref _iValue2, value);

                int opVal;
                if (int.TryParse(value, out opVal))
                {
                    setIValue(opVal, 1);
                }
            }
        }

        private string _iValue3;
        public string IValue3
        {
            get { return _iValue3; }
            set
            {
                OnPropertyChanged(ref _iValue3, value);

                int opVal;
                if (int.TryParse(value, out opVal))
                {
                    setIValue(opVal, 2);
                }
            }
        }

        private string _iValue4;
        public string IValue4
        {
            get { return _iValue4; }
            set
            {
                OnPropertyChanged(ref _iValue4, value);

                int opVal;
                if (int.TryParse(value, out opVal))
                {
                    setIValue(opVal, 3);
                }
            }
        }

        private string _iValue5;
        public string IValue5
        {
            get { return _iValue5; }
            set
            {
                OnPropertyChanged(ref _iValue5, value);

                int opVal;
                if (int.TryParse(value, out opVal))
                {
                    setIValue(opVal, 4);
                }
            }
        }

        private string _iValue6;
        public string IValue6
        {
            get { return _iValue6; }
            set
            {
                OnPropertyChanged(ref _iValue6, value);

                int opVal;
                if (int.TryParse(value, out opVal))
                {
                    setIValue(opVal, 5);
                }
            }
        }

        private string _iValue7;
        public string IValue7
        {
            get { return _iValue7; }
            set
            {
                OnPropertyChanged(ref _iValue7, value);

                int opVal;
                if (int.TryParse(value, out opVal))
                {
                    setIValue(opVal, 6);
                }
            }
        }

        private string _iValue8;
        public string IValue8
        {
            get { return _iValue8; }
            set
            {
                OnPropertyChanged(ref _iValue8, value);

                int opVal;
                if (int.TryParse(value, out opVal))
                {
                    setIValue(opVal, 7);
                }
            }
        }

        private string _rValue1;
        public string RValue1
        {
            get { return _rValue1; }
            set
            {
                OnPropertyChanged(ref _rValue1, value);

                float opVal;
                if (float.TryParse(value, out opVal))
                {
                    setRValue(opVal, 0);
                }
            }
        }

        private string _rValue2;
        public string RValue2
        {
            get { return _rValue2; }
            set
            {
                OnPropertyChanged(ref _rValue2, value);

                float opVal;
                if (float.TryParse(value, out opVal))
                {
                    setRValue(opVal, 1);
                }
            }
        }

        private string _rValue3;
        public string RValue3
        {
            get { return _rValue3; }
            set
            {
                OnPropertyChanged(ref _rValue3, value);

                float opVal;
                if (float.TryParse(value, out opVal))
                {
                    setRValue(opVal, 2);
                }
            }
        }

        private string _rValue4;
        public string RValue4
        {
            get { return _rValue4; }
            set
            {
                OnPropertyChanged(ref _rValue4, value);

                float opVal;
                if (float.TryParse(value, out opVal))
                {
                    setRValue(opVal, 3);
                }
            }
        }

        private string _rValue5;
        public string RValue5
        {
            get { return _rValue5; }
            set
            {
                OnPropertyChanged(ref _rValue5, value);

                float opVal;
                if (float.TryParse(value, out opVal))
                {
                    setRValue(opVal, 4);
                }
            }
        }

        private string _rValue6;
        public string RValue6
        {
            get { return _rValue6; }
            set
            {
                OnPropertyChanged(ref _rValue6, value);

                float opVal;
                if (float.TryParse(value, out opVal))
                {
                    setRValue(opVal, 5);
                }
            }
        }

        private string _rValue7;
        public string RValue7
        {
            get { return _rValue7; }
            set
            {
                OnPropertyChanged(ref _rValue7, value);

                float opVal;
                if (float.TryParse(value, out opVal))
                {
                    setRValue(opVal, 6);
                }
            }
        }

        private string _rValue8;
        public string RValue8
        {
            get { return _rValue8; }
            set
            {
                OnPropertyChanged(ref _rValue8, value);

                float opVal;
                if (float.TryParse(value, out opVal))
                {
                    setRValue(opVal, 7);
                }
            }
        }

        private string _sValue1;
        public string SValue1
        {
            get { return _sValue1; }
            set
            {
                OnPropertyChanged(ref _sValue1, value);
                setSValue(_sValue1, 0);
            }
        }

        private string _sValue2;
        public string SValue2
        {
            get { return _sValue2; }
            set
            {
                OnPropertyChanged(ref _sValue2, value);
                setSValue(_sValue2, 1);
            }
        }

        private string _sValue3;
        public string SValue3
        {
            get { return _sValue3; }
            set
            {
                OnPropertyChanged(ref _sValue3, value);
                setSValue(_sValue3, 2);
            }
        }

        private string _sValue4;
        public string SValue4
        {
            get { return _sValue4; }
            set
            {
                OnPropertyChanged(ref _sValue4, value);
                setSValue(_sValue4, 3);
            }
        }

        private string _sValue5;
        public string SValue5
        {
            get { return _sValue5; }
            set
            {
                OnPropertyChanged(ref _sValue5, value);
                setSValue(_sValue5, 4);
            }
        }

        private string _sValue6;
        public string SValue6
        {
            get { return _sValue6; }
            set
            {
                OnPropertyChanged(ref _sValue6, value);
                setSValue(_sValue6, 5);
            }
        }

        private string _sValue7;
        public string SValue7
        {
            get { return _sValue7; }
            set
            {
                OnPropertyChanged(ref _sValue7, value);
                setSValue(_sValue7, 6);
            }
        }

        private string _sValue8;
        public string SValue8
        {
            get { return _sValue8; }
            set
            {
                OnPropertyChanged(ref _sValue8, value);
                setSValue(_sValue8, 7);
            }
        }

        private bool _isEnabledIValue1;
        public bool IsEnabledIValue1
        {
            get { return _isEnabledIValue1; }
            set
            {
                OnPropertyChanged(ref _isEnabledIValue1, value);

                if (_isEnabledIValue1 == false)
                {
                    IValue1ButtonImage = redButtonImage;
                }
                else
                {
                    IValue1ButtonImage = greenButtonImage;
                }
            }
        }

        private bool _isEnabledIValue2;
        public bool IsEnabledIValue2
        {
            get { return _isEnabledIValue2; }
            set
            {
                OnPropertyChanged(ref _isEnabledIValue2, value);

                if (_isEnabledIValue2 == false)
                {
                    IValue2ButtonImage = redButtonImage;
                }
                else
                {
                    IValue2ButtonImage = greenButtonImage;
                }
            }
        }

        private bool _isEnabledIValue3;
        public bool IsEnabledIValue3
        {
            get { return _isEnabledIValue3; }
            set
            {
                OnPropertyChanged(ref _isEnabledIValue3, value);

                if (_isEnabledIValue3 == false)
                {
                    IValue3ButtonImage = redButtonImage;
                }
                else
                {
                    IValue3ButtonImage = greenButtonImage;
                }
            }
        }

        private bool _isEnabledIValue4;
        public bool IsEnabledIValue4
        {
            get { return _isEnabledIValue4; }
            set
            {
                OnPropertyChanged(ref _isEnabledIValue4, value);

                if (_isEnabledIValue4 == false)
                {
                    IValue4ButtonImage = redButtonImage;
                }
                else
                {
                    IValue4ButtonImage = greenButtonImage;
                }
            }
        }

        private bool _isEnabledIValue5;
        public bool IsEnabledIValue5
        {
            get { return _isEnabledIValue5; }
            set
            {
                OnPropertyChanged(ref _isEnabledIValue5, value);

                if (_isEnabledIValue5 == false)
                {
                    IValue5ButtonImage = redButtonImage;
                }
                else
                {
                    IValue5ButtonImage = greenButtonImage;
                }
            }
        }

        private bool _isEnabledIValue6;
        public bool IsEnabledIValue6
        {
            get { return _isEnabledIValue6; }
            set
            {
                OnPropertyChanged(ref _isEnabledIValue6, value);

                if (_isEnabledIValue6 == false)
                {
                    IValue6ButtonImage = redButtonImage;
                }
                else
                {
                    IValue6ButtonImage = greenButtonImage;
                }
            }
        }

        private bool _isEnabledIValue7;
        public bool IsEnabledIValue7
        {
            get { return _isEnabledIValue7; }
            set
            {
                OnPropertyChanged(ref _isEnabledIValue7, value);

                if (_isEnabledIValue7 == false)
                {
                    IValue7ButtonImage = redButtonImage;
                }
                else
                {
                    IValue7ButtonImage = greenButtonImage;
                }
            }
        }

        private bool _isEnabledIValue8;
        public bool IsEnabledIValue8
        {
            get { return _isEnabledIValue8; }
            set
            {
                OnPropertyChanged(ref _isEnabledIValue8, value);

                if (_isEnabledIValue8 == false)
                {
                    IValue8ButtonImage = redButtonImage;
                }
                else
                {
                    IValue8ButtonImage = greenButtonImage;
                }
            }
        }

        private bool _isEnabledRValue1;
        public bool IsEnabledRValue1
        {
            get { return _isEnabledRValue1; }
            set
            {
                OnPropertyChanged(ref _isEnabledRValue1, value);

                if (_isEnabledRValue1 == false)
                {
                    RValue1ButtonImage = redButtonImage;
                }
                else
                {
                    RValue1ButtonImage = greenButtonImage;
                }
            }
        }

        private bool _isEnabledRValue2;
        public bool IsEnabledRValue2
        {
            get { return _isEnabledRValue2; }
            set
            {
                OnPropertyChanged(ref _isEnabledRValue2, value);

                if (_isEnabledRValue2 == false)
                {
                    RValue2ButtonImage = redButtonImage;
                }
                else
                {
                    RValue2ButtonImage = greenButtonImage;
                }
            }
        }

        private bool _isEnabledRValue3;
        public bool IsEnabledRValue3
        {
            get { return _isEnabledRValue3; }
            set
            {
                OnPropertyChanged(ref _isEnabledRValue3, value);

                if (_isEnabledRValue3 == false)
                {
                    RValue3ButtonImage = redButtonImage;
                }
                else
                {
                    RValue3ButtonImage = greenButtonImage;
                }
            }
        }

        private bool _isEnabledRValue4;
        public bool IsEnabledRValue4
        {
            get { return _isEnabledRValue4; }
            set
            {
                OnPropertyChanged(ref _isEnabledRValue4, value);

                if (_isEnabledRValue4 == false)
                {
                    RValue4ButtonImage = redButtonImage;
                }
                else
                {
                    RValue4ButtonImage = greenButtonImage;
                }
            }
        }

        private bool _isEnabledRValue5;
        public bool IsEnabledRValue5
        {
            get { return _isEnabledRValue5; }
            set
            {
                OnPropertyChanged(ref _isEnabledRValue5, value);

                if (_isEnabledRValue5 == false)
                {
                    RValue5ButtonImage = redButtonImage;
                }
                else
                {
                    RValue5ButtonImage = greenButtonImage;
                }
            }
        }

        private bool _isEnabledRValue6;
        public bool IsEnabledRValue6
        {
            get { return _isEnabledRValue6; }
            set
            {
                OnPropertyChanged(ref _isEnabledRValue6, value);

                if (_isEnabledRValue6 == false)
                {
                    RValue6ButtonImage = redButtonImage;
                }
                else
                {
                    RValue6ButtonImage = greenButtonImage;
                }
            }
        }

        private bool _isEnabledRValue7;
        public bool IsEnabledRValue7
        {
            get { return _isEnabledRValue7; }
            set
            {
                OnPropertyChanged(ref _isEnabledRValue7, value);

                if (_isEnabledRValue7 == false)
                {
                    RValue7ButtonImage = redButtonImage;
                }
                else
                {
                    RValue7ButtonImage = greenButtonImage;
                }
            }
        }

        private bool _isEnabledRValue8;
        public bool IsEnabledRValue8
        {
            get { return _isEnabledRValue8; }
            set
            {
                OnPropertyChanged(ref _isEnabledRValue8, value);

                if (_isEnabledRValue8 == false)
                {
                    RValue8ButtonImage = redButtonImage;
                }
                else
                {
                    RValue8ButtonImage = greenButtonImage;
                }
            }
        }

        private bool _isEnabledSValue1;
        public bool IsEnabledSValue1
        {
            get { return _isEnabledSValue1; }
            set
            {
                OnPropertyChanged(ref _isEnabledSValue1, value);

                if (_isEnabledSValue1 == false)
                {
                    SValue1ButtonImage = redButtonImage;
                }
                else
                {
                    SValue1ButtonImage = greenButtonImage;
                }
            }
        }

        private bool _isEnabledSValue2;
        public bool IsEnabledSValue2
        {
            get { return _isEnabledSValue2; }
            set
            {
                OnPropertyChanged(ref _isEnabledSValue2, value);

                if (_isEnabledSValue2 == false)
                {
                    SValue2ButtonImage = redButtonImage;
                }
                else
                {
                    SValue2ButtonImage = greenButtonImage;
                }
            }
        }

        private bool _isEnabledSValue3;
        public bool IsEnabledSValue3
        {
            get { return _isEnabledSValue3; }
            set
            {
                OnPropertyChanged(ref _isEnabledSValue3, value);

                if (_isEnabledSValue3 == false)
                {
                    SValue3ButtonImage = redButtonImage;
                }
                else
                {
                    SValue3ButtonImage = greenButtonImage;
                }
            }
        }

        private bool _isEnabledSValue4;
        public bool IsEnabledSValue4
        {
            get { return _isEnabledSValue4; }
            set
            {
                OnPropertyChanged(ref _isEnabledSValue4, value);

                if (_isEnabledSValue4 == false)
                {
                    SValue4ButtonImage = redButtonImage;
                }
                else
                {
                    SValue4ButtonImage = greenButtonImage;
                }
            }
        }

        private bool _isEnabledSValue5;
        public bool IsEnabledSValue5
        {
            get { return _isEnabledSValue5; }
            set
            {
                OnPropertyChanged(ref _isEnabledSValue5, value);

                if (_isEnabledSValue5 == false)
                {
                    SValue5ButtonImage = redButtonImage;
                }
                else
                {
                    SValue5ButtonImage = greenButtonImage;
                }
            }
        }

        private bool _isEnabledSValue6;
        public bool IsEnabledSValue6
        {
            get { return _isEnabledSValue6; }
            set
            {
                OnPropertyChanged(ref _isEnabledSValue6, value);

                if (_isEnabledSValue6 == false)
                {
                    SValue6ButtonImage = redButtonImage;
                }
                else
                {
                    SValue6ButtonImage = greenButtonImage;
                }
            }
        }

        private bool _isEnabledSValue7;
        public bool IsEnabledSValue7
        {
            get { return _isEnabledSValue7; }
            set
            {
                OnPropertyChanged(ref _isEnabledSValue7, value);

                if (_isEnabledSValue7 == false)
                {
                    SValue7ButtonImage = redButtonImage;
                }
                else
                {
                    SValue7ButtonImage = greenButtonImage;
                }
            }
        }

        private bool _isEnabledSValue8;
        public bool IsEnabledSValue8
        {
            get { return _isEnabledSValue8; }
            set
            {
                OnPropertyChanged(ref _isEnabledSValue8, value);

                if (_isEnabledSValue8 == false)
                {
                    SValue8ButtonImage = redButtonImage;
                }
                else
                {
                    SValue8ButtonImage = greenButtonImage;
                }
            }
        }

        private ICommand _iValue1ButtonClick;
        public ICommand IValue1ButtonClick
        {
            get { return _iValue1ButtonClick; }
            set { OnPropertyChanged(ref _iValue1ButtonClick, value); }
        }

        private ICommand _iValue2ButtonClick;
        public ICommand IValue2ButtonClick
        {
            get { return _iValue2ButtonClick; }
            set { OnPropertyChanged(ref _iValue2ButtonClick, value); }
        }

        private ICommand _iValue3ButtonClick;
        public ICommand IValue3ButtonClick
        {
            get { return _iValue3ButtonClick; }
            set { OnPropertyChanged(ref _iValue3ButtonClick, value); }
        }

        private ICommand _iValue4ButtonClick;
        public ICommand IValue4ButtonClick
        {
            get { return _iValue4ButtonClick; }
            set { OnPropertyChanged(ref _iValue4ButtonClick, value); }
        }

        private ICommand _iValue5ButtonClick;
        public ICommand IValue5ButtonClick
        {
            get { return _iValue5ButtonClick; }
            set { OnPropertyChanged(ref _iValue5ButtonClick, value); }
        }

        private ICommand _iValue6ButtonClick;
        public ICommand IValue6ButtonClick
        {
            get { return _iValue6ButtonClick; }
            set { OnPropertyChanged(ref _iValue6ButtonClick, value); }
        }

        private ICommand _iValue7ButtonClick;
        public ICommand IValue7ButtonClick
        {
            get { return _iValue7ButtonClick; }
            set { OnPropertyChanged(ref _iValue7ButtonClick, value); }
        }

        private ICommand _iValue8ButtonClick;
        public ICommand IValue8ButtonClick
        {
            get { return _iValue8ButtonClick; }
            set { OnPropertyChanged(ref _iValue8ButtonClick, value); }
        }

        private ICommand _rValue1ButtonClick;
        public ICommand RValue1ButtonClick
        {
            get { return _rValue1ButtonClick; }
            set { OnPropertyChanged(ref _rValue1ButtonClick, value); }
        }

        private ICommand _rValue2ButtonClick;
        public ICommand RValue2ButtonClick
        {
            get { return _rValue2ButtonClick; }
            set { OnPropertyChanged(ref _rValue2ButtonClick, value); }
        }

        private ICommand _rValue3ButtonClick;
        public ICommand RValue3ButtonClick
        {
            get { return _rValue3ButtonClick; }
            set { OnPropertyChanged(ref _rValue3ButtonClick, value); }
        }

        private ICommand _rValue4ButtonClick;
        public ICommand RValue4ButtonClick
        {
            get { return _rValue4ButtonClick; }
            set { OnPropertyChanged(ref _rValue4ButtonClick, value); }
        }

        private ICommand _rValue5ButtonClick;
        public ICommand RValue5ButtonClick
        {
            get { return _rValue5ButtonClick; }
            set { OnPropertyChanged(ref _rValue5ButtonClick, value); }
        }

        private ICommand _rValue6ButtonClick;
        public ICommand RValue6ButtonClick
        {
            get { return _rValue6ButtonClick; }
            set { OnPropertyChanged(ref _rValue6ButtonClick, value); }
        }

        private ICommand _rValue7ButtonClick;
        public ICommand RValue7ButtonClick
        {
            get { return _rValue7ButtonClick; }
            set { OnPropertyChanged(ref _rValue7ButtonClick, value); }
        }

        private ICommand _rValue8ButtonClick;
        public ICommand RValue8ButtonClick
        {
            get { return _rValue8ButtonClick; }
            set { OnPropertyChanged(ref _rValue8ButtonClick, value); }
        }

        private ICommand _sValue1ButtonClick;
        public ICommand SValue1ButtonClick
        {
            get { return _sValue1ButtonClick; }
            set { OnPropertyChanged(ref _sValue1ButtonClick, value); }
        }

        private ICommand _sValue2ButtonClick;
        public ICommand SValue2ButtonClick
        {
            get { return _sValue2ButtonClick; }
            set { OnPropertyChanged(ref _sValue2ButtonClick, value); }
        }

        private ICommand _sValue3ButtonClick;
        public ICommand SValue3ButtonClick
        {
            get { return _sValue3ButtonClick; }
            set { OnPropertyChanged(ref _sValue3ButtonClick, value); }
        }

        private ICommand _sValue4ButtonClick;
        public ICommand SValue4ButtonClick
        {
            get { return _sValue4ButtonClick; }
            set { OnPropertyChanged(ref _sValue4ButtonClick, value); }
        }

        private ICommand _sValue5ButtonClick;
        public ICommand SValue5ButtonClick
        {
            get { return _sValue5ButtonClick; }
            set { OnPropertyChanged(ref _sValue5ButtonClick, value); }
        }

        private ICommand _sValue6ButtonClick;
        public ICommand SValue6ButtonClick
        {
            get { return _sValue6ButtonClick; }
            set { OnPropertyChanged(ref _sValue6ButtonClick, value); }
        }

        private ICommand _sValue7ButtonClick;
        public ICommand SValue7ButtonClick
        {
            get { return _sValue7ButtonClick; }
            set { OnPropertyChanged(ref _sValue7ButtonClick, value); }
        }

        private ICommand _sValue8ButtonClick;
        public ICommand SValue8ButtonClick
        {
            get { return _sValue8ButtonClick; }
            set { OnPropertyChanged(ref _sValue8ButtonClick, value); }
        }

        private ImageSource _iValue1ButtonImage;
        public ImageSource IValue1ButtonImage
        {
            get { return _iValue1ButtonImage; }
            set { OnPropertyChanged(ref _iValue1ButtonImage, value); }
        }

        private ImageSource _iValue2ButtonImage;
        public ImageSource IValue2ButtonImage
        {
            get { return _iValue2ButtonImage; }
            set { OnPropertyChanged(ref _iValue2ButtonImage, value); }
        }

        private ImageSource _iValue3ButtonImage;
        public ImageSource IValue3ButtonImage
        {
            get { return _iValue3ButtonImage; }
            set { OnPropertyChanged(ref _iValue3ButtonImage, value); }
        }

        private ImageSource _iValue4ButtonImage;
        public ImageSource IValue4ButtonImage
        {
            get { return _iValue4ButtonImage; }
            set { OnPropertyChanged(ref _iValue4ButtonImage, value); }
        }

        private ImageSource _iValue5ButtonImage;
        public ImageSource IValue5ButtonImage
        {
            get { return _iValue5ButtonImage; }
            set { OnPropertyChanged(ref _iValue5ButtonImage, value); }
        }

        private ImageSource _iValue6ButtonImage;
        public ImageSource IValue6ButtonImage
        {
            get { return _iValue6ButtonImage; }
            set { OnPropertyChanged(ref _iValue6ButtonImage, value); }
        }

        private ImageSource _iValue7ButtonImage;
        public ImageSource IValue7ButtonImage
        {
            get { return _iValue7ButtonImage; }
            set { OnPropertyChanged(ref _iValue7ButtonImage, value); }
        }

        private ImageSource _iValue8ButtonImage;
        public ImageSource IValue8ButtonImage
        {
            get { return _iValue8ButtonImage; }
            set { OnPropertyChanged(ref _iValue8ButtonImage, value); }
        }

        private ImageSource _rValue1ButtonImage;
        public ImageSource RValue1ButtonImage
        {
            get { return _rValue1ButtonImage; }
            set { OnPropertyChanged(ref _rValue1ButtonImage, value); }
        }

        private ImageSource _rValue2ButtonImage;
        public ImageSource RValue2ButtonImage
        {
            get { return _rValue2ButtonImage; }
            set { OnPropertyChanged(ref _rValue2ButtonImage, value); }
        }

        private ImageSource _rValue3ButtonImage;
        public ImageSource RValue3ButtonImage
        {
            get { return _rValue3ButtonImage; }
            set { OnPropertyChanged(ref _rValue3ButtonImage, value); }
        }

        private ImageSource _rValue4ButtonImage;
        public ImageSource RValue4ButtonImage
        {
            get { return _rValue4ButtonImage; }
            set { OnPropertyChanged(ref _rValue4ButtonImage, value); }
        }

        private ImageSource _rValue5ButtonImage;
        public ImageSource RValue5ButtonImage
        {
            get { return _rValue5ButtonImage; }
            set { OnPropertyChanged(ref _rValue5ButtonImage, value); }
        }

        private ImageSource _rValue6ButtonImage;
        public ImageSource RValue6ButtonImage
        {
            get { return _rValue6ButtonImage; }
            set { OnPropertyChanged(ref _rValue6ButtonImage, value); }
        }

        private ImageSource _rValue7ButtonImage;
        public ImageSource RValue7ButtonImage
        {
            get { return _rValue7ButtonImage; }
            set { OnPropertyChanged(ref _rValue7ButtonImage, value); }
        }

        private ImageSource _rValue8ButtonImage;
        public ImageSource RValue8ButtonImage
        {
            get { return _rValue8ButtonImage; }
            set { OnPropertyChanged(ref _rValue8ButtonImage, value); }
        }

        private ImageSource _sValue1ButtonImage;
        public ImageSource SValue1ButtonImage
        {
            get { return _sValue1ButtonImage; }
            set { OnPropertyChanged(ref _sValue1ButtonImage, value); }
        }

        private ImageSource _sValue2ButtonImage;
        public ImageSource SValue2ButtonImage
        {
            get { return _sValue2ButtonImage; }
            set { OnPropertyChanged(ref _sValue2ButtonImage, value); }
        }

        private ImageSource _sValue3ButtonImage;
        public ImageSource SValue3ButtonImage
        {
            get { return _sValue3ButtonImage; }
            set { OnPropertyChanged(ref _sValue3ButtonImage, value); }
        }

        private ImageSource _sValue4ButtonImage;
        public ImageSource SValue4ButtonImage
        {
            get { return _sValue4ButtonImage; }
            set { OnPropertyChanged(ref _sValue4ButtonImage, value); }
        }

        private ImageSource _sValue5ButtonImage;
        public ImageSource SValue5ButtonImage
        {
            get { return _sValue5ButtonImage; }
            set { OnPropertyChanged(ref _sValue5ButtonImage, value); }
        }

        private ImageSource _sValue6ButtonImage;
        public ImageSource SValue6ButtonImage
        {
            get { return _sValue6ButtonImage; }
            set { OnPropertyChanged(ref _sValue6ButtonImage, value); }
        }

        private ImageSource _sValue7ButtonImage;
        public ImageSource SValue7ButtonImage
        {
            get { return _sValue7ButtonImage; }
            set { OnPropertyChanged(ref _sValue7ButtonImage, value); }
        }

        private ImageSource _sValue8ButtonImage;
        public ImageSource SValue8ButtonImage
        {
            get { return _sValue8ButtonImage; }
            set { OnPropertyChanged(ref _sValue8ButtonImage, value); }
        }

        #endregion
    }
}
