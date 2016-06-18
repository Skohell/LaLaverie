using BusinessLayer.DAO;
using LaLaverie.Model;
using LaLaverieProject.Factory;
using LaLaverieProject.View;
using Library;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace LaLaverieProject.ViewModel
{
    /// <summary>
    /// ViewModel de la View NewClientWindow
    /// </summary>
    public class NewClientWindowViewModel : NotifyPropertyChangedBase
    {
        #region Propriétés
        /// <summary>
        /// Commande d'ajout du client
        /// </summary>
        public DelegateCommand OnNewClientCommand { get; set; }

        /// <summary>
        /// Commande de retour à la page précédente
        /// </summary>
        public DelegateCommand OnRetourCommand { get; set; }

        /// <summary>
        /// Fenetre actuelle
        /// </summary>
        NewClientWindow fenetre;

        /// <summary>
        /// Client à ajouter
        /// </summary>
        public ClientModel client { get; set; }

        /// <summary>
        /// Liste des clients
        /// </summary>
        public ObservableCollection<ClientModel> ListeClient;
        #endregion

        #region Constructeur
        /// <summary>
        /// Constructeur du ViewModel
        /// </summary>
        /// <param name="listeClients">Liste des clients</param>
        /// <param name="fenetre">fenetre actuelle</param>
        public NewClientWindowViewModel(ObservableCollection<ClientModel> listeClients, NewClientWindow fenetre)
        {
            OnNewClientCommand = new DelegateCommand(OnNewClientAction);
            OnRetourCommand = new DelegateCommand(OnRetourAction);
            client = new ClientModel("Nom", "Prénom", 0, "Nom de la Rue", "Ville", 00000, "mail", "mot de passe", 18);
            this.ListeClient = listeClients;
            this.fenetre = fenetre;
        }
        #endregion

        #region Actions

        /// <summary>
        /// Commande de retour à la fenêtre précédente
        /// </summary>
        /// <param name="obj"></param>
        private void OnRetourAction(object obj)
        {
            fenetre.Close();
        }

        /// <summary>
        /// Commande d'ajout du nouveau client
        /// </summary>
        /// <param name="obj"></param>
        private void OnNewClientAction(object obj)
        {
            ListeClient.Add(client);
            ClientDAO.SaveClient(ClientFactory.AllClientModelToClient(ListeClient));
            MessageBox.Show(String.Format("Vous êtes maintenant enregistré dans notre base de donnée !"));
            fenetre.Close();

        }
        #endregion
    }
}
