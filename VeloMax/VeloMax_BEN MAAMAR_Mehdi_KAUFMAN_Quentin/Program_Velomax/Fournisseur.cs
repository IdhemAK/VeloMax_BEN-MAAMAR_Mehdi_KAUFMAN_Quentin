using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Program_Velomax
{
    public class Fournisseur
    {
        #region Attributs
        private string siret_fournisseur;   //clé primaire
        private string nom_fournisseur;
        private string qualite_fournisseur;
        private string nom_contact_fournisseur;
        private Adresse adresse_fournisseur;
        #endregion Attributs

        #region Constructeurs
        public Fournisseur(string siret_fournisseur, string nom_fournisseur, string qualite_fournisseur,
            string nom_contact_fournisseur, Adresse adresse_fournisseur)
        {
            this.siret_fournisseur = siret_fournisseur;
            this.nom_fournisseur = nom_fournisseur;
            this.qualite_fournisseur = qualite_fournisseur;
            this.nom_contact_fournisseur = nom_contact_fournisseur;
            this.adresse_fournisseur = adresse_fournisseur;
        }
        #endregion Constructeurs

        #region Accesseurs
        public string Siret_Fournisseur
        {
            get { return siret_fournisseur; }
            set { siret_fournisseur = value; }
        }
        public string Nom_fournisseur
        {
            get { return nom_fournisseur; }
            set { nom_fournisseur = value; }
        }
        public string Qualite_fournisseur
        {
            get { return qualite_fournisseur; }
            set { qualite_fournisseur = value; }
        }
        public string Nom_contact_fournisseur
        {
            get { return nom_contact_fournisseur; }
            set { nom_contact_fournisseur = value; }
        }
        public Adresse Adresse_fournisseur
        {
            get { return adresse_fournisseur; }
            set { adresse_fournisseur = value; }
        }
        #endregion Accesseurs
    }
}
