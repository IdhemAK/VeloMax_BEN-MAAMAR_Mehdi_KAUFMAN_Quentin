using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_Velomax
{
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
    }
}
