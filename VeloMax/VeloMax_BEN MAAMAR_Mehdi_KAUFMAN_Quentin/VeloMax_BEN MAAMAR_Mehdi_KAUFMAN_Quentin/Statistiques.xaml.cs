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
using System.IO;
using Newtonsoft.Json;

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
        public static int relanceClient = 1;


        #region REQUETES

        #region pieceVendues
        string pieceVenduesRef = "select numero_piece_catalogue_commande as 'Ref fournisseur', sum(quantite_piece_commande) as 'Quantité vendue' from liste_piece_commande group by numero_piece_catalogue_commande;";
        string pieceVenduesNum = "select SUBSTRING_INDEX(numero_piece_catalogue_commande,'_',-1) as 'Numéro pièce', sum(quantite_piece_commande) as 'Quantité vendue' from liste_piece_commande group by SUBSTRING_INDEX(numero_piece_catalogue_commande,'_',-1);";
        string veloVendusModele = "select v.nom_velo as 'Modele', sum(l.quantite_velo_commande) as 'Quantité vendue' from liste_velo_commande l join velo v on v.numero_velo=l.numero_velo group by v.nom_velo;";
        string veloVenduTaille = "select v.grandeur_velo as 'Taille', sum(l.quantite_velo_commande) as 'Quantité vendue' from liste_velo_commande l join velo v on v.numero_velo=l.numero_velo group by v.grandeur_velo;";
        #endregion

        #region membreProgramme
        string membreProgramme = "select ID_client_particulier as 'ID client', nom_programme as 'Programme', nom_client_particulier as 'Nom', prenom_client_particulier as 'Prenom', DATE_FORMAT(date_adhesion_programme, '%Y-%m-%d') as 'Date adhésion', DATE_FORMAT(DATE_ADD(date_adhesion_programme, INTERVAL duree_programme YEAR), '%Y-%m-%d') as 'Date expiration' from client_particulier c join programme p on p.numero_programme=c.numero_programme;";
        string membreJSON = "select ID_client_particulier as 'ID client', nom_client_particulier as 'Nom', prenom_client_particulier as 'Prenom', DATE_FORMAT(date_adhesion_programme, '%Y-%m-%d') as 'Date adhésion', DATE_FORMAT(DATE_ADD(date_adhesion_programme, INTERVAL duree_programme YEAR), '%Y-%m-%d') as 'Date expiration', courriel_particulier as 'Courriel', telephone_particulier as 'Telephone', nom_programme as 'Programme' from client_particulier c join programme p on p.numero_programme=c.numero_programme;";
        #endregion

        #region MeilleursClients
        string cParticulierQte = "select cp.ID_client_particulier as 'ID client particulier', cp.nom_client_particulier as 'Nom', cp.prenom_client_particulier as 'Prenom', sum(l.quantite_piece_commande) as 'Quantité commandée (pièces)' from liste_piece_commande l join commande c on c.numero_commande=l.numero_commande_piece join client_particulier cp on cp.ID_client_particulier= c.ID_client_particulier group by cp.ID_client_particulier order by sum(l.quantite_piece_commande) desc;";
        string cParticulierDepenses = "select cp.ID_client_particulier as 'ID particulier', cp.nom_client_particulier as 'Nom', cp.prenom_client_particulier as 'Prenom', sum(l.quantite_piece_commande* p.prix_piece) as 'Dépense totale de pièces (en €)' from liste_piece_commande l join piece p on p.numero_piece_catalogue=l.numero_piece_catalogue_commande join commande c on c.numero_commande= l.numero_commande_piece join client_particulier cp on cp.ID_client_particulier= c.ID_client_particulier group by cp.ID_client_particulier order by sum(l.quantite_piece_commande* p.prix_piece) DESC;";
        string cEntreprisesQte = "select ce.ID_client_entreprise as 'ID entreprise', ce.nom_client_entreprise as 'Nom', sum(l.quantite_piece_commande) as 'Quantité commandée (pièces)' from liste_piece_commande l join commande c on c.numero_commande=l.numero_commande_piece join client_entreprise ce on ce.ID_client_entreprise= c.ID_client_entreprise group by ce.ID_client_entreprise;";
        string cEntreprisesDepenses = "select ce.ID_client_entreprise as 'ID entreprise', ce.nom_client_entreprise as 'Nom', sum(l.quantite_piece_commande* p.prix_piece) as 'Dépense totale de pièces (en €)' from liste_piece_commande l join piece p on p.numero_piece_catalogue=l.numero_piece_catalogue_commande join commande c on c.numero_commande= l.numero_commande_piece join client_entreprise ce on ce.ID_client_entreprise= c.ID_client_entreprise group by ce.ID_client_entreprise order by sum(l.quantite_piece_commande* p.prix_piece) DESC;";
        #endregion

        #region RapportStatistique
        string moyennePieceCommande = "select avg(newtable.SommePiece) as 'SommePiece' from (select numero_commande as 'NumCommande', numero_piece_catalogue_commande as 'NumPiece', sum(quantite_piece_commande)as 'SommePiece' from commande c join liste_piece_commande lp on lp.numero_commande_piece= c.numero_commande group by numero_commande order by numero_commande )newtable;";
        string moyenneVeloCommande = "select avg(newtable.SommeVelo) as 'SommeVelo' from (select numero_commande as 'NumCommande', numero_velo as 'NumVelo', sum(quantite_velo_commande) as 'SommeVelo' from commande c join liste_velo_commande lv on lv.numero_commande_velo= c.numero_commande group by numero_commande)newtable;";
        string sommePrixPieceCommande = "select numero_commande as 'NumCommandePiece', sum(prix_piece* quantite_piece_commande) as 'SommePiece' from commande c join liste_piece_commande lp on lp.numero_commande_piece=c.numero_commande join piece p on p.numero_piece_catalogue= lp.numero_piece_catalogue_commande group by numero_commande order by numero_commande;";
        string sommePrixVeloCommande = "select numero_commande as 'NumCommandeVelo', sum(prix_velo* quantite_velo_commande) as 'SommeVelo' from commande c join liste_velo_commande lv on lv.numero_commande_velo=c.numero_commande join velo v on v.numero_velo= lv.numero_velo group by numero_commande order by numero_commande;";
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
        public float moyennePrixCommande()
        {
            float moyenne = 0;
            int nbreCommande = 0;
            float somme = 0;
            DataTable prixPieces = dataLoader(sommePrixPieceCommande);
            DataTable prixVelos = dataLoader(sommePrixVeloCommande);
            int compteurP = prixPieces.Rows.Count;
            int compteurV = prixVelos.Rows.Count;
            for (int i = 0; i < compteurP; i++)
            {
                DataRow ligneP = prixPieces.Rows[i];
                int numP = Convert.ToInt32(ligneP["NumCommandePiece"]);
                for (int j = 0; j < compteurV; j++)
                {
                    DataRow ligneV = prixVelos.Rows[j];
                    int numV = Convert.ToInt32(ligneV["NumCommandeVelo"]);
                    if (numP == numV)
                    {
                        float prixUnePiece = (float)Convert.ToDouble(ligneP["SommePiece"]);
                        float prixUnVelo = (float)Convert.ToDouble(ligneV["SommeVelo"]);
                        somme += (prixUnePiece + prixUnVelo);
                        nbreCommande += 1;
                    }
                }
            }
            moyenne = somme / nbreCommande;
            return moyenne;
        }
        public void serialiseJson()
        {
            List<Client_particulier> liste = new List<Client_particulier>();
            DataTable clients = dataLoader(membreJSON);
            DataTable clientsFiltre = clients.Copy();
            for (int i = 0; i < clientsFiltre.Rows.Count; i++)
            {
                DataRow ligne = clientsFiltre.Rows[i];
                DateTime dateFin = Convert.ToDateTime(ligne["Date expiration"]);
                DateTime dateDebut = Convert.ToDateTime(ligne["Date adhésion"]);
                if (ligne["Programme"] != null)
                {
                    int deltaJour = (dateFin - dateDebut).Days;
                    if (deltaJour < 60)
                    {
                        ligne.Delete();
                    }
                }
            }
            foreach(DataRow ligne in clientsFiltre.Rows)
            {
                if (ligne.RowState != DataRowState.Deleted)
                {

                    string ID_client = Convert.ToString(ligne["ID client"]);
                    string nom_client_particulier = ligne["Nom"].ToString();
                    string prenom_client_particulier = ligne["Prenom"].ToString();
                    DateTime date_adhesion_programme = Convert.ToDateTime(ligne["Date adhésion"]);
                    DateTime date_expiration_programme = Convert.ToDateTime(ligne["Date expiration"]);
                    string courriel = ligne["Courriel"].ToString();
                    string telephone = ligne["Telephone"].ToString();
                    string programme = ligne["Programme"].ToString();
                    Client_particulier c = new Client_particulier(
                        ID_client,
                        nom_client_particulier, 
                        prenom_client_particulier, 
                        date_adhesion_programme, 
                        date_expiration_programme,
                        courriel,
                        telephone,
                        programme);

                    liste.Add(c);
                }
            }
            string fileToWrite = "relance_clients"+ relanceClient.ToString()+".json";
            relanceClient += 1;
            StreamWriter fileWriter = new StreamWriter(fileToWrite);
            JsonTextWriter jsonWriter = new JsonTextWriter(fileWriter);
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(jsonWriter, liste);
            jsonWriter.Close();
            fileWriter.Close();
            MessageBox.Show("Succès de l'export de : "+fileToWrite + " !");
        }

        #region BUTTONS
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
        #endregion



        private void but_JSON(object sender, RoutedEventArgs e)
        {
            serialiseJson();
        }

        private void but_Statistcs(object sender, RoutedEventArgs e)
        {
            
            string textToShow = "Rapport des ventes :\n";
            float moyPrixCommande = moyennePrixCommande();
            textToShow += "La dépense moyenne lors d'une commande est de : " + moyPrixCommande.ToString() + " €\n";
            DataTable piece = dataLoader(moyennePieceCommande);
            DataTable velo = dataLoader(moyenneVeloCommande);
            string moyPieceCommande = Convert.ToString(piece.Rows[0][0]);
            textToShow += "En moyenne " + moyPieceCommande + " pièces sont achetées par commandes\n";
            string moyVeloCommande = Convert.ToString(velo.Rows[0][0]);
            textToShow += "En moyenne " + moyVeloCommande + " vélos sont achetés par commandes\n";




            MessageBox.Show(textToShow);
            moyennePrixCommande();
        }
    }
}
