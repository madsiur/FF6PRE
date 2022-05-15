using System;
using System.Collections.Generic;
using System.Text;

namespace FF6PRE
{
    public static class Enums
    {
        public enum OperandType
        {
            INT,
            FLOAT
        };

        public enum AiMnemonic
        {
            Act = 1,
            CounterAct = 2,
            CounterActAll = 3,
            CounterActReceiveCommand = 4,
            FinalAttackAct = 5,
            FirstAttackAct = 6,
            Other = 7
        };
    }
}
