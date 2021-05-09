using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Program_Velomax
{
    class Program
    {
        static void Main(string[] args)
        {
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

            Console.ReadKey();
        }
    }
}
