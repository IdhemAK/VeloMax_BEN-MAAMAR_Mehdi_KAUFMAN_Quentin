using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Program_Velomax
{
    public class VeloMax
    {
        #region Attributs
        //Tables
        private List<Velo> velo;
        private List<Piece> piece;
        private List<Commande> commande;
        private List<Fournisseur> fournisseur;
        private List<Client> client;
        private List<Adresse> adresse;
        private List<Programme> programme;

        //Associations
        private List<Tuple<Velo, Piece, int>> liste_assemblage;
        private List<Tuple<Commande, Piece, int>> liste_piece_commande;
        private List<Tuple<Commande, Velo, int>> liste_velo_commande;
        private List<Tuple<Piece, Fournisseur, int>> catalogue;
        // = new List<Tuple<Velo, Piece, int>>();
        #endregion Attributs

        #region Constructeurs
        public VeloMax()
        {
            //velo = new List<Velo>();
        }
        public VeloMax(List<Velo> velo, List<Piece> piece, List<Commande> commande, List<Fournisseur> fournisseur,
            List<Client> client, List<Adresse> adresse, List<Programme> programme,
            List<Tuple<Velo, Piece, int>> liste_assemblage,
            List<Tuple<Commande, Piece, int>> liste_piece_commande,
            List<Tuple<Commande, Velo, int>> liste_velo_commande,
            List<Tuple<Piece, Fournisseur, int>> catalogue)
        {
            //Tables
            this.velo = velo;
            this.piece = piece;
            this.commande = commande;
            this.fournisseur = fournisseur;
            this.client = client;
            this.adresse = adresse;
            this.programme = programme;

            //Associations
            this.liste_assemblage = liste_assemblage;
            this.liste_piece_commande = liste_piece_commande;
            this.liste_velo_commande = liste_velo_commande;
            this.catalogue = catalogue;
        }
        #endregion Constructeurs

        #region Accesseurs
        //Tables
        public List<Velo> Liste_velo
        {
            get { return velo; }
            set { velo = value; }
        }
        public List<Piece> Liste_piece
        {
            get { return piece; }
            set { piece = value; }
        }
        public List<Commande> Liste_commande
        {
            get { return commande; }
            set { commande = value; }
        }
        public List<Fournisseur> Liste_fournisseur
        {
            get { return fournisseur; }
            set { fournisseur = value; }
        }
        public List<Client> Liste_client
        {
            get { return client; }
            set { client = value; }
        }
        public List<Adresse> Liste_adresse
        {
            get { return adresse; }
            set { adresse = value; }
        }
        public List<Programme> Liste_programme
        {
            get { return programme; }
            set { programme = value; }
        }

        //Associations
        public List<Tuple<Velo, Piece, int>> Liste_assemblage
        {
            get { return liste_assemblage; }
            set { liste_assemblage = value; }
        }
        public List<Tuple<Commande, Piece, int>> Liste_piece_commande
        {
            get { return liste_piece_commande; }
            set { liste_piece_commande = value; }
        }
        public List<Tuple<Commande, Velo, int>> Liste_velo_commande
        {
            get { return liste_velo_commande; }
            set { liste_velo_commande = value; }
        }
        public List<Tuple<Piece, Fournisseur, int>> Catalogue
        {
            get { return catalogue; }
            set { catalogue = value; }
        }
        #endregion Accesseurs

        #region Changements
        public delegate void Creation(MySqlConnection connection, string[] variables);
        public void Create(Creation n, MySqlConnection connection, string[] variables)
        {
            n(connection, variables);
        }
        public string Concatenate_Create(string table, string[] variables)
        {
            string conc = "INSERT INTO " + table + " VALUES (";
            for (int i = 0; i < variables.Length - 1; i++)
            {
                conc += variables[i] + ", ";
            }
            return conc + variables[variables.Length - 1] + ");";
        }
        public string Concatenate_Update(string table, string column, string oldVariable, string newVariable)
        {
            return "UPDATE " + table + " SET " + column + "='" + newVariable +
                "' WHERE " + column + "='" + oldVariable + "';";
        }
        public string Concatenate_Remove(string table, string column, string nameVariable)
        {
            return "DELETE FROM " + table +
                " WHERE " + column + " ='" + nameVariable + "';";
        }

        public void Query(MySqlConnection connection, string query)
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = query;
            try
            {
                command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                Console.ReadLine();
                return;
            }
            connection.Close();
        }

        //Pensez à vérifier si les string entrés sont bons
        //à partir du Mainwindow WPF
        //==> format date - int - nombre de variables

        //voir si on ouvre la connexion dans Query


        #region Velo
        public void Create_velo(MySqlConnection connection, string[] variables)
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
        #endregion Velo


        #endregion Changements
    }
}
