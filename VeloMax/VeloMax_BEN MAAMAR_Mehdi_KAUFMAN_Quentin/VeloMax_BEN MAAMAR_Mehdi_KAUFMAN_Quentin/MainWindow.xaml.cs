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
using System.ComponentModel;
using MySql.Data.MySqlClient;
using System.Xml;
using System.Xml.XPath;
using System.IO;
using System.Xml.Serialization;


namespace VeloMax_BEN_MAAMAR_Mehdi_KAUFMAN_Quentin
{
    //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    //Lire dans l'ordre suivant : MainWindow.xaml.cs -> MenuPrincipal.saml.cs -> Stock.xaml.cs -> Statistiques.xaml.cs
    //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        VeloMax velomax = new VeloMax();
        MySqlConnection connection;
        string Mehdi = "SERVER=localhost;" + "PORT=3306;DATABASE=VeloMax;" + "UID=root;" + "PASSWORD=BDDMySQLD!d!2000;" + "SSLMODE=none;";
        string Quentin = "SERVER=localhost;PORT=3306;" + "DATABASE=VeloMax;" + "UID=root;PASSWORD=patate";
        //On déclare une connexion mySQL pour pouvoir avoir accès à la base SQL
        //On crée des user qui sont des string de connection à nos bdd SQL respectives 
        //cela permet de pouvoir tester le code malgrés les commit sur github
        public MainWindow()
        {
            InitializeComponent();
            connection = null;
            try
            {
                string connexionString = Quentin;
                connection = new MySqlConnection(connexionString);
            }
            catch (MySqlException e)
            {
                MessageBox.Show(" ErreurConnexion : " + e.ToString());
                return;
            }
            //On fait le try catch de la connexion SQL
        }

        #region BUTTON
        private void Menu_Principal(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new MenuPrincipal(connection, velomax);
            //Lorsque l'on clique sur le bouton menu principal, 
            //on créée une nouvelle page de type menu principal
        }
        
        private void Entree_Sortie(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new EntreeSortie(connection, velomax);
            //Lorsque l'on clique sur le bouton entrée-sortie, 
            //on créée une nouvelle page de type entrée-sortie
        }
        private void Stock(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Stock(connection, velomax);
            //Lorsque l'on clique sur le bouton stock, 
            //on créée une nouvelle page de type stock
        }
        private void Statistiques(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Statistiques(connection, velomax);
            //Lorsque l'on clique sur le bouton statistiques, 
            //on créée une nouvelle page de type statistiques
        }
        private void Quitter(object sender, RoutedEventArgs e)
        {
            //System.Environment.Exit(-1);
            //Pour fermer violemment
            this.Close();
        }
        #endregion

        private void lance_video(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new MenuPrincipal(connection, velomax);
            //Lorsque l'on clique sur le bouton statistiques, 
            //on créée une nouvelle page de type statistiques
            //cette instance est utilisée pour lancer le tutoriel
        }
    }
}


