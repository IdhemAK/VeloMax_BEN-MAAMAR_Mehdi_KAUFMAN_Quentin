using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Program_Velomax
{
    abstract public class Client
    {
        #region Attributs
        private int ID_client;      //clé primaire
        private string courriel;
        private string telephone;
        private Adresse adresse_client;
        #endregion Attributs

        #region Constructeurs
        public Client(int ID_client, string courriel, string telephone, Adresse adresse_client)
        {
            this.ID_client = ID_client;
            this.courriel = courriel;
            this.telephone = telephone;
            this.adresse_client = adresse_client;
        }
        #endregion Constructeurs

        #region Accesseurs
        public int ID_Client
        {
            get { return ID_client; }
            set { ID_client = value; }
        }
        public string Courriel
        {
            get { return courriel; }
            set { courriel = value; }
        }
        public string Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }
        public Adresse Adresse_client
        {
            get { return adresse_client; }
            set { adresse_client = value; }
        }
        #endregion Accesseurs
    }
}
