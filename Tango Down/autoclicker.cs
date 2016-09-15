using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tango_Down
{
    class autoclicker
    {
        string _str_name;
        public string str_name{
            get { return _str_name; }
            set { _str_name = value; }
        }

        double _dbl_clickspersecond;
        public double dbl_clickspersecond
        {
            get { return _dbl_clickspersecond; }
            set { _dbl_clickspersecond = value; }
        }

        int _int_cost;
        public int int_cost
        {
            get { return _int_cost; }
            set { _int_cost = value; }
        }

    }
}
