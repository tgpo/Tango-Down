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

        int _int_clickspersecond;
        public int int_clickspersecond
        {
            get { return _int_clickspersecond; }
            set { _int_clickspersecond = value; }
        }

        int _int_cost;
        public int int_cost
        {
            get { return _int_cost; }
            set { _int_cost = value; }
        }

    }
}
