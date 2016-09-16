using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tango_Down
{
    class autoclicker
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

        int _cost;
        public int cost
        {
            get { return _cost; }
            set { _cost = value; }
        }

    }
}
