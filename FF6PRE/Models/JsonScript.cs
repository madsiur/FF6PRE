using System;
using System.Collections.Generic;
using System.Text;

namespace FF6PRE.Models
{
    public class JsonScript
    {
        public string Name { get; set; }
        public Dictionary<string, string> Title { get; set; }
        public IList<JsonAnimation>? Animations { get; set; }
        public Dictionary<string, int>? SystemFlag { get; set; }
        public IList<JsonSegments> Segments { get; set; }
        public IList<string>? ScriptLocal { get; set; }
        public IList<int>? ScriptLocalValue { get; set; }
        public IList<JsonMnemonic> Mnemonics { get; set; }

        public JsonScript()
        {

        }
    }

    public class JsonAnimation
    {
        public string name { get; set; }
        public float play_speed { get; set; }
        public int play_mode { get; set; }
        public bool is_reverse { get; set; }
        public string? next_anim_name { get; set; }
        public IList<JsonFrame>? frames { get; set; }
    }

    public class JsonFrame
    {
        public string? sprite_name { get; set; }
        public float offsetx { get; set; }
        public float offsety { get; set; }
        public float alpha { get; set; }
        public bool flip { get; set; }
        public Dictionary<string, float> rgb { get; set; }
    }

    public class JsonSegments
    {
        public string Label { get; set; }
        public int EntryPoint { get; set; }
        public int Count { get; set; }
    }

    public class JsonMnemonic
    {
        public string label { get; set; }
        public string mnemonic { get; set; }
        public int type { get; set; }
        public string comment { get; set; }
        public JsonOperands operands { get; set; }

        public JsonMnemonic(string label, string mnemonic, int type, string comment, JsonOperands operands)
        {
            this.label = label;
            this.mnemonic = mnemonic;
            this.type = type;
            this.comment = comment;
            this.operands = operands;
        }

        public JsonMnemonic()
        {

        }
    }

    public class JsonOperands
    {
        public IList<int>? iValues { get; set; }
        public IList<float>? rValues { get; set; }
        public IList<string>? sValues { get; set; }

        public JsonOperands()
        {

        }
    }
}
