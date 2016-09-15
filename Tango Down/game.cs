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
        double _servercount;
        public double servercount
        {
            get { return _servercount; }
            set {
                _servercount = value;
                servercountstring = value + " Servers Taken Down";
                OnPropertyChanged("servercount");
            }
        }

        string _servercountstring;
        public string servercountstring
        {
            get { return _servercountstring; }
            set { _servercountstring = value; OnPropertyChanged("servercountstring"); }
        }

        double _clickspersecond;
        public double clickspersecond
        {
            get { return _clickspersecond; }
            set { _clickspersecond = value; OnPropertyChanged("clickspersecond"); }
        }

        protected virtual void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public game()
        {
            servercount = 0;
            clickspersecond = 0;
        }
    }
}
