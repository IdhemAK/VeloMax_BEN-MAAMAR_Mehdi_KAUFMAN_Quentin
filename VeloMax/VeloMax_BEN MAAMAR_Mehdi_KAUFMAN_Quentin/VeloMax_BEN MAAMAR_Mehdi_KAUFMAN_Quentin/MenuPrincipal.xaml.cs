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

        public void touche(Key touche, string source)
        {
            if (Keyboard.IsKeyToggled(touche))
            {
                video.Stop();
                video.Source = new Uri(source, UriKind.Relative);
                video.Play();
            }
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

        private void refresh(object sender, RoutedEventArgs e)
        {
            video.Stop();
            touche(Key.A, "video1.mp4");
            touche(Key.B, "video2.mp4");
            touche(Key.C, "video3.mp4");
            touche(Key.D, "video4.mp4");
            touche(Key.E, "video5.mp4");
            video.Play();
            butPlay.Visibility = Visibility.Collapsed;
        }
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.A && Keyboard.Modifiers == ModifierKeys.Control)
            {
                video.Stop();
                video.Source = new Uri("video1.mp4", UriKind.Relative);
                video.Play();
                e.Handled = true;
            }
            if (e.Key == Key.B && Keyboard.Modifiers == ModifierKeys.Control)
            {
                video.Stop();
                video.Source = new Uri("video2.mp4", UriKind.Relative);
                video.Play();
                e.Handled = true;
            }
            if (e.Key == Key.C && Keyboard.Modifiers == ModifierKeys.Control)
            {
                video.Stop();
                video.Source = new Uri("video3.mp4", UriKind.Relative);
                video.Play();
                e.Handled = true;
            }
            if (e.Key == Key.D && Keyboard.Modifiers == ModifierKeys.Control)
            {
                video.Stop();
                video.Source = new Uri("video4.mp4", UriKind.Relative);
                video.Play();
                e.Handled = true;
            }
            if (e.Key == Key.E && Keyboard.Modifiers == ModifierKeys.Control)
            {
                video.Stop();
                video.Source = new Uri("video5.mp4", UriKind.Relative);
                video.Play();
                e.Handled = true;
            }



        }

    }
}
