using FF6PRE.MVVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace FF6PRE.Models
{
    public class Mnemonic
    {
        public int Id { get; set; }

        public string Label { get; set; }

        public string MnemonicName { get; set; }

        public int Type { get; set; }

        public string Comment { get; set; }

        public JsonOperands Operands { get; set; }

        public string Description { get; set; }

        public Mnemonic(int id, string label, string mnemonicName, int type, string comment, JsonOperands jsonOperands)
        {
            this.Id = id;
            this.Label = label;
            this.MnemonicName = mnemonicName;
            this.Type = type;
            this.Comment = comment;
            this.Operands = jsonOperands;
            Description = string.Empty;
        }

        public void buildDescription()
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
