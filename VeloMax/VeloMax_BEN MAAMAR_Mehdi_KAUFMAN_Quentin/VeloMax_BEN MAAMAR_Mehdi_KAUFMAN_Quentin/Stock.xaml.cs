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
            afficheVeloV2();
        }

        private void stock_Piece(object sender, RoutedEventArgs e)
        {
            
            mainDataGrid.Visibility = Visibility.Visible;
            manqueStock.Visibility = Visibility.Visible;

            butPieceFournisseur.Visibility = Visibility.Visible;
            butPieceNum.Visibility = Visibility.Visible;
            butPieceRef.Visibility = Visibility.Visible;
            butPieceType.Visibility = Visibility.Visible;
            affichePieceV2();
            butVeloModele.Visibility = Visibility.Collapsed;
            butVeloNum.Visibility = Visibility.Collapsed;
            butVeloTaille.Visibility = Visibility.Collapsed;
            butVeloType.Visibility = Visibility.Collapsed;

        }
        private void stock_Velo(object sender, RoutedEventArgs e)
        {
            mainDataGrid.Visibility = Visibility.Visible;
            manqueStock.Visibility = Visibility.Visible;

            butVeloModele.Visibility = Visibility.Visible;
            butVeloNum.Visibility = Visibility.Visible;
            butVeloTaille.Visibility = Visibility.Visible;
            butVeloType.Visibility = Visibility.Visible;
            afficheVeloV2();
            butPieceFournisseur.Visibility = Visibility.Collapsed;
            butPieceNum.Visibility = Visibility.Collapsed;
            butPieceRef.Visibility = Visibility.Collapsed;
            butPieceType.Visibility = Visibility.Collapsed;
        }
        private void commander(object sender, RoutedEventArgs e)
        {
            //oceddole
        }


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
        string pieceNumero = "select p.numero_piece as 'Numéro',sum(p.stock_piece) as 'Stock' from piece p group by p.numero_piece order by sum(p.stock_piece);";
        string pieceRefFournisseur = "select numero_piece_catalogue as 'Ref fournisseur', p.stock_piece as 'Stock' from piece p order by p.stock_piece;";
        string pieceFournisseur = "select f.nom_fournisseur as 'Fournisseur', sum(p.stock_piece) as 'Stock' from catalogue c, piece p, fournisseur f where p.numero_piece_catalogue = c.numero_piece_catalogue and c.siret_fournisseur = f.siret_fournisseur group by f.nom_fournisseur order by sum(p.stock_piece);";
        string pieceType = "select p.description_piece as 'Type', sum(p.stock_piece) as 'Stock' from piece p group by p.description_piece order by sum(p.stock_piece);";


        string getVelo = "select * from velo;";
        string getVeloV2 = "select numero_velo as 'Numéro'," +
            " nom_velo as 'Modele'," +
            "grandeur_velo as 'Taille'," +
            " prix_velo as 'Prix'," +
            " ligne_produit_velo as 'Type'," +
            " DATE_FORMAT(date_introduction_velo, '%Y-%m-%d') as 'Début production'," +
            " DATE_FORMAT(date_discontinuation_velo, '%Y-%m-%d') as 'Fin production'," +
            " stock_velo as 'Stock' from velo;";
        string veloCleUnitaire = "select v.numero_velo as 'Numéro', v.stock_velo as 'Stock' from velo v order by v.stock_velo;";
        string veloTaille = "select v.grandeur_velo as 'Taille',  sum(v.stock_velo) as 'Stock' from velo v group by v.grandeur_velo order by sum(v.stock_velo);";
        string veloModele = "select v.nom_velo as 'Modele', sum(v.stock_velo) as 'Stock' from velo v group by v.nom_velo order by sum(v.stock_velo);";
        string veloLigne = "select v.ligne_produit_velo as 'Type', sum(v.stock_velo) as 'Stock' from velo v group by v.ligne_produit_velo order by sum(v.stock_velo);";     
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
        
        public void affichePieceV2()
        {
            DataTable pieces = velomax.dataLoader(connection, getPieceV2);
            DataTable piecesManque = checkQuantity(pieces, "Stock",35);
            piecesManque.Columns.Remove("Numéro");
            piecesManque.Columns.Remove("Début production");
            piecesManque.Columns.Remove("Fin production");
            //piecesManque.Columns.Remove("");
            //piecesManque.Columns.Remove("");
            mainDataGrid.ItemsSource = pieces.DefaultView;
            manqueStock.ItemsSource = piecesManque.DefaultView;
        }
        public void afficheVeloV2()
        {
            DataTable velos = velomax.dataLoader(connection, getVeloV2);
            DataTable veloManque = checkQuantity(velos, "Stock",120);
            veloManque.Columns.Remove("Type");
            veloManque.Columns.Remove("Taille");
            veloManque.Columns.Remove("Début production");
            veloManque.Columns.Remove("Fin production");
            mainDataGrid.ItemsSource = velos.DefaultView;
            manqueStock.ItemsSource = veloManque.DefaultView;
        }


        #region Trie
        private void trieVeloCleUnitaire(object sender, RoutedEventArgs e)
        {
            DataTable velo = velomax.dataLoader(connection, veloCleUnitaire);
            mainDataGrid.ItemsSource = velo.DefaultView;
        }
        private void trieVeloParTaille(object sender, RoutedEventArgs e)
        {
            DataTable velo = velomax.dataLoader(connection, veloTaille);
            mainDataGrid.ItemsSource = velo.DefaultView;
        }
        private void trieVeloParModele(object sender, RoutedEventArgs e)
        {
            DataTable velo = velomax.dataLoader(connection, veloModele);
            mainDataGrid.ItemsSource = velo.DefaultView;           
        }
        private void trieVeloParLigneProduit(object sender, RoutedEventArgs e)
        {
            DataTable velo = velomax.dataLoader(connection, veloLigne);
            mainDataGrid.ItemsSource = velo.DefaultView;
        }
        private void triePieceNumero(object sender, RoutedEventArgs e)
        {
            DataTable piece = velomax.dataLoader(connection, pieceNumero);
            mainDataGrid.ItemsSource = piece.DefaultView;
        }
        private void triePieceRefFournisseur(object sender, RoutedEventArgs e)
        {
            DataTable piece = velomax.dataLoader(connection, pieceRefFournisseur);
            mainDataGrid.ItemsSource = piece.DefaultView;
        }
        private void triePieceFournisseur(object sender, RoutedEventArgs e)
        {
            DataTable piece = velomax.dataLoader(connection, pieceFournisseur);
            mainDataGrid.ItemsSource = piece.DefaultView;
        }
        private void triePieceType(object sender, RoutedEventArgs e)
        {
            DataTable piece = velomax.dataLoader(connection, pieceType);
            mainDataGrid.ItemsSource = piece.DefaultView;
        }
        #endregion Trie
    }
}
