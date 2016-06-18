using BusinessLayer.Entities;
using LaLaverie.Model;
using System.Collections.ObjectModel;

namespace LaLaverieProject.Factory
{
    /// <summary>
    /// Classe de conversion de bière entity/model
    /// </summary>
    public static class BiereFactory
    {
        #region Transformation de bieres
        /// <summary>
        /// Transforme et retourne une Biere en BiereModel
        /// </summary>
        /// <param name="b"> Biere a transformer</param>
        /// <returns>Biere transformée</returns>
        public static BiereModel BiereToBiereModel(Biere b)
        {
            return new BiereModel
            {
                Nom = b.Nom,
                Categorie = b.Categorie,
                Description = b.Description,
                Amertume = b.Amertume,
                Prix = b.Prix,
                Empatage = b.Empatage,
                Brassin = b.Brassin,
                Fermentation = b.Fermentation,
                Embouteillage = b.Embouteillage,
                Conservation = b.Conservation,
                ImageUrl = b.ImageUrl,
                NbBouteille = b.NbBouteille
            };
        }

        /// <summary>
        /// Transforme et retourne une BiereModel en Biere
        /// </summary>
        /// <param name="b"> Biere a transformer</param>
        /// <returns>Biere transformée</returns>
        public static Biere BiereModelToBiere(BiereModel b)
        {
            return new Biere
            {
                Nom = b.Nom,
                Categorie = b.Categorie,
                Description = b.Description,
                Amertume = b.Amertume,
                Prix = b.Prix,
                Empatage = b.Empatage,
                Brassin = b.Brassin,
                Fermentation = b.Fermentation,
                Embouteillage = b.Embouteillage,
                Conservation = b.Conservation,
                ImageUrl = b.ImageUrl,
                NbBouteille = b.NbBouteille
            };
        }
        #endregion

        #region transformation de liste de bières
        /// <summary>
        /// Transforme et retourne une ObservableCollection de Biere en BiereModel
        /// </summary>
        /// <param name="b"> liste de Biere a transformer</param>
        /// <returns>liste de Biere transformée</returns>
        public static ObservableCollection<BiereModel> AllBiereToBiereModel(ObservableCollection<Biere> list)
        {
            ObservableCollection<BiereModel> liste = new ObservableCollection<BiereModel>();
            foreach(Biere b in list)
            {
                liste.Add(BiereToBiereModel(b));
            }
            return liste;
        }

        /// <summary>
        /// Transforme et retourne une ObservableCollection de BiereModel en Biere
        /// </summary>
        /// <param name="b"> liste de Biere a transformer</param>
        /// <returns>liste de Biere transformée</returns>
        public static ObservableCollection<Biere> AllBiereModelToBiere(ObservableCollection<BiereModel> list)
        {
            ObservableCollection<Biere> liste = new ObservableCollection<Biere>();
            foreach (BiereModel b in list)
            {
                liste.Add(BiereModelToBiere(b));
            }
            return liste;
        }
        #endregion
    }
}
