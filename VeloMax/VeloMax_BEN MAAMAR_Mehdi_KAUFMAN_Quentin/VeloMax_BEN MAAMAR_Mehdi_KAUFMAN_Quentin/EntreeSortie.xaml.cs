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
        bool isAdresse;
        bool[] isTab;

        //Requête utilisé pour compléter les commandes
        string columnFindVeloC = "numero_commande_velo AS 'Numéro commande', numero_velo AS 'Numéro vélo'," +
                            "quantite_velo_commande AS 'Quantité vélo'";
        string columnFindPieceC = "numero_commande_piece AS 'Numéro commande', numero_piece_catalogue_commande AS 'Réf fournisseur'," +
                            "quantite_piece_commande AS 'Quantité pièce'";
        string numCommandeTemp;

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
            isAdresse = false;

            isTab = new bool[] { isVelo , isPiece, isCommande, isFournisseur, isClient, isAdresse };         
        }

        public void IsTableChecking(int index)  //index du tableau isTab
        {
            for(int i = 0; i < isTab.Length; i++)
            {
                isTab[i] =  i == index ? true : false;
            }
        }

        public void DisplayTypeClient(string typeClient)
        {
            string chain = null;
            List<string> ids = velomax.SelectColumn(connection, typeClient,
                "CONVERT(SUBSTRING(ID_" + typeClient + ", 6), UNSIGNED INT)",
                "CONVERT(SUBSTRING(ID_" + typeClient + ", 6), UNSIGNED INT)");

            if (typeClient == "client_entreprise")
            {
                List<string> nomE = velomax.SelectColumn(connection, "client_entreprise", "nom_client_entreprise",
                    "CONVERT(SUBSTRING(ID_" + typeClient + ", 6), UNSIGNED INT)");
                for (int i = 0; i < nomE.Count(); i++)
                {
                    chain += "\n" + ids[i] + " : " + nomE[i];
                }
            }
            else
            {
                List<string> nomP = velomax.SelectColumn(connection, "client_particulier", "nom_client_particulier",
                    "CONVERT(SUBSTRING(ID_" + typeClient + ", 6), UNSIGNED INT)");
                List<string> prenomP = velomax.SelectColumn(connection, "client_particulier", "prenom_client_particulier",
                    "CONVERT(SUBSTRING(ID_" + typeClient + ", 6), UNSIGNED INT)");
                for (int i = 0; i < nomP.Count(); i++)
                {
                    chain += "\n" + ids[i] + " : " + nomP[i] + " " + prenomP[i];
                }
            }
            MessageBox.Show("Entrer l'un des ID correspondant à l'un des clients existant suivants :\n" + chain);
        }

        public void DisplayAdresses()
        {
            List<Adresse> adresses = (List<Adresse>)velomax.SelectAllFromTable(connection, "adresse");

            string chainAdresses = "Entrer l'un des numéros correspondant aux adresses suivantes :\n";
            for(int i = 0; i < adresses.Count(); i++)
            {
                chainAdresses += "\n" + adresses[i];
            }
            MessageBox.Show(chainAdresses);
        }

        public void DisplayProgramme()
        {
            List<Programme> programmes = (List<Programme>)velomax.SelectAllFromTable(connection, "programme");
            string chainProgrammes = "Entrer l'un des numéros correspondant aux programmes suivante :\n";
            for (int i = 0; i < programmes.Count(); i++)
            {
                chainProgrammes += "\n" + programmes[i];
            }
            MessageBox.Show(chainProgrammes);
        }

        private void Creer(object sender, RoutedEventArgs e)
        {
            
            DataRowView rowview = IODataGrid.SelectedItem as DataRowView;
            if(rowview == null)
            {
                MessageBox.Show("DataGrid NULL");
            }
            else
            {                
                if (isTab[0] == true) //velo 
                {                   
                    string[] velo = new string[rowview.Row.ItemArray.Length];
                    for(int i = 1; i < velo.Length; i++)
                    {
                        velo[i] = Convert.ToString(rowview.Row.ItemArray[i]);
                    }

                    if ((DateTime.TryParse(velo[5], out DateTime dateIntro) || velo[5] == "") && (DateTime.TryParse(velo[6], out DateTime dateDiscont) || velo[6] == ""))
                    {
                        velo[0] = Convert.ToString(velomax.CountTuple(connection, "velo") + 1);

                        if (!double.TryParse(velo[3], out double prix))
                        {
                            MessageBox.Show("Entrer un nombre pour le prix du vélo");
                        }
                        else if (!int.TryParse(velo[7], out int stock))
                        {
                            MessageBox.Show("Entrer un nombre entier pour le stock du vélo");
                        }
                        else                       
                        {                           
                            while (velomax.ExistsInDataBase(connection, "velo", "numero_velo", velo[0], true))
                            {
                                velo[0] = Convert.ToString(Convert.ToInt32(velo[0]) + 1);
                            }

                            if(velo[5] == "" && velo[6] == "")
                            {
                                velo[5] = "null";
                                velo[6] = "null";
                                velomax.Create(connection, "velo", velo, new int[] { 0, 3, 5, 6, 7 });
                            }
                            else if(velo[5] == "")
                            {                               
                                velo[5] = "null";
                                velo[6] = dateDiscont.ToString("yyyy-MM-dd");
                                velomax.Create(connection, "velo", velo, new int[] { 0, 3, 5, 7 });
                            }
                            else if (velo[6] == "")
                            {
                                velo[5] = dateIntro.ToString("yyyy-MM-dd");
                                velo[6] = "null";
                                velomax.Create(connection, "velo", velo, new int[] { 0, 3, 6, 7 });
                            }
                            else
                            {
                                velo[5] = dateIntro.ToString("yyyy-MM-dd");
                                velo[6] = dateDiscont.ToString("yyyy-MM-dd");
                                velomax.Create(connection, "velo", velo, new int[] { 0, 3, 7 });
                            }

                            DataTable newVelo = velomax.dataLoader(connection, velomax.GetVelo);
                            IODataGrid.ItemsSource = newVelo.DefaultView;
                        }                        
                    }
                    else
                    {
                        MessageBox.Show("Mauvais format de date\nBon format : YYYY/MM/DD");
                    }
                } //velo
                else if (isTab[1] == true) //piece
                {
                    string[] piece = new string[rowview.Row.ItemArray.Length];
                    
                    for (int i = 2; i < piece.Length; i++)
                    {
                        piece[i] = Convert.ToString(rowview.Row.ItemArray[i]);
                    }

                    if ((DateTime.TryParse(piece[3], out DateTime dateIntro) || piece[3] == "") && (DateTime.TryParse(piece[4], out DateTime dateDiscont) || piece[4] == ""))
                    {
                        string test = null;

                        bool okInt = true;
                        for (int i = 5; i < piece.Length && okInt == true; i++)
                        {
                            if (!int.TryParse(piece[i], out int result)) okInt = false;
                            test += piece[i] + " ";
                        }

                        if (okInt == false) MessageBox.Show("Entrer un nombre entier pour : \n-Prix\n-Délai\n-Stock");
                        else
                        {
                            if (comboBoxFournisseur.Text == "") MessageBox.Show("Entrer un fournisseur dans le menu déroulant");
                            else
                            {
                                int numeroPiece = velomax.IDMaxPlusOne(connection, "piece", "numero_piece", 2, true);
                                piece[0] = comboBoxFournisseur.Text + "_P" + numeroPiece;
                                piece[1] = "P" + numeroPiece;

                                if (piece[3] == "" && piece[4] == "")
                                {
                                    piece[3] = "null";
                                    piece[4] = "null";
                                    velomax.Create(connection, "piece", piece, new int[] { 3, 4, 5, 6, 7 });
                                }
                                else if (piece[3] == "")
                                {
                                    piece[3] = "null";
                                    piece[4] = dateDiscont.ToString("yyyy-MM-dd");
                                    velomax.Create(connection, "piece", piece, new int[] { 3, 5, 6, 7 });
                                }
                                else if (piece[4] == "")
                                {
                                    piece[3] = dateIntro.ToString("yyyy-MM-dd");
                                    piece[4] = "null";
                                    velomax.Create(connection, "piece", piece, new int[] { 4, 5, 6, 7 });
                                }
                                else
                                {
                                    piece[3] = dateIntro.ToString("yyyy-MM-dd");
                                    piece[4] = dateDiscont.ToString("yyyy-MM-dd");
                                    velomax.Create(connection, "piece", piece, new int[] { 5, 6, 7 });
                                }

                                string siretF = velomax.SelectColumnFromWhere(connection, "fournisseur", "siret_fournisseur", "nom_fournisseur",
                                    comboBoxFournisseur.Text, 0)[0];
                                int stockPCatalogue = Convert.ToInt32(piece[7]) * 10;

                                //Des apostrophes sont créées sur piece[0]
                                //La boucle for sert à les retirer
                                string reference = null;
                                for(int i = 0; i < piece[0].Length; i++)
                                {
                                    reference += Convert.ToString(piece[0][i]) == "'" ? null : Convert.ToString(piece[0][i]);
                                }

                                velomax.Create(connection, "catalogue", 
                                    new string[] { reference, siretF, Convert.ToString(stockPCatalogue) }, new int[] { 2 });

                                DataTable newPiece = velomax.dataLoader(connection, velomax.GetPiece);
                                IODataGrid.ItemsSource = newPiece.DefaultView;
                            }
                        }
                    }
                    else MessageBox.Show("Mauvais format de date\nBon format : YYYY/MM/DD");
                } //piece
                else if (isTab[2] == true) //commande
                {
                    
                    string id = Convert.ToString(rowview.Row.ItemArray[4]);
                    string idClient = (Entreprises.IsChecked == true ? "cliE_" : "cliP_") + id;

                    //start
                    string typeClient = Entreprises.IsChecked == true ? "client_entreprise" : "client_particulier";
                    if (!int.TryParse(id, out int res))
                    {
                        DisplayTypeClient(typeClient);
                    }
                    else if (!velomax.ExistsInDataBase(connection, typeClient, "ID_" + typeClient, idClient, false))
                    {
                        DisplayTypeClient(typeClient);
                    }                                                    
                    else
                    {
                        string[] fullCommande = new string[6];
                        fullCommande[0] = Convert.ToString(velomax.IDMaxPlusOne(connection, "commande", "numero_commande", 0, false));
                        DateTime now = DateTime.Now;
                        fullCommande[1] = now.ToString("yyyy/MM/dd");
                        fullCommande[2] = (now + new TimeSpan(new Random().Next(1, 30), 0, 0, 0)).ToString("yyyy/MM/dd");
                        fullCommande[3] = velomax.SelectColumnFromWhere(connection, typeClient, "ID_adresse_" + typeClient, "ID_" + typeClient, idClient, 0)[0];
                        
                        DataTable newCommande = null;
                        if (Entreprises.IsChecked == true)
                        {
                            fullCommande[4] = idClient;
                            fullCommande[5] = "null";
                            velomax.Create(connection, "commande", fullCommande, new int[] { 0, 3, 5 });
                            newCommande = velomax.dataLoader(connection, velomax.GetCommande_entreprise);
                        }
                        else
                        {
                            fullCommande[4] = "null";
                            fullCommande[5] = idClient;
                            velomax.Create(connection, "commande", fullCommande, new int[] { 0, 3, 4 });
                            newCommande = velomax.dataLoader(connection, velomax.GetCommande_particulier);
                        }                      
                        //MessageBox.Show(test);
                        IODataGrid.ItemsSource = newCommande.DefaultView;
                    }
                } //commande
                else if (isTab[3] == true) //fournisseur
                {
                    string[] fournisseur = new string[rowview.Row.ItemArray.Length];                        
                    for (int i = 0; i < fournisseur.Length; i++)
                    {
                        fournisseur[i] = Convert.ToString(rowview.Row.ItemArray[i]);
                    }
                    
                    if (!int.TryParse(fournisseur[4], out int result))
                    {
                        DisplayAdresses();
                    }
                    else
                    {                        
                        if (!velomax.ExistsInDataBase(connection, "adresse", "ID_adresse", fournisseur[4], true))
                        {
                            DisplayAdresses();
                        }
                        else
                        {                           
                            if(velomax.ExistsInDataBase(connection, "fournisseur", "siret_fournisseur", fournisseur[0], false))
                            {
                                MessageBox.Show("Entrer un siret non existant");
                            }
                            else
                            {
                                velomax.Create(connection, "fournisseur", fournisseur, new int[] { 4 });
                                DataTable newFournisseur = velomax.dataLoader(connection, velomax.GetFournisseur);
                                IODataGrid.ItemsSource = newFournisseur.DefaultView;
                            }                           
                        }
                    }                                      
                } //fournisseur
                else if (isTab[4] == true && Entreprises.IsChecked == true) //client_entreprise
                {
                    string[] clientE = new string[rowview.Row.ItemArray.Length];

                    for (int i = 1; i < clientE.Length; i++)
                    {
                        clientE[i] = Convert.ToString(rowview.Row.ItemArray[i]);
                    }

                    if (!int.TryParse(clientE[6], out int testAdresse))
                    {
                        DisplayAdresses();
                    }
                    else if (!velomax.ExistsInDataBase(connection, "adresse", "ID_adresse", clientE[6], true))
                    {
                        DisplayAdresses();
                    }
                    else if (!float.TryParse(clientE[2], out float testRemise))
                    {
                        MessageBox.Show("Entrer un pourcentage entre 0 et 0.2 (entre 0 et 20%) pour la remise");
                    }
                    else if (testRemise < 0 || testRemise > 0.21)
                    {
                        MessageBox.Show("Entrer un pourcentage entre 0 et 0.2 (entre 0 et 20%) pour la remise");
                    }
                    else
                    {                       
                        clientE[0] = "cliE_" + Convert.ToString(velomax.IDMaxPlusOne(connection, "client_entreprise", "ID_client_entreprise", 6, true));
                        string remise = null;
                        for (int i = 0; i < clientE[2].Length; i++)
                        {
                            remise += (clientE[2][i] == ',') ? "." : Convert.ToString(clientE[2][i]);
                        }
                        clientE[2] = remise;

                        velomax.Create(connection, "client_entreprise", clientE, new int[] { 2, 6 });

                        DataTable newClientE = velomax.dataLoader(connection, velomax.GetClient_entreprise);
                        IODataGrid.ItemsSource = newClientE.DefaultView;
                    }
                } //client_entreprise
                else if (isTab[4] == true && Particuliers.IsChecked == true) //client_particulier
                {
                    string[] clientP = new string[rowview.Row.ItemArray.Length];
                    //MessageBox.Show("Here");
                    string test = null;

                    for (int i = 1; i < clientP.Length; i++)
                    {
                        clientP[i] = Convert.ToString(rowview.Row.ItemArray[i]);
                        test += clientP[i] + " - ";
                    }                   
                    //MessageBox.Show(test);

                    if(!DateTime.TryParse(clientP[3], out DateTime dateAdh))
                    {
                        MessageBox.Show("Mauvais format de date\nBon format : YYYY/MM/DD");
                    }
                    else if(!int.TryParse(clientP[6], out int numProg))
                    {
                        DisplayProgramme();
                    }
                    else if(!velomax.ExistsInDataBase(connection, "programme", "numero_programme", clientP[6], true))
                    {
                        DisplayProgramme();
                    }
                    else if (!int.TryParse(clientP[7], out int testAdresseP))
                    {
                        DisplayAdresses();
                    }
                    else if (!velomax.ExistsInDataBase(connection, "adresse", "ID_adresse", clientP[7], true))
                    {
                        DisplayAdresses();
                    }
                    else
                    {
                        clientP[3] = dateAdh.ToString("yyyy-MM-dd");

                        clientP[0] = "cliP_" + Convert.ToString(velomax.IDMaxPlusOne(connection, "client_particulier", "ID_client_particulier", 6, true));

                        velomax.Create(connection, "client_particulier", clientP, new int[] { 6, 7 });

                        DataTable newClientP = velomax.dataLoader(connection, velomax.GetClient_particulier);
                        IODataGrid.ItemsSource = newClientP.DefaultView;
                    }
                } //client_particulier
                else if (isTab[5] == true) //adresse
                {                    
                    string[] adresse = new string[rowview.Row.ItemArray.Length];
                    adresse[0] = Convert.ToString(velomax.CountTuple(connection, "adresse") + 1);

                    
                    while(velomax.ExistsInDataBase(connection, "adresse", "ID_adresse", adresse[0], true))
                    {
                        adresse[0] = Convert.ToString(Convert.ToInt32(adresse[0]) + 1);
                    }
                   
                    for (int i = 1; i < adresse.Length; i++)
                    {
                        adresse[i] = Convert.ToString(rowview.Row.ItemArray[i]);
                    }
                    velomax.Create(connection, "adresse", adresse, new int[] { 0 });                   

                    DataTable newAdresse = velomax.dataLoader(connection, velomax.GetAdresse);
                    IODataGrid.ItemsSource = newAdresse.DefaultView;
                } //adresse
            }
        }

        /// <summary>
        /// Généralise la suppression d'un tuple dans toutes les tables
        /// </summary>
        /// <param name="tableAffichage">nom de la table affiché dans la MessagBox</param>
        /// <param name="table">nom de la table dans la BDD</param>
        /// <param name="columnKey">colonne de la table à laquelle on fait référence</param>
        /// <param name="keyName">clé de la colonne </param>
        /// <param name="isIntOrNull">true si keyName est int ou null et false sinon</param>
        private void MessageSupprimerAndDisplay(string tableAffichage, string table, string columnKey, string keyName, bool isIntOrNull, 
            string getDisplay)
        {
            MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de supprimer : " + tableAffichage + " " + keyName + " ?\n" +
                       "Cela supprimera toutes les données associées."
                       , "Suppression", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    velomax.Remove(connection, table, columnKey, keyName, isIntOrNull);
                    DataTable reDisplay = velomax.dataLoader(connection, getDisplay);
                    IODataGrid.ItemsSource = reDisplay.DefaultView;

                    MessageBox.Show(char.ToUpper(tableAffichage[0]) + tableAffichage.Substring(1)  + " " + keyName + 
                        " supprimé(e)", "Suppression " + tableAffichage);
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void Supprimer(object sender, RoutedEventArgs e)
        {
            DataRowView rowview = IODataGrid.SelectedItem as DataRowView;
            if (rowview == null)
            {
                MessageBox.Show("DataGrid NULL");
            }
            else
            {
                if (isTab[0] == true) //supprimer vélo
                {
                    //supprime les commandes et liste_assemblage associées
                    MessageSupprimerAndDisplay("vélo", "velo", "numero_velo", rowview.Row[0].ToString(), true, velomax.GetVelo);                    
                } 
                else if (isTab[1] == true) //supprimer pièce
                {
                    //supprime les commandes et liste_assemblage associées
                    MessageSupprimerAndDisplay("pièce", "piece", "numero_piece_catalogue", rowview.Row[0].ToString(), true, velomax.GetPiece);
                }
                else if (isCommande == true) //supprimer commande
                {
                    //supprime les données de la commande
                    //ne suprime pas les clients et les adresses
                    //Le dernier paramètre permet d'afficher les commandes entreprises ou particuliers
                    MessageSupprimerAndDisplay("commande", "commande", "numero_commande", rowview.Row[0].ToString(), true,
                        Entreprises.IsChecked == true ? velomax.GetCommande_entreprise : velomax.GetCommande_particulier);
                }
                else if (isTab[3] == true) //supprimer fournisseur
                {
                    //ne supprime pas les pièces du stocks et les adresses
                    MessageSupprimerAndDisplay("fournisseur", "fournisseur", "siret_fournisseur", rowview.Row[0].ToString(), true, velomax.GetFournisseur);
                }
                else if (isTab[4] == true && Entreprises.IsChecked == true) //supprimer entreprise
                {
                    //supprime les commandes associées
                     MessageSupprimerAndDisplay("entreprise", "client_entreprise", "ID_client_entreprise", rowview.Row[0].ToString(), true, 
                         velomax.GetClient_entreprise);
                }
                else if (isTab[4] == true && Particuliers.IsChecked == true) //supprimer particulier
                {
                    //supprime les commandes associées
                    //ne supprime pas les adresses
                    MessageSupprimerAndDisplay("particulier", "client_particulier", "ID_client_particulier", rowview.Row[0].ToString(), true,
                         velomax.GetClient_particulier);
                }
                else if (isTab[5] == true) //supprimer adresse
                {
                    //supprime les commandes, fournisseurs et clients associés
                    MessageSupprimerAndDisplay("adresse", "adresse", "ID_adresse", rowview.Row[0].ToString(), true, velomax.GetAdresse);
                }
            }           
        }

        private void Modifier(object sender, RoutedEventArgs e)
        {            
            DataRowView rowview = IODataGrid.SelectedItem as DataRowView;
            if (rowview == null)
            {
                MessageBox.Show("DataGrid NULL");
            }
            else
            {
                string query = null;
                if (isTab[0] == true) //modifier vélo
                {
                    string date1 = rowview.Row[5].ToString();
                    string date2 = rowview.Row[6].ToString();

                    if (rowview.Row[0].ToString() == "")
                    {
                        MessageBox.Show("Modifier un vélo déjà existant");
                    }
                    else if ((DateTime.TryParse(date1, out DateTime dateIntro) || date1 == "") && (DateTime.TryParse(date2, out DateTime dateDiscont) || date2 == ""))
                    {
                        string strPrix = rowview.Row[3].ToString();
                        string strStock = rowview.Row[7].ToString();

                        if (!double.TryParse(strPrix, out double prix))
                        {
                            MessageBox.Show("Entrer un nombre pour le prix du vélo");
                        }
                        else if (!int.TryParse(strStock, out int stock))
                        {
                            MessageBox.Show("Entrer un nombre entier pour le stock du vélo");
                        }
                        else
                        {
                            //on change les virgules en points pour MySQL
                            string prixFormat = null;
                            for (int i = 0; i < strPrix.Length; i++)
                            {
                                prixFormat += (strPrix[i] == ',') ? "." : Convert.ToString(strPrix[i]);
                            }

                            date1 = date1 == "" ? "null" :("'" + dateIntro.ToString("yyyy-MM-dd") + "'");
                            date2 = date2 == "" ? "null" :("'" + dateDiscont.ToString("yyyy-MM-dd") + "'");

                            query = "UPDATE velo SET " +
                            "nom_velo='" + rowview.Row[1].ToString() + "', " +
                            "grandeur_velo='" + rowview.Row[2].ToString() + "', " +
                            "prix_velo=" + prixFormat + ", " +
                            "ligne_produit_velo='" + rowview.Row[4].ToString() + "', " +
                            "date_introduction_velo=" + date1 + ", " +
                            "date_discontinuation_velo=" + date2 + ", " +
                            "stock_velo=" + strStock +
                            " WHERE numero_velo=" + rowview.Row[0].ToString() + ";";

                            velomax.Query(connection, query);

                            DataTable newVelo = velomax.dataLoader(connection, velomax.GetVelo);
                            IODataGrid.ItemsSource = newVelo.DefaultView;
                        }

                    } 
                    else
                    {
                        MessageBox.Show("Mauvais format de date\nBon format : YYYY/MM/DD");
                    }

                } //modifier vélo
                else if (isTab[1] == true) //modifier pièce
                {
                    string[] piece = new string[rowview.Row.ItemArray.Length];

                    for (int i = 2; i < piece.Length; i++)
                    {
                        piece[i] = Convert.ToString(rowview.Row.ItemArray[i]);
                    }

                    if (rowview.Row[0].ToString() == "")
                    {
                        MessageBox.Show("Modifier un pièce déjà existante");
                    }
                    else if ((DateTime.TryParse(piece[3], out DateTime dateIntro) || piece[3] == "") && (DateTime.TryParse(piece[4], out DateTime dateDiscont) || piece[4] == ""))
                    {
                        string test = null;

                        bool okInt = true;
                        for (int i = 5; i < piece.Length && okInt == true; i++)
                        {
                            if (!int.TryParse(piece[i], out int result)) okInt = false;
                            test += piece[i] + " ";
                        }

                        if (okInt == false) MessageBox.Show("Entrer un nombre entier pour : \n-Prix\n-Délai\n-Stock");
                        else
                        {
                            if (comboBoxFournisseur.Text != "") MessageBox.Show("On ne peut pas changer le fournisseur d'une pièce");

                            int numeroPiece = velomax.IDMaxPlusOne(connection, "piece", "numero_piece", 2, true);
                            piece[0] = comboBoxFournisseur.Text + "_P" + numeroPiece;
                            piece[1] = "P" + numeroPiece;

                            piece[3] = piece[3] == "" ? "null": "'" + dateIntro.ToString("yyyy-MM-dd") + "'";
                            piece[4] = piece[4] == "" ? "null" : "'" + dateDiscont.ToString("yyyy-MM-dd") + "'";

                            //on change les virgules en points pour MySQL
                            string prixFormat = null;
                            for (int i = 0; i < piece[5].Length; i++)
                            {
                                prixFormat += (piece[5][i] == ',') ? "." : Convert.ToString(piece[5][i]);
                            }

                            query = "UPDATE piece SET " +
                            "numero_piece='" + rowview.Row[1].ToString() + "', " +
                            "description_piece='" + piece[2] + "', " +
                            "date_introduction_piece=" + piece[3] + ", " +
                            "date_discontinuation_piece=" + piece[4] + ", " +
                            "prix_piece=" + prixFormat + ", " +
                            "delai_approvisionnement_piece=" + piece[6] + ", " +
                            "stock_piece=" + piece[7] +
                            " WHERE numero_piece_catalogue='" + rowview.Row[0].ToString() + "';";

                            velomax.Query(connection, query);

                            DataTable newPiece = velomax.dataLoader(connection, velomax.GetPiece);
                            IODataGrid.ItemsSource = newPiece.DefaultView;                         
                        }
                    }
                    else MessageBox.Show("Mauvais format de date\nBon format : YYYY/MM/DD");
                } //modifier pièce
                else if (isCommande == true) //modifier commande
                {
                    IODataGrid.Columns[0].IsReadOnly = true;

                    string id = Convert.ToString(rowview.Row.ItemArray[4]);
                    string idClient = (Entreprises.IsChecked == true ? "cliE_" : "cliP_") + id;

                    //start
                    string typeClient = Entreprises.IsChecked == true ? "client_entreprise" : "client_particulier";
                    if (rowview.Row[0].ToString() == "")
                    {
                        MessageBox.Show("Modifier une commande déjà existante");
                    }
                    else if (!int.TryParse(id, out int res))
                    {
                        DisplayTypeClient(typeClient);
                    }
                    else if (!velomax.ExistsInDataBase(connection, typeClient, "ID_" + typeClient, idClient, false))
                    {
                        DisplayTypeClient(typeClient);
                    }
                    else if (!int.TryParse(rowview.Row[3].ToString(), out int idAdresse))
                    {
                        DisplayAdresses();
                    }
                    else if (idAdresse < 0 || idAdresse > velomax.IDMaxPlusOne(connection, "adresse", "ID_adresse", 0, false))
                    {
                        DisplayAdresses();
                    }
                    else
                    {
                        string[] fullCommande = new string[6];
                        fullCommande[0] = rowview.Row[0].ToString();
                        DateTime now = DateTime.Now;
                        fullCommande[1] = now.ToString("yyyy-MM-dd");
                        fullCommande[2] = (now + new TimeSpan(new Random().Next(1, 30), 0, 0, 0)).ToString("yyyy-MM-dd");
                        fullCommande[3] = velomax.SelectColumnFromWhere(connection, typeClient, "ID_adresse_" + typeClient, "ID_" + typeClient, idClient, 0)[0];

                        DataTable newCommande = null;
                        if (Entreprises.IsChecked == true)
                        {
                            fullCommande[4] = idClient;
                            fullCommande[5] = "null";

                            query = "UPDATE commande SET " +
                            "date_commande='" + fullCommande[1] + "', " +
                            "date_livraison_commande='" + fullCommande[2] + "', " +
                            "ID_adresse_commande=" + fullCommande[3] + ", " +
                            "ID_client_entreprise='" + fullCommande[4] + "', " +
                            "ID_client_particulier=" + fullCommande[5] + 
                            " WHERE numero_commande=" + fullCommande[0] + ";";

                            velomax.Query(connection, query);

                            newCommande = velomax.dataLoader(connection, velomax.GetCommande_entreprise);
                        }
                        else
                        {
                            fullCommande[4] = "null";
                            fullCommande[5] = idClient;

                            query = "UPDATE commande SET " +
                            "date_commande='" + fullCommande[1] + "', " +
                            "date_livraison_commande='" + fullCommande[2] + "', " +
                            "ID_adresse_commande=" + fullCommande[3] + ", " +
                            "ID_client_entreprise=" + fullCommande[4] + ", " +
                            "ID_client_particulier='" + fullCommande[5] +
                            "' WHERE numero_commande=" + fullCommande[0] + ";";

                            velomax.Query(connection, query);

                            newCommande = velomax.dataLoader(connection, velomax.GetCommande_particulier);
                        }
                        //MessageBox.Show(test);
                        IODataGrid.ItemsSource = newCommande.DefaultView;
                    }
                }
                else if (isTab[3] == true) //modifier fournisseur
                {
                    //Attention : Les noms des pièces ne sont pas modifiés
                    //car elles portent le nom de l'ancien catalogue du fournisseur
                    string[] fournisseur = new string[rowview.Row.ItemArray.Length];
                    for (int i = 0; i < fournisseur.Length; i++)
                    {
                        fournisseur[i] = Convert.ToString(rowview.Row.ItemArray[i]);
                    }

                    if (rowview.Row[0].ToString() == "")
                    {
                        MessageBox.Show("Modifier un fournisseur déjà existant");
                    }
                    else if (!int.TryParse(fournisseur[4], out int result))
                    {
                        DisplayAdresses();
                    }
                    else
                    {
                        if (!velomax.ExistsInDataBase(connection, "adresse", "ID_adresse", fournisseur[4], true))
                        {
                            DisplayAdresses();
                        }
                        else if (!velomax.ExistsInDataBase(connection, "fournisseur", "siret_fournisseur", fournisseur[0], true))
                        {
                            MessageBox.Show("Vous ne pouvez pas changer le siret d'un fournisseur");
                            DataTable newFournisseur = velomax.dataLoader(connection, velomax.GetFournisseur);
                            IODataGrid.ItemsSource = newFournisseur.DefaultView;
                        }
                        else
                        {
                            query = "UPDATE fournisseur SET " +
                            "nom_fournisseur='" + fournisseur[1] + "', " +
                            "qualite_fournisseur='" + fournisseur[2] + "', " +
                            "nom_contact_fournisseur='" + fournisseur[3] + "', " +
                            "ID_adresse_fournisseur='" + fournisseur[4] +
                            "' WHERE siret_fournisseur='" + fournisseur[0] + "';";

                            velomax.Query(connection, query);

                            DataTable newFournisseur = velomax.dataLoader(connection, velomax.GetFournisseur);
                            IODataGrid.ItemsSource = newFournisseur.DefaultView;
                        }
                    }
                }
                else if (isTab[4] == true && Entreprises.IsChecked == true) //modifier entreprise
                {
                    string[] clientE = new string[rowview.Row.ItemArray.Length];
                    for (int i = 0; i < clientE.Length; i++)
                    {
                        clientE[i] = Convert.ToString(rowview.Row.ItemArray[i]);
                    }

                    if(rowview.Row[0].ToString() == "")
                    {
                        MessageBox.Show("Modifier un client entreprise déjà existant");
                    }
                    else if (!int.TryParse(clientE[6], out int testAdresse))
                    {
                        DisplayAdresses();
                    }
                    else if (!velomax.ExistsInDataBase(connection, "adresse", "ID_adresse", clientE[6], true))
                    {
                        DisplayAdresses();
                    }
                    else if (!float.TryParse(clientE[2], out float testRemise))
                    {
                        MessageBox.Show("Entrer un pourcentage entre 0 et 0.2 (entre 0 et 20%) pour la remise");
                    }
                    else if (testRemise < 0 || testRemise > 0.21)
                    {
                        MessageBox.Show("Entrer un pourcentage entre 0 et 0.2 (entre 0 et 20%) pour la remise");
                    }
                    else
                    {
                        clientE[0] = rowview.Row[0].ToString();
                        string remise = null;
                        for (int i = 0; i < clientE[2].Length; i++)
                        {
                            remise += (clientE[2][i] == ',') ? "." : Convert.ToString(clientE[2][i]);
                        }
                        clientE[2] = remise;

                        query = "UPDATE client_entreprise SET " +
                            "nom_client_entreprise='" + clientE[1] + "', " +
                            "remise_client_entreprise=" + clientE[2] + ", " +
                            "courriel_entreprise='" + clientE[3] + "', " +
                            "telephone_entreprise='" + clientE[4] + "', " +
                            "nom_contact_entreprise='" + clientE[5] + "', " +
                            "ID_adresse_client_entreprise=" + clientE[6] +
                            " WHERE ID_client_entreprise='" + clientE[0] + "';";

                        velomax.Query(connection, query);

                        DataTable newClientE = velomax.dataLoader(connection, velomax.GetClient_entreprise);
                        IODataGrid.ItemsSource = newClientE.DefaultView;
                    }
                }
                else if (isTab[4] == true && Particuliers.IsChecked == true) //modifier particulier
                {
                    string[] clientP = new string[rowview.Row.ItemArray.Length];
                    //MessageBox.Show("Here");
                    string test = null;

                    for (int i = 0; i < clientP.Length; i++)
                    {
                        clientP[i] = Convert.ToString(rowview.Row.ItemArray[i]);
                        test += clientP[i] + " - ";
                    }
                    //MessageBox.Show(test);

                    if (rowview.Row[0].ToString() == "")
                    {
                        MessageBox.Show("Modifier un client particulier déjà existant");
                    }
                    else if (!DateTime.TryParse(clientP[3], out DateTime dateAdh))
                    {
                        MessageBox.Show("Mauvais format de date\nBon format : YYYY/MM/DD");
                    }
                    else if (!int.TryParse(clientP[6], out int numProg))
                    {
                        DisplayProgramme();
                    }
                    else if (!velomax.ExistsInDataBase(connection, "programme", "numero_programme", clientP[6], true))
                    {
                        DisplayProgramme();
                    }
                    else if (!int.TryParse(clientP[7], out int testAdresseP))
                    {
                        DisplayAdresses();
                    }
                    else if (!velomax.ExistsInDataBase(connection, "adresse", "ID_adresse", clientP[7], true))
                    {
                        DisplayAdresses();
                    }
                    else
                    {
                        clientP[3] = dateAdh.ToString("yyyy-MM-dd");

                        query = "UPDATE client_particulier SET " +
                             "nom_client_particulier='" + clientP[1] + "', " +
                             "prenom_client_particulier='" + clientP[2] + "', " +
                             "date_adhesion_programme='" + clientP[3] + "', " +
                             "courriel_particulier='" + clientP[4] + "', " +
                             "telephone_particulier='" + clientP[5] + "', " +
                             "numero_programme=" + clientP[6] + ", " +
                             "ID_adresse_client_particulier=" + clientP[7] +
                             " WHERE ID_client_particulier='" + clientP[0] + "';";
                        
                        velomax.Query(connection, query);

                        DataTable newClientP = velomax.dataLoader(connection, velomax.GetClient_particulier);
                        IODataGrid.ItemsSource = newClientP.DefaultView;
                    }
                }
                else if (isTab[5] == true) //modifier adresse
                {
                    if (rowview.Row[0].ToString() == "")
                    {
                        MessageBox.Show("Modifier une adresse déjà existant");
                    }
                    else
                    {
                        query = "UPDATE adresse SET " +
                        "rue_adresse='" + rowview.Row[1].ToString() + "', " +
                        "ville_adresse='" + rowview.Row[2].ToString() + "', " +
                        "code_postal_adresse='" + rowview.Row[3].ToString() + "', " +
                        "province_adresse='" + rowview.Row[4].ToString() +
                        "' WHERE ID_adresse=" + rowview.Row[0].ToString() + ";";
                        velomax.Query(connection, query);
                    }                  
                }
            }
        }

        private void Velo(object sender, RoutedEventArgs e)
        {
            isCommande = false;
            isClient = false;
            Entreprises.IsChecked = false;
            Particuliers.IsChecked = false;
            Entreprises.Visibility = Visibility.Collapsed;
            Particuliers.Visibility = Visibility.Collapsed;
            stackPanelFournisseur.Visibility = Visibility.Collapsed;

            newPageCommande.Visibility = Visibility.Collapsed;

            DataTable particuliers = velomax.dataLoader(connection, velomax.GetVelo);
            IODataGrid.ItemsSource = particuliers.DefaultView;
            IODataGrid.Columns[0].IsReadOnly = true;

            IsTableChecking(0);
        }

        private void Piece(object sender, RoutedEventArgs e)
        {
            isCommande = false;
            isClient = false;
            Entreprises.IsChecked = false;
            Particuliers.IsChecked = false;
            Entreprises.Visibility = Visibility.Collapsed;
            Particuliers.Visibility = Visibility.Collapsed;
            stackPanelFournisseur.Visibility = Visibility.Visible;

            newPageCommande.Visibility = Visibility.Collapsed;

            DataTable piece = velomax.dataLoader(connection, velomax.GetPiece);
            comboBoxFournisseur.ItemsSource = velomax.SelectColumn(connection, "fournisseur", "nom_fournisseur", "nom_fournisseur");

            IODataGrid.ItemsSource = piece.DefaultView;
            IODataGrid.Columns[0].IsReadOnly = true;

            IsTableChecking(1);
        }

        private void Fournisseur(object sender, RoutedEventArgs e)
        {
            isCommande = false;
            isClient = false;
            Entreprises.IsChecked = false;
            Particuliers.IsChecked = false;
            Entreprises.Visibility = Visibility.Collapsed;
            Particuliers.Visibility = Visibility.Collapsed;
            stackPanelFournisseur.Visibility = Visibility.Collapsed;

            newPageCommande.Visibility = Visibility.Collapsed;

            DataTable fournisseur = velomax.dataLoader(connection, velomax.GetFournisseur);
            IODataGrid.ItemsSource = fournisseur.DefaultView;
            
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
            stackPanelFournisseur.Visibility = Visibility.Collapsed;

            newPageCommande.Visibility = Visibility.Visible;

            IsTableChecking(2);
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
            stackPanelFournisseur.Visibility = Visibility.Collapsed;

            newPageCommande.Visibility = Visibility.Collapsed;

            IsTableChecking(4);
        }

        private void Entreprises_Checked(object sender, RoutedEventArgs e)
        {
            if (isCommande == true)
            {
                Particuliers.IsChecked = false;
                DataTable commandes = velomax.dataLoader(connection, velomax.GetCommande_entreprise);
                IODataGrid.ItemsSource = commandes.DefaultView;
                IODataGrid.Columns[0].IsReadOnly = true;
                IODataGrid.Columns[2].IsReadOnly = true;
                IODataGrid.Columns[3].IsReadOnly = true;
            }
            else if (isClient == true)
            {
                Particuliers.IsChecked = false;
                DataTable entreprises = velomax.dataLoader(connection, velomax.GetClient_entreprise);
                IODataGrid.ItemsSource = entreprises.DefaultView;
                IODataGrid.Columns[0].IsReadOnly = true;
            }
        }

        private void Particuliers_Checked(object sender, RoutedEventArgs e)
        {
            if (isCommande == true)
            {
                Entreprises.IsChecked = false;
                DataTable commandes = velomax.dataLoader(connection, velomax.GetCommande_particulier);
                IODataGrid.ItemsSource = commandes.DefaultView;
                IODataGrid.Columns[0].IsReadOnly = true;
                IODataGrid.Columns[2].IsReadOnly = true;
                IODataGrid.Columns[3].IsReadOnly = true;
            }
            else if (isClient == true)
            {
                Entreprises.IsChecked = false;
                DataTable particuliers = velomax.dataLoader(connection, velomax.GetClient_particulier);
                IODataGrid.ItemsSource = particuliers.DefaultView;
                IODataGrid.Columns[0].IsReadOnly = true;
            }
        }

        private void Adresse(object sender, RoutedEventArgs e)
        {
            isCommande = false;
            isClient = false;
            Entreprises.IsChecked = false;
            Particuliers.IsChecked = false;
            Entreprises.Visibility = Visibility.Collapsed;
            Particuliers.Visibility = Visibility.Collapsed;
            stackPanelFournisseur.Visibility = Visibility.Collapsed;

            newPageCommande.Visibility = Visibility.Collapsed;

            DataTable adresse = velomax.dataLoader(connection, velomax.GetAdresse);        
            IODataGrid.ItemsSource = adresse.DefaultView;
            IODataGrid.Columns[0].IsReadOnly = true;

            IsTableChecking(5);           
        }
        
        private void newPageCommande_Checked(object sender, RoutedEventArgs e)
        {
            DataRowView rowview = IODataGrid.SelectedItem as DataRowView;
            
            if (rowview == null)
            {
                MessageBox.Show("Item NULL");
                newPageCommande.IsChecked = false;
            }
            else
            {
                if (!int.TryParse(rowview.Row[0].ToString(), out int res))
                {
                    MessageBox.Show("Choisir une case avec un numéro commande");
                    newPageCommande.IsChecked = false;
                }
                else
                {
                    if (rowview.Row[1].ToString() == "" || rowview.Row[2].ToString() == "" || rowview.Row[3].ToString() == ""
                            || rowview.Row[4].ToString() == "")
                    {
                        MessageBox.Show("Sélectionner une commande existante");
                        newPageCommande.IsChecked = false;
                    }
                    else if (!velomax.ExistsInDataBase(connection, "commande", "numero_commande", Convert.ToString(res), true))
                    {
                        MessageBox.Show("Numéro commande non existant");
                        newPageCommande.IsChecked = false;
                    }
                    else
                    {
                        numCommandeTemp = rowview.Row[0].ToString();
                        
                        #region DataGrids parameters
                        //taille datagrid original : Height=269 && Width=550
                        //nouvelle taille : Height=220 then 130 && Width =250
                        IODataGrid.ItemsSource = null;
                        IODataGrid.Height = 130;
                        IODataGrid.Width = 250;
                        IODataGrid.Margin = new Thickness(IODataGrid.Margin.Left, IODataGrid.Margin.Top + 50,
                            IODataGrid.Margin.Right, IODataGrid.Margin.Bottom);
                        IODataGrid.CanUserAddRows = false;
                        IODataGrid.IsReadOnly = true;

                        IODataGridBis.Visibility = Visibility.Visible;
                        IODataGridTer.Visibility = Visibility.Visible;                      

                        DataGridVeloCommand.Visibility = Visibility.Visible;
                        DataGridPieceCommand.Visibility = Visibility.Visible;

                        
                        #endregion DataGrids parameters

                        #region Buttons/Checkboxes parameters
                        Entreprises.Visibility = Visibility.Collapsed;
                        Particuliers.Visibility = Visibility.Collapsed;

                        AddVelo.Visibility = Visibility.Visible;
                        AddPiece.Visibility = Visibility.Visible;

                        RemoveVelo.Visibility = Visibility.Visible;
                        RemovePiece.Visibility = Visibility.Visible;

                        SendCommand.Visibility = Visibility.Visible;

                        AdresseButton.Visibility = Visibility.Collapsed;
                        CommandeButton.Visibility = Visibility.Collapsed;
                        ClientButton.Visibility = Visibility.Collapsed;
                        FournisseurButton.Visibility = Visibility.Collapsed;
                        VeloButton.Visibility = Visibility.Collapsed;
                        PieceButton.Visibility = Visibility.Collapsed;
                        #endregion Buttons/Checkboxes parameters
                       
                        livreur.Visibility = Visibility.Visible;

                        string requeteCommandToEdit = "select numero_commande as 'Numéro commande'," +
                            "DATE_FORMAT(date_commande, '%Y-%m-%d') as 'Date de commande'," +
                            "DATE_FORMAT(date_livraison_commande, '%Y-%m-%d') as 'Date de livraison'," +
                            "ID_adresse_commande as 'ID adresse',";
                            

                        if(Entreprises.IsChecked == true)
                        {
                            requeteCommandToEdit += "c.ID_client_entreprise as 'ID entreprise' " +
                            "from commande c " +
                            "join client_entreprise ce on ce.ID_client_entreprise = c.ID_client_entreprise " +
                            "where numero_commande=" + numCommandeTemp + ";";
                        }
                        else
                        {
                            requeteCommandToEdit += "c.ID_client_particulier as 'ID particulier' " +
                            "from commande c " +
                            "join client_particulier cp on cp.ID_client_particulier = c.ID_client_particulier " +
                            "where numero_commande=" + numCommandeTemp + ";";
                        }

                        DataTable commandToEdit = velomax.dataLoader(connection, requeteCommandToEdit);

                        IODataGridTer.ItemsSource = commandToEdit.DefaultView;

                        DataTable velo = velomax.dataLoader(connection, velomax.GetVelo);
                        IODataGrid.ItemsSource = velo.DefaultView;

                        DataTable piece = velomax.dataLoader(connection, velomax.GetPiece);
                        IODataGridBis.ItemsSource = piece.DefaultView;

                        //Les listes commandes
                        
                        DataTable listeVeloCommande = velomax.dataLoader(connection, 
                            velomax.QuerySelectColumnFromWhere("liste_velo_commande", columnFindVeloC, "numero_commande_velo", numCommandeTemp));
                        DataGridVeloCommand.ItemsSource = listeVeloCommande.DefaultView;

                        
                        DataTable listePieceCommande = velomax.dataLoader(connection,
                            velomax.QuerySelectColumnFromWhere("liste_piece_commande", columnFindPieceC, "numero_commande_piece", numCommandeTemp));
                        DataGridPieceCommand.ItemsSource = listePieceCommande.DefaultView;
                    }
                }
            }
        }

        private void newPageCommande_Unchecked(object sender, RoutedEventArgs e)
        {
            if(IODataGrid.Margin.Top == 150)
            {               
                numCommandeTemp = null;

                #region DataGrids parameters
                IODataGrid.ItemsSource = null;
                IODataGrid.Height = 269;
                IODataGrid.Width = 550;
                IODataGrid.Margin = new Thickness(IODataGrid.Margin.Left, IODataGrid.Margin.Top - 50,
                                IODataGrid.Margin.Right, IODataGrid.Margin.Bottom);                
                IODataGrid.CanUserAddRows = true;
                IODataGrid.IsReadOnly = false;

                IODataGridBis.Visibility = Visibility.Collapsed;
                IODataGridTer.Visibility = Visibility.Collapsed;

                DataGridVeloCommand.Visibility = Visibility.Collapsed;
                DataGridPieceCommand.Visibility = Visibility.Collapsed;
                #endregion DataGrids parameters

                #region Buttons/Checkboxes parameters
                Entreprises.Visibility = Visibility.Visible;
                Particuliers.Visibility = Visibility.Visible;

                AddVelo.Visibility = Visibility.Collapsed;
                AddPiece.Visibility = Visibility.Collapsed;

                RemoveVelo.Visibility = Visibility.Collapsed;
                RemovePiece.Visibility = Visibility.Collapsed;

                SendCommand.Visibility = Visibility.Collapsed;

                AdresseButton.Visibility = Visibility.Visible;
                CommandeButton.Visibility = Visibility.Visible;
                ClientButton.Visibility = Visibility.Visible;
                FournisseurButton.Visibility = Visibility.Visible;
                VeloButton.Visibility = Visibility.Visible;
                PieceButton.Visibility = Visibility.Visible;
                #endregion Buttons/Checkboxes parameters

                livreur.Visibility = Visibility.Collapsed;

                if (Entreprises.IsChecked == true) Entreprises_Checked(sender, e);
                else Particuliers_Checked(sender, e);
            }
        }

        private void AjoutVelo(object sender, RoutedEventArgs e)
        {
            DataRowView rowview = IODataGrid.SelectedItem as DataRowView;

            if(rowview == null)
            {
                MessageBox.Show("Sélectionner un vélo sur la liste des vélo pour l'ajouter à la commande");
            }
            else
            {
                if (!velomax.ExistsInDataBaseWhereAnd(connection, "liste_velo_commande", "numero_commande_velo", numCommandeTemp,
                "numero_velo", rowview.Row[0].ToString()))
                {
                    velomax.Create(connection, "liste_velo_commande",
                        new string[] { numCommandeTemp, rowview.Row[0].ToString(), "1" }, new int[] { 0, 1, 2 });
                }
                else
                {
                    //"UPDATE velo SET nom_velo = 'ALPHABETA' WHERE nom_velo ='Riverside';";

                    int qteVelo = Convert.ToInt32(velomax.SelectColumnFromWhereAnd(connection, "liste_velo_commande", "numero_commande_velo", numCommandeTemp,
                        "numero_velo", rowview.Row[0].ToString(), 2)[0]) + 1;

                    velomax.Query(connection, "UPDATE liste_velo_commande SET quantite_velo_commande =" + Convert.ToString(qteVelo) +
                        " WHERE numero_commande_velo =" + numCommandeTemp + " AND numero_velo=" + rowview.Row[0].ToString() + ";");
                }

                DataTable listeVeloCommande = velomax.dataLoader(connection,
                                 velomax.QuerySelectColumnFromWhere("liste_velo_commande", columnFindVeloC, "numero_commande_velo", numCommandeTemp));
                DataGridVeloCommand.ItemsSource = listeVeloCommande.DefaultView;
            }           
        }

        private void AjoutPiece(object sender, RoutedEventArgs e)
        {
            DataRowView rowview = IODataGridBis.SelectedItem as DataRowView;

            if(rowview == null)
            {
                MessageBox.Show("Sélectionner une pièce sur la liste des pièces pour l'ajouter à la commande");
            }
            else
            {
                if (!velomax.ExistsInDataBaseWhereAnd(connection, "liste_piece_commande", "numero_commande_piece", numCommandeTemp,
                "numero_piece_catalogue_commande", rowview.Row[0].ToString()))
                {
                    
                    velomax.Create(connection, "liste_piece_commande",
                        new string[] { rowview.Row[0].ToString(), numCommandeTemp, "1" }, new int[] { 1, 2 });
                    //MessageBox.Show(rowview.Row[0].ToString());
                }
                else
                {
                    int qtePiece = Convert.ToInt32(velomax.SelectColumnFromWhereAnd(connection, "liste_piece_commande", "numero_commande_piece", numCommandeTemp,
                        "numero_piece_catalogue_commande", rowview.Row[0].ToString(), 2)[0]) + 1;

                    velomax.Query(connection, "UPDATE liste_piece_commande SET quantite_piece_commande =" + Convert.ToString(qtePiece) +
                        " WHERE numero_commande_piece =" + numCommandeTemp + " AND numero_piece_catalogue_commande=" + "'" + rowview.Row[0].ToString() + "';");
                }

                DataTable listeVeloCommande = velomax.dataLoader(connection,
                                 velomax.QuerySelectColumnFromWhere("liste_piece_commande", columnFindPieceC, "numero_commande_piece", numCommandeTemp));
                DataGridPieceCommand.ItemsSource = listeVeloCommande.DefaultView;
            }           
        }

        private void RemoveVelo_Click(object sender, RoutedEventArgs e)
        {
            //queryRemove = "DELETE FROM velo WHERE nom_velo ='Btwin';";
            DataRowView rowview = DataGridVeloCommand.SelectedItem as DataRowView;

            if(rowview == null)
            {
                MessageBox.Show("Sélectionner un item sur la liste des vélos à commander pour le supprimer");
            }
            else
            {
                //MessageBox.Show(rowview.Row[0].ToString());
                int qteVelo = Convert.ToInt32(velomax.SelectColumnFromWhereAnd(connection, "liste_velo_commande", "numero_commande_velo", numCommandeTemp,
                    "numero_velo", rowview.Row[1].ToString(), 2)[0]);

                if (qteVelo > 1)
                {
                    qteVelo -= 1;
                    velomax.Query(connection, "UPDATE liste_velo_commande SET quantite_velo_commande =" + Convert.ToString(qteVelo) +
                        " WHERE numero_commande_velo =" + numCommandeTemp + " AND numero_velo=" + rowview.Row[1].ToString() + ";");
                }
                else
                {
                    velomax.Query(connection, "DELETE FROM liste_velo_commande WHERE numero_commande_velo= " + numCommandeTemp +
                        " AND numero_velo=" + rowview.Row[1].ToString() + ";");
                }

                DataTable listeVeloCommande = velomax.dataLoader(connection,
                                 velomax.QuerySelectColumnFromWhere("liste_velo_commande", columnFindVeloC, "numero_commande_velo", numCommandeTemp));
                DataGridVeloCommand.ItemsSource = listeVeloCommande.DefaultView;
            }                    
        }

        private void RemovePiece_Click(object sender, RoutedEventArgs e)
        {
            //queryRemove = "DELETE FROM velo WHERE nom_velo ='Btwin';";
            DataRowView rowview = DataGridPieceCommand.SelectedItem as DataRowView;

            if (rowview == null)
            {
                MessageBox.Show("Sélectionner un item sur la liste des pièces à commander pour le supprimer");
            }
            else
            {
                //MessageBox.Show(rowview.Row[0].ToString());
                int qtePiece = Convert.ToInt32(velomax.SelectColumnFromWhereAnd(connection, "liste_piece_commande", "numero_commande_piece", numCommandeTemp,
                    "numero_piece_catalogue_commande", rowview.Row[1].ToString(), 2)[0]);

                if (qtePiece > 1)
                {
                    qtePiece -= 1;
                    velomax.Query(connection, "UPDATE liste_piece_commande SET quantite_piece_commande =" + Convert.ToString(qtePiece) +
                        " WHERE numero_commande_piece =" + numCommandeTemp + " AND numero_piece_catalogue_commande='" + rowview.Row[1].ToString() + "';");
                }
                else
                {
                    velomax.Query(connection, "DELETE FROM liste_piece_commande WHERE numero_commande_piece= " + numCommandeTemp +
                        " AND numero_piece_catalogue_commande='" + rowview.Row[1].ToString() + "';");
                }

                DataTable listePieceCommande = velomax.dataLoader(connection,
                                 velomax.QuerySelectColumnFromWhere("liste_piece_commande", columnFindPieceC, "numero_commande_piece", numCommandeTemp));
                DataGridPieceCommand.ItemsSource = listePieceCommande.DefaultView;
            }
        }

        /// <summary>
        /// On envoie la commande étudiée si les stocks sont suffisants
        /// et si la commande a au moins un article
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendCommand_Click(object sender, RoutedEventArgs e)
        {
            List<string> qteVeloCommande = velomax.SelectColumnFromWhere(connection, "liste_velo_commande", "quantite_velo_commande",
                "numero_commande_velo", numCommandeTemp, 0);
            List<string> numVeloCommande = velomax.SelectColumnFromWhere(connection, "liste_velo_commande", "*",
                "numero_commande_velo", numCommandeTemp, 1);
            int[] qteVeloStock = new int[qteVeloCommande.Count()];

            bool check = true;  //commande peut être faite
            string num = null;    //Indique l'item qui n'est pas présent en une quantité suffisamment grande
            bool commandIsEmpty = true; //Pour vérifier si la commande est vide

            if (qteVeloCommande.Count() > 0)
            {
                commandIsEmpty = false;
                //On prend les valeurs du stock vélo de vélomax dans qteVeloStock
                for (int i = 0; i < qteVeloCommande.Count(); i++)
                {
                    qteVeloStock[i] = Convert.ToInt32(velomax.SelectColumnFromWhere(connection, "velo", "stock_velo",
                    "numero_velo", numVeloCommande[i], 0)[0]);

                    if (qteVeloStock[i] - Convert.ToInt32(qteVeloCommande[i]) < 0)
                    {
                        check = false;  //On renvoie false si les stocks ne sont pas suffisants
                        num = "\n" + numVeloCommande[i];
                    }
                }
            }
            
            if (check == false) MessageBox.Show("Pas assez de stock pour les vélo numéros :\n" + num);
            else 
            {
                List<string> qtePieceCommande = velomax.SelectColumnFromWhere(connection, "liste_piece_commande", "quantite_piece_commande",
               "numero_commande_piece", numCommandeTemp, 0);
                List<string> numPieceCommande = velomax.SelectColumnFromWhere(connection, "liste_piece_commande", "*",
                    "numero_commande_piece", numCommandeTemp, 0);
                int[] qtePieceStock = new int[qtePieceCommande.Count()];

                //MessageBox.Show(Convert.ToString(qtePieceCommande.Count()));

                if (qtePieceCommande.Count() > 0)
                {
                    commandIsEmpty = false;
                    //On prend les valeurs du stock pièce de vélomax dans qtePièceStock
                    for (int i = 0; i < qteVeloCommande.Count(); i++)
                    {
                        qtePieceStock[i] = Convert.ToInt32(velomax.SelectColumnFromWhere(connection, "piece", "stock_piece",
                        "numero_piece_catalogue", numPieceCommande[i], 0)[0]);

                        if (qtePieceStock[i] - Convert.ToInt32(qtePieceCommande[i]) < 0)
                        {
                            check = false;  //On renvoie false si les stocks ne sont pas suffisants
                            num = "\n" + numPieceCommande[i];
                        }
                        //MessageBox.Show(numPieceCommande[i]);
                        //MessageBox.Show(qtePieceCommande[i] + " " + numPieceCommande[i]);
                    }

                    if (check == false) MessageBox.Show("Pas assez de stock pour les pièces :\n" + num);
                    else //Update des stocks si jamais tous les items de la commande sont présents en stock
                    {
                        for (int i = 0; i < qteVeloCommande.Count() && check; i++)
                        {
                            qteVeloStock[i] = qteVeloStock[i] - Convert.ToInt32(qteVeloCommande[i]);
                            velomax.Query(connection, "UPDATE velo SET stock_velo =" + Convert.ToString(qteVeloStock[i]) +
                                " WHERE numero_velo =" + numVeloCommande[i] + ";");
                        }

                        for (int i = 0; i < qtePieceCommande.Count() && check; i++)
                        {
                            qtePieceStock[i] = qtePieceStock[i] - Convert.ToInt32(qtePieceCommande[i]);
                            velomax.Query(connection, "UPDATE piece SET stock_piece =" + Convert.ToString(qtePieceStock[i]) +
                                " WHERE numero_piece_catalogue ='" + numPieceCommande[i] + "';");
                            
                        }

                        MessageBox.Show("Commande " + numCommandeTemp + " envoyée");

                        /*
                        #region Stocks checking                      
                        if (qteVeloStock.Length > 0) //On vérifie les stocks des vélos 
                                                     //s'il y a des vélos dans la commande
                        {
                            bool checkVelo = true;  //true == tous les stocks sont ok
                            string chainVelo = "Attention le stock des vélos suivants sont vides : \n";
                            for (int i = 0; i < qteVeloStock.Length; i++)
                            {
                                if(qteVeloStock[i] == 0)
                                {
                                    checkVelo = false;
                                    chainVelo += "\n " + numVeloCommande[i];
                                }
                            }

                            if (!checkVelo) MessageBox.Show(chainVelo);                                
                        }

                        if (qtePieceStock.Length > 0) //On vérifie le stock des pièces
                                                      //s'il y a des pièces dans la commande
                        {
                            bool checkPiece = true;  //true == tous les stocks sont ok
                            string chainPiece = "Attention le stock des pièces suivantes sont vides : \n";
                            for (int i = 0; i < qtePieceStock.Length; i++)
                            {
                                if (qtePieceStock[i] == 0)
                                {
                                    checkPiece = false;
                                    chainPiece += "\n " + numPieceCommande[i];
                                }
                            }

                            if (!checkPiece) MessageBox.Show(chainPiece);
                        }
                        #endregion Stocks checking
                        */

                        newPageCommande.IsChecked = false;
                        newPageCommande_Unchecked(sender, e);
                    }
                }
                if (commandIsEmpty) MessageBox.Show("Commande vide");
            }
            CheckStock();
        }

        private void CheckStock()
        {
            List<Velo> velo = (List<Velo>)velomax.SelectAllFromTable(connection, "velo");
            List<Piece> piece = (List<Piece>)velomax.SelectAllFromTable(connection, "piece");

            string veloStock = "Les vélos suivants sont en rupture de stock :\n";
            bool checkVeloStock = false;
            for(int i = 0; i < velo.Count(); i++)
            {
                if (velo[i].Stock_velo <= 0)
                {
                    veloStock += "\n" + velo[i];
                    checkVeloStock = true;
                }
            }

            string pieceStock = "Les pièces suivantes sont en rupture de stock :\n";
            bool checkPieceStock = false;
            for (int i = 0; i < piece.Count(); i++)
            {                
                if(piece[i].Stock_piece <= 0)
                {
                    pieceStock += "\n" + piece[i];
                    checkPieceStock = true;
                }
            }

            if (checkVeloStock) MessageBox.Show(veloStock);
            if (checkPieceStock) MessageBox.Show(pieceStock);
        }       
    }
}
