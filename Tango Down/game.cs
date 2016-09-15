using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tango_Down
{
    class game : INotifyPropertyChanged
    {
        double _dbl_servercount;
        public double dbl_servercount
        {
            get { return _dbl_servercount; }
            set {
                _dbl_servercount = value;
                str_servercount = value + " Servers Taken Down";
                OnPropertyChanged("dbl_servercount");
            }
        }

        string _str_servercount;
        public string str_servercount
        {
            get { return _str_servercount; }
            set { _str_servercount = value; OnPropertyChanged("str_servercount"); }
        }

        double _dbl_cps;
        public double dbl_cps
        {
            get { return _dbl_cps; }
            set { _dbl_cps = value; OnPropertyChanged("dbl_cps"); }
        }

        protected virtual void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public game()
        {
            dbl_servercount = 0;
            dbl_cps = 0;
        }
    }
}
