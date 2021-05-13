using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace VeloMax_BEN_MAAMAR_Mehdi_KAUFMAN_Quentin
{
    sealed public class Client_particulier : Client
    {
        #region Attributs
        private string nom_client_particulier;
        private string prenom_client_particulier;
        private DateTime date_adhesion_programme;
        DateTime date_expiration_programme;
        private Programme programme;
        private string theProgramme;
        #endregion Attributs

        #region Constructeurs

        public Client_particulier(
        string ID_client,
        string nom_client_particulier,
        string prenom_client_particulier,
        DateTime date_adhesion_programme,
        DateTime date_expiration_programme,
        string courriel,
        string telephone,
        string programme)
        : base(ID_client, courriel, telephone)
            {
                this.nom_client_particulier = nom_client_particulier;
                this.prenom_client_particulier = prenom_client_particulier;
                this.date_adhesion_programme = date_adhesion_programme;
                this.date_expiration_programme = date_expiration_programme;
                this.theProgramme = programme;
            }


        public Client_particulier(string ID_client, string courriel, string telephone, Adresse adresse_client,
            string nom_client_particulier, string prenom_client_particulier, DateTime date_adhesion_programme,
            Programme programme)
            : base(ID_client, courriel, telephone, adresse_client)
        {
            this.nom_client_particulier = nom_client_particulier;
            this.prenom_client_particulier = prenom_client_particulier;
            this.date_adhesion_programme = date_adhesion_programme;
            this.programme = programme;
        }





        public Client_particulier()
        : base()
        {

        }
        #endregion Constructeurs

        #region Accesseurs
        public string Nom_client_particulier
        {
            get { return nom_client_particulier; }
            set { nom_client_particulier = value; }
        }
        public string Prenom_client_particulier
        {
            get { return prenom_client_particulier; }
            set { prenom_client_particulier = value; }
        }
        public DateTime Date_adhesion_programme
        {
            get { return date_adhesion_programme; }
            set { date_adhesion_programme = value; }
        }
        public Programme Programme
        {
            get { return programme; }
            set { programme = value; }
        }
        #endregion Accesseurs
    }
}
