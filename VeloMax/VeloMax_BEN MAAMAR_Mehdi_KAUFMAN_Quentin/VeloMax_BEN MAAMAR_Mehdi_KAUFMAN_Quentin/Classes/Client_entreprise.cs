using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace VeloMax_BEN_MAAMAR_Mehdi_KAUFMAN_Quentin
{
    sealed public class Client_entreprise : Client
    {
        #region Attributs
        private string nom_client_entreprise;
        private float remise_client_entreprise;
        private string nom_contact_client_entreprise;
        #endregion Attributs

        #region Constructeurs
        public Client_entreprise(string ID_client, string courriel, string telephone, Adresse adresse_client,
            string nom_client_entreprise, float remise_client_entreprise, string nom_contact_client_entreprise)
            : base(ID_client, courriel, telephone, adresse_client)
        {
            this.nom_client_entreprise = nom_client_entreprise;
            this.remise_client_entreprise = remise_client_entreprise;
            this.nom_contact_client_entreprise = nom_contact_client_entreprise;
        }
        public Client_entreprise()
        : base()
        {

        }
        #endregion Constructeurs

        #region Accesseurs
        public string Nom_client_entreprise
        {
            get { return nom_client_entreprise; }
            set { nom_client_entreprise = value; }
        }
        public float Remise_client_entreprise
        {
            get { return remise_client_entreprise; }
            set { remise_client_entreprise = value; }
        }
        public string Nom_contact_client_entreprise
        {
            get { return nom_contact_client_entreprise; }
            set { nom_contact_client_entreprise = value; }
        }
        #endregion Accesseurs    
    }
}
