using LaLaverieProject.View;
using Library;


namespace LaLaverieProject.ViewModel
{
    /// <summary>
    /// ViewModel de la View MainWindow
    /// </summary>
    public class MainWindowViewModel : NotifyPropertyChangedBase
    {
        #region Propriétés
        /// <summary>
        /// Fenetre actuelle
        /// </summary>
        MainWindow fenetre;
        /// <summary>
        /// Commande pour passer à la fenetre suivante
        /// </summary>
        public DelegateCommand OnClickCommand {get; set;}

        #endregion

        #region Constructeur
        /// <summary>
        /// Constructeur du ViewModel
        /// </summary>
        /// <param name="fenetre"></param>
        public MainWindowViewModel(MainWindow fenetre)
        {
            OnClickCommand = new DelegateCommand(OnClickAction);
            this.fenetre = fenetre;
        }
        #endregion

        #region Actions
        /// <summary>
        /// Action de clic pour passer à la fenetre suivante
        /// </summary>
        /// <param name="obj"></param>
        private void OnClickAction(object obj)
        {
            MainUserWindow nextFenetre = new MainUserWindow();
            nextFenetre.Show();
            fenetre.Close();
        }
        #endregion
    }
}
