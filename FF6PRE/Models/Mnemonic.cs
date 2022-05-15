using FF6PRE.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static FF6PRE.Enums;

namespace FF6PRE.Models
{
    public class Mnemonic
    {
        public int Id { get; set; }

        public string Label { get; set; }

        public string MnemonicName { get; set; }

        public AiMnemonic AiMnemon { get; set; }

        public int Type { get; set; }

        public string Comment { get; set; }

        public JsonOperands Operands { get; set; }

        public string Description { get; set; }

        public Mnemonic()
        {

        }

        public Mnemonic(int id, string label, string mnemonicName, int type, string comment, JsonOperands jsonOperands)
        {
            this.Id = id;
            this.Label = label;
            this.MnemonicName = mnemonicName;
            this.Type = type;
            this.Comment = comment;
            this.Operands = jsonOperands;
            Description = string.Empty;
            AiMnemon = getAiMnemonic();
        }

        public Mnemonic(int id, string label, string mnemonicName, int type, string comment)
        {
            this.Id = id;
            this.Label = label;
            this.MnemonicName = mnemonicName;
            this.Type = type;
            this.Comment = comment;
            this.Operands = new JsonOperands();
            this.Operands.iValues = new List<int>();
            this.Operands.rValues = new List<float>();
            this.Operands.sValues = new List<string>();
            Description = string.Empty;
            AiMnemon = getAiMnemonic();
        }

        private AiMnemonic getAiMnemonic()
        {
            foreach (string aim in Enum.GetNames(typeof(AiMnemonic)))
            {
                if (MnemonicName == aim)
                {
                    return (AiMnemonic)Enum.Parse(typeof(AiMnemonic), aim);
                }
            }
            return AiMnemonic.Other;
        }

        public void fillValues()
        {
            for(int i = 0; i < 8; i++)
            {
                this.Operands.iValues.Add(0);
                this.Operands.rValues.Add(0);
                this.Operands.sValues.Add(string.Empty);
            }
        }

        public void buildDescription()
        {
            Description = string.Empty;

            if (Utils.isActMnemonic(this))
            {
                buildActDescription();
            }
            else
            {
                if (Operands != null)
                {
                    if (Operands.iValues != null)
                    {
                        string strIVals = string.Empty;
                        for (int i = 0; i < Operands.iValues.Count; i++)
                        {
                            if (Operands.iValues[i] != 0)
                            {
                                if (strIVals == string.Empty)
                                {
                                    strIVals += "i" + (i + 1).ToString() + ": " + Operands.iValues[i].ToString();
                                }
                                else
                                {
                                    strIVals += ", i" + (i + 1).ToString() + ": " + Operands.iValues[i].ToString();
                                }
                            }
                        }
                        Description = strIVals;
                    }

                    if (Operands.rValues != null)
                    {
                        string strRVals = string.Empty;
                        for (int i = 0; i < Operands.rValues.Count; i++)
                        {
                            if (Operands.rValues[i] != 0)
                            {
                                if (strRVals == string.Empty)
                                {
                                    strRVals += "r" + (i + 1).ToString() + ": " + Operands.rValues[i].ToString();
                                }
                                else
                                {
                                    strRVals += ", r" + (i + 1).ToString() + ": " + Operands.rValues[i].ToString();
                                }
                            }
                        }

                        if (strRVals != string.Empty)
                        {
                            if (Description != string.Empty)
                            {
                                Description += ", ";
                            }
                            Description += strRVals;
                        }
                    }

                    if (Operands.sValues != null)
                    {
                        string strSVals = string.Empty;
                        for (int i = 0; i < Operands.sValues.Count; i++)
                        {
                            if (Operands.sValues[i] != string.Empty)
                            {
                                if (strSVals == string.Empty)
                                {
                                    strSVals += "s" + (i + 1).ToString() + ": " + Operands.sValues[i];
                                }
                                else
                                {
                                    strSVals += ", s" + (i + 1).ToString() + ": " + Operands.sValues[i];
                                }
                            }
                        }

                        if (strSVals != string.Empty)
                        {
                            if (Description != string.Empty)
                            {
                                Description += ", ";
                            }
                            Description += strSVals;
                        }
                    }
                }
            }
        }

        private void buildActDescription()
        {
            if (Operands != null)
            {
                if (Operands.iValues != null && Operands.rValues != null &&
                    Operands.iValues.Count == Operands.rValues.Count)
                {
                    if (Operands.iValues.Count > 0)
                    {
                        for (int i = 0; i < Operands.iValues.Count - 1; i++)
                        {
                            if (Operands.iValues[i] != 0)
                            {
                                Description += getActDesc(i) + ", ";
                            }
                        }
                        if (Operands.iValues[Operands.iValues.Count - 1] != 0)
                        {
                            Description += getActDesc(Operands.iValues.Count - 1);
                        }
                    }
                }
                else
                {
                    Description = "Cannot build description, mismatch between iValues and rValues";
                }
            }
        }
        private string getActDesc(int index)
        {
            string[] arr = Utils.AbilityKeyValues.Where(x => x.Key == Operands.iValues[index]).First().Value.Split(' ');
            string name = string.Empty;
            if (arr.Length > 2)
            {
                for (int j = 2; j < arr.Length - 1; j++)
                {
                    name += arr[j] + " ";
                }
                name += arr[arr.Length - 1];
            }
            return name + " " + Operands.rValues[index].ToString() + "%";
        }
    }
}
