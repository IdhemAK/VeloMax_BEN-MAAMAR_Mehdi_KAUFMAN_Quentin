using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Program_Velomax
{
    class Velo
    {
        #region Attributs
        private int numero_velo;
        private string nom_velo;
        private string grandeur_velo;
        private float prix_velo;
        private string ligne_produit_velo;
        private DateTime date_introduction_velo;
        private DateTime date_discontinuation_velo;
        private int stock_velo;
        #endregion Attributs


        #region Constructeurs
        public Velo(int numero_velo, string nom_velo, string grandeur_velo, float prix_velo,
            string ligne_produit_velo, DateTime date_introduction_velo, DateTime date_discontinuation_velo, 
            int stock_velo)
        {
            this.numero_velo = numero_velo;
            this.nom_velo = nom_velo;
            this.grandeur_velo = grandeur_velo;
            this.prix_velo = prix_velo;
            this.ligne_produit_velo = ligne_produit_velo;
            this.date_introduction_velo = date_introduction_velo;
            this.date_discontinuation_velo = date_discontinuation_velo;
            this.stock_velo = stock_velo;
        }
        #endregion Constructeurs


        #region Accesseurs
        public int Numero_velo
        {
            get { return numero_velo; }
            set { numero_velo = value; }
        }
        public string Nom_velo
        {
            get { return nom_velo; }
            set { nom_velo = value; }
        }
        public string Grandeur_velo
        {
            get { return grandeur_velo; }
            set { grandeur_velo = value; }
        }
        public float Prix_velo
        {
            get { return prix_velo; }
            set { prix_velo = value; }
        }
        public string Ligne_produit_velo
        {
            get { return ligne_produit_velo; }
            set { ligne_produit_velo = value; }
        }
        public DateTime Date_introduction_velo
        {
            get { return date_introduction_velo; }
            set { date_introduction_velo = value; }
        }
        public DateTime Date_discontinuation_velo
        {
            get { return date_discontinuation_velo; }
            set { date_discontinuation_velo = value; }
        }
        public int Stock_velo
        {
            get { return stock_velo; }
            set { stock_velo = value; }
        }
        #endregion Accesseurs
    }
}
