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
    /// Logique d'interaction pour Stock.xaml
    /// </summary>
    public partial class Stock : Page
    {
        //veloDataGrid
        string getPiece = "select * from piece;";
        string getPieceV2 = "select p.numero_piece as 'Numéro'," +
            " p.numero_piece_catalogue as 'Ref fournisseur'," +
            " p.description_piece as 'Type', " +
            "DATE_FORMAT(p.date_introduction_piece, '%Y-%m-%d') as 'Début production'," +
            "DATE_FORMAT(p.date_discontinuation_piece, '%Y-%m-%d') as 'Fin production'," +
            " p.prix_piece as 'Prix'," +
            " p.delai_approvisionnement_piece as 'Délai'," +
            " p.stock_piece as 'Stock' from piece p;";




        string getVelo = "select * from velo;";
        string Mehdi = "SERVER=localhost;" + "PORT=3306;DATABASE=VeloMax;" + "UID=root;" + "PASSWORD=BDDMySQLD!d!2000;" + "SSLMODE=none;";
        string Quentin = "SERVER=localhost;PORT=3306;" + "DATABASE=VeloMax;" + "UID=root;PASSWORD=patate";
        public void affichePiece(string user)
        {
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
                return;
            }
            MySqlCommand commande = maConnexion.CreateCommand();
            commande.CommandText = getPieceV2;
            MySqlDataReader reader = commande.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            reader.Close();
            maConnexion.Close();
            pieceDataGrid.ItemsSource = dt.DefaultView;
            //pieceDataGrid
        }
        public void afficheVelo(string user)
        {
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
                return;
            }
            MySqlCommand commande = maConnexion.CreateCommand();
            commande.CommandText = getVelo;
            MySqlDataReader reader = commande.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            reader.Close();
            maConnexion.Close();
            veloDataGrid.ItemsSource = dt.DefaultView;
            //pieceDataGrid
        }


        public Stock()
        {
            InitializeComponent();
            veloDataGrid.Visibility = Visibility.Visible;
            afficheVelo(Quentin);
        }
        private void stock_Piece(object sender, RoutedEventArgs e)
        {
            //but1.Visibility = Visibility.Collapsed;
            veloDataGrid.Visibility = Visibility.Collapsed;
            pieceDataGrid.Visibility = Visibility.Visible;
            affichePiece(Quentin);
        }
        private void stock_Velo(object sender, RoutedEventArgs e)
        {
            pieceDataGrid.Visibility = Visibility.Collapsed;
            veloDataGrid.Visibility = Visibility.Visible;
            afficheVelo(Quentin);
        }
    }
}
