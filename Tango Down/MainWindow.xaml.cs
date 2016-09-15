using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            lbl_servercount.DataContext = thisgame;
        }

        private void img_server_mousedown(object sender, MouseButtonEventArgs e)
        {
            thisgame.int_servercount++;
            thisgame.str_servercount = thisgame.int_servercount + " Servers Taken Down";
        }

    }
}
