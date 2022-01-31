using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graWKosci3P
{
    public class Dice : INotifyPropertyChanged
    {
        private int _value;
        private bool _isSelected;
        public int Value
        {
            get => _value;
            set
            {
                _value = value;
                if(PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
                }
            }
        }
        public bool IsSelected { 
            get => _isSelected;
            set 
            { 
                _isSelected = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this,
                        new PropertyChangedEventArgs(nameof(IsSelected)));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
