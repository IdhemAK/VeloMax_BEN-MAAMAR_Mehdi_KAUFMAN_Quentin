using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace VeloMax_BEN_MAAMAR_Mehdi_KAUFMAN_Quentin
{
    public class Piece
    {
        #region Attributs
        private string numero_piece_catalogue;      //clé primaire
        private string numero_piece;
        private string description_piece;
        private DateTime date_introduction_piece;
        private DateTime date_discontinuation_piece;
        private float prix_piece;
        private int delai_approvisionnement_piece;
        private int stock_piece;
        #endregion Attributs

        #region Constructeurs
        public Piece(string numero_piece_catalogue, string numero_piece, string description_piece,
            DateTime date_introduction_piece, DateTime date_discontinuation_piece, float prix_piece,
            int delai_approvisionnement_piece, int stock_piece)
        {
            this.numero_piece_catalogue = numero_piece_catalogue;
            this.numero_piece = numero_piece;
            this.description_piece = description_piece;
            this.date_introduction_piece = date_introduction_piece;
            this.date_discontinuation_piece = date_discontinuation_piece;
            this.prix_piece = prix_piece;
            this.delai_approvisionnement_piece = delai_approvisionnement_piece;
            this.stock_piece = stock_piece;
        }
        public Piece()
        {

        }


        #endregion Constructeurs

        #region Accesseurs
        public string Numero_piece_catalogue
        {
            get { return numero_piece_catalogue; }
            set { numero_piece_catalogue = value; }
        }
        public string Numero_piece
        {
            get { return numero_piece; }
            set { numero_piece = value; }
        }
        public string Description_piece
        {
            get { return description_piece; }
            set { description_piece = value; }
        }
        public DateTime Date_introduction_piece
        {
            get { return date_introduction_piece; }
            set { date_introduction_piece = value; }
        }
        public DateTime Date_discontinuation_piece
        {
            get { return date_discontinuation_piece; }
            set { date_discontinuation_piece = value; }
        }
        public float Prix_piece
        {
            get { return prix_piece; }
            set { prix_piece = value; }
        }
        public int Delai_approvisionnement_piece
        {
            get { return delai_approvisionnement_piece; }
            set { delai_approvisionnement_piece = value; }
        }
        public int Stock_piece
        {
            get { return stock_piece; }
            set { stock_piece = value; }
        }
        #endregion Accesseurs

        public override string ToString()
        {
            return numero_piece_catalogue + " - " + numero_piece + " : " + description_piece +
                " " + prix_piece + "€ delai-" + delai_approvisionnement_piece + " stock " + stock_piece;
        }
    }
}
