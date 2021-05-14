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
using MySql.Data.MySqlClient;
using System.Xml;
using System.Xml.XPath;
using System.IO;
using System.Xml.Serialization;
using System.Data;

namespace VeloMax_BEN_MAAMAR_Mehdi_KAUFMAN_Quentin
{
    /// <summary>
    /// Logique d'interaction pour MenuPrincipal.xaml
    /// </summary>
    public partial class MenuPrincipal : Page
    {
        VeloMax velomax;
        public MenuPrincipal(MySqlConnection connection, VeloMax velomax)
        {
            this.velomax = velomax;
            InitializeComponent();
            video.Visibility = Visibility.Visible;
            video.Play();
            butPause.Visibility = Visibility.Visible;
        }

        private void play(object sender, RoutedEventArgs e)
        {
            video.Play();
            butPlay.Visibility = Visibility.Collapsed;
            butPause.Visibility = Visibility.Visible;
        }

        private void pause(object sender, RoutedEventArgs e)
        {
            video.Pause();
            butPlay.Visibility = Visibility.Visible;
            butPause.Visibility = Visibility.Collapsed;
        }
    }
}
