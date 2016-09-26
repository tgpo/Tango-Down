using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            set { _clickspersecond = Math.Round(value, 2, MidpointRounding.AwayFromZero); }
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
            set {
                _cost = Math.Ceiling(value);
                formattedcost = MainWindow.formatnumber(_cost);
                OnPropertyChanged("cost");
            }
        }

        string _formattedcost;
        public string formattedcost
        {
            get { return _formattedcost; }
            set { _formattedcost = value; OnPropertyChanged("formattedcost"); }
        }

        double _clickercount;
        public double clickercount
        {
            get { return _clickercount; }
            set { _clickercount = value; OnPropertyChanged("clickercount"); }
        }

        Dictionary<string, upgrade> _upgrades;
        public Dictionary<string, upgrade> upgrades {
            get { return _upgrades; }
            set { _upgrades = value; OnPropertyChanged("upgrades"); }
        }

        public void apply(upgrade thisupgrade, game thisgame)
        {
            // Deduct cost
            thisgame.servercount -= thisupgrade.cost;

            // Add to active upgrade list
            thisgame.activeupgrades.Add(thisupgrade.name, thisupgrade);

            // Up the CPS for the autoclicker
            this.clickspersecond = this.clickspersecond * thisupgrade.clickspersecondincrease;

            // Hide the upgrade
            thisupgrade.visibility = Visibility.Hidden;
        }

        public void unlock(upgrade thisupgrade)
        {
            // Show the upgrade
            thisupgrade.visibility = Visibility.Visible;
            thisupgrade.purchased = true;
        }

        public void unlockcheck()
        {
            foreach (var item in upgrades)
            {
                upgrade thisupgrade = (upgrade)item.Value;

                if (thisupgrade.amounttounlock <= clickercount && !thisupgrade.purchased)
                {
                    unlock(thisupgrade);
                }
            }
        }

        protected virtual void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public autoclicker()
        {
            upgrades = new Dictionary<string, upgrade>();
           
        }

    }
}
