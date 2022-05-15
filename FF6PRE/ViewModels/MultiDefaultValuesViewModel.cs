using FF6PRE.Models;
using FF6PRE.MVVM;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows.Media;

namespace FF6PRE.ViewModels
{
    public class MultiDefaultValuesViewModel: ObservableObject
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

        public MultiDefaultValuesViewModel(AiEditorViewModel aiEditorVM)
        {
            AiEditorVM = aiEditorVM;
            setCommands();
        }

        private void setCommands()
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

        #endregion

        #region FUNCTIONS

        private void setIValue(int opVal, int index)
        {
            if (!AiEditorVM.isInitMnemonic)
            {
                JsonOperands operands = AiEditorVM.getOperands();

                if (operands != null)
                {
                    if (operands.iValues != null && operands.iValues.Count > index)
                    {
                        AiEditorVM.isChangingProperty = true;
                        AiEditorVM.AiScripts[AiEditorVM.ScriptIndex].Mnemonics[AiEditorVM.AiScripts[AiEditorVM.ScriptIndex].Mnemonics.IndexOf(AiEditorVM.CurrentAiMnemonic)].Operands.iValues[index] = opVal;
                        AiEditorVM.setSelectedAiScript();
                        AiEditorVM.isChangingProperty = false;
                    }
                }
            }
        }

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

        private void setSValue(string opVal, int index)
        {
            if (!AiEditorVM.isInitMnemonic)
            {
                JsonOperands operands = AiEditorVM.getOperands();

                if (operands != null)
                {
                    if (operands.sValues != null && operands.sValues.Count > index)
                    {
                        AiEditorVM.isChangingProperty = true;
                        AiEditorVM.AiScripts[AiEditorVM.ScriptIndex].Mnemonics[AiEditorVM.AiScripts[AiEditorVM.ScriptIndex].Mnemonics.IndexOf(AiEditorVM.CurrentAiMnemonic)].Operands.sValues[index] = opVal;
                        AiEditorVM.setSelectedAiScript();
                        AiEditorVM.isChangingProperty = false;
                    }
                }
            }
        }

        #endregion

        #region REFRESH FUNCTION

