using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;

namespace VeloMax_BEN_MAAMAR_Mehdi_KAUFMAN_Quentin
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
        #endregion Attributs

        #region Requête
        private string getVelo;
        private string getPiece;
        private string getCommande_entreprise;
        private string getCommande_particulier;
        private string getFournisseur;
        private string getClient_entreprise;
        private string getClient_particulier;
        private string getAdresse;
        #endregion Requête

        #region Constructeurs
        /// <summary>
        /// Constructeur principal initialisant toutes les requêtes
        /// </summary>
        public VeloMax()
        {
            getVelo = "select numero_velo as 'Numéro'," +
                " nom_velo as 'Modèle'," +
                "grandeur_velo as 'Taille'," +
                " prix_velo as 'Prix'," +
                " ligne_produit_velo as 'Type'," +
                " DATE_FORMAT(date_introduction_velo, '%Y-%m-%d') as 'Début production'," +
                " DATE_FORMAT(date_discontinuation_velo, '%Y-%m-%d') as 'Fin production'," +
                " stock_velo as 'Stock' from velo;";

            getPiece = "select p.numero_piece_catalogue as 'Ref fournisseur', " +
                " p.numero_piece as 'Numéro'," +
                " p.description_piece as 'Type', " +
                "DATE_FORMAT(p.date_introduction_piece, '%Y-%m-%d') as 'Début production'," +
                "DATE_FORMAT(p.date_discontinuation_piece, '%Y-%m-%d') as 'Fin production'," +
                " p.prix_piece as 'Prix'," +
                " p.delai_approvisionnement_piece as 'Délai'," +
                " p.stock_piece as 'Stock' from piece p " +
                "ORDER BY CONVERT(SUBSTRING(numero_piece, 2), UNSIGNED INT);";

            getCommande_entreprise = "select numero_commande as 'Numéro commande'," +
                "DATE_FORMAT(date_commande, '%Y-%m-%d') as 'Date de commande'," +
                "DATE_FORMAT(date_livraison_commande, '%Y-%m-%d') as 'Date de livraison'," +
                "ID_adresse_commande as 'ID adresse'," +
                "c.ID_client_entreprise as 'ID entreprise' " +
                "from commande c " +
                "join client_entreprise ce on ce.ID_client_entreprise = c.ID_client_entreprise; ";

            getCommande_particulier = "select numero_commande as 'Numéro commande'," +
                "DATE_FORMAT(date_commande, '%Y-%m-%d') as 'Date de commande'," +
                "DATE_FORMAT(date_livraison_commande, '%Y-%m-%d') as 'Date de livraison'," +
                "ID_adresse_commande as 'ID adresse'," +
                "c.ID_client_particulier as 'ID particulier' " +
                "from commande c " +
                "join client_particulier ce on ce.ID_client_particulier = c.ID_client_particulier; ";

            getFournisseur = "select siret_fournisseur as 'Siret'," +
               "nom_fournisseur as 'Fournisseur'," +
               "qualite_fournisseur as 'Qualité'," +
               "nom_contact_fournisseur as 'Contact'," +
               "ID_adresse_fournisseur as 'Adresse'" +
               "from fournisseur; ";

            getClient_entreprise = "select ID_client_entreprise as 'ID'," +
                "nom_client_entreprise as 'Entreprise'," +
                "remise_client_entreprise as 'Remise'," +
                "courriel_entreprise as 'Courriel'," +
                "telephone_entreprise as 'Téléphone'," +
                "nom_contact_entreprise as 'Nom contact'," +
                "ID_adresse_client_entreprise as 'ID adresse'" +
                "from client_entreprise " +
                "order by CONVERT(SUBSTRING(ID_client_entreprise, 6), UNSIGNED INT);";

            getClient_particulier = "SELECT ID_client_particulier AS 'ID'," +
                "nom_client_particulier AS 'Nom'," +
                "prenom_client_particulier AS 'Prénom'," +
                "DATE_FORMAT(date_adhesion_programme, '%Y-%m-%d') AS 'Date adhésion programme'," +
                "courriel_particulier AS 'Courriel'," +
                "telephone_particulier AS 'Téléphone'," +
                "numero_programme AS 'Numéro programme'," +
                "ID_adresse_client_particulier AS 'Adresse'" +
                "FROM client_particulier " +
                "order by CONVERT(SUBSTRING(ID_client_particulier, 6), UNSIGNED INT); ";

            getAdresse = "select ID_adresse as 'ID adresse'," +
                "rue_adresse as 'Rue'," +
                "ville_adresse as 'Ville'," +
                "code_postal_adresse as 'Code postal'," +
                "province_adresse as 'Province' " +
                "from adresse;";
        }
        
        /// <summary>
        /// Constructeur définit avec toutes les listes de la BDD au cas où
        /// Nous le laissons ici bien que nous ne l'ayons pas utilisé
        /// </summary>
        /// <param name="velo"></param>
        /// <param name="piece"></param>
        /// <param name="commande"></param>
        /// <param name="fournisseur"></param>
        /// <param name="client"></param>
        /// <param name="adresse"></param>
        /// <param name="programme"></param>
        /// <param name="liste_assemblage"></param>
        /// <param name="liste_piece_commande"></param>
        /// <param name="liste_velo_commande"></param>
        /// <param name="catalogue"></param>
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

        /// <summary>
        /// Sélectionne tous les tuples de la table indiquée en paramètre dans une liste
        /// définie en attribut de la classe VeloMax
        /// On peut voir dans la structure switch case les différentes
        /// tables implémentée
        /// En effet nous n'avons pas eu besoin de mettre toutes les tables
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        public object SelectAllFromTable(MySqlConnection connection, string table)
        {
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            MySqlDataReader reader;

            object liste = null;

            switch(table)
            {
                case "velo":
                    command.CommandText = "SELECT * FROM velo order by numero_velo;";
                    reader = command.ExecuteReader();
                    velo = new List<Velo>();
                    while (reader.Read())
                    {               
                        velo.Add(new Velo(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetFloat(3),
                                reader.GetString(4), DateTime.MinValue, DateTime.MinValue, reader.GetInt32(7)));
                    }
                    liste = velo;
                    break;

                case "piece":
                    command.CommandText = "SELECT * FROM piece order by CONVERT(SUBSTRING(numero_piece, 2), UNSIGNED INT);";
                    reader = command.ExecuteReader();
                    piece = new List<Piece>();
                    while (reader.Read())
                    {
                        piece.Add(new Piece(reader.GetString(0), reader.GetString(1), reader.GetString(2), DateTime.MinValue,
                            DateTime.MinValue, reader.GetFloat(5), reader.GetInt32(6), reader.GetInt32(7)));
                    }
                    liste = piece;
                    break;

                case "adresse":
                    command.CommandText = "SELECT * FROM adresse order by ID_adresse;";
                    reader = command.ExecuteReader();
                    adresse = new List<Adresse>();
                    while (reader.Read())
                    {
                        adresse.Add(new Adresse(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),
                            reader.GetString(3), reader.GetString(4)));
                    }
                    liste = adresse;
                    break;                  

                case "client_entreprise":
                    command.CommandText = "SELECT * FROM client_entreprise ORDER BY CONVERT(SUBSTRING(ID_client_entreprise, 6), UNSIGNED INT);";
                    reader = command.ExecuteReader();
                    client = new List<Client>();
                    while (reader.Read())
                    {
                        client.Add(new Client_entreprise(reader.GetString(0), reader.GetString(3), reader.GetString(4),
                            adresse.Find(ad => ad.ID_Adresse == reader.GetInt32(6)), reader.GetString(1), reader.GetFloat(2),
                            reader.GetString(5)));
                    }
                    liste = client;
                    break;

                case "client_particulier":
                    command.CommandText = "SELECT * FROM client_particulier ORDER BY CONVERT(SUBSTRING(ID_client_particulier, 6), UNSIGNED INT);";
                    reader = command.ExecuteReader();
                    client = new List<Client>();
                    while (reader.Read())
                    {
                        client.Add(new Client_particulier(reader.GetString(0), reader.GetString(4), reader.GetString(5),
                            adresse.Find(ad => ad.ID_Adresse == reader.GetInt32(7)), reader.GetString(1), reader.GetString(2),
                            reader.GetDateTime(3), programme.Find(prog => prog.Numero_programme == reader.GetInt32(6))));
                    }
                    liste = client;
                    break;

                case "programme":
                    command.CommandText = "SELECT * FROM programme ORDER BY numero_programme;";
                    reader = command.ExecuteReader();
                    programme = new List<Programme>();
                    while (reader.Read())
                    {
                        programme.Add(new Programme(reader.GetInt32(0), reader.GetString(1), reader.GetFloat(2),
                            reader.GetInt32(3), reader.GetFloat(4)));
                    }
                    liste = programme;
                    break;
            }           
            connection.Close();
            return liste;
        }

        #region Accesseurs Listes
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
        #endregion Accesseurs Listes     

        #region Accesseurs Requêtes
        public string GetVelo
        {
            get { return this.getVelo; }
        }
        public string GetPiece
        {
            get { return getPiece; }
        }
        public string GetCommande_entreprise
        {
            get { return getCommande_entreprise; }
        }
        public string GetCommande_particulier
        {
            get { return getCommande_particulier; }
        }
        public string GetFournisseur
        {
            get { return getFournisseur; }
        }
        public string GetClient_entreprise
        {
            get { return getClient_entreprise; }
        }
        public string GetClient_particulier
        {
            get { return getClient_particulier; }
        }
        public string GetAdresse
        {
            get { return getAdresse; }
        }
        #endregion Accesseurs Requêtes

        #region Gestion (velo, piece, client, fournisseur, commande)
        /// <summary>
        /// Renvoie un string contenant une requête d'insertion
        /// </summary>
        /// <param name="table">table dans laquelle insérer le tuple</param>
        /// <param name="variables">variables du tuple à créer</param>
        /// <returns></returns>
        public string Concatenate_Create(string table, string[] variables)
        {
            string conc = "INSERT INTO " + table + " VALUES (";
            for (int i = 0; i < variables.Length - 1; i++)
            {
                conc += variables[i] + ", ";
            }
            return conc + variables[variables.Length - 1] + ");";
        }
        /// <summary>
        /// Renvoie un string contenant une requête de mise à jour
        /// d'un tuple
        /// </summary>
        /// <param name="table">table du tuple à modifier</param>
        /// <param name="columnFind">colonne dans laquelle chercher le tuple</param>
        /// <param name="columnChange">colonne de la valeur à modifier</param>
        /// <param name="variableFind">variable de la colonne à chercher</param>
        /// <param name="variableChange">variable de la colonne à modifier</param>
        /// <returns></returns>
        public string Concatenate_Update(string table, string columnFind, string columnChange, string variableFind, string variableChange)
        {
            return "UPDATE " + table + " SET " + columnChange + "=" + variableChange +
                " WHERE " + columnFind + "=" + variableFind + ";";
        }
        /// <summary>
        /// Renvoie un string contenant une requête de suppression
        /// </summary>
        /// <param name="table">table du tuple à supprimer</param>
        /// <param name="column">colonne du tuple à supprimer</param>
        /// <param name="nameVariable">nom de la variable de la colonne dans laquelle 
        /// chercher le tuple à supprimer</param>
        /// <returns></returns>
        public string Concatenate_Remove(string table, string column, string nameVariable)
        {
            return "DELETE FROM " + table +
                " WHERE " + column + " ='" + nameVariable + "';";
        }

        /// <summary>
        /// Envoie une requête SQL
        /// </summary>
        /// <param name="connection">connexion MySQL</param>
        /// <param name="query">requête MySQL</param>
        public void Query(MySqlConnection connection, string query)
        {            
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = query;
            try
            {
                //MessageBox.Show(query);
                command.ExecuteNonQuery();                
            }
            catch (MySqlException e)
            {
                MessageBox.Show(" ErreurConnexion : " + e.ToString());
                return;
            }
            connection.Close();
        }

        /// <summary>
        /// Créer un tuple dans une table
        /// </summary>
        /// <param name="connection">connexion MySQL</param>
        /// <param name="table">nom de la table</param>
        /// <param name="variables">contient les variables à placer dans la requête SQL</param>
        /// <param name="indexNb">index des nombres qui sont des int ou bien des null</param>
        public void Create(MySqlConnection connection, string table, string[] variables, int[] indexNb)
        {
            string test = null;
            for (int i = 0; i < variables.Length; i++)
            {
                //si la variable n'est pas un nombre
                if (!indexNb.Contains(i)) variables[i] = "'" + variables[i] + "'";
                test += variables[i] + " ";
            }
            
            Query(connection, Concatenate_Create(table, variables));
            //MessageBox.Show(test);
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
        #endregion Gestion (velo, piece, client, fournisseur, commande)

        /// <summary>
        /// Renvoie un DataTable contenant les éléments d'une requête
        /// </summary>
        /// <param name="connection">connexion MySQL</param>
        /// <param name="requete">requête MySQL</param>
        /// <returns></returns>
        public DataTable dataLoader(MySqlConnection connection, string requete)
        {
            connection.Open();
            MySqlCommand commande = connection.CreateCommand();
            commande.CommandText = requete;
            MySqlDataReader reader = commande.ExecuteReader();

            DataTable data = new DataTable();
            data.Load(reader);
            reader.Close();

            connection.Close();
            return data;
        }

        #region SQL Queries
        /// <summary>
        /// Renvoie le nombre de tuple contenu dans 
        /// une table de la BDD
        /// </summary>
        /// <param name="connection">connexion MySQL</param>
        /// <param name="table">table dans laquelle chercher</param>
        /// <returns>nombre de tuple contenu dans la table</returns>
        public int CountTuple(MySqlConnection connection, string table)
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            //Requête sql
            command.CommandText = "SELECT count(*) FROM " + table + ";";

            MySqlDataReader reader;
            reader = command.ExecuteReader();

            int count = 0;
            while (reader.Read()) count = reader.GetInt32(0);

            connection.Close();
            return count;        
        }

        /// <summary>
        /// Renvoie un bool indiquant si un tuple existe
        /// dans l'une des tables de la BDD à l'aide d'une 
        /// requête SQL
        /// </summary>
        /// <param name="connection">connesion MySQL</param>
        /// <param name="table">table du tuple à chercher</param>
        /// <param name="columnPrimaryKey">colonne du tuple à chercher</param>
        /// <param name="primaryKey">variable du tuple à chercher dans columnPrimaryKey</param>
        /// <param name="keyIntOrNull">true si primaryKey est un int ou null et false sinon</param>
        /// <returns></returns>
        public bool ExistsInDataBase(MySqlConnection connection, string table, string columnPrimaryKey, string primaryKey, bool keyIntOrNull)
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();

            if (keyIntOrNull)
            {
                command.CommandText = "SELECT " + columnPrimaryKey + " FROM " + table +
                " WHERE " + columnPrimaryKey + " = " + primaryKey + ";";
            }
            else
            {
                command.CommandText = "SELECT " + columnPrimaryKey + " FROM " + table +
                " WHERE " + columnPrimaryKey + " = '" + primaryKey + "';";
            }
            
            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string take = null;
            while (reader.Read()) take = reader.GetString(0);

            connection.Close();
            return take == null ? false : true;
        }
        /// <summary>
        /// Renvoie un bool indiquant si un tuple existe
        /// dans l'une des tables de la BDD à l'aide d'une 
        /// requête SQL ayant la structure 
        /// Select ... From ... Where ... And...
        /// </summary>
        /// <param name="connection">connexion MySQL</param>
        /// <param name="table">table du tuple à chercher</param>
        /// <param name="columnKeyOne">colonne 1 du tuple à chercher</param>
        /// <param name="keyOne">variable du tuple à chercher dans columnKeyOne</param>
        /// <param name="columnKeyTwo">colonne 2 du tuple à chercher</param>
        /// <param name="keyTwo">variable du tuple à chercher dans columnKeyTwo</param>
        /// <returns></returns>
        public bool ExistsInDataBaseWhereAnd(MySqlConnection connection, string table, string columnKeyOne, string keyOne,
            string columnKeyTwo, string keyTwo)
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = QuerySelectAllFromWhereAnd(table, columnKeyOne, keyOne, columnKeyTwo, keyTwo);

            MySqlDataReader reader;
            reader = command.ExecuteReader();

            string take = null;
            while (reader.Read()) take = reader.GetString(0);

            connection.Close();
            return take == null ? false : true;
        }

        /// <summary>
        /// Renvoie l'indice maximal+1 d'un tuple d'une table
        /// ayant des valeurs incrémentales
        /// </summary>
        /// <param name="connection">connexion MySQL</param>
        /// <param name="table">table du tuple à chercher</param>
        /// <param name="column">colonne du tuple à chercher</param>
        /// <param name="nbCharSubstr">nombre de caractères à soustraire de la chaîne à chercher</param>
        /// <param name="isSubstr">true si on doit soustraire des caractères à la chaîne et false sinon</param>
        /// <returns>indice maximal+1 d'un tuple</returns>
        public int IDMaxPlusOne(MySqlConnection connection, string table, string column, int nbCharSubstr, bool isSubstr)
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();

            command.CommandText = isSubstr == true ? "select max(CONVERT(SUBSTRING(" + column + ", " + nbCharSubstr + "), UNSIGNED INT)) " + "from " + table + ";" :
                "SELECT max(" + column + ") FROM " + table;

            MySqlDataReader reader;
            reader = command.ExecuteReader();

            int take = 0;
            while (reader.Read()) take = reader.GetInt32(0);

            connection.Close();

            return take + 1;
        }

        /// <summary>
        /// Renvoie toute la colonne d'une table avec la structure
        /// Select... From... order by...
        /// </summary>
        /// <param name="connection">connexion MySQL</param>
        /// <param name="table">table à étudier</param>
        /// <param name="column">colonne à renvoyer</param>
        /// <param name="orderBy">comment les tuples son classés dans la requête order by</param>
        /// <returns>colonne d'une table</returns>
        public List<string> SelectColumn(MySqlConnection connection, string table, string column, string orderBy)
        {
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT " + column + " FROM " + table + " order by " + orderBy + ";";

            MySqlDataReader reader;
            reader = command.ExecuteReader();

            List<string> take = new List<string>();
            while (reader.Read()) take.Add(reader.GetString(0));

            connection.Close();
            return take;
        }

     
        /// <summary>
        /// Construit et retourne une requête SQL ayant la structure
        /// Select... Column... From... Where...
        /// permettant e retourner tout une colonne
        /// </summary>
        /// <param name="table">table SQL à sélectionner</param>
        /// <param name="columnFind">colonne de la table à retourner</param>
        /// <param name="columnWhere">colonne de la table dans laquelle chercher</param>
        /// <param name="where">nom de la variable qu'on doit trouver dans les tuples à sélectionner</param>
        /// <returns></returns>
        public string QuerySelectColumnFromWhere(string table, string columnFind, string columnWhere, string where)
        {
            return "SELECT " + columnFind + " FROM " + table +
                " WHERE " + columnWhere + " = " + (int.TryParse(where, out int res) ? where : ("'" + where + "'")) + ";";
        }
        /// <summary>
        /// Construit et retourne une requête SQL ayant la structure
        /// Select... Column... From... Where... And...
        /// Avec tous les tupeles d'une table
        /// </summary>
        /// <param name="table">table SQL à sélectionner</param>
        /// <param name="columnKeyOne">colonne 1 de la table dans laquelle chercher</param>
        /// <param name="keyOne">variable de la colonne 1</param>
        /// <param name="columnKeyTwo">colonne 2 de la table dans laquelle chercher</param>
        /// <param name="keyTwo">variable de la colonne 2</param>
        /// <returns></returns>
        public string QuerySelectAllFromWhereAnd(string table, string columnKeyOne, string keyOne, string columnKeyTwo, string keyTwo)
        {
            return "SELECT * FROM " + table +
                " WHERE " + columnKeyOne + "=" + (int.TryParse(keyOne, out int res1) ? keyOne : ("'" + keyOne + "'")) + " AND " +
                columnKeyTwo + "=" + (int.TryParse(keyTwo, out int res2) ? keyTwo : ("'" + keyTwo + "'")) + ";";
        }

        /// <summary>
        /// Renvoie toute la colonne d'une table avec la structure
        /// Select... From... Where...
        /// </summary>
        /// <param name="connection">connexion MySQL</param>
        /// <param name="table">table dans laquelle chercher</param>
        /// <param name="columnFind">colonne à retourner</param>
        /// <param name="columnWhere">colonne de la clause Where</param>
        /// <param name="where">variable de columnWhere</param>
        /// <param name="index">index de la table à prendre ==> utile si Select * (All)</param>
        /// <returns>retourne la colonne recherchée</returns>
        public List<string> SelectColumnFromWhere(MySqlConnection connection, string table, string columnFind, string columnWhere, string where, 
            int index)
        {
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = QuerySelectColumnFromWhere(table, columnFind, columnWhere, where);

            MySqlDataReader reader;
            reader = command.ExecuteReader();

            List<string> take = new List<string>();
            while (reader.Read()) take.Add(reader.GetString(index));

            //if(table == "piece") MessageBox.Show(take[0]);
            connection.Close();
            return take;
        }

        /// <summary>
        /// Renvoie toute la colonne d'une table avec la structure
        /// Select... From... Where... And...
        /// </summary>
        /// <param name="connection">connexion MySQl</param>
        /// <param name="table">table dans laquelle chercher</param>
        /// <param name="columnKeyOne">colonne 1 de la clause where</param>
        /// <param name="keyOne">variable de colonne 1</param>
        /// <param name="columnKeyTwo">colonne 2 de la clause where</param>
        /// <param name="keyTwo">variable de colonne 2</param>
        /// <param name="index">index de la colonne à retourner</param>
        /// <returns>retourne la colonne recherchée</returns>
        public List<string> SelectColumnFromWhereAnd(MySqlConnection connection, string table, string columnKeyOne, string keyOne,
            string columnKeyTwo, string keyTwo, int index)
        {
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = QuerySelectAllFromWhereAnd(table, columnKeyOne, keyOne, columnKeyTwo, keyTwo);

            MySqlDataReader reader;
            reader = command.ExecuteReader();

            List<string> take = new List<string>();
            while (reader.Read()) take.Add(reader.GetString(index));

            connection.Close();

            return take;
        }
        #endregion SQL Queries
    }
}
