using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Entities
{
    public class Transaction
    {
        # region Listes static
        /// <summary>
        /// Liste de bières de la vente actuelle
        /// </summary>
        public static List<Biere> panier = new List<Biere>();

        /// <summary>
        /// Liste d'achat passé
        /// </summary>
        public static List<Stock> ventes = new List<Stock>();
        #endregion

        #region Attributs et propriétés
        /// <summary>
        /// Date et heure de la vente
        /// </summary>
        private DateTime _date;
        public DateTime Date
        {
            get
            {
                return _date;
            }

            private set
            {
                _date = value;
            }
        }

        /// <summary>
        /// Prix total de la vente
        /// </summary>
        private float _prixTotal;
        public float PrixTotal
        {
            get
            {
                return _prixTotal;
            }
            set
            {
                if (value < 0)
                    throw new Exception("Le montant total ne peut être négatif.");
                else
                    _prixTotal = value;
            }
        }

        /// <summary>
        /// Description de la vente
        /// </summary>
        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (value == null)
                    _description = "Aucune description pour cette vente.";
                else
                    _description = value;
            }
        }
        #endregion

        #region Constructeur
        /// <summary>
        /// Constructeur de la vente
        /// </summary>
        /// <param name="description">Description de la vente</param>
        public Transaction(string description)
        {
            try
            {
                Date = DateTime.Now;
                PrixTotal = 0;
                foreach (Biere b in panier)
                {
                    PrixTotal = PrixTotal + (b.Prix * b.NbBouteille);
                }
                Description = description;
            }
            catch (Exception e)
            {
                Console.WriteLine("Un élément de la vente n'est pas conforme. {0}", e);
            }
        }
        #endregion

        #region Methodes
        /// <summary>
        /// Affichage formatté du prix
        /// </summary>
        /// <returns>Affichage formatté du prix</returns>
        public string AfficherPrix()
        {
            return string.Format("{0} euros", PrixTotal);
        }

        public override string ToString()
        {
            return string.Format("{0}", Description);
        }

        /// <summary>
        /// Affichage formatté de la date ------------------------------- Avec erreur-------------------------------
        /// </summary>
        /// <returns>Affichage formatté de la date</returns>
        ///public string AfficherDate()
        ///{
        ///    return string.Format("---------------------------------------------------------", Date);
        ///}
        #endregion
    }
}