        public void refreshValues(Mnemonic currentMnemonic)
        {
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

            if (currentMnemonic.Operands != null)
            {
                if (currentMnemonic.Operands.iValues != null)
                {
                    IList<int> iValues = currentMnemonic.Operands.iValues;
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

                if (currentMnemonic.Operands.rValues != null)
                {
                    IList<float> rValues = currentMnemonic.Operands.rValues;
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

                if (currentMnemonic.Operands.sValues != null)
                {
                    IList<string> sValues = currentMnemonic.Operands.sValues;
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
        }

        #endregion

        #region CLICK FUNCTIONS

        private void clickIValuePostDisable()
        {
            IsEnabledIValue4 = false;
            IsEnabledIValue5 = false;
            IsEnabledIValue6 = false;
            IsEnabledIValue7 = false;
            IsEnabledIValue8 = false;
        }

        private void ClickIValue1Button()
        {
            if (IsEnabledIValue1 == false)
            {
                IsEnabledIValue1 = true;
                AiEditorVM.initOperands();
                AiEditorVM.initIValues();
                AiEditorVM.addIValue(0);
            }
            else
            {
                AiEditorVM.initIValues();
                IsEnabledIValue1 = false;
                IsEnabledIValue2 = false;
                IsEnabledIValue3 = false;
                clickIValuePostDisable();
            }
            AiEditorVM.setSelectedAiScript();
        }

        private void ClickIValue2Button()
        {
            if (IsEnabledIValue2 == false)
            {
                IsEnabledIValue1 = true;
                IsEnabledIValue2 = true;
                AiEditorVM.initOperands();
                AiEditorVM.initIValues();
                AiEditorVM.addStrIValue(IValue1);
                AiEditorVM.addIValue(0);
            }
            else
            {
                AiEditorVM.initIValues();
                AiEditorVM.addStrIValue(IValue1);
                IsEnabledIValue2 = false;
                IsEnabledIValue3 = false;
                clickIValuePostDisable();
            }
            AiEditorVM.setSelectedAiScript();
        }

        private void clickIValueBtn3()
        {
            AiEditorVM.initIValues();
            AiEditorVM.addStrIValue(IValue1);
            AiEditorVM.addStrIValue(IValue2);
        }

        private void ClickIValue3Button()
        {
            if (IsEnabledIValue3 == false)
            {
                IsEnabledIValue1 = true;
                IsEnabledIValue2 = true;
                IsEnabledIValue3 = true;
                AiEditorVM.initOperands();
                clickIValueBtn3();
                AiEditorVM.addIValue(0);
            }
            else
            {
                clickIValueBtn3();
                IsEnabledIValue3 = false;
                clickIValuePostDisable();
            }
            AiEditorVM.setSelectedAiScript();
        }

        private void clickIValuePreEnable()
        {
            IsEnabledIValue1 = true;
            IsEnabledIValue2 = true;
            IsEnabledIValue3 = true;
            IsEnabledIValue4 = true;
        }

        private void clickIValueBtn4()
        {
            clickIValueBtn3();
            AiEditorVM.addStrIValue(IValue3);
        }

        private void ClickIValue4Button()
        {
            if (IsEnabledIValue4 == false)
            {
                clickIValuePreEnable();
                AiEditorVM.initOperands();
                clickIValueBtn4();
                AiEditorVM.addIValue(0);
            }
            else
            {
                clickIValueBtn4();
                clickIValuePostDisable();
            }
            AiEditorVM.setSelectedAiScript();
        }

        private void clickIValueBtn5()
        {
            clickIValueBtn4();
            AiEditorVM.addStrIValue(IValue4);
        }

        private void ClickIValue5Button()
        {
            if (IsEnabledIValue5 == false)
            {
                clickIValuePreEnable();
                IsEnabledIValue5 = true;
                AiEditorVM.initOperands();
                clickIValueBtn5();
                AiEditorVM.addIValue(0);
            }
            else
            {
                clickIValueBtn5();
                IsEnabledIValue5 = false;
                IsEnabledIValue6 = false;
                IsEnabledIValue7 = false;
                IsEnabledIValue8 = false;
            }
            AiEditorVM.setSelectedAiScript();
        }

        private void clickIValueBtn6()
        {
            clickIValueBtn5();
            AiEditorVM.addStrIValue(IValue5);
        }

        private void ClickIValue6Button()
        {
            if (IsEnabledIValue6 == false)
            {
                clickIValuePreEnable();
                IsEnabledIValue5 = true;
                IsEnabledIValue6 = true;
                AiEditorVM.initOperands();
                clickIValueBtn6();
                AiEditorVM.addIValue(0);
            }
            else
            {
                clickIValueBtn6();
                IsEnabledIValue6 = false;
                IsEnabledIValue7 = false;
                IsEnabledIValue8 = false;
            }
            AiEditorVM.setSelectedAiScript();
        }

        private void clickIValueBtn7()
        {
            clickIValueBtn6();
            AiEditorVM.addStrIValue(IValue6);
        }

        private void ClickIValue7Button()
        {
            if (IsEnabledIValue7 == false)
            {
                clickIValuePreEnable();
                IsEnabledIValue5 = true;
                IsEnabledIValue6 = true;
                IsEnabledIValue7 = true;
                AiEditorVM.initOperands();
                clickIValueBtn7();
                AiEditorVM.addIValue(0);
            }
            else
            {
                clickIValueBtn7();
                IsEnabledIValue7 = false;
                IsEnabledIValue8 = false;
            }
            AiEditorVM.setSelectedAiScript();
        }

        private void clickIValueBtn8()
        {
            clickIValueBtn7();
            AiEditorVM.addStrIValue(IValue7);
        }

        private void ClickIValue8Button()
        {
            if (IsEnabledIValue8 == false)
            {
                clickIValuePreEnable();
                IsEnabledIValue5 = true;
                IsEnabledIValue6 = true;
                IsEnabledIValue7 = true;
                IsEnabledIValue8 = true;
                AiEditorVM.initOperands();
                clickIValueBtn8();
                AiEditorVM.addIValue(0);
            }
            else
            {
                clickIValueBtn8();
                IsEnabledIValue8 = false;
            }
            AiEditorVM.setSelectedAiScript();
        }

        private void clickRValuePostDisable()
        {
            IsEnabledRValue4 = false;
            IsEnabledRValue5 = false;
            IsEnabledRValue6 = false;
            IsEnabledRValue7 = false;
            IsEnabledRValue8 = false;
        }

        private void ClickRValue1Button()
        {
            if (IsEnabledRValue1 == false)
            {
                IsEnabledRValue1 = true;
                AiEditorVM.initOperands();
                AiEditorVM.initRValues();
                AiEditorVM.addRValue(0);
            }
            else
            {
                AiEditorVM.initRValues();
                IsEnabledRValue1 = false;
                IsEnabledRValue2 = false;
                IsEnabledRValue3 = false;
                clickRValuePostDisable();
            }
            AiEditorVM.setSelectedAiScript();
        }

        private void ClickRValue2Button()
        {
            if (IsEnabledRValue2 == false)
            {
                IsEnabledRValue1 = true;
                IsEnabledRValue2 = true;
                AiEditorVM.initOperands();
                AiEditorVM.initRValues();
                AiEditorVM.addStrRValue(RValue1);
                AiEditorVM.addRValue(0);
            }
            else
            {
                AiEditorVM.initRValues();
                AiEditorVM.addStrRValue(RValue1);
                IsEnabledRValue2 = false;
                IsEnabledRValue3 = false;
                clickRValuePostDisable();
            }
            AiEditorVM.setSelectedAiScript();
        }

        private void clickRValueBtn3()
        {
            AiEditorVM.initRValues();
            AiEditorVM.addStrRValue(RValue1);
            AiEditorVM.addStrRValue(RValue2);
        }

        private void ClickRValue3Button()
        {
            if (IsEnabledRValue3 == false)
            {
                IsEnabledRValue1 = true;
                IsEnabledRValue2 = true;
                IsEnabledRValue3 = true;
                AiEditorVM.initOperands();
                clickRValueBtn3();
                AiEditorVM.addRValue(0);
            }
            else
            {
                clickRValueBtn3();
                IsEnabledRValue3 = false;
                clickRValuePostDisable();
            }
            AiEditorVM.setSelectedAiScript();
        }

        private void clickRValuePreEnable()
        {
            IsEnabledRValue1 = true;
            IsEnabledRValue2 = true;
            IsEnabledRValue3 = true;
            IsEnabledRValue4 = true;
        }

        private void clickRValueBtn4()
        {
            clickRValueBtn3();
            AiEditorVM.addStrRValue(RValue3);
        }

        private void ClickRValue4Button()
        {
            if (IsEnabledRValue4 == false)
            {
                clickRValuePreEnable();
                AiEditorVM.initOperands();
                clickRValueBtn4();
                AiEditorVM.addRValue(0);
            }
            else
            {
                clickRValueBtn4();
                clickRValuePostDisable();
            }
            AiEditorVM.setSelectedAiScript();
        }

        private void clickRValueBtn5()
        {
            clickRValueBtn4();
            AiEditorVM.addStrRValue(RValue4);
        }

        private void ClickRValue5Button()
        {
            if (IsEnabledRValue5 == false)
            {
                clickRValuePreEnable();
                IsEnabledRValue5 = true;
                AiEditorVM.initOperands();
                clickRValueBtn5();
                AiEditorVM.addRValue(0);
            }
            else
            {
                clickRValueBtn5();
                IsEnabledRValue5 = false;
                IsEnabledRValue6 = false;
                IsEnabledRValue7 = false;
                IsEnabledRValue8 = false;
            }
            AiEditorVM.setSelectedAiScript();
        }

        private void clickRValueBtn6()
        {
            clickRValueBtn5();
            AiEditorVM.addStrRValue(RValue5);
        }

        private void ClickRValue6Button()
        {
            if (IsEnabledRValue6 == false)
            {
                clickRValuePreEnable();
                IsEnabledRValue5 = true;
                IsEnabledRValue6 = true;
                AiEditorVM.initOperands();
                clickRValueBtn6();
                AiEditorVM.addRValue(0);
            }
            else
            {
                clickRValueBtn6();
                IsEnabledRValue6 = false;
                IsEnabledRValue7 = false;
                IsEnabledRValue8 = false;
            }
            AiEditorVM.setSelectedAiScript();
        }

        private void clickRValueBtn7()
        {
            clickRValueBtn6();
            AiEditorVM.addStrRValue(RValue6);
        }

        private void ClickRValue7Button()
        {
            if (IsEnabledRValue7 == false)
            {
                clickRValuePreEnable();
                IsEnabledRValue5 = true;
                IsEnabledRValue6 = true;
                IsEnabledRValue7 = true;
                AiEditorVM.initOperands();
                clickRValueBtn7();
                AiEditorVM.addRValue(0);
            }
            else
            {
                clickRValueBtn7();
                IsEnabledRValue7 = false;
                IsEnabledRValue8 = false;
            }
            AiEditorVM.setSelectedAiScript();
        }

        private void clickRValueBtn8()
        {
            clickRValueBtn7();
            AiEditorVM.addStrRValue(RValue7);
        }

        private void ClickRValue8Button()
        {
            if (IsEnabledRValue8 == false)
            {
                clickRValuePreEnable();
                IsEnabledRValue5 = true;
                IsEnabledRValue6 = true;
                IsEnabledRValue7 = true;
                IsEnabledRValue8 = true;
                AiEditorVM.initOperands();
                clickRValueBtn8();
                AiEditorVM.addRValue(0);
            }
            else
            {
                clickRValueBtn8();
                IsEnabledRValue8 = false;
            }
            AiEditorVM.setSelectedAiScript();
        }

        private void clickSValuePostDisable()
        {
            IsEnabledSValue4 = false;
            IsEnabledSValue5 = false;
            IsEnabledSValue6 = false;
            IsEnabledSValue7 = false;
            IsEnabledSValue8 = false;
        }

        private void ClickSValue1Button()
        {
            if (IsEnabledSValue1 == false)
            {
                IsEnabledSValue1 = true;
                AiEditorVM.initOperands();
                AiEditorVM.initSValues();
                AiEditorVM.addSValue(string.Empty);
            }
            else
            {
                AiEditorVM.initSValues();
                IsEnabledSValue1 = false;
                IsEnabledSValue2 = false;
                IsEnabledSValue3 = false;
                clickSValuePostDisable();
            }
            AiEditorVM.setSelectedAiScript();
        }

        private void ClickSValue2Button()
        {
            if (IsEnabledSValue2 == false)
            {
                IsEnabledSValue1 = true;
                IsEnabledSValue2 = true;
                AiEditorVM.initOperands();
                AiEditorVM.initSValues();
                AiEditorVM.addSValue(SValue1);
                AiEditorVM.addSValue(string.Empty);
            }
            else
            {
                AiEditorVM.initSValues();
                AiEditorVM.addSValue(SValue1);
                IsEnabledSValue2 = false;
                IsEnabledSValue3 = false;
                clickSValuePostDisable();
            }
            AiEditorVM.setSelectedAiScript();
        }

        private void clickSValueBtn3()
        {
            AiEditorVM.initSValues();
            AiEditorVM.addSValue(SValue1);
            AiEditorVM.addSValue(SValue2);
        }

        private void ClickSValue3Button()
        {
            if (IsEnabledSValue3 == false)
            {
                IsEnabledSValue1 = true;
                IsEnabledSValue2 = true;
                IsEnabledSValue3 = true;
                AiEditorVM.initOperands();
                clickSValueBtn3();
                AiEditorVM.addSValue(string.Empty);
            }
            else
            {
                clickSValueBtn3();
                IsEnabledSValue3 = false;
                clickSValuePostDisable();
            }
            AiEditorVM.setSelectedAiScript();
        }

        private void clickSValuePreEnable()
        {
            IsEnabledSValue1 = true;
            IsEnabledSValue2 = true;
            IsEnabledSValue3 = true;
            IsEnabledSValue4 = true;
        }

        private void clickSValueBtn4()
        {
            clickSValueBtn3();
            AiEditorVM.addSValue(SValue3);
        }

        private void ClickSValue4Button()
        {
            if (IsEnabledSValue4 == false)
            {
                clickSValuePreEnable();
                AiEditorVM.initOperands();
                clickSValueBtn4();
                AiEditorVM.addSValue(string.Empty);
            }
            else
            {
                clickSValueBtn4();
                clickSValuePostDisable();
            }
            AiEditorVM.setSelectedAiScript();
        }

        private void clickSValueBtn5()
        {
            clickSValueBtn4();
            AiEditorVM.addSValue(SValue4);
        }

        private void ClickSValue5Button()
        {
            if (IsEnabledSValue5 == false)
            {
                clickSValuePreEnable();
                IsEnabledSValue5 = true;
                AiEditorVM.initOperands();
                clickSValueBtn5();
                AiEditorVM.addSValue(string.Empty);
            }
            else
            {
                clickSValueBtn5();
                IsEnabledSValue5 = false;
                IsEnabledSValue6 = false;
                IsEnabledSValue7 = false;
                IsEnabledSValue8 = false;
            }
            AiEditorVM.setSelectedAiScript();
        }

        private void clickSValueBtn6()
        {
            clickSValueBtn5();
            AiEditorVM.addSValue(SValue5);
        }

        private void ClickSValue6Button()
        {
            if (IsEnabledSValue6 == false)
            {
                clickSValuePreEnable();
                IsEnabledSValue5 = true;
                IsEnabledSValue6 = true;
                AiEditorVM.initOperands();
                clickSValueBtn6();
                AiEditorVM.addSValue(string.Empty);
            }
            else
            {
                clickSValueBtn6();
                IsEnabledSValue6 = false;
                IsEnabledSValue7 = false;
                IsEnabledSValue8 = false;
            }
            AiEditorVM.setSelectedAiScript();
        }

        private void clickSValueBtn7()
        {
            clickSValueBtn6();
            AiEditorVM.addSValue(SValue6);
        }

        private void ClickSValue7Button()
        {
            if (IsEnabledSValue7 == false)
            {
                clickSValuePreEnable();
                IsEnabledSValue5 = true;
                IsEnabledSValue6 = true;
                IsEnabledSValue7 = true;
                AiEditorVM.initOperands();
                clickSValueBtn7();
                AiEditorVM.addSValue(string.Empty);
            }
            else
            {
                clickSValueBtn7();
                IsEnabledSValue7 = false;
                IsEnabledSValue8 = false;
            }
            AiEditorVM.setSelectedAiScript();
        }

        private void clickSValueBtn8()
        {
            clickSValueBtn7();
            AiEditorVM.addSValue(SValue7);
        }

        private void ClickSValue8Button()
        {
            if (IsEnabledSValue8 == false)
            {
                clickSValuePreEnable();
                IsEnabledSValue5 = true;
                IsEnabledSValue6 = true;
                IsEnabledSValue7 = true;
                IsEnabledSValue8 = true;
                AiEditorVM.initOperands();
                clickSValueBtn8();
                AiEditorVM.addSValue(string.Empty);
            }
            else
            {
                clickSValueBtn8();
                IsEnabledSValue8 = false;
            }
            AiEditorVM.setSelectedAiScript();
        }

        #endregion

        #region BINDING

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
                if (_sValue1 != null)
                {
                    setSValue(_sValue1, 0);
                }
            }
        }

        private string _sValue2;
        public string SValue2
        {
            get { return _sValue2; }
            set
            {
                OnPropertyChanged(ref _sValue2, value);
                if (_sValue2 != null)
                {
                    setSValue(_sValue2, 1);
                }
            }
        }

        private string _sValue3;
        public string SValue3
        {
            get { return _sValue3; }
            set
            {
                OnPropertyChanged(ref _sValue3, value);
                if (_sValue3 != null)
                {
                    setSValue(_sValue3, 2);
                }
            }
        }

        private string _sValue4;
        public string SValue4
        {
            get { return _sValue4; }
            set
            {
                OnPropertyChanged(ref _sValue4, value);
                if (_sValue4 != null)
                {
                    setSValue(_sValue4, 3);
                }
            }
        }

        private string _sValue5;
        public string SValue5
        {
            get { return _sValue5; }
            set
            {
                OnPropertyChanged(ref _sValue5, value);
                if (_sValue5 != null)
                {
                    setSValue(_sValue5, 4);
                }
            }
        }

        private string _sValue6;
        public string SValue6
        {
            get { return _sValue6; }
            set
            {
                OnPropertyChanged(ref _sValue6, value);
                if (_sValue6 != null)
                {
                    setSValue(_sValue6, 5);
                }
            }
        }

        private string _sValue7;
        public string SValue7
        {
            get { return _sValue7; }
            set
            {
                OnPropertyChanged(ref _sValue7, value);
                if (_sValue7 != null)
                {
                    setSValue(_sValue7, 6);
                }
            }
        }

        private string _sValue8;
        public string SValue8
        {
            get { return _sValue8; }
            set
            {
                OnPropertyChanged(ref _sValue8, value);
                if (_sValue8 != null)
                {
                    setSValue(_sValue8, 7);
                }
            }
        }

        private Brush _iValue1ButtonBrush;
        public Brush IValue1ButtonBrush
        {
            get { return _iValue1ButtonBrush; }
            set { OnPropertyChanged(ref _iValue1ButtonBrush, value); }
        }

        private Brush _iValue2ButtonBrush;
        public Brush IValue2ButtonBrush
        {
            get { return _iValue2ButtonBrush; }
            set { OnPropertyChanged(ref _iValue2ButtonBrush, value); }
        }

        private Brush _iValue3ButtonBrush;
        public Brush IValue3ButtonBrush
        {
            get { return _iValue3ButtonBrush; }
            set { OnPropertyChanged(ref _iValue3ButtonBrush, value); }
        }

        private Brush _iValue4ButtonBrush;
        public Brush IValue4ButtonBrush
        {
            get { return _iValue4ButtonBrush; }
            set { OnPropertyChanged(ref _iValue4ButtonBrush, value); }
        }

        private Brush _iValue5ButtonBrush;
        public Brush IValue5ButtonBrush
        {
            get { return _iValue5ButtonBrush; }
            set { OnPropertyChanged(ref _iValue5ButtonBrush, value); }
        }

        private Brush _iValue6ButtonBrush;
        public Brush IValue6ButtonBrush
        {
            get { return _iValue6ButtonBrush; }
            set { OnPropertyChanged(ref _iValue6ButtonBrush, value); }
        }

        private Brush _iValue7ButtonBrush;
        public Brush IValue7ButtonBrush
        {
            get { return _iValue7ButtonBrush; }
            set { OnPropertyChanged(ref _iValue7ButtonBrush, value); }
        }

        private Brush _iValue8ButtonBrush;
        public Brush IValue8ButtonBrush
        {
            get { return _iValue8ButtonBrush; }
            set { OnPropertyChanged(ref _iValue8ButtonBrush, value); }
        }

        private Brush _rValue1ButtonBrush;
        public Brush RValue1ButtonBrush
        {
            get { return _rValue1ButtonBrush; }
            set { OnPropertyChanged(ref _rValue1ButtonBrush, value); }
        }

        private Brush _rValue2ButtonBrush;
        public Brush RValue2ButtonBrush
        {
            get { return _rValue2ButtonBrush; }
            set { OnPropertyChanged(ref _rValue2ButtonBrush, value); }
        }

        private Brush _rValue3ButtonBrush;
        public Brush RValue3ButtonBrush
        {
            get { return _rValue3ButtonBrush; }
            set { OnPropertyChanged(ref _rValue3ButtonBrush, value); }
        }

        private Brush _rValue4ButtonBrush;
        public Brush RValue4ButtonBrush
        {
            get { return _rValue4ButtonBrush; }
            set { OnPropertyChanged(ref _rValue4ButtonBrush, value); }
        }

        private Brush _rValue5ButtonBrush;
        public Brush RValue5ButtonBrush
        {
            get { return _rValue5ButtonBrush; }
            set { OnPropertyChanged(ref _rValue5ButtonBrush, value); }
        }

        private Brush _rValue6ButtonBrush;
        public Brush RValue6ButtonBrush
        {
            get { return _rValue6ButtonBrush; }
            set { OnPropertyChanged(ref _rValue6ButtonBrush, value); }
        }

        private Brush _rValue7ButtonBrush;
        public Brush RValue7ButtonBrush
        {
            get { return _rValue7ButtonBrush; }
            set { OnPropertyChanged(ref _rValue7ButtonBrush, value); }
        }

        private Brush _rValue8ButtonBrush;
        public Brush RValue8ButtonBrush
        {
            get { return _rValue8ButtonBrush; }
            set { OnPropertyChanged(ref _rValue8ButtonBrush, value); }
        }

        private Brush _sValue1ButtonBrush;
        public Brush SValue1ButtonBrush
        {
            get { return _sValue1ButtonBrush; }
            set { OnPropertyChanged(ref _sValue1ButtonBrush, value); }
        }

        private Brush _sValue2ButtonBrush;
        public Brush SValue2ButtonBrush
        {
            get { return _sValue2ButtonBrush; }
            set { OnPropertyChanged(ref _sValue2ButtonBrush, value); }
        }

        private Brush _sValue3ButtonBrush;
        public Brush SValue3ButtonBrush
        {
            get { return _sValue3ButtonBrush; }
            set { OnPropertyChanged(ref _sValue3ButtonBrush, value); }
        }

        private Brush _sValue4ButtonBrush;
        public Brush SValue4ButtonBrush
        {
            get { return _sValue4ButtonBrush; }
            set { OnPropertyChanged(ref _sValue4ButtonBrush, value); }
        }

        private Brush _sValue5ButtonBrush;
        public Brush SValue5ButtonBrush
        {
            get { return _sValue5ButtonBrush; }
            set { OnPropertyChanged(ref _sValue5ButtonBrush, value); }
        }

        private Brush _sValue6ButtonBrush;
        public Brush SValue6ButtonBrush
        {
            get { return _sValue6ButtonBrush; }
            set { OnPropertyChanged(ref _sValue6ButtonBrush, value); }
        }

        private Brush _sValue7ButtonBrush;
        public Brush SValue7ButtonBrush
        {
            get { return _sValue7ButtonBrush; }
            set { OnPropertyChanged(ref _sValue7ButtonBrush, value); }
        }

        private Brush _sValue8ButtonBrush;
        public Brush SValue8ButtonBrush
        {
            get { return _sValue8ButtonBrush; }
            set { OnPropertyChanged(ref _sValue8ButtonBrush, value); }
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

        private bool _isEnabledIValue1;
        public bool IsEnabledIValue1
        {
            get { return _isEnabledIValue1; }
            set
            {
                OnPropertyChanged(ref _isEnabledIValue1, value);

                if (_isEnabledIValue1 == false)
                {
                    IValue1ButtonBrush = Utils.redButtonBrush;
                }
                else
                {
                    IValue1ButtonBrush = Utils.greenButtonBrush;
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
                    IValue2ButtonBrush = Utils.redButtonBrush;
                }
                else
                {
                    IValue2ButtonBrush = Utils.greenButtonBrush;
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
                    IValue3ButtonBrush = Utils.redButtonBrush;
                }
                else
                {
                    IValue3ButtonBrush = Utils.greenButtonBrush;
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
                    IValue4ButtonBrush = Utils.redButtonBrush;
                }
                else
                {
                    IValue4ButtonBrush = Utils.greenButtonBrush;
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
                    IValue5ButtonBrush = Utils.redButtonBrush;
                }
                else
                {
                    IValue5ButtonBrush = Utils.greenButtonBrush;
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
                    IValue6ButtonBrush = Utils.redButtonBrush;
                }
                else
                {
                    IValue6ButtonBrush = Utils.greenButtonBrush;
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
                    IValue7ButtonBrush = Utils.redButtonBrush;
                }
                else
                {
                    IValue7ButtonBrush = Utils.greenButtonBrush;
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
                    IValue8ButtonBrush = Utils.redButtonBrush;
                }
                else
                {
                    IValue8ButtonBrush = Utils.greenButtonBrush;
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
                    RValue1ButtonBrush = Utils.redButtonBrush;
                }
                else
                {
                    RValue1ButtonBrush = Utils.greenButtonBrush;
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
                    RValue2ButtonBrush = Utils.redButtonBrush;
                }
                else
                {
                    RValue2ButtonBrush = Utils.greenButtonBrush;
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
                    RValue3ButtonBrush = Utils.redButtonBrush;
                }
                else
                {
                    RValue3ButtonBrush = Utils.greenButtonBrush;
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
                    RValue4ButtonBrush = Utils.redButtonBrush;
                }
                else
                {
                    RValue4ButtonBrush = Utils.greenButtonBrush;
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
                    RValue5ButtonBrush = Utils.redButtonBrush;
                }
                else
                {
                    RValue5ButtonBrush = Utils.greenButtonBrush;
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
                    RValue6ButtonBrush = Utils.redButtonBrush;
                }
                else
                {
                    RValue6ButtonBrush = Utils.greenButtonBrush;
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
                    RValue7ButtonBrush = Utils.redButtonBrush;
                }
                else
                {
                    RValue7ButtonBrush = Utils.greenButtonBrush;
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
                    RValue8ButtonBrush = Utils.redButtonBrush;
                }
                else
                {
                    RValue8ButtonBrush = Utils.greenButtonBrush;
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
                    SValue1ButtonBrush = Utils.redButtonBrush;
                }
                else
                {
                    SValue1ButtonBrush = Utils.greenButtonBrush;
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
                    SValue2ButtonBrush = Utils.redButtonBrush;
                }
                else
                {
                    SValue2ButtonBrush = Utils.greenButtonBrush;
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
                    SValue3ButtonBrush = Utils.redButtonBrush;
                }
                else
                {
                    SValue3ButtonBrush = Utils.greenButtonBrush;
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
                    SValue4ButtonBrush = Utils.redButtonBrush;
                }
                else
                {
                    SValue4ButtonBrush = Utils.greenButtonBrush;
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
                    SValue5ButtonBrush = Utils.redButtonBrush;
                }
                else
                {
                    SValue5ButtonBrush = Utils.greenButtonBrush;
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
                    SValue6ButtonBrush = Utils.redButtonBrush;
                }
                else
                {
                    SValue6ButtonBrush = Utils.greenButtonBrush;
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
                    SValue7ButtonBrush = Utils.redButtonBrush;
                }
                else
                {
                    SValue7ButtonBrush = Utils.greenButtonBrush;
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
                    SValue8ButtonBrush = Utils.redButtonBrush;
                }
                else
                {
                    SValue8ButtonBrush = Utils.greenButtonBrush;
                }
            }
        }

        #endregion
    }
}
