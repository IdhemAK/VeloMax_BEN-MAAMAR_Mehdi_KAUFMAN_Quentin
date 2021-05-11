using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Program_Velomax
{
    public class Commande
    {
        #region Attributs
        private int numero_commande;    //clé primaire
        private DateTime date_commande;
        private DateTime date_livraison_commande;
        private Adresse adresse_commande;
        private string ID_client_entreprise;
        private string ID_client_particulier;
        #endregion Attributs

        #region Constructeurs
        public Commande(int numero_commande, DateTime date_commande, DateTime date_livraison_commande,
            Adresse adresse_commande, string ID_client_entreprise, string ID_client_particulier)
        {
            this.numero_commande = numero_commande;
            this.date_commande = date_commande;
            this.date_livraison_commande = date_livraison_commande;
            this.adresse_commande = adresse_commande;
            this.ID_client_entreprise = ID_client_entreprise;
            this.ID_client_particulier = ID_client_particulier;
        }
        #endregion Constructeurs

        #region Accesseurs
        public int Numero_commande
        {
            get { return numero_commande; }
            set { numero_commande = value; }
        }
        public DateTime Date_commande
        {
            get { return date_commande; }
            set { date_commande = value; }
        }
        public DateTime Date_livraison_commande
        {
            get { return date_livraison_commande; }
            set { date_livraison_commande = value; }
        }
        private Adresse Adresse_commande
        {
            get { return adresse_commande; }
            set { adresse_commande = value; }
        }
        private string ID_Client_entreprise
        {
            get { return ID_client_entreprise; }
            set { ID_client_entreprise = value; }
        }
        private string ID_Client_particulier
        {
            get { return ID_client_particulier; }
            set { ID_client_particulier = value; }
        }
        #endregion Accesseurs
    }
}
