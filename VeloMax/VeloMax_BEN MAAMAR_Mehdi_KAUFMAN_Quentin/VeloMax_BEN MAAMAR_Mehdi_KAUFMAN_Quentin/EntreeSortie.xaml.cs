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
        bool isAdresse;
        bool[] isTab;

        bool isChanged;


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
            isAdresse = false;

            isTab = new bool[] { isVelo , isPiece, isCommande, isFournisseur,
                isClient_entreprise, isClient_particulier, isAdresse };

            isChanged = false;
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
                isTab[i] =  i == index ? true : false;
            }
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
                if (isTab[0] == true)
                {                    
                    string[] velo = new string[rowview.Row.ItemArray.Length];
                    for(int i = 1; i < velo.Length; i++)
                    {
                        velo[i] = Convert.ToString(rowview.Row.ItemArray[i]);
                    }

                    if (DateTime.TryParse(velo[5], out DateTime dateIntro) || DateTime.TryParse(velo[6], out DateTime dateDiscont) 
                        || velo[5] == "" || velo[6] == "")
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
                                velomax.Create(connection, "velo", velo, new int[] { 0, 3, 5, 7 });
                            }
                            else if (velo[6] == "")
                            {
                                velo[6] = "null";
                                velomax.Create(connection, "velo", velo, new int[] { 0, 3, 6, 7 });
                            }

                            DataTable newVelo = velomax.dataLoader(connection, velomax.GetVelo);
                            IODataGrid.ItemsSource = newVelo.DefaultView;
                        }                        
                    }
                    else
                    {
                        MessageBox.Show("Mauvais format de date\nBon format : YYYY/MM/DD");
                    }
                }
                else if (isTab[1] == true)
                {
                    string[] piece = new string[rowview.Row.ItemArray.Length];
                    
                    for (int i = 2; i < piece.Length; i++)
                    {
                        piece[i] = Convert.ToString(rowview.Row.ItemArray[i]);
                    }

                    if (DateTime.TryParse(piece[3], out DateTime dateIntro) || DateTime.TryParse(piece[4], out DateTime dateDiscont)
                        || piece[3] == "" || piece[4] == "")
                    {
                        string test = null;

                        bool okInt = true;
                        for(int i = 5; i < piece.Length && okInt == true; i++)
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
                                int numeroPiece = velomax.IDMaxPlusOne(connection, "piece", "numero_piece", 2);

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
                                    velomax.Create(connection, "piece", piece, new int[] { 3, 5, 6, 7 });
                                }
                                else if (piece[4] == "")
                                {
                                    piece[4] = "null";
                                    velomax.Create(connection, "piece", piece, new int[] { 4, 5, 6, 7 });
                                }

                                //MessageBox.Show(piece[3] + " " + piece[4]);
                                //MessageBox.Show(test);

                                DataTable newPiece = velomax.dataLoader(connection, velomax.GetPiece);
                                IODataGrid.ItemsSource = newPiece.DefaultView;
                            }                          
                        }                      
                    }
                    else
                    {
                        MessageBox.Show("Mauvais format de date\nBon format : YYYY/MM/DD");
                    }
                }
                else if (isCommande == true)
                {

                }
                else if (isTab[3] == true)
                {
                    string[] fournisseur = new string[rowview.Row.ItemArray.Length];                        
                    for (int i = 0; i < fournisseur.Length; i++)
                    {
                        fournisseur[i] = Convert.ToString(rowview.Row.ItemArray[i]);
                    }
                    

                    if (!int.TryParse(fournisseur[4], out int result))
                    {
                        MessageBox.Show("Entrer un nombre pour l'identifiant adresse");
                    }
                    else
                    {
                        
                        if (!velomax.ExistsInDataBase(connection, "adresse", "ID_adresse", fournisseur[4], true))
                        {
                            MessageBox.Show("Entrer un identifiant adresse existant");
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
                            }                           
                        }
                    }                   

                    DataTable newFournisseur = velomax.dataLoader(connection, velomax.GetFournisseur);
                    IODataGrid.ItemsSource = newFournisseur.DefaultView;
                }
                else if (isClient_entreprise == true)
                {

                }
                else if (isClient_particulier == true)
                {

                }
                else if (isTab[6] == true)
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
                    MessageBox.Show(adresse[0]);
                    velomax.Create(connection, "adresse", adresse, new int[] { 0 });
                    
                    //if (!velomax.ExistsInDataBase(connection, "adresse", "ID_adresse", rowview.Row[0].ToString()))
                    //else MessageBox.Show("Création impossible");

                    DataTable newAdresse = velomax.dataLoader(connection, velomax.GetAdresse);
                    IODataGrid.ItemsSource = newAdresse.DefaultView;
                }
            }
            

            /*
            string test = null;
            string id = rowview.Row[0].ToString();
            foreach (object row in rowview.Row.ItemArray)
            {
                test += row + " ";
            }

            MessageBox.Show(test);
            */
            //Entreprises.IsChecked == true;
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
                if (isVelo == true)
                {

                }
                else if (isPiece == true)
                {

                }
                else if (isCommande == true)
                {

                }
                else if (isTab[3] == true)
                {

                }
                else if (isClient_entreprise == true)
                {

                }
                else if (isClient_particulier == true)
                {

                }
                else if (isTab[6] == true)
                {
                    velomax.Remove(connection, "adresse", "ID_adresse", rowview.Row[0].ToString(), true);
                    DataTable newAdresse = velomax.dataLoader(connection, velomax.GetAdresse);
                    IODataGrid.ItemsSource = newAdresse.DefaultView;
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

            DataTable particuliers = velomax.dataLoader(connection, velomax.GetVelo);
            IODataGrid.ItemsSource = particuliers.DefaultView;
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

            

            DataTable piece = velomax.dataLoader(connection, velomax.GetPiece);

            stackPanelFournisseur.Visibility = Visibility.Visible;
            comboBoxFournisseur.ItemsSource = velomax.NomDesFournisseurs(connection);

            IODataGrid.ItemsSource = piece.DefaultView;
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

            DataTable fournisseur = velomax.dataLoader(connection, velomax.GetFournisseur);
            IODataGrid.ItemsSource = fournisseur.DefaultView;
            
            IsTableChecking(3);

            //comboboxAdresse.SelectedItemBinding = fournisseur.Columns[4];
            //comboboxAdresse.ItemsSource = new List<string>() { "A", "B", "C", "D" };
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

        private void Adresse(object sender, RoutedEventArgs e)
        {
            isCommande = false;
            isClient = false;
            Entreprises.IsChecked = false;
            Particuliers.IsChecked = false;
            Entreprises.Visibility = Visibility.Collapsed;
            Particuliers.Visibility = Visibility.Collapsed;
            stackPanelFournisseur.Visibility = Visibility.Collapsed;

            DataTable adresse = velomax.dataLoader(connection, velomax.GetAdresse);        
            IODataGrid.ItemsSource = adresse.DefaultView;
            
            IsTableChecking(6);           
        }


    }
}
