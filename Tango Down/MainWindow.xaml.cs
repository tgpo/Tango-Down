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
            lbl_cursorcount.DataContext = cursor;
            lbl_cursorcost.DataContext = cursor;

            // Auto-Clicker Setup
            cursor.clickspersecond = .1;
            cursor.cost = 15;

            thisgame.controls.Add("cursor",cursor);

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

        // Click on Autoclick
        private void img_autoclick_mousedown(object sender, MouseButtonEventArgs e)
        {
            // Read tag property to determine which autoclicker was clicked
            // Find object with tag property value
            var autoclickerclicked = thisgame.controls[(dynamic)((Image)sender).Tag];

            if (thisgame.servercount >= autoclickerclicked.cost)
            {
                // Deduct cost. Gotta pay the man first.
                thisgame.servercount -= autoclickerclicked.cost;

                // Increase clicker count
                autoclickerclicked.clickercount++;
                
                // Increase CPS
                thisgame.clickspersecond += autoclickerclicked.clickspersecond;

                // Increase cost
                autoclickerclicked.cost = autoclickerclicked.cost * 1.15;

            }


        }
    }
}
