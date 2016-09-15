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
            cursor.clickspersecond = .1;
            cursor.cost = 10;

            // Main Game Timer
            var gametimer = new System.Timers.Timer();
            gametimer.Elapsed += new ElapsedEventHandler(coregameadvance);
            gametimer.Interval = 1000;
            gametimer.Enabled = true;
        }


        // Core game advance method
        // Gets called every second by the gametimer
        private void coregameadvance(object source, ElapsedEventArgs e)
        {
            thisgame.servercount += thisgame.clickspersecond;
        }


        // Click on Server Image
        private void img_server_mousedown(object sender, MouseButtonEventArgs e)
        {
            thisgame.servercount++;
        }


        // Click on Autoclick: Cursor
        private void img_autoclick_cursor_mousedown(object sender, MouseButtonEventArgs e)
        {
            if (thisgame.servercount >= cursor.cost)
            {
                thisgame.servercount -= cursor.cost;
                thisgame.clickspersecond += cursor.clickspersecond;

                // Round numbers to 3 decimal points
                thisgame.servercount = Math.Round(thisgame.servercount, 3, MidpointRounding.AwayFromZero);
                thisgame.clickspersecond = Math.Round(thisgame.clickspersecond, 3, MidpointRounding.AwayFromZero);
            }


        }
    }
}
