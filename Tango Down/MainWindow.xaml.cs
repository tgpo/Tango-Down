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
        autoclicker ti83 = new autoclicker();

        int autosaveinterval = 60;

        public MainWindow()
        {
            InitializeComponent();

            // Auto-Clicker Setup
            setupautoclickers();

            // Upgrades Setup
            setupupgrades();

            // Set Data Context for GUI
            setupguidatacontext();

            loadgame();

            // Main Game Timer
            var gametimer = new System.Timers.Timer();
            gametimer.Elapsed += new ElapsedEventHandler(coregameadvance);
            gametimer.Interval = 1000;
            gametimer.Enabled = true;

        }


        // Save game state to property settings
        public void savegame()
        {
            Properties.Settings.Default.servercount = thisgame.servercount;
            Properties.Settings.Default.clickspersecond = thisgame.clickspersecond;
            Properties.Settings.Default.cursorcost = cursor.cost;
            Properties.Settings.Default.cursorcount = cursor.clickercount;
            Properties.Settings.Default.ti83cost = ti83.cost;
            Properties.Settings.Default.ti83count = ti83.clickercount;
            Properties.Settings.Default.Save();
        }


        // Save game state to property settings
        public void resetgame()
        {
            Properties.Settings.Default.servercount = 50000000;
            Properties.Settings.Default.clickspersecond = 0;
            Properties.Settings.Default.cursorcost = cursor.basecost;
            Properties.Settings.Default.cursorcount = 0;
            Properties.Settings.Default.ti83cost = ti83.basecost;
            Properties.Settings.Default.ti83count = 0;
            Properties.Settings.Default.Save();

            thisgame.servercount = 0;
            thisgame.clickspersecond = 0;
            cursor.cost = cursor.basecost;
            cursor.clickercount = 0;
            ti83.cost = ti83.basecost;
            ti83.clickercount = 0;

        }


        // Check if it's time to auto save the game
        public void autosave()
        {

            if (autosaveinterval > 0)
            {
                autosaveinterval--;
            }
            else
            {
                savegame();
                autosaveinterval = 60;
            }

        }


        // Load game state from property settings
        public void loadgame()
        {
            thisgame.servercount = Properties.Settings.Default.servercount;
            thisgame.clickspersecond = Properties.Settings.Default.clickspersecond;
            cursor.clickercount = Properties.Settings.Default.cursorcount;
            ti83.clickercount = Properties.Settings.Default.ti83count;

            if (Properties.Settings.Default.cursorcost > 0)
            {
                cursor.cost = Properties.Settings.Default.cursorcost;
            }

            if (Properties.Settings.Default.ti83cost > 0)
            {
                ti83.cost = Properties.Settings.Default.ti83cost;
            }

        }


        // Setup GUI Data Contexts for Binding
        private void setupguidatacontext()
        {
            lbl_servercount.DataContext = thisgame;
            lbl_cpscount.DataContext = thisgame;
            lbl_cursorbuyfactor.DataContext = thisgame;
            lbl_ti83buyfactor.DataContext = thisgame;

            lbl_cursorcount.DataContext = cursor;
            lbl_cursorcost.DataContext = cursor;

            upgrades.ItemsSource = thisgame.unlockedupgrades;

            lbl_ti83count.DataContext = ti83;
            lbl_ti83cost.DataContext = ti83;
        }


        // Setup Autoclicker base data
        private void setupautoclickers()
        {
            cursor.clickspersecond = .1;
            cursor.cost = 15;
            cursor.basecost = 15;

            ti83.clickspersecond = 1;
            ti83.cost = 100;
            ti83.basecost = 100;

            thisgame.controls.Add("cursor", cursor);
            thisgame.controls.Add("ti83", ti83);
        }


        // Setup Upgrade base data
        private void setupupgrades()
        {
            // Lookup Name, Upgrade Name, Cost, Autoclicker to apply to, CPS multiplyer, # needed to uplock, iconfile
            cursor.upgrades.Add("upgrade_cursor_1", new upgrade("upgrade_cursor_1", 25, "cursor", 2, 1, "/resources/upgrades/cursor/cursor-blue.gif"));
            cursor.upgrades.Add("upgrade_cursor_2", new upgrade("upgrade_cursor_2", 50, "cursor", 2, 10, "/resources/upgrades/cursor/cursor-green.gif"));

        }


        // Recalculate our Clicks Per Second
        public void recalculatecps()
        {
            double clickspersecond = 0;

            // Loop through all autoclickers
            foreach (var item in thisgame.controls)
            {
                autoclicker thisclicker = (autoclicker)item.Value;

                if(thisclicker.clickercount > 0)
                {
                    clickspersecond += thisclicker.clickspersecond * thisclicker.clickercount;
                }
            }

            // Reset the game Clicker Per Second
            thisgame.clickspersecond = clickspersecond;

        }


        public static string formatnumber(double number)
        {
            string[] numberscales = { "", " million", " billion", " trillion", " quadrillion", " quintillion", " sextillion", " septillion", " octillion", " nonillion", " decillion", " undecillion", " duodecillion", " tredecillion", " quattuordecillion", " quindecillion" };

            if (number >= 1000000 && !double.IsInfinity(number) && !double.IsNaN(number) )
            {
                int cnt = 0;

                number /= 1000;
                while (Math.Round(number) >= 1000)
                {
                    number /= 1000;
                    cnt++;
                }

                string notationValue = numberscales[cnt];
                return Math.Round((Math.Round(number * 1000) / 1000), 3) + notationValue;
            }

            return number.ToString();
        }


        // Calculate cost based on base cost and # of clickers owned
        private double recalculatecost(double cost, double clickercount)
        {
            double returnvalue = 0;

            if (thisgame.buyfactor > 1)
            {
                for (int i = 0; i < (clickercount + thisgame.buyfactor); i++)
                {
                    cost = cost * 1.15;
                    returnvalue += cost;
                }
            }
            else
            {
                for (int i = 0; i < clickercount; i++)
                {
                    cost *= 1.15;
                }

                returnvalue = cost;
            }

            return returnvalue;
        }


        // Recalculate costs for all autoclickers
        private void recalculateallcosts()
        {
            cursor.cost = recalculatecost(cursor.basecost, cursor.clickercount);
            ti83.cost = recalculatecost(ti83.basecost, ti83.clickercount);
        }


        // Hide / Show "10x" or "100x" beside autoclicker cost
        private void setbuyfactorlabelvisibility()
        {
            if (thisgame.buyfactor > 1)
            {
                thisgame.buyfactorvisibility = Visibility.Visible;
            }
            else
            {
                thisgame.buyfactorvisibility = Visibility.Hidden;
            }

        }


        // Core game advance method
        // Gets called every second by the gametimer
        private void coregameadvance(object source, ElapsedEventArgs e)
        {
            autosave();
            thisgame.servercount += thisgame.clickspersecond;
        }


        #region Click Events

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
                autoclickerclicked.clickercount += thisgame.buyfactor;

                // Increase CPS
                thisgame.clickspersecond += autoclickerclicked.clickspersecond * thisgame.buyfactor;

                // Increase cost
                autoclickerclicked.cost = recalculatecost(autoclickerclicked.basecost, autoclickerclicked.clickercount);

                // Check for Unlocked Upgrades
                autoclickerclicked.unlockcheck(thisgame);

            }

        }


        // Buy Factor Clicked
        private void buyfactor_mousedown(object sender, MouseButtonEventArgs e)
        {
            // Read tag property to determine which buyfactor was clicked
            thisgame.buyfactor = Int32.Parse((dynamic)((Label)sender).Tag);

            recalculateallcosts();
            setbuyfactorlabelvisibility();
        }


        // Reset Game Clicked
        private void lbl_resetgame_mousedown(object sender, MouseButtonEventArgs e)
        {
            resetgame();

        }


        // TODO: Make upgrade % cumulative.
        // Upgrade Clicked
        private void img_upgrade_mousedown(object sender, MouseButtonEventArgs e)
        {

            string upgradetag = (dynamic)((Image)sender).Tag;
            String[] upgradetagdata = upgradetag.Split('/');

            autoclicker thisautoclicker = (autoclicker)thisgame.controls[upgradetagdata[0]];
            upgrade thisupgrade = thisautoclicker.upgrades[upgradetagdata[1]];

            // Ensure user has enough money to purchase upgrade
            if (thisgame.servercount >= thisupgrade.cost)
            {

                // Apply Upgrade
                thisautoclicker.apply(thisupgrade, thisgame);

                // Recalculate the game's clicks per second
                recalculatecps();
            }

        }
       

        #endregion
    }
}
