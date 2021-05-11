using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Program_Velomax
{
    public class Programme
    {
        #region Attributs
        private int numero_programme;
        private string nom_programme;
        private float prix_programme;
        private int duree_programme;
        private float rabais_programme;
        #endregion Attributs

        #region Constructeurs
        public Programme(int numero_programme, string nom_programme, float prix_programme,
            int duree_programme, float rabais_programme)
        {
            this.numero_programme = numero_programme;
            this.nom_programme = nom_programme;
            this.prix_programme = prix_programme;
            this.duree_programme = duree_programme;
            this.rabais_programme = rabais_programme;
        }
        #endregion Constructeurs

        #region Accesseurs
        public int Numero_programme
        {
            get { return numero_programme; }
            set { numero_programme = value; }
        }
        public string Nom_programme
        {
            get { return nom_programme; }
            set { nom_programme = value; }
        }
        public float Prix_programme
        {
            get { return prix_programme; }
            set { prix_programme = value; }
        }
        public int Duree_programme
        {
            get { return duree_programme; }
            set { duree_programme = value; }
        }
        public float Rabais_programme
        {
            get { return rabais_programme; }
            set { rabais_programme = value; }
        }
        #endregion Accesseurs
    }
}
