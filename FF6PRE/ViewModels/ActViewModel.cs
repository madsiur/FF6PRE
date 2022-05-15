using FF6PRE.Models;
using FF6PRE.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace FF6PRE.ViewModels
{
    public class ActViewModel : ObservableObject
    {
        #region VIEWMODEL ELEMENTS

        private AiEditorViewModel _aAiEditorVM;
        public AiEditorViewModel AiEditorVM
        {
            get { return _aAiEditorVM; }
            set { OnPropertyChanged(ref _aAiEditorVM, value); }
        }

        #endregion

        #region INIT

        public bool IsButtonPressed = false;

        public ActViewModel(AiEditorViewModel aiEditorVM)
        {
            AiEditorVM = aiEditorVM;
            setCommands();
            initDescriptionsLists();
        }

        private void setCommands()
        {
            ActValue1ButtonClick = new RelayCommand(ClickActValue1Button);
            ActValue2ButtonClick = new RelayCommand(ClickActValue2Button);
            ActValue3ButtonClick = new RelayCommand(ClickActValue3Button);
            ActValue4ButtonClick = new RelayCommand(ClickActValue4Button);
            ActValue5ButtonClick = new RelayCommand(ClickActValue5Button);
            ActValue6ButtonClick = new RelayCommand(ClickActValue6Button);
            ActValue7ButtonClick = new RelayCommand(ClickActValue7Button);
            ActValue8ButtonClick = new RelayCommand(ClickActValue8Button);
        }

        private void initDescriptionsLists()
        {
            ActDescriptions1 = GetDescriptions();
            ActDescriptions2 = GetDescriptions();
            ActDescriptions3 = GetDescriptions();
            ActDescriptions4 = GetDescriptions();
            ActDescriptions5 = GetDescriptions();
            ActDescriptions6 = GetDescriptions();
            ActDescriptions7 = GetDescriptions();
            ActDescriptions8 = GetDescriptions();
        }

        public static List<string> GetDescriptions()
        {
            return new List<string>(Utils.AbilityKeyValues.Values.ToList());
        }

        #endregion

        #region FUNCTIONS

        private void setRValue(float opVal, int index)
        {
            if (!AiEditorVM.isInitMnemonic)
            {
                JsonOperands operands = AiEditorVM.getOperands();

                if (operands != null)
                {
                    if (operands.rValues != null && operands.rValues.Count > index)
                    {
                        AiEditorVM.isChangingProperty = true;
                        AiEditorVM.AiScripts[AiEditorVM.ScriptIndex].Mnemonics[AiEditorVM.AiScripts[AiEditorVM.ScriptIndex].Mnemonics.IndexOf(AiEditorVM.CurrentAiMnemonic)].Operands.rValues[index] = opVal;
                        AiEditorVM.setSelectedAiScript();
                        AiEditorVM.isChangingProperty = false;
                    }
                }
            }
        }

        private void setActValueStrDesc(string opVal, int index)
        {
            if (!AiEditorVM.isInitMnemonic)
            {
                JsonOperands operands = AiEditorVM.getOperands();

                if (operands != null)
                {
                    if (operands.iValues != null && operands.iValues.Count > index)
                    {
                        AiEditorVM.isChangingProperty = true;
                        AiEditorVM.AiScripts[AiEditorVM.ScriptIndex].Mnemonics[AiEditorVM.AiScripts[AiEditorVM.ScriptIndex].Mnemonics.IndexOf(AiEditorVM.CurrentAiMnemonic)].Operands.iValues[index] = AiEditorVM.getDescriptionKey(opVal);
                        AiEditorVM.setSelectedAiScript();
                        AiEditorVM.isChangingProperty = false;
                    }
                }
            }
        }

        #endregion

        #region REFRESH FUNCTION

        public void refreshAct(Mnemonic currentMnemonic)
        {
            string defaultDescription = AiEditorVM.getDescriptionValue(0);
            ActValue1StrDescription = defaultDescription;
            ActValue2StrDescription = defaultDescription;
            ActValue3StrDescription = defaultDescription;
            ActValue4StrDescription = defaultDescription;
            ActValue5StrDescription = defaultDescription;
            ActValue6StrDescription = defaultDescription;
            ActValue7StrDescription = defaultDescription;
            ActValue8StrDescription = defaultDescription;
            ActValue1 = string.Empty;
            ActValue2 = string.Empty;
            ActValue3 = string.Empty;
            ActValue4 = string.Empty;
            ActValue5 = string.Empty;
            ActValue6 = string.Empty;
            ActValue7 = string.Empty;
            ActValue8 = string.Empty;
            IsEnabledActValue1 = false;
            IsEnabledActValue2 = false;
            IsEnabledActValue3 = false;
            IsEnabledActValue4 = false;
            IsEnabledActValue5 = false;
            IsEnabledActValue6 = false;
            IsEnabledActValue7 = false;
            IsEnabledActValue8 = false;

            if (currentMnemonic.Operands != null)
            {
                if (currentMnemonic.Operands.iValues != null && currentMnemonic.Operands.rValues != null)
                {
                    IList<int> iValues = currentMnemonic.Operands.iValues;
                    IList<float> rValues = currentMnemonic.Operands.rValues;
                    if (iValues.Count > 0 && rValues.Count > 0)
                    {
                        IsEnabledActValue1 = true;
                        ActValue1StrDescription = AiEditorVM.getDescriptionValue(iValues[0]);
                        ActValue1 = rValues[0].ToString();
                        if (iValues.Count > 1 && rValues.Count > 1)
                        {
                            IsEnabledActValue2 = true;
                            ActValue2StrDescription = AiEditorVM.getDescriptionValue(iValues[1]);
                            ActValue2 = rValues[1].ToString();
                            if (iValues.Count > 2 && rValues.Count > 2)
                            {
                                IsEnabledActValue3 = true;
                                ActValue3StrDescription = AiEditorVM.getDescriptionValue(iValues[2]);
                                ActValue3 = rValues[2].ToString();
                                if (iValues.Count > 3 && rValues.Count > 3)
                                {
                                    IsEnabledActValue4 = true;
                                    ActValue4StrDescription = AiEditorVM.getDescriptionValue(iValues[3]);
                                    ActValue4 = rValues[3].ToString();
                                    if (iValues.Count > 4 && rValues.Count > 4)
                                    {
                                        IsEnabledActValue5 = true;
                                        ActValue5StrDescription = AiEditorVM.getDescriptionValue(iValues[4]);
                                        ActValue5 = rValues[4].ToString();
                                        if (iValues.Count > 5 && rValues.Count > 5)
                                        {
                                            IsEnabledActValue6 = true;
                                            ActValue6StrDescription = AiEditorVM.getDescriptionValue(iValues[5]);
                                            ActValue6 = rValues[5].ToString();
                                            if (iValues.Count > 6 && rValues.Count > 6)
                                            {
                                                IsEnabledActValue7 = true;
                                                ActValue7StrDescription = AiEditorVM.getDescriptionValue(iValues[6]);
                                                ActValue7 = rValues[6].ToString();
                                                if (iValues.Count > 7 && rValues.Count > 7)
                                                {
                                                    IsEnabledActValue8 = true;
                                                    ActValue8StrDescription = AiEditorVM.getDescriptionValue(iValues[7]);
                                                    ActValue8 = rValues[7].ToString();
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
        }

        #endregion

        #region CLICK FUNCTIONS

        private void ClickBtn1()
        {
            AiEditorVM.initIValues();
            AiEditorVM.initRValues();
        }

        private void ClickPostEnable()
        {
            AiEditorVM.addIValue(0);
            AiEditorVM.addRValue(0);
        }

        private void ClickPostDisable()
        {
            IsEnabledActValue5 = false;
            IsEnabledActValue6 = false;
            IsEnabledActValue7 = false;
            IsEnabledActValue8 = false;
        }

        private void ClickActValue1Button()
        {
            IsButtonPressed = true;
            if (IsEnabledActValue1 == false)
            {
                IsEnabledActValue1 = true;
                AiEditorVM.initOperands();
                ClickBtn1();
                ClickPostEnable();
            }
            else
            {
                ClickBtn1();
                IsEnabledActValue1 = false;
                IsEnabledActValue2 = false;
                IsEnabledActValue3 = false;
                IsEnabledActValue4 = false;
                ClickPostDisable();

            }
            AiEditorVM.setSelectedAiScript();
            IsButtonPressed = false;
        }

        private void ClickBtn2()
        {
            ClickBtn1();
            AiEditorVM.addIValue(AiEditorVM.getDescriptionKey(ActValue1StrDescription));
            AiEditorVM.addStrRValue(ActValue1);
        }

        private void ClickActValue2Button()
        {
            IsButtonPressed = true;
            if (IsEnabledActValue2 == false)
            {
                IsEnabledActValue1 = true;
                IsEnabledActValue2 = true;
                AiEditorVM.initOperands();
                ClickBtn2();
                ClickPostEnable();
            }
            else
            {
                ClickBtn2();
                IsEnabledActValue2 = false;
                IsEnabledActValue3 = false;
                IsEnabledActValue4 = false;
                ClickPostDisable();
            }
            AiEditorVM.setSelectedAiScript();
            IsButtonPressed = false;
        }

        private void ClickBtn3()
        {
            ClickBtn2();
            AiEditorVM.addIValue(AiEditorVM.getDescriptionKey(ActValue2StrDescription));
            AiEditorVM.addStrRValue(ActValue2);
        }

        private void ClickActValue3Button()
        {
            IsButtonPressed = true;
            if (IsEnabledActValue3 == false)
            {
                IsEnabledActValue1 = true;
                IsEnabledActValue2 = true;
                IsEnabledActValue3 = true;
                AiEditorVM.initOperands();
                ClickBtn3();
                ClickPostEnable();
            }
            else
            {
                ClickBtn3();
                IsEnabledActValue3 = false;
                IsEnabledActValue4 = false;
                ClickPostDisable();
            }
            AiEditorVM.setSelectedAiScript();
            IsButtonPressed = false;
        }

        private void ClickPreEnable()
        {
            IsEnabledActValue1 = true;
            IsEnabledActValue2 = true;
            IsEnabledActValue3 = true;
            IsEnabledActValue4 = true;
        }

        private void ClickBtn4()
        {
            ClickBtn3();
            AiEditorVM.addIValue(AiEditorVM.getDescriptionKey(ActValue3StrDescription));
            AiEditorVM.addStrRValue(ActValue3);
        }

        private void ClickActValue4Button()
        {
            IsButtonPressed = true;
            if (IsEnabledActValue4 == false)
            {
                ClickPreEnable();
                AiEditorVM.initOperands();
                ClickBtn4();
                ClickPostEnable();
            }
            else
            {
                ClickBtn4();
                IsEnabledActValue4 = false;
                ClickPostDisable();
            }
            AiEditorVM.setSelectedAiScript();
            IsButtonPressed = false;
        }

        private void ClickBtn5()
        {
            ClickBtn4();
            AiEditorVM.addIValue(AiEditorVM.getDescriptionKey(ActValue4StrDescription));
            AiEditorVM.addStrRValue(ActValue4);
        }

        private void ClickActValue5Button()
        {
            IsButtonPressed = true;
            if (IsEnabledActValue5 == false)
            {
                ClickPreEnable();
                IsEnabledActValue5 = true;
                AiEditorVM.initOperands();
                ClickBtn5();
                ClickPostEnable();
            }
            else
            {
                ClickBtn5();
                ClickPostDisable();
            }
            AiEditorVM.setSelectedAiScript();
            IsButtonPressed = false;
        }

        private void ClickBtn6()
        {
            ClickBtn5();
            AiEditorVM.addIValue(AiEditorVM.getDescriptionKey(ActValue5StrDescription));
            AiEditorVM.addStrRValue(ActValue5);
        }

        private void ClickActValue6Button()
        {
            IsButtonPressed = true;
            if (IsEnabledActValue6 == false)
            {
                ClickPreEnable();
                IsEnabledActValue5 = true;
                IsEnabledActValue6 = true;
                AiEditorVM.initOperands();
                ClickBtn6();
                ClickPostEnable();
            }
            else
            {
                ClickBtn6();
                IsEnabledActValue6 = false;
                IsEnabledActValue7 = false;
                IsEnabledActValue8 = false;
            }
            AiEditorVM.setSelectedAiScript();
            IsButtonPressed = false;
        }

        private void ClickBtn7()
        {
            ClickBtn6();
            AiEditorVM.addIValue(AiEditorVM.getDescriptionKey(ActValue6StrDescription));
            AiEditorVM.addStrRValue(ActValue6);
        }

        private void ClickActValue7Button()
        {
            IsButtonPressed = true;
            if (IsEnabledActValue7 == false)
            {
                ClickPreEnable();
                IsEnabledActValue5 = true;
                IsEnabledActValue6 = true;
                IsEnabledActValue7 = true;
                AiEditorVM.initOperands();
                ClickBtn7();
                ClickPostEnable();
            }
            else
            {
                ClickBtn7();
                IsEnabledActValue7 = false;
                IsEnabledActValue8 = false;
            }
            AiEditorVM.setSelectedAiScript();
            IsButtonPressed = false;
        }

        private void ClickBtn8()
        {
            ClickBtn7();
            AiEditorVM.addIValue(AiEditorVM.getDescriptionKey(ActValue7StrDescription));
            AiEditorVM.addStrRValue(ActValue7);
        }

        private void ClickActValue8Button()
        {
            IsButtonPressed = true;
            if (IsEnabledActValue8 == false)
            {
                ClickPreEnable();
                IsEnabledActValue5 = true;
                IsEnabledActValue6 = true;
                IsEnabledActValue7 = true;
                IsEnabledActValue8 = true;
                AiEditorVM.initOperands();
                ClickBtn8();
                ClickPostEnable();
            }
            else
            {
                ClickBtn8();
                IsEnabledActValue8 = false;
            }
            AiEditorVM.setSelectedAiScript();
            IsButtonPressed = false;
        }

        #endregion

        #region BINDING

        private List<string> _actDescriptions1;
        public List<string> ActDescriptions1
        {
            get { return _actDescriptions1; }
            set { OnPropertyChanged(ref _actDescriptions1, value); }
        }

        private List<string> _actDescriptions2;
        public List<string> ActDescriptions2
        {
            get { return _actDescriptions2; }
            set { OnPropertyChanged(ref _actDescriptions2, value); }
        }

        private List<string> _actDescriptions3;
        public List<string> ActDescriptions3
        {
            get { return _actDescriptions3; }
            set { OnPropertyChanged(ref _actDescriptions3, value); }
        }

        private List<string> _actDescriptions4;
        public List<string> ActDescriptions4
        {
            get { return _actDescriptions4; }
            set { OnPropertyChanged(ref _actDescriptions4, value); }
        }

        private List<string> _actDescriptions5;
        public List<string> ActDescriptions5
        {
            get { return _actDescriptions5; }
            set { OnPropertyChanged(ref _actDescriptions5, value); }
        }

        private List<string> _actDescriptions6;
        public List<string> ActDescriptions6
        {
            get { return _actDescriptions6; }
            set { OnPropertyChanged(ref _actDescriptions6, value); }
        }

        private List<string> _actDescriptions7;
        public List<string> ActDescriptions7
        {
            get { return _actDescriptions7; }
            set { OnPropertyChanged(ref _actDescriptions7, value); }
        }

        private List<string> _actDescriptions8;
        public List<string> ActDescriptions8
        {
            get { return _actDescriptions8; }
            set { OnPropertyChanged(ref _actDescriptions8, value); }
        }

        private string _actValue1StrDescription;
        public string ActValue1StrDescription
        {
            get { return _actValue1StrDescription; }
            set
            {
                if (value != null)
                {
                    OnPropertyChanged(ref _actValue1StrDescription, value);
                    if (_actValue1StrDescription != string.Empty)
                    {
                        setActValueStrDesc(_actValue1StrDescription, 0);
                    }
                }
            }
        }

        private string _actValue2StrDescription;
        public string ActValue2StrDescription
        {
            get { return _actValue2StrDescription; }
            set
            {
                if (value != null)
                {
                    OnPropertyChanged(ref _actValue2StrDescription, value);
                    if (_actValue2StrDescription != string.Empty)
                    {
                        setActValueStrDesc(_actValue2StrDescription, 1);
                    }
                }
            }
        }

        private string _actValue3StrDescription;
        public string ActValue3StrDescription
        {
            get { return _actValue3StrDescription; }
            set
            {
                if (value != null)
                {
                    OnPropertyChanged(ref _actValue3StrDescription, value);
                    if (_actValue3StrDescription != string.Empty)
                    {
                        setActValueStrDesc(_actValue3StrDescription, 2);
                    }
                }
            }
        }

        private string _actValue4StrDescription;
        public string ActValue4StrDescription
        {
            get { return _actValue4StrDescription; }
            set
            {
                if (value != null)
                {
                    OnPropertyChanged(ref _actValue4StrDescription, value);
                    if (_actValue4StrDescription != string.Empty)
                    {
                        setActValueStrDesc(_actValue4StrDescription, 3);
                    }
                }
            }
        }

        private string _actValue5StrDescription;
        public string ActValue5StrDescription
        {
            get { return _actValue5StrDescription; }
            set
            {
                if (value != null)
                {
                    OnPropertyChanged(ref _actValue5StrDescription, value);
                    if (_actValue5StrDescription != string.Empty)
                    {
                        setActValueStrDesc(_actValue5StrDescription, 4);
                    }
                }
            }
        }

        private string _actValue6StrDescription;
        public string ActValue6StrDescription
        {
            get { return _actValue6StrDescription; }
            set
            {
                if (value != null)
                {
                    OnPropertyChanged(ref _actValue6StrDescription, value);
                    if (_actValue6StrDescription != string.Empty)
                    {
                        setActValueStrDesc(_actValue6StrDescription, 5);
                    }
                }
            }
        }

        private string _actValue7StrDescription;
        public string ActValue7StrDescription
        {
            get { return _actValue7StrDescription; }
            set
            {
                if (value != null)
                {
                    OnPropertyChanged(ref _actValue7StrDescription, value);
                    if (_actValue7StrDescription != string.Empty)
                    {
                        setActValueStrDesc(_actValue7StrDescription, 6);
                    }
                }
            }
        }

        private string _actValue8StrDescription;
        public string ActValue8StrDescription
        {
            get { return _actValue8StrDescription; }
            set
            {
                if (value != null)
                {
                    OnPropertyChanged(ref _actValue8StrDescription, value);
                    if (_actValue8StrDescription != string.Empty)
                    {
                        setActValueStrDesc(_actValue8StrDescription, 7);
                    }
                }
            }
        }

        private string _actValue1;
        public string ActValue1
        {
            get { return _actValue1; }
            set
            {
                OnPropertyChanged(ref _actValue1, value);

                float opVal;
                if (float.TryParse(value, out opVal))
                {
                    setRValue(opVal, 0);
                }
            }
        }

        private string _actValue2;
        public string ActValue2
        {
            get { return _actValue2; }
            set
            {
                OnPropertyChanged(ref _actValue2, value);

                float opVal;
                if (float.TryParse(value, out opVal))
                {
                    setRValue(opVal, 1);
                }
            }
        }

        private string _actValue3;
        public string ActValue3
        {
            get { return _actValue3; }
            set
            {
                OnPropertyChanged(ref _actValue3, value);

                float opVal;
                if (float.TryParse(value, out opVal))
                {
                    setRValue(opVal, 2);
                }
            }
        }

        private string _actValue4;
        public string ActValue4
        {
            get { return _actValue4; }
            set
            {
                OnPropertyChanged(ref _actValue4, value);

                float opVal;
                if (float.TryParse(value, out opVal))
                {
                    setRValue(opVal, 3);
                }
            }
        }

        private string _actValue5;
        public string ActValue5
        {
            get { return _actValue5; }
            set
            {
                OnPropertyChanged(ref _actValue5, value);

                float opVal;
                if (float.TryParse(value, out opVal))
                {
                    setRValue(opVal, 4);
                }
            }
        }

        private string _actValue6;
        public string ActValue6
        {
            get { return _actValue6; }
            set
            {
                OnPropertyChanged(ref _actValue6, value);

                float opVal;
                if (float.TryParse(value, out opVal))
                {
                    setRValue(opVal, 5);
                }
            }
        }

        private string _actValue7;
        public string ActValue7
        {
            get { return _actValue7; }
            set
            {
                OnPropertyChanged(ref _actValue7, value);

                float opVal;
                if (float.TryParse(value, out opVal))
                {
                    setRValue(opVal, 6);
                }
            }
        }

        private string _actValue8;
        public string ActValue8
        {
            get { return _actValue8; }
            set
            {
                OnPropertyChanged(ref _actValue8, value);

                float opVal;
                if (float.TryParse(value, out opVal))
                {
                    setRValue(opVal, 7);
                }
            }
        }

        private Brush _actValue1ButtonBrush;
        public Brush ActValue1ButtonBrush
        {
            get { return _actValue1ButtonBrush; }
            set { OnPropertyChanged(ref _actValue1ButtonBrush, value); }
        }

        private Brush _actValue2ButtonBrush;
        public Brush ActValue2ButtonBrush
        {
            get { return _actValue2ButtonBrush; }
            set { OnPropertyChanged(ref _actValue2ButtonBrush, value); }
        }

        private Brush _actValue3ButtonBrush;
        public Brush ActValue3ButtonBrush
        {
            get { return _actValue3ButtonBrush; }
            set { OnPropertyChanged(ref _actValue3ButtonBrush, value); }
        }

        private Brush _actValue4ButtonBrush;
        public Brush ActValue4ButtonBrush
        {
            get { return _actValue4ButtonBrush; }
            set { OnPropertyChanged(ref _actValue4ButtonBrush, value); }
        }

        private Brush _actValue5ButtonBrush;
        public Brush ActValue5ButtonBrush
        {
            get { return _actValue5ButtonBrush; }
            set { OnPropertyChanged(ref _actValue5ButtonBrush, value); }
        }

        private Brush _actValue6ButtonBrush;
        public Brush ActValue6ButtonBrush
        {
            get { return _actValue6ButtonBrush; }
            set { OnPropertyChanged(ref _actValue6ButtonBrush, value); }
        }

        private Brush _actValue7ButtonBrush;
        public Brush ActValue7ButtonBrush
        {
            get { return _actValue7ButtonBrush; }
            set { OnPropertyChanged(ref _actValue7ButtonBrush, value); }
        }

        private Brush _actValue8ButtonBrush;
        public Brush ActValue8ButtonBrush
        {
            get { return _actValue8ButtonBrush; }
            set { OnPropertyChanged(ref _actValue8ButtonBrush, value); }
        }

        private ICommand _actValue1ButtonClick;
        public ICommand ActValue1ButtonClick
        {
            get { return _actValue1ButtonClick; }
            set { OnPropertyChanged(ref _actValue1ButtonClick, value); }
        }

        private ICommand _actValue2ButtonClick;
        public ICommand ActValue2ButtonClick
        {
            get { return _actValue2ButtonClick; }
            set { OnPropertyChanged(ref _actValue2ButtonClick, value); }
        }

        private ICommand _actValue3ButtonClick;
        public ICommand ActValue3ButtonClick
        {
            get { return _actValue3ButtonClick; }
            set { OnPropertyChanged(ref _actValue3ButtonClick, value); }
        }

        private ICommand _actValue4ButtonClick;
        public ICommand ActValue4ButtonClick
        {
            get { return _actValue4ButtonClick; }
            set { OnPropertyChanged(ref _actValue4ButtonClick, value); }
        }

        private ICommand _actValue5ButtonClick;
        public ICommand ActValue5ButtonClick
        {
            get { return _actValue5ButtonClick; }
            set { OnPropertyChanged(ref _actValue5ButtonClick, value); }
        }

        private ICommand _actValue6ButtonClick;
        public ICommand ActValue6ButtonClick
        {
            get { return _actValue6ButtonClick; }
            set { OnPropertyChanged(ref _actValue6ButtonClick, value); }
        }

        private ICommand _actValue7ButtonClick;
        public ICommand ActValue7ButtonClick
        {
            get { return _actValue7ButtonClick; }
            set { OnPropertyChanged(ref _actValue7ButtonClick, value); }
        }

        private ICommand _actValue8ButtonClick;
        public ICommand ActValue8ButtonClick
        {
            get { return _actValue8ButtonClick; }
            set { OnPropertyChanged(ref _actValue8ButtonClick, value); }
        }

        private bool _isEnabledActValue1;
        public bool IsEnabledActValue1
        {
            get { return _isEnabledActValue1; }
            set
            {
                OnPropertyChanged(ref _isEnabledActValue1, value);

                if (_isEnabledActValue1 == false)
                {
                    ActValue1ButtonBrush = Utils.redButtonBrush;
                }
                else
                {
                    ActValue1ButtonBrush = Utils.greenButtonBrush;
                }
            }
        }

        private bool _isEnabledActValue2;
        public bool IsEnabledActValue2
        {
            get { return _isEnabledActValue2; }
            set
            {
                OnPropertyChanged(ref _isEnabledActValue2, value);

                if (_isEnabledActValue2 == false)
                {
                    ActValue2ButtonBrush = Utils.redButtonBrush;
                }
                else
                {
                    ActValue2ButtonBrush = Utils.greenButtonBrush;
                }
            }
        }

        private bool _isEnabledActValue3;
        public bool IsEnabledActValue3
        {
            get { return _isEnabledActValue3; }
            set
            {
                OnPropertyChanged(ref _isEnabledActValue3, value);

                if (_isEnabledActValue3 == false)
                {
                    ActValue3ButtonBrush = Utils.redButtonBrush;
                }
                else
                {
                    ActValue3ButtonBrush = Utils.greenButtonBrush;
                }
            }
        }

        private bool _isEnabledActValue4;
        public bool IsEnabledActValue4
        {
            get { return _isEnabledActValue4; }
            set
            {
                OnPropertyChanged(ref _isEnabledActValue4, value);

                if (_isEnabledActValue4 == false)
                {
                    ActValue4ButtonBrush = Utils.redButtonBrush;
                }
                else
                {
                    ActValue4ButtonBrush = Utils.greenButtonBrush;
                }
            }
        }

        private bool _isEnabledActValue5;
        public bool IsEnabledActValue5
        {
            get { return _isEnabledActValue5; }
            set
            {
                OnPropertyChanged(ref _isEnabledActValue5, value);

                if (_isEnabledActValue5 == false)
                {
                    ActValue5ButtonBrush = Utils.redButtonBrush;
                }
                else
                {
                    ActValue5ButtonBrush = Utils.greenButtonBrush;
                }
            }
        }

        private bool _isEnabledActValue6;
        public bool IsEnabledActValue6
        {
            get { return _isEnabledActValue6; }
            set
            {
                OnPropertyChanged(ref _isEnabledActValue6, value);

                if (_isEnabledActValue6 == false)
                {
                    ActValue6ButtonBrush = Utils.redButtonBrush;
                }
                else
                {
                    ActValue6ButtonBrush = Utils.greenButtonBrush;
                }
            }
        }

        private bool _isEnabledActValue7;
        public bool IsEnabledActValue7
        {
            get { return _isEnabledActValue7; }
            set
            {
                OnPropertyChanged(ref _isEnabledActValue7, value);

                if (_isEnabledActValue7 == false)
                {
                    ActValue7ButtonBrush = Utils.redButtonBrush;
                }
                else
                {
                    ActValue7ButtonBrush = Utils.greenButtonBrush;
                }
            }
        }

        private bool _isEnabledActValue8;
        public bool IsEnabledActValue8
        {
            get { return _isEnabledActValue8; }
            set
            {
                OnPropertyChanged(ref _isEnabledActValue8, value);

                if (_isEnabledActValue8 == false)
                {
                    ActValue8ButtonBrush = Utils.redButtonBrush;
                }
                else
                {
                    ActValue8ButtonBrush = Utils.greenButtonBrush;
                }
            }
        }

        #endregion
    }
}
