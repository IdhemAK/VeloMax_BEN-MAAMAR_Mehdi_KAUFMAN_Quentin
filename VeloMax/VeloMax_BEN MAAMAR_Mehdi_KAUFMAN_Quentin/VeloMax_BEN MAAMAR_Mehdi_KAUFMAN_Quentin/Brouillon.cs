using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_Velomax
{
    /// <summary>
    /// Cette classe sert uniquement à entreposer des
    /// idées de code 
    /// </summary>
    class Brouillon
    {

        /* Ancien delegate pour Creation etc
        public delegate void Creation(MySqlConnection connection, string[] variables);
        public void Create(Creation n, MySqlConnection connection, string[] variables)
        {
            n(connection, variables);
        }
        */

        /* Ancien Create et Remove avec List
        public void Create_velo(MySqlConnection connection, string table, string[] variables, int[] indexInt)
        {
            string[] temp1 = variables[5].Split('-');
            string[] temp2 = variables[6].Split('-');
            DateTime date_introduction_velo =
                new DateTime(int.Parse(temp1[0]), int.Parse(temp1[1]), int.Parse(temp1[2]));
            DateTime date_discontinuation_velo =
                new DateTime(int.Parse(temp2[0]), int.Parse(temp2[1]), int.Parse(temp2[2]));

            velo.Add(new Velo(Convert.ToInt32(variables[0]), variables[1], variables[2],
                float.Parse(variables[3]), variables[4], date_introduction_velo,
                date_discontinuation_velo, int.Parse(variables[7])));

            for (int i = 0; i < variables.Length; i++)
            {
                if (i != 0 || i != 3 || i != 7)
                {
                    variables[i] = "'" + variables[i] + "'";
                }
            }

            Query(connection, Concatenate_Create("velo", variables));
        }

        public void Remove_velo(MySqlConnection connection, string column, string variable)
        {
            int numero_velo = int.Parse(variable);
            int num = 2;
            string column2 = "grandeur_velo";
            Velo bt = new Velo();

            //int numV = new Velo().Variables_velo.IndexOf(column)
        }
        */

        /* ancienne structure commande EntreeSortie
                    //Possibility if DateTime condition
                    if (!int.TryParse(commande[3], out int idAdresse))
                    {
                        MessageBox.Show("Entrer un nombre entier pour ID adresse ");
                    }
                    else if (!velomax.ExistsInDataBase(connection, "adresse", "ID_adresse", commande[3], true))
                    {
                        string chain = null;
                        List<Adresse> adresse = (List<Adresse>)velomax.SelectAllFromTable(connection, "adresse");
                        for (int i = 0; i < adresse.Count(); i++)
                        {
                            chain += "\n" + adresse[i];
                        }
                        MessageBox.Show("Entrer l'un des ID correspondant à l'une des adresses existante suivante : \n" + chain);
                    }
                    else if (!int.TryParse(commande[4], out int idClient))
                    {
                        string typeClient = Entreprises.IsChecked == true ? "client_entreprise" : "client_particulier";
                        DisplayTypeClient(typeClient);                        
                    }
                    else
                    {
                                   
                    }
                    
                    if (DateTime.TryParse(commande[1], out DateTime dateIntro) || DateTime.TryParse(commande[2], out DateTime dateDiscont)
                        || commande[1] == "" || commande[2] == "")
                    {
                                       
                    }
                    else MessageBox.Show("Mauvais format de date\nBon format : YYYY/MM/DD");

                    if (commande[1] == "" && commande[2] == "")
                        {
                            commande[3] = "null";
                            commande[4] = "null";
                            velomax.Create(connection, "commande", commande, new int[] { 0, 1, 2, 3 });
                        }
                        else if (commande[1] == "")
                        {
                            commande[1] = "null";
                            velomax.Create(connection, "commande", commande, new int[] { 0, 1, 3 });
                        }
                        else if (commande[2] == "")
                        {
                            commande[2] = "null";
                            velomax.Create(connection, "commande", commande, new int[] { 0, 2, 3 });
                        }
                        else velomax.Create(connection, "commande", commande, new int[] { 0, 3 });
                    */

        /* Je ne prends qu'un string dans commande
                        commande[0] = Convert.ToString(velomax.IDMaxPlusOne(connection, "commande", "numero_commande", 0, false));

                        DateTime now = DateTime.Now;
                        commande[1] = now.ToString("yyyy/MM/dd");
                        commande[2] = (now + new TimeSpan(new Random().Next(1, 30), 0, 0, 0)).ToString("yyyy/MM/dd");
                        commande[3] = velomax.SelectColumnFromWhere(connection, typeClient, "ID_adresse_" + typeClient, "ID_" + typeClient, commande[4])[0];
                        string[] fullCommande = new string[commande.Length + 1];

                        string test = null;

                        DataTable newCommande = null;
                        if (Entreprises.IsChecked == true)
                        {
                            for (int i = 0; i < commande.Length; i++)
                            {
                                fullCommande[i] = commande[i];
                                test += fullCommande[i] + " ";
                            }
                            fullCommande[fullCommande.Length - 1] = "null";
                            test += fullCommande[fullCommande.Length - 1];

                            MessageBox.Show(test);

                            velomax.Create(connection, "commande", fullCommande, new int[] { 0, 3 });
                            newCommande = velomax.dataLoader(connection, velomax.GetCommande_entreprise);
                        }
                        else
                        {
                            for (int i = 0; i < commande.Length - 1; i++) fullCommande[i] = commande[i];
                            fullCommande[fullCommande.Length - 2] = "null";
                            fullCommande[fullCommande.Length - 1] = commande[4];

                            velomax.Create(connection, "commande", fullCommande, new int[] { 0, 3 });
                            newCommande = velomax.dataLoader(connection, velomax.GetCommande_particulier);
                        }
                        */


        //comboboxAdresse.SelectedItemBinding = fournisseur.Columns[4];
        //comboboxAdresse.ItemsSource = new List<string>() { "A", "B", "C", "D" };


        /* idée pour vérifier les stocks lorsque on crée la commande
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



        /* //Utilisatio de enum pour Velo
        public enum variables_velo
        {
            numero_velo = Numero_velo, nom_velo, grandeur_velo, prix_velo, ligne_produit_velo,
            date_introduction_velo, date_discontinuation_velo, stock_velo
        }
        */

        /* Noms des variables de Velo
        private List<string> variables_velo =
            new List<string>() { "numero_velo", "nom_velo", "grandeur_velo", "prix_velo", "ligne_produit_velo," +
                "date_introduction_velo", "date_discontinuation_velo", "stock_velo" };
                */


        /* Recherche sur les DataGrid
         <!-- Recherches et tests sur les DataGrids -->
<!--
            <DataGridTemplateColumn Header="Velo">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <TextBlock Text="{Binding Début production}"/>
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
                <DataGridTemplateColumn.CellEditingTemplate>
                    <DataTemplate>
                        <DatePicker SelectedDate="{Binding Début production}"/>
                    </DataTemplate>
                </DataGridTemplateColumn.CellEditingTemplate>
            </DataGridTemplateColumn>
            -->

<!--
            <DataGrid.Columns>
                <DataGridComboBoxColumn Header="Fournisseur" x:Name="comboBoxFournisseur"
                SelectedValueBinding="{Binding Fournisseur, Mode=TwoWay}" SelectedItemBinding="{Binding Status}" Visibility="Collapsed"/>
            </DataGrid.Columns>
            -->



         */
    }
}
