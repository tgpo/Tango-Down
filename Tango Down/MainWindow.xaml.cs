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

        public MainWindow()
        {
            InitializeComponent();

            // Set Data Context for GUI
            lbl_servercount.DataContext = thisgame;
            lbl_cpscount.DataContext = thisgame;

            // Main Game Timer
            var myTimer = new System.Timers.Timer();
            // Tell the timer what to do when it elapses
            myTimer.Elapsed += new ElapsedEventHandler(gametimer);
            // Set it to go off every second
            myTimer.Interval = 1000;
            // And start it        
            myTimer.Enabled = true;
        }

        private void gametimer(object source, ElapsedEventArgs e) {
            thisgame.int_servercount += thisgame.int_cps;
            thisgame.str_servercount = thisgame.int_servercount + " Servers Taken Down";

            Console.WriteLine(thisgame.str_servercount);
        }

        private void img_server_mousedown(object sender, MouseButtonEventArgs e)
        {
            thisgame.int_servercount++;
            thisgame.str_servercount = thisgame.int_servercount + " Servers Taken Down";
        }

        private void img_autoclick_cursor_mousedown(object sender, MouseButtonEventArgs e)
        {
            autoclicker cursor = new autoclicker();
            cursor.int_clickspersecond = 1;

            thisgame.int_cps += cursor.int_clickspersecond;
        }
    }
}
