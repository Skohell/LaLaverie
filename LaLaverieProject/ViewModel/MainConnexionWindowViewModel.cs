using LaLaverie.Model;
using LaLaverieProject.View;
using Library;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace LaLaverieProject.ViewModel
{
    /// <summary>
    /// ViewModel de la View MainConnexionWindow
    /// </summary>
    public class MainConnexionWindowViewModel
    {
        #region Propriétés
        /// <summary>
        /// fenetre actuelle
        /// </summary>
        MainConnexionWindow fenetre;

        /// <summary>
        /// Commande de connexion
        /// </summary>
        public DelegateCommand OnConnexionCommand { get; set; }

        /// <summary>
        /// Commande de retour
        /// </summary>
        public DelegateCommand OnRetourCommand { get; set; }

        /// <summary>
        /// Liste des clients
        /// </summary>
        public ObservableCollection<ClientModel> ListeClient;

        /// <summary>
        /// Nom du client 
        /// </summary>
        public string NomClient { get; set; }

        /// <summary>
        /// Mot de passe du client
        /// </summary>
        public string MdpClient { get; set; }
        #endregion

        #region Constructeur
        /// <summary>
        /// Constructeur du ViewModel
        /// </summary>
        /// <param name="ListeClient">liste des clients</param>
        /// <param name="fenetre">Fenetre actuelle</param>
        public MainConnexionWindowViewModel(ObservableCollection<ClientModel> ListeClient, MainConnexionWindow fenetre)
        {
            OnConnexionCommand = new DelegateCommand(OnConnexionAction);
            OnRetourCommand = new DelegateCommand(OnRetourAction);
            this.ListeClient = ListeClient;
            this.fenetre = fenetre;
        }
        #endregion

        #region Actions
        /// <summary>
        /// Commadne de retour à la fenêtre précédente
        /// </summary>
        /// <param name="obj"></param>
        private void OnRetourAction(object obj)
        {
            MainUserWindow retour = new MainUserWindow();
            retour.Show();
            fenetre.Close();
        }

        /// <summary>
        /// Commande de connexion
        /// </summary>
        /// <param name="obj"></param>
        private void OnConnexionAction(object obj)
        {
            foreach(ClientModel c in ListeClient)
            {
                if(c.Nom.Equals(NomClient) && c.MotDePasse.Equals(MdpClient))
                {
                    ClientProduitWindow page = new ClientProduitWindow(c, ListeClient);
                    page.Show();
                    fenetre.Close();
                    return;
                }
            }
            MessageBox.Show(String.Format("Login et/ou mot de passe incorrect(s)."));
        }
        #endregion
    }
}
