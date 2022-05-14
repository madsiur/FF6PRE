using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FF6PRE.Models
{
    public class AiScript
    {
        public int id { get; set; }
        public string name { get; set; }
        public JsonScript script { get; set; }
        public List<Mnemonic> Mnemonics { get; set; }

        public string filePath { get; set; }

        public AiScript(int id, JsonScript script, string filePath)
        {
            this.id = id;
            this.script = script;
            this.filePath = filePath;
            name = script.Name.Split(".")[0];

            Mnemonics = new List<Mnemonic>();

            for (int i = 1; i <= script.Mnemonics.Count; i++)
            {
                JsonMnemonic m = script.Mnemonics[i - 1];
                Mnemonics.Add(new Mnemonic(i, m.label, m.mnemonic, m.type, m.comment, m.operands));
            }
        }

        public void save()
        {
            if (script.Segments != null)
            {
                script.Segments.Where(s => s.Label == "Main").First().Count = Mnemonics.Count;

                script.Mnemonics = new List<JsonMnemonic>();
                for (int i = 0; i < Mnemonics.Count; i++)
                {
                    script.Mnemonics.Add(new JsonMnemonic(Mnemonics[i].Label, Mnemonics[i].MnemonicName, Mnemonics[i].Type, Mnemonics[i].Comment, Mnemonics[i].Operands));
                }
            }
        }

        public void buildDescriptions()
        {
            foreach (var m in Mnemonics)
            {
                m.buildDescription();
            }
        }
    }
}
