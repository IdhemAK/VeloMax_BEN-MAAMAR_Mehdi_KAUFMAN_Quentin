using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Xml;
using System.Xml.XPath;
using System.IO;
using System.Xml.Serialization;

namespace Program_Velomax
{
    class Program
    {

        static void afficheRequete(string user, string requete)
        {
            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = user;
                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            string[] valueString = new string[0];
            MySqlCommand commande = maConnexion.CreateCommand();
            commande.CommandText = requete;
            MySqlDataReader reader = commande.ExecuteReader();
            valueString = new string[reader.FieldCount];
            valueString = new string[reader.FieldCount];
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    valueString[i] = reader.GetValue(i).ToString();
                    Console.Write(valueString[i] + " , ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("\n");
            reader.Close();
            maConnexion.Close();
        }



        static void stockPiece(string user)
        {
            string pieceToOrder = "";
            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = user;
                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            string[] valueString = new string[0];
            MySqlCommand commande = maConnexion.CreateCommand();
            commande.CommandText = "select p.numero_piece,sum(p.stock_piece) from piece p group by p.numero_piece order by sum(p.stock_piece);";
            MySqlDataReader reader = commande.ExecuteReader();
            //valueString = new string[reader.FieldCount];
            string jsp = "";
            Console.WriteLine("Stock pièces :");
            Console.WriteLine("NumPiece | QteEnStock");
            Console.WriteLine("---------------------");
            while (reader.Read())
            {   
                Console.WriteLine(String.Format("   {0,-5} |    {1,-10}", reader.GetValue(0).ToString(), reader.GetValue(1).ToString()));
                if (Convert.ToInt32(reader.GetValue(1))< 50)
                {
                    pieceToOrder += String.Format("   {0,-5} |    {1,-10}", reader.GetValue(0).ToString(), reader.GetValue(1).ToString()) + "\n";
                }
            }
            Console.WriteLine("\nPieces en manque :");
            Console.WriteLine("NumPiece | QteEnStock");
            Console.WriteLine("---------------------");
            Console.WriteLine(pieceToOrder);
            reader.Close();
            maConnexion.Close();
            Console.WriteLine("Voulez-vous recommander ces pièces ?\n");
            // Insérer la fonction pour faire une commande 
            // Commande automatique 60 pieces de chaque ou alors choisir
            // On peut implémenter ces 2 trucs en WPF
        }
        static void stockPieceIndiv(string user)
        {
            string pieceToOrder = "";
            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = user;
                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            string[] valueString = new string[0];
            MySqlCommand commande = maConnexion.CreateCommand();
            commande.CommandText = "select numero_piece_catalogue, p.stock_piece, p.date_discontinuation_piece from piece p order by p.stock_piece;";
            MySqlDataReader reader = commande.ExecuteReader();
            //valueString = new string[reader.FieldCount];
            Console.WriteLine("Stock pièces individuelles :");
            Console.WriteLine("NumPiece     |QteEnStock|DateFinProduction");
            Console.WriteLine("------------------------------------------");
            while (reader.Read())
            {
                Console.WriteLine(String.Format("{0,-12} |    {1,-4}  | {2,-12}", reader.GetValue(0).ToString(), reader.GetValue(1).ToString(), reader.GetValue(2).ToString()));
                if (Convert.ToInt32(reader.GetValue(1)) <=30)
                {
                    pieceToOrder += String.Format("{0,-12} |    {1,-4}  | {2,-12}\n", reader.GetValue(0).ToString(), reader.GetValue(1).ToString(), reader.GetValue(2).ToString());
                }
            }
            Console.WriteLine("\nPieces en manque :");
            Console.WriteLine("NumPiece     |QteEnStock|DateFinProduction");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine(pieceToOrder);
            reader.Close();
            maConnexion.Close();
            Console.WriteLine("Voulez-vous recommander ces pièces ?\n");
            // Insérer la fonction pour faire une commande 
            // Commande automatique 60 pieces de chaque ou alors choisir
            // On peut implémenter ces 2 trucs en WPF
        }
        static void stockPieceType(string user)
        {
            string pieceToOrder = "";
            MySqlConnection maConnexion = null;
            try
            {
                string connexionString = user;
                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }
            string[] valueString = new string[0];
            MySqlCommand commande = maConnexion.CreateCommand();
            commande.CommandText = "select p.description_piece, sum(p.stock_piece) from piece p group by p.description_piece order by sum(p.stock_piece);";
            MySqlDataReader reader = commande.ExecuteReader();
            //valueString = new string[reader.FieldCount];
            string jsp = "";
            Console.WriteLine("Stock pièces par type :");
            Console.WriteLine("Type               | QteEnStock");
            Console.WriteLine("-------------------------------");
            while (reader.Read())
            {
                Console.WriteLine(String.Format("{0,-18} |    {1,-6}", reader.GetValue(0).ToString(), reader.GetValue(1).ToString()));
                if (Convert.ToInt32(reader.GetValue(1)) < 100)
                {
                    pieceToOrder += String.Format("{0,-18} |    {1,-6}", reader.GetValue(0).ToString(), reader.GetValue(1).ToString()) + "\n";
                }
            }
            Console.WriteLine("\nPieces en manque :");
            Console.WriteLine("Type               | QteEnStock");
            Console.WriteLine("-------------------------------");
            Console.WriteLine(pieceToOrder);
            reader.Close();
            maConnexion.Close();
            Console.WriteLine("Voulez-vous recommander ces pièces ?\n");
            // Insérer la fonction pour faire une commande 
            // Commande automatique 60 pieces de chaque ou alors choisir
            // On peut implémenter ces 2 trucs en WPF
        }


        static void serialiserSimple()
        {
            BD bd11 = new BD("978-2203001169", "On a marché sur la Lune", 62);
            Console.WriteLine(bd11);  // affichage pour débug

            // Code pour sérialiser l'objet bd11 en XML dans un fichier "bd11.xml"
            XmlSerializer xs = new XmlSerializer(typeof(BD));  // l'outil de sérialisation
            StreamWriter wr = new StreamWriter("bd11.xml");  // accès en écriture à un fichier (texte)
            xs.Serialize(wr, bd11); // action de sérialiser en XML l'objet bd11 
                                    // et d'écrire le résultat dans le fichier manipulé par wr
            wr.Close();
            Console.WriteLine("sérialisation dans fichier bd11.xml terminée");

            // vérifier le contenu du fichier "bd11.xml" dans le dossier bin\Debug de Visual Studio.
        }
        static void serialiserEnMasse()
        {
            Artiste herge = new Artiste("Remi", "Georges", "Hergé");
            BDtheque bdtheque = new BDtheque();

            BandeDessinee bd1 = new BandeDessinee("978-2203001169", "On a marché sur la Lune", herge, 62);
            bdtheque.Ajouter(bd1);
            bdtheque.Ajouter(new BandeDessinee("978-2203001039", "Les Cigares du pharaon", herge));
            bdtheque.Ajouter(new BandeDessinee("978-2012101371", "Le tour de	Gaule d'Astérix", new Artiste("Goscinny", "René"), 48));
            Console.WriteLine(bdtheque); //  affichage pour débug							

            //Instanciation des objets									
            XmlSerializer xs = new XmlSerializer(typeof(BDtheque));
            StreamWriter wr = new StreamWriter("theTest.xml");

            //sérialisation de bdtheque
            xs.Serialize(wr, bdtheque);

            wr.Close();
        }


        //select f.nom_fournisseur , sum(p.stock_piece) from catalogue c, piece p, fournisseur f where p.numero_piece_catalogue = c.numero_piece_catalogue and c.siret_fournisseur = f.siret_fournisseur group by f.nom_fournisseur order by sum(p.stock_piece);


        static void Main(string[] args)
        {
            string Mehdi = "SERVER=localhost;" + "PORT=3306;DATABASE=VeloMax;" + "UID=root;" + "PASSWORD=BDDMySQLD!d!2000;" + "SSLMODE=none;";
            string Quentin = "SERVER=localhost;PORT=3306;" + "DATABASE=VeloMax;" + "UID=root;PASSWORD=patate";



            #region LeTrucDeMehdi
            MySqlConnection connection = null;
            try
            {
                string connectionString = "SERVER=localhost;" +
                    "PORT=3306;DATABASE=VeloMax;" +
                    "UID=root;" +
                    "PASSWORD=BDDMySQLD!d!2000;" +
                    "SSLMODE=none;";

                connection = new MySqlConnection(connectionString);
                //connection.Open();
                //dans les static void 
            }
            catch (MySqlException e)
            {
                Console.WriteLine(" ErreurConnexion : " + e.ToString());
                return;
            }

            DateTime test = new DateTime(2000, 5, 24);
            Console.WriteLine(test);

            string[] vel = new string[] { "3", "Gamme", "Adulte", "400", "BMX", "2010-04-23", "2040-01-01", "80" };
            VeloMax velomax = new VeloMax();
            //velomax.Create(velomax.Create_velo, connection, vel);

            Velo bt = new Velo(1, "test", "Adultes", 10, "VTT", test, test, 12);
            int i = 2;

            //Console.WriteLine((Velo.variables_velo)i);

            /*
            Velo test = new Velo();

            string queryInsert = "INSERT INTO velo VALUES(2, 'Riverside', 'Adulte', 200, 'VTT', '2020-01-12', '2030-01-01', 50);";        
            test.Query(connection, queryInsert);

            string queryRemove = "DELETE FROM velo WHERE nom_velo ='Btwin';";
            test.Query(connection, queryRemove);

            string queryUpdate = "UPDATE velo SET nom_velo = 'ALPHABETA' WHERE nom_velo ='Riverside';";
            test.Query(connection, queryUpdate);
            */

            /*
            Tuple<string, double, int> test = new Tuple<string, double, int>("Noct", 18.8, 24);
            Console.WriteLine(test.Item1);
            Console.WriteLine(test.Item2);
            Console.WriteLine(test.Item3);
            Console.WriteLine(test);
            Console.WriteLine();

            List<Tuple<string, double, int>> listTest = new List<Tuple<string, double, int>>();
            listTest.Add(test);
            listTest.Add(new Tuple<string, double, int>("Luna", 9.9, 12));

            listTest.ForEach(delegate (Tuple<string, double, int> a)
            {
                Console.WriteLine(a);
            });
            */
            #endregion




            //stockPiece(Quentin);
            //stockPieceIndiv(Quentin);
            //stockPieceType(Quentin);

            Console.ReadKey();
        }
    }
}
