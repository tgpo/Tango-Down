using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tango_Down
{
    class upgrade
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

        public upgrade(string name, double cost, string target, double clickspersecondincrease)
        {
            this.name = name;
            this.cost = cost;
            this.autoclickertarget = target;
            this.clickspersecondincrease = clickspersecondincrease;
        }
    }
}
