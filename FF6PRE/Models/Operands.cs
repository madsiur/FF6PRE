using FF6PRE.MVVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace FF6PRE.Models
{
    public class Operands: ObservableObject
    {
        public List<int>? _iValues;
        public List<int>? IValues
        {
            get { return _iValues; }
            set { OnPropertyChanged(ref _iValues, value); }
        }

        public List<float>? _rValues;
        public List<float>? RValues
        {
            get { return _rValues; }
            set { OnPropertyChanged(ref _rValues, value); }
        }

        public List<string>? _sValues;
        public List<string>? SValues
        {
            get { return _sValues; }
            set { OnPropertyChanged(ref _sValues, value); }
        }

        public Operands(JsonOperands jsonOperands)
        {
            if (jsonOperands == null)
            {
                IValues = null;
                RValues = null;
                SValues = null;
            }
            else
            {
                IValues = (List<int>?)jsonOperands.iValues;
                RValues = (List<float>?)jsonOperands.rValues;
                SValues = (List<string>?)jsonOperands.sValues;
            }
        }
    }
}
