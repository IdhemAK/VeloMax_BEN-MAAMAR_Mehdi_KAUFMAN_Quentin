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
        #region chaîne de caractère pour les queries
        public string Concatenate_Create(string table, string[] variables)
        {
            string conc = "INSERT INTO " + table + " VALUES (";
            for (int i = 0; i < variables.Length - 1; i++)
            {
                conc += variables[i] + ", ";
            }
            return conc + variables[variables.Length - 1] + ");";
        }
        public string Concatenate_Update(string table, string columnFind, string columnChange, string variableFind, string variableChange)
        {
            return "UPDATE " + table + " SET " + columnChange + "=" + variableChange +
                " WHERE " + columnFind + "=" + variableFind + ";";
        }
        public string Concatenate_Remove(string table, string column, string nameVariable)
        {
            return "DELETE FROM " + table +
                " WHERE " + column + " ='" + nameVariable + "';";
        }
        #endregion string des queries

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

        /// <summary>
        /// Créer un tuple dans une table
        /// </summary>
        /// <param name="connection">connexion MySQL</param>
        /// <param name="table">nom de la table</param>
        /// <param name="variables">contient les variables à placer dans la requête SQL</param>
        /// <param name="indexNb">index des nombres qui sont des int ou bien des null</param>
        public void Create(MySqlConnection connection, string table, string[] variables, int[] indexNb)
        {
            for (int i = 0; i < variables.Length; i++)
            {
                //si la variable n'est pas un nombre
                if (!indexNb.Contains(i)) variables[i] = "'" + variables[i] + "'";             
            }
            Query(connection, Concatenate_Create(table, variables));
        }

        /// <summary>
        /// Supprime un élément de la BDD
        /// </summary>
        /// <param name="connection">connexion MySQL</param>
        /// <param name="table">nom de la table</param>
        /// <param name="column">nom de la colonne de la table</param>
        /// <param name="variable">variable correspondant au tuple à supprimer</param>
        /// <param name="variableIntOrNull">indique si la variable est int ou null
        /// pour adapter sa forme conséquence</param>
        public void Remove(MySqlConnection connection, string table, string column, string variable, bool variableIntOrNull)
        {
            if (!variableIntOrNull) variable = "'" + variable + "'";
            Query(connection, Concatenate_Remove(table, column, variable));
        }

        /// <summary>
        /// Met à jour la variable d'un élément
        /// </summary>
        /// <param name="connection">connexion MySQL</param>
        /// <param name="table">nom de la table</param>
        /// <param name="columnFind">nom de la colonne dans laquelle chercher</param>
        /// <param name="columnChange">nom de la colonne où le changemet est appliqué</param>
        /// <param name="variableFind">variable par laquelle le tuple à changer est identifié</param>
        /// <param name="variableChange">modification à appliquer</param>
        /// <param name="variableFindIntOrNull">variableFind true si elle est int ou null et false sinon</param>
        /// <param name="nvariableChangeIntOrNull">variableChange si elle est int ou null et false sinon</param>
        public void Update(MySqlConnection connection, string table, string columnFind, string columnChange, string variableFind, string variableChange, 
            bool variableFindIntOrNull, bool nvariableChangeIntOrNull)
        {
            if(!variableFindIntOrNull) variableFind = "'" + variableFind + "'";
            if (!nvariableChangeIntOrNull) variableChange = "'" + variableChange + "'";
            Query(connection, Concatenate_Update(table, columnFind, columnChange, variableFind, variableChange));
        }
        #endregion Changements
    }
}
