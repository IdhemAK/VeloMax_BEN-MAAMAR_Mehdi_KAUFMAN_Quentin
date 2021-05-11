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
        VeloMax velomax;
        MySqlConnection connection;
        public Stock(MySqlConnection connection, VeloMax velomax)
        {
            this.connection = connection;
            this.velomax = velomax;            
            InitializeComponent();
            afficheVeloV2(Mehdi);
        }

        private void stock_Piece(object sender, RoutedEventArgs e)
        {
            mainDataGrid.Visibility = Visibility.Visible;
            manqueStock.Visibility = Visibility.Visible;
            affichePieceV2(Mehdi);


        }
        private void stock_Velo(object sender, RoutedEventArgs e)
        {
            mainDataGrid.Visibility = Visibility.Visible;
            afficheVeloV2(Mehdi);
        }
        private void commander(object sender, RoutedEventArgs e)
        {
            //oceddole
        }



        string Mehdi = "SERVER=localhost;" + "PORT=3306;DATABASE=VeloMax;" + "UID=root;" + "PASSWORD=BDDMySQLD!d!2000;" + "SSLMODE=none;";
        string Quentin = "SERVER=localhost;PORT=3306;" + "DATABASE=VeloMax;" + "UID=root;PASSWORD=patate";
        #region REQUETES
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
        string getVeloV2 = "select numero_velo as 'Numéro'," +
            " nom_velo as 'Nom'," +
            "grandeur_velo as 'Taille'," +
            " prix_velo as 'Prix'," +
            " ligne_produit_velo as 'Type'," +
            " DATE_FORMAT(date_introduction_velo, '%Y-%m-%d') as 'Début production'," +
            " DATE_FORMAT(date_discontinuation_velo, '%Y-%m-%d') as 'Fin production'," +
            " stock_velo as 'Stock' from velo;";
        string aaa = "select v.numero_velo,v.stock_velo,v.date_discontinuation_velo from velo v order by v.stock_velo;";
        string veloTaille = "select v.grandeur_velo, sum(v.stock_velo) from velo v group by v.grandeur_velo order by sum(v.stock_velo);";


        #endregion

        public DataTable checkQuantity(DataTable data, string columnName, int seuil)
        {
            DataTable Acommander = data.Copy();
            for(int i =0; i< Acommander.Rows.Count; i++)
            {
                DataRow ligne = Acommander.Rows[i];
                int stock = Convert.ToInt32(ligne[columnName]);
                if(stock > seuil)
                {
                    ligne.Delete();  
                }
            }
            return Acommander;
        }       
        
        public DataTable dataLoader(string user, string requete)
        {
            DataTable erreur = new DataTable();
            connection.Open();
            MySqlCommand commande = connection.CreateCommand();
            commande.CommandText = requete;
            MySqlDataReader reader = commande.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(reader);
            reader.Close();
            connection.Close();
            return data;
            //pieceDataGrid.ItemsSource = data.DefaultView;
            //manqueStock.ItemsSource = manquePiece.DefaultView;
        }
        public void affichePieceV2(string user)
        {
            DataTable pieces = dataLoader(user, getPieceV2);
            DataTable piecesManque = checkQuantity(pieces, "Stock",35);
            piecesManque.Columns.Remove("Numéro");
            piecesManque.Columns.Remove("Début production");
            piecesManque.Columns.Remove("Fin production");
            //piecesManque.Columns.Remove("");
            //piecesManque.Columns.Remove("");
            mainDataGrid.ItemsSource = pieces.DefaultView;
            manqueStock.ItemsSource = piecesManque.DefaultView;
        }
        public void afficheVeloV2(string user)
        {
            DataTable velos = dataLoader(user, getVeloV2);
            DataTable veloManque = checkQuantity(velos, "Stock",120);
            veloManque.Columns.Remove("Type");
            veloManque.Columns.Remove("Taille");
            veloManque.Columns.Remove("Début production");
            veloManque.Columns.Remove("Fin production");
            mainDataGrid.ItemsSource = velos.DefaultView;
            manqueStock.ItemsSource = veloManque.DefaultView;
        }
        
        
    }
}
