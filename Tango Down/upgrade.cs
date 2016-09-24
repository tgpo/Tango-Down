using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Tango_Down
{
    class upgrade : INotifyPropertyChanged
    {
        string _name;
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        double _cost;
        public double cost
        {
            get { return _cost; }
            set
            {
                _cost = Math.Ceiling(value);
                formattedcost = MainWindow.formatnumber(_cost);
            }
        }

        double _clickspersecondincrease;
        public double clickspersecondincrease
        {
            get { return _clickspersecondincrease; }
            set
            {
                _clickspersecondincrease = value;
            }
        }

        string _formattedcost;
        public string formattedcost
        {
            get { return _formattedcost; }
            set { _formattedcost = value; }
        }

        string _autoclickertarget;
        public string autoclickertarget
        {
            get { return _autoclickertarget; }
            set { _autoclickertarget = value; }
        }

        Visibility _visibility;
        public Visibility visibility
        {
            get { return _visibility; }
            set { _visibility = value; OnPropertyChanged("visibility"); }
        }

        double _amounttounlock;
        public double amounttounlock
        {
            get { return _amounttounlock; }
            set { _amounttounlock = value; }
        }

        protected virtual void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public upgrade(string name, double cost, string target, double clickspersecondincrease, double amounttounlock)
        {
            this.name = name;
            this.cost = cost;
            this.autoclickertarget = target;
            this.clickspersecondincrease = clickspersecondincrease;
            this.amounttounlock = amounttounlock;
            this.visibility = Visibility.Hidden;
        }
    }
}
