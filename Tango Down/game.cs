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
        int _int_servercount;
        public int int_servercount
        {
            get { return _int_servercount; }
            set { _int_servercount = value; OnPropertyChanged("int_servercount"); }
        }

        string _str_servercount;
        public string str_servercount
        {
            get { return _str_servercount; }
            set { _str_servercount = value; OnPropertyChanged("str_servercount"); }
        }

        int _int_cps;
        public int int_cps
        {
            get { return _int_cps; }
            set { _int_cps = value; OnPropertyChanged("int_cps"); }
        }

        protected virtual void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public game()
        {
            int_servercount = 0;
            str_servercount = int_servercount + " Servers Taken Down";
            int_cps = 0;
        }
    }
}
