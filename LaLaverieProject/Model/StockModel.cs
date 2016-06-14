using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaLaverie.Model
{
    public class StockModel : NotifyPropertyChangedBase
    {
        #region Listes static
        /// <summary>
        /// Liste de catégories des stocks
        /// </summary>
        public static List<string> categoriesStocks = new List<string>();
        #endregion

        #region Attributs et propriétés
        /// <summary>
        /// Désignation du produit
        /// </summary>
        private string _designation;
        public string Designation
        {
            get
            {
                return _designation;
            }
            set
            {
                if (value == null)
                    throw new Exception("Ce produit doit avoir une désignation permettant de l'identifier.");
                else
                {
                    _designation = value;
                    NotifyPropertyChanged("Designation");
                }
            }
        }

        /// <summary>
        /// Quantité du produit
        /// </summary>
        private int _quantite;
        public int Quantite
        {
            get
            {
                return _quantite;
            }
            set
            {
                if (value < 0)
                    throw new Exception("Il est impossible d'avoir une quantité négative.");
                else
                {
                    _quantite = value;
                    NotifyPropertyChanged("Quantite");
                }
            }
        }

        /// <summary>
        /// Catégorie du produit
        /// </summary>
        private string _categorie;
        public string Categorie
        {
            get
            {
                return _categorie;
            }
            set
            {
                if (value == null)
                    throw new Exception("Ce produit doit faire partie d'une catégorie.");
                else
                {
                    _categorie = value;
                    NotifyPropertyChanged("Categorie");
                }
            }
        }
        #endregion

        #region Constructeur
        /// <summary>
        /// Constructeur du produit
        /// </summary>
        /// <param name="designation">Désignation du produit</param>
        /// <param name="quantite">Quantité du produit</param>
        /// <param name="categorie">Catégorie du produit</param>
        public StockModel(string designation, int quantite, string categorie)
        {
            try
            {
                Designation = designation;
                Quantite = quantite;
                Categorie = categorie;
            }
            catch (Exception e)
            {
                Console.WriteLine("Un paramètre de se produit est invalide. {0}", e);
            }
        }
        #endregion

        #region Methode
        /// <summary>
        /// Détermine si le produit existe déjà
        /// </summary>
        /// <param name="produit">Produit existant potentiellement déjà</param>
        /// <returns>True si le produit existe sinon false</returns>
        public bool Equals(StockModel produit)
        {
            if (produit.Designation == Designation)
            {
                if (produit.Categorie == Categorie)
                {
                    return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            return string.Format("{0}", Designation);
        }
        #endregion
    }
}
