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
    /// Logique d'interaction pour Statistiques.xaml
    /// </summary>
    /// 





    public partial class Statistiques : Page
    {
        VeloMax velomax;
        MySqlConnection connection;
        public Statistiques(MySqlConnection connection, VeloMax velomax)
        {
            this.connection = connection;
            this.velomax = velomax;
            InitializeComponent();

            button_Items_Pieces.Visibility = Visibility.Visible;
            button_Items_Pieces_Numero.Visibility = Visibility.Visible;
            button_Items_Pieces_Ref.Visibility = Visibility.Visible;
            button_Items_Velos.Visibility = Visibility.Visible;
            button_Items_Velos_Modele.Visibility = Visibility.Visible;
            button_Items_Velos_Taille.Visibility = Visibility.Visible;




            button_Meilleurs_Clients_E.Visibility = Visibility.Collapsed;
            button_Meilleurs_Clients_E_Prix.Visibility = Visibility.Collapsed;
            button_Meilleurs_Clients_E_Qte.Visibility = Visibility.Collapsed;
            button_Meilleurs_Clients_P.Visibility = Visibility.Collapsed;
            button_Meilleurs_Clients_P_Prix.Visibility = Visibility.Collapsed;
            button_Meilleurs_Clients_P_Qte.Visibility = Visibility.Collapsed;

        }
        string Mehdi = "SERVER=localhost;" + "PORT=3306;DATABASE=VeloMax;" + "UID=root;" + "PASSWORD=BDDMySQLD!d!2000;" + "SSLMODE=none;";
        string Quentin = "SERVER=localhost;PORT=3306;" + "DATABASE=VeloMax;" + "UID=root;PASSWORD=patate";

        #region REQUETES

        #region pieceVendues
        string pieceVenduesRef = "select numero_piece_catalogue_commande as 'Ref fournisseur', sum(quantite_piece_commande) as 'Quantité vendue' from liste_piece_commande group by numero_piece_catalogue_commande;";
        string pieceVenduesNum = "select SUBSTRING_INDEX(numero_piece_catalogue_commande,'_',-1) as 'Numéro pièce', sum(quantite_piece_commande) as 'Quantité vendue' from liste_piece_commande group by SUBSTRING_INDEX(numero_piece_catalogue_commande,'_',-1);";
        string veloVendusModele = "select v.nom_velo as 'Modele', sum(l.quantite_velo_commande) as 'Quantité vendue' from liste_velo_commande l join velo v on v.numero_velo=l.numero_velo group by v.nom_velo;";
        string veloVenduTaille = "select v.grandeur_velo as 'Taille', sum(l.quantite_velo_commande) as 'Quantité vendue' from liste_velo_commande l join velo v on v.numero_velo=l.numero_velo group by v.grandeur_velo;";
        #endregion

        #region membreProgramme
        string membreProgramme = "select ID_client_particulier as 'ID client', nom_programme as 'Programme', nom_client_particulier as 'Nom', prenom_client_particulier as 'Prenom', DATE_FORMAT(date_adhesion_programme, '%Y-%m-%d') as 'Date adhésion', DATE_FORMAT(DATE_ADD(date_adhesion_programme, INTERVAL duree_programme YEAR), '%Y-%m-%d') as 'Date expiration' from client_particulier c join programme p on p.numero_programme=c.numero_programme;";
        #endregion

        #region MeilleursClients
        string cParticulierQte = "select cp.ID_client_particulier as 'ID client particulier', cp.nom_client_particulier as 'Nom', cp.prenom_client_particulier as 'Prenom', sum(l.quantite_piece_commande) as 'Quantité commandée (pièces)' from liste_piece_commande l join commande c on c.numero_commande=l.numero_commande_piece join client_particulier cp on cp.ID_client_particulier= c.ID_client_particulier group by cp.ID_client_particulier order by sum(l.quantite_piece_commande) desc;";
        string cParticulierDepenses = "select cp.ID_client_particulier as 'ID particulier', cp.nom_client_particulier as 'Nom', cp.prenom_client_particulier as 'Prenom', sum(l.quantite_piece_commande* p.prix_piece) as 'Dépense totale de pièces (en €)' from liste_piece_commande l join piece p on p.numero_piece_catalogue=l.numero_piece_catalogue_commande join commande c on c.numero_commande= l.numero_commande_piece join client_particulier cp on cp.ID_client_particulier= c.ID_client_particulier group by cp.ID_client_particulier order by sum(l.quantite_piece_commande* p.prix_piece) DESC;";
        string cEntreprisesQte = "select ce.ID_client_entreprise as 'ID entreprise', ce.nom_client_entreprise as 'Nom', sum(l.quantite_piece_commande) as 'Quantité commandée (pièces)' from liste_piece_commande l join commande c on c.numero_commande=l.numero_commande_piece join client_entreprise ce on ce.ID_client_entreprise= c.ID_client_entreprise group by ce.ID_client_entreprise;";
        string cEntreprisesDepenses = "select ce.ID_client_entreprise as 'ID entreprise', ce.nom_client_entreprise as 'Nom', sum(l.quantite_piece_commande* p.prix_piece) as 'Dépense totale de pièces (en €)' from liste_piece_commande l join piece p on p.numero_piece_catalogue=l.numero_piece_catalogue_commande join commande c on c.numero_commande= l.numero_commande_piece join client_entreprise ce on ce.ID_client_entreprise= c.ID_client_entreprise group by ce.ID_client_entreprise order by sum(l.quantite_piece_commande* p.prix_piece) DESC;";
        #endregion

        #endregion


        public DataTable dataLoader(string requete)
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
        public void affiche(DataTable data)
        {

            mainDataGrid.ItemsSource = data.DefaultView;
        }
        public void affichageVide()
        {
            DataTable data = new DataTable();
            mainDataGrid.ItemsSource = data.DefaultView;
        }
        private void but_Items(object sender, RoutedEventArgs e)
        {
            button_Items_Pieces.Visibility = Visibility.Visible;
            button_Items_Pieces_Numero.Visibility = Visibility.Visible;
            button_Items_Pieces_Ref.Visibility = Visibility.Visible;
            button_Items_Velos.Visibility = Visibility.Visible;
            button_Items_Velos_Modele.Visibility = Visibility.Visible;
            button_Items_Velos_Taille.Visibility = Visibility.Visible;


            //affiche(dataLoader(""));
            affichageVide();

            button_Meilleurs_Clients_E.Visibility = Visibility.Collapsed;
            button_Meilleurs_Clients_E_Prix.Visibility = Visibility.Collapsed;
            button_Meilleurs_Clients_E_Qte.Visibility = Visibility.Collapsed;
            button_Meilleurs_Clients_P.Visibility = Visibility.Collapsed;
            button_Meilleurs_Clients_P_Prix.Visibility = Visibility.Collapsed;
            button_Meilleurs_Clients_P_Qte.Visibility = Visibility.Collapsed;



        }


        private void but_Programmes_Clients(object sender, RoutedEventArgs e)
        {
            button_Items_Pieces.Visibility = Visibility.Collapsed;
            button_Items_Pieces_Numero.Visibility = Visibility.Collapsed;
            button_Items_Pieces_Ref.Visibility = Visibility.Collapsed;
            button_Items_Velos.Visibility = Visibility.Collapsed;
            button_Items_Velos_Modele.Visibility = Visibility.Collapsed;
            button_Items_Velos_Taille.Visibility = Visibility.Collapsed;


            affiche(dataLoader(membreProgramme));


            button_Meilleurs_Clients_E.Visibility = Visibility.Collapsed;
            button_Meilleurs_Clients_E_Prix.Visibility = Visibility.Collapsed;
            button_Meilleurs_Clients_E_Qte.Visibility = Visibility.Collapsed;
            button_Meilleurs_Clients_P.Visibility = Visibility.Collapsed;
            button_Meilleurs_Clients_P_Prix.Visibility = Visibility.Collapsed;
            button_Meilleurs_Clients_P_Qte.Visibility = Visibility.Collapsed;
        }


        private void but_Meilleurs_Clients(object sender, RoutedEventArgs e)
        {
            button_Meilleurs_Clients_E.Visibility = Visibility.Visible;
            button_Meilleurs_Clients_E_Prix.Visibility = Visibility.Visible;
            button_Meilleurs_Clients_E_Qte.Visibility = Visibility.Visible;
            button_Meilleurs_Clients_P.Visibility = Visibility.Visible;
            button_Meilleurs_Clients_P_Prix.Visibility = Visibility.Collapsed;
            button_Meilleurs_Clients_P_Qte.Visibility = Visibility.Collapsed;



            //affiche(dataLoader(""));
            affichageVide();


            button_Items_Pieces.Visibility = Visibility.Collapsed;
            button_Items_Pieces_Numero.Visibility = Visibility.Collapsed;
            button_Items_Pieces_Ref.Visibility = Visibility.Collapsed;
            button_Items_Velos.Visibility = Visibility.Collapsed;
            button_Items_Velos_Modele.Visibility = Visibility.Collapsed;
            button_Items_Velos_Taille.Visibility = Visibility.Collapsed;




        }


        private void but_Items_Pieces(object sender, RoutedEventArgs e)
        {
            button_Items_Pieces_Numero.Visibility = Visibility.Visible;
            button_Items_Pieces_Ref.Visibility = Visibility.Visible;
            button_Items_Velos_Modele.Visibility = Visibility.Collapsed;
            button_Items_Velos_Taille.Visibility = Visibility.Collapsed;

            //affiche(dataLoader(""));
            affichageVide();
        }

        private void but_Items_Velos(object sender, RoutedEventArgs e)
        {
            button_Items_Pieces_Numero.Visibility = Visibility.Collapsed;
            button_Items_Pieces_Ref.Visibility = Visibility.Collapsed;
            button_Items_Velos_Modele.Visibility = Visibility.Visible;
            button_Items_Velos_Taille.Visibility = Visibility.Visible;

            //affiche(dataLoader(""));
            affichageVide();
        }

        private void but_Items_Pieces_Ref(object sender, RoutedEventArgs e)
        {
            affiche(dataLoader(pieceVenduesRef));

        }
        private void but_Items_Pieces_Numero(object sender, RoutedEventArgs e)
        {
            affiche(dataLoader(pieceVenduesNum));

        }
        private void but_Items_Velos_Modele(object sender, RoutedEventArgs e)
        {
            affiche(dataLoader(veloVendusModele));

        }
        private void but_Items_Velos_Taille(object sender, RoutedEventArgs e)
        {
            affiche(dataLoader(veloVenduTaille));

        }

        private void but_Meilleurs_Clients_E(object sender, RoutedEventArgs e)
        {
            //button_Meilleurs_Clients_E.Visibility = Visibility.Visible;
            button_Meilleurs_Clients_E_Prix.Visibility = Visibility.Visible;
            button_Meilleurs_Clients_E_Qte.Visibility = Visibility.Visible;
            //button_Meilleurs_Clients_P.Visibility = Visibility.Visible;
            button_Meilleurs_Clients_P_Prix.Visibility = Visibility.Collapsed;
            button_Meilleurs_Clients_P_Qte.Visibility = Visibility.Collapsed;

            //affiche(dataLoader(""));
            affichageVide();
        }

        private void but_Meilleurs_Clients_P(object sender, RoutedEventArgs e)
        {
            button_Meilleurs_Clients_E_Prix.Visibility = Visibility.Collapsed;
            button_Meilleurs_Clients_E_Qte.Visibility = Visibility.Collapsed;
            button_Meilleurs_Clients_P_Prix.Visibility = Visibility.Visible;
            button_Meilleurs_Clients_P_Qte.Visibility = Visibility.Visible;

            //affiche(dataLoader(""));
            affichageVide();
        }

        private void but_Meilleurs_Clients_E_Qte(object sender, RoutedEventArgs e)
        {
            affiche(dataLoader(cEntreprisesQte));

        }
        private void but_Meilleurs_Clients_E_Prix(object sender, RoutedEventArgs e)
        {
            affiche(dataLoader(cEntreprisesDepenses));

        }
        private void but_Meilleurs_Clients_P_Qte(object sender, RoutedEventArgs e)
        {
            affiche(dataLoader(cParticulierQte));

        }
        private void but_Meilleurs_Clients_P_Prix(object sender, RoutedEventArgs e)
        {
            affiche(dataLoader(cParticulierDepenses));

        }




        private void blablou(object sender, RoutedEventArgs e)
        {

        }
    }
}
