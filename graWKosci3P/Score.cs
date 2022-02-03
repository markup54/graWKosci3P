using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graWKosci3P
{
    public class Score : NotifyPropertyChange
    {
        private string _name;
        //public string Name { get;set }
        private int _points;
        private bool _isSet;

        public Score(string name)
        {
            Name = name;
            Points = 0;
            IsSet = false;
        }

        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Points
        {
            get { return _points; }
            set { _points = value; 
                OnProperyChanged();
            }
        }
        public bool IsSet
        {
            get { return _isSet; }
            set { _isSet = value;
                OnProperyChanged();
            }
        }
    }
}
