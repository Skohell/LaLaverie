using LaLaverie.Model;

namespace LaLaverieProject.ViewModel
{
    /// <summary>
    /// ViewModel de la View RecetteWindow
    /// </summary>
    public class RecetteWindowViewModel
    {
        #region Propriétés
        /// <summary>
        /// Biere à afficher
        /// </summary>
        public BiereModel biere { get; set; }
        #endregion

        #region Constructeur
        /// <summary>
        /// Constructeur du ViewModel
        /// </summary>
        /// <param name="b">Biere a afficher</param>
        public RecetteWindowViewModel(BiereModel b)
        {
            biere = b;
        }
        #endregion
    }
}
