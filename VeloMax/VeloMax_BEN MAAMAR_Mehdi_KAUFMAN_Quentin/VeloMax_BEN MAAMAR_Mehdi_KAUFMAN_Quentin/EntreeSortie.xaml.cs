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
    /// Logique d'interaction pour EntreeSortie.xaml
    /// </summary>
    public partial class EntreeSortie : Page
    {
        MySqlConnection connection;
        VeloMax velomax;

        

        bool isVelo;
        bool isPiece;
        bool isCommande;
        bool isFournisseur;
        bool isClient;
        bool isClient_entreprise;
        bool isClient_particulier;
        bool[] isTab;


        public EntreeSortie(MySqlConnection connection, VeloMax velomax)
        {
            this.connection = connection;
            this.velomax = velomax;
            
            InitializeComponent();

            Entreprises.Visibility = Visibility.Collapsed;
            Particuliers.Visibility = Visibility.Collapsed;

            isVelo = false;
            isPiece = false;
            isCommande = false;
            isFournisseur = false;
            isClient = false;
            isClient_entreprise = false;
            isClient_particulier = false;

            isTab = new bool[] { isVelo , isPiece, isCommande, isFournisseur,
                isClient, isClient_entreprise, isClient_particulier };
            /*
            MySqlDataReader reader = commande.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            reader.Close();
            */
        }

        public void Visibilities()
        {
            //testDataGrid.Columns["AddToCartButton"].Frozen = true;
        }

        public void IsTableChecking(int index)  //index du tableau isTab
        {
            for(int i = 0; i < isTab.Length; i++)
            {
                isTab[i] =  i == index ? false : true;
            }
        }

        private void Creer(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Reprise");
            //DataRowView rowview = testDataGrid.SelectedItem as DataRowView;
            DataRowView rowview = IODataGrid.SelectedItem as DataRowView;
            if(rowview == null)
            {
                MessageBox.Show("NULL DATAGRID NULL !!");
            }

            //rowview.Row.

            if(isVelo == true)
            {

            }
            else if(isPiece == true)
            {

            }
            else if(isCommande == true)
            {

            }
            else if(isFournisseur == true)
            {

            }
            else if(isClient_entreprise == true)
            {

            }
            else if(isClient_particulier == true)
            {

            }


            string test = null;
            string id = rowview.Row[0].ToString();
            foreach (object row in rowview.Row.ItemArray)
            {
                test += row + " ";
            }

            MessageBox.Show(test);
            //Entreprises.IsChecked == true;
        }

        private void Velo(object sender, RoutedEventArgs e)
        {
            isCommande = false;
            isClient = false;
            Entreprises.IsChecked = false;
            Particuliers.IsChecked = false;
            Entreprises.Visibility = Visibility.Collapsed;
            Particuliers.Visibility = Visibility.Collapsed;

            DataTable particuliers = velomax.dataLoader(connection, velomax.GetVelo);
            IODataGrid.ItemsSource = particuliers.DefaultView;
        }

        private void Piece(object sender, RoutedEventArgs e)
        {
            isCommande = false;
            isClient = false;
            Entreprises.IsChecked = false;
            Particuliers.IsChecked = false;
            Entreprises.Visibility = Visibility.Collapsed;
            Particuliers.Visibility = Visibility.Collapsed;

            DataTable particuliers = velomax.dataLoader(connection, velomax.GetPiece);
            IODataGrid.ItemsSource = particuliers.DefaultView;
        }

        private void Fournisseur(object sender, RoutedEventArgs e)
        {
            isCommande = false;
            isClient = false;
            Entreprises.IsChecked = false;
            Particuliers.IsChecked = false;
            Entreprises.Visibility = Visibility.Collapsed;
            Particuliers.Visibility = Visibility.Collapsed;

            DataTable particuliers = velomax.dataLoader(connection, velomax.GetFournisseur);
            IODataGrid.ItemsSource = particuliers.DefaultView;
            IsTableChecking(3);
        }

        private void Commande(object sender, RoutedEventArgs e)
        {
            isCommande = true;
            isClient = false;
            Entreprises.Visibility = Visibility.Visible;
            Particuliers.Visibility = Visibility.Visible;
            Entreprises.IsChecked = false;
            Particuliers.IsChecked = false;
            IODataGrid.ItemsSource = null;
        }

        private void Client(object sender, RoutedEventArgs e)
        {
            isCommande = false;
            isClient = true;
            Entreprises.Visibility = Visibility.Visible;
            Particuliers.Visibility = Visibility.Visible;
            Entreprises.IsChecked = false;
            Particuliers.IsChecked = false;
            IODataGrid.ItemsSource = null;
        }

        private void Entreprises_Checked(object sender, RoutedEventArgs e)
        {
            if (isCommande == true)
            {
                Particuliers.IsChecked = false;
                DataTable commandes = velomax.dataLoader(connection, velomax.GetCommande_entreprise);
                IODataGrid.ItemsSource = commandes.DefaultView;
            }
            else if (isClient == true)
            {
                Particuliers.IsChecked = false;
                DataTable particuliers = velomax.dataLoader(connection, velomax.GetClient_entreprise);
                IODataGrid.ItemsSource = particuliers.DefaultView;
            }
        }

        private void Particuliers_Checked(object sender, RoutedEventArgs e)
        {
            if (isCommande == true)
            {
                Entreprises.IsChecked = false;
                DataTable commandes = velomax.dataLoader(connection, velomax.GetCommande_particulier);
                IODataGrid.ItemsSource = commandes.DefaultView;
            }
            else if (isClient == true)
            {
                Entreprises.IsChecked = false;
                DataTable particuliers = velomax.dataLoader(connection, velomax.GetClient_particulier);
                IODataGrid.ItemsSource = particuliers.DefaultView;
            }
        }


    }
}
