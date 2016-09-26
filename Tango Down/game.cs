using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tango_Down
{
    class game : INotifyPropertyChanged
    {

        double _servercount;
        public double servercount
        {
            get { return _servercount; }
            set {
                _servercount = Math.Round(value, 3, MidpointRounding.AwayFromZero);
                servercountstring = MainWindow.formatnumber(_servercount) + " Servers Taken Down";
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
            set { _clickspersecond = Math.Round(value, 1, MidpointRounding.AwayFromZero); OnPropertyChanged("clickspersecond"); }
        }

        int _buyfactor;
        public int buyfactor
        {
            get { return _buyfactor; }
            set {
                _buyfactor = value;
                buyfactorxcount = "x" + _buyfactor;
                OnPropertyChanged("buyfactor"); }
        }

        string _buyfactorxcount;
        public string buyfactorxcount
        {
            get { return _buyfactorxcount; }
            set { _buyfactorxcount = value; OnPropertyChanged("buyfactorxcount"); }
        }

        Visibility _buyfactorvisibility;
        public Visibility buyfactorvisibility
        {
            get { return _buyfactorvisibility; }
            set { _buyfactorvisibility = value; OnPropertyChanged("buyfactorvisibility"); }
        }

        public Dictionary<string, Object> controls { get; set; }
        public Dictionary<string, Object> activeupgrades { get; set; }

        protected virtual void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public game()
        {
            controls = new Dictionary<string, Object>();
            activeupgrades = new Dictionary<string, Object>();
            servercount = 0;
            clickspersecond = 0;
            buyfactor = 1;
            buyfactorvisibility = Visibility.Hidden;
        }
    }
}
