using LaLaverie.Model;
using LaLaverieProject.View;
using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LaLaverieProject.ViewModel
{
    /// <summary>
    /// ViewModel de la View ClientProfilWindow
    /// </summary>
    public class ClientProfilWindowViewModel
    {
        #region Propriétés
        /// <summary>
        /// Client à éditer
        /// </summary>
        public ClientModel ClientToEdit { get; set; }

        /// <summary>
        /// Fenetre actuelle
        /// </summary>
        ClientProfilWindow fenetre;

        /// <summary>
        /// Commande de modification
        /// </summary>
        public DelegateCommand OnEditCommand { get; set; }
        #endregion

        #region Constructeur
        /// <summary>
        /// Constructeur du ViewModel
        /// </summary>
        /// <param name="c">Client à modifier</param>
        /// <param name="fenetre">fenetre actuelle</param>
        public ClientProfilWindowViewModel(ClientModel c, ClientProfilWindow fenetre)
        {
         
            OnEditCommand = new DelegateCommand(OnEditAction);

            ClientToEdit = c;
            this.fenetre = fenetre;
        }
        #endregion

        #region Actions
        /// <summary>
        /// Commande de modification du profil
        /// </summary>
        /// <param name="obj"></param>
        private void OnEditAction(object obj)
        {
            fenetre.Close();
            MessageBox.Show(String.Format("Profil modifié !"),"Modification de profil");
        }
        #endregion
    }
}
