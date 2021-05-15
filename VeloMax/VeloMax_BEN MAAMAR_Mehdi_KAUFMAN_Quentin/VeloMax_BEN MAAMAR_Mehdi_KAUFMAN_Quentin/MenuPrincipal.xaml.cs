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

//menuprincipal.xaml.cs
namespace VeloMax_BEN_MAAMAR_Mehdi_KAUFMAN_Quentin
{
    //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    //Lire dans l'ordre suivant : MainWindow.xaml.cs -> MenuPrincipal.saml.cs -> Stock.xaml.cs -> Statistiques.xaml.cs
    //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    /// <summary>
    /// Logique d'interaction pour MenuPrincipal.xaml
    /// </summary>
    public partial class MenuPrincipal : Page
    {
        VeloMax velomax;
        //Dans menu principal, on a accès a un tutoriel vidéo
        public MenuPrincipal(MySqlConnection connection, VeloMax velomax)
        {
            this.velomax = velomax;
            InitializeComponent();
            video.Visibility = Visibility.Visible;
            video.Play();
            butPause.Visibility = Visibility.Visible;
            //Par défaut on lance la vidéo
        }


        public void touche(Key touche, string source)
        {
            if (Keyboard.IsKeyToggled(touche))
            {
                video.Stop();
                video.Source = new Uri(source, UriKind.Relative);
                video.Play();
            }
            //cette fonction permet de changer la source de la vidéo lorsque l'on appuie sur une touche du clavier
        }





        private void play(object sender, RoutedEventArgs e)
        {

            video.Play();
            butPlay.Visibility = Visibility.Collapsed;
            butPause.Visibility = Visibility.Visible;



            //Lorsque l'on appuie sur le bouton play,
            //On lance la video, on fait disparaitre le bouton play 
            //et on fait apparaitre le bouton pause
        }

        private void pause(object sender, RoutedEventArgs e)
        {

            video.Pause();
            butPlay.Visibility = Visibility.Visible;
            butPause.Visibility = Visibility.Collapsed;
            //Fait l'inverse du bouton play

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
            butPause.Visibility = Visibility.Visible;
            //Cette fonction permet de prendre en compte le changement de source vidéo, elle appelle la fonction touche
            //Le changement de source de video est important car on doit pouvoir changer de tutoriel 
            //en appuyant sur une touche donc à une touche, on associe une video qui correspond à un tutoriel
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

            //test de fonction pour changer la source de la video au seul appuie d'une touche 
            //cela n'a pas fonctionné

        }

    }
}
