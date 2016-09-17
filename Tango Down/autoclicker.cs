using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tango_Down
{
    class autoclicker : INotifyPropertyChanged
    {
        string _name;
        public string name{
            get { return _name; }
            set { _name = value; }
        }

        double _clickspersecond;
        public double clickspersecond
        {
            get { return _clickspersecond; }
            set { _clickspersecond = Math.Round(value, 1, MidpointRounding.AwayFromZero); }
        }

        double _basecost;
        public double basecost
        {
            get { return _basecost; }
            set { _basecost = Math.Ceiling(value); }
        }

        double _cost;
        public double cost
        {
            get { return _cost; }
            set { _cost = Math.Ceiling(value); OnPropertyChanged("cost"); }
        }

        double _clickercount;
        public double clickercount
        {
            get { return _clickercount; }
            set { _clickercount = value; OnPropertyChanged("clickercount"); }
        }

        protected virtual void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public autoclicker()
        {

        }

    }
}
