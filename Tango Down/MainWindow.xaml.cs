using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tango_Down
{

    public partial class MainWindow : Window
    {
        game thisgame = new game();
        autoclicker cursor = new autoclicker();

        public MainWindow()
        {
            InitializeComponent();

            // Set Data Context for GUI
            lbl_servercount.DataContext = thisgame;
            lbl_cpscount.DataContext = thisgame;

            // Auto-Clicker Setup
            cursor.dbl_clickspersecond = .1;
            cursor.int_cost = 10;

            // Main Game Timer
            var myTimer = new System.Timers.Timer();
            myTimer.Elapsed += new ElapsedEventHandler(gametimer);
            myTimer.Interval = 1000;
            myTimer.Enabled = true;
        }

        private void gametimer(object source, ElapsedEventArgs e) {
            thisgame.dbl_servercount += thisgame.dbl_cps;
            Console.WriteLine(thisgame.dbl_cps);
        }

        private void img_server_mousedown(object sender, MouseButtonEventArgs e)
        {
            thisgame.dbl_servercount++;
        }

        private void img_autoclick_cursor_mousedown(object sender, MouseButtonEventArgs e)
        {
            if (thisgame.dbl_servercount >= cursor.int_cost)
            {
                thisgame.dbl_servercount -= cursor.int_cost;
                thisgame.dbl_cps += cursor.dbl_clickspersecond;
            }

            
        }
    }
}
