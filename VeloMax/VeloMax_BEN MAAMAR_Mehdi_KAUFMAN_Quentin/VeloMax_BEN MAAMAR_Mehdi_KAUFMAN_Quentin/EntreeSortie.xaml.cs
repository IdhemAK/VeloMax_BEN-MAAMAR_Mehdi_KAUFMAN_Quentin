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

        public EntreeSortie(MySqlConnection connection, VeloMax velomax)
        {
            this.connection = connection;
            this.velomax = velomax;
            InitializeComponent();

            /*
            MySqlDataReader reader = commande.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            reader.Close();
            */
        }

        public DataTable dataLoader(string user, string requete)
        {
            DataTable erreur = new DataTable();
            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = user;
                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return erreur;
            }
            MySqlCommand commande = maConnexion.CreateCommand();
            commande.CommandText = requete;
            MySqlDataReader reader = commande.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(reader);
            reader.Close();
            maConnexion.Close();
            return data;
            //pieceDataGrid.ItemsSource = data.DefaultView;
            //manqueStock.ItemsSource = manquePiece.DefaultView;
        }

        private void Creer(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Reprise");
        }
    }
}
