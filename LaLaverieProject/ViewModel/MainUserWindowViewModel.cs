using BusinessLayer.DAO;
using LaLaverie.Model;
using LaLaverieProject.Factory;
using LaLaverieProject.View;
using Library;
using System.Collections.ObjectModel;

namespace LaLaverieProject.ViewModel
{
    /// <summary>
    /// ViewModel de la View MainuserWindow
    /// </summary>
    public class MainUserWindowViewModel : NotifyPropertyChangedBase
    {

        #region Propriété
        /// <summary>
        /// Fenetre actuelle
        /// </summary>
        MainUserWindow fenetre;

        /// <summary>
        /// Commande d'ajout d'un nouveau client
        /// </summary>
        public DelegateCommand OnNewClientCommand { get; set; }
        /// <summary>
        /// Commande de connexion
        /// </summary>
        public DelegateCommand OnConnexionCommand { get; set; }

        /// <summary>
        /// Liste des clients
        /// </summary>
        private ObservableCollection<ClientModel> _listeClient;
        public ObservableCollection<ClientModel> ListeClient
        {
            get
            {
                return _listeClient;
            }

            set
            {
                { _listeClient = value; NotifyPropertyChanged("ListeClient");}
            }
        }
        #endregion

        #region Constructeur
        /// <summary>
        /// Constructeur du ViewModel
        /// </summary>
        /// <param name="fenetre">Fenetre actuelle</param>
        public MainUserWindowViewModel(MainUserWindow fenetre)
        {
            //Attribution des commandes
            OnNewClientCommand = new DelegateCommand(OnNewClientAction);
            OnConnexionCommand = new DelegateCommand(OnConnexionAction);

            //On charge le fichier client ou on le créer avec un utilisateur admin à la première utilisation
            ListeClient = new ObservableCollection<ClientModel>();
            try
            {
                ListeClient = ClientFactory.AllClientToClientModel(ClientDAO.LoadClient());
            }
            catch
            {
                ListeClient.Add(new ClientModel("admin", "admin", 42, "admin", "admin", 42, "admin", "admin", 42));
                ListeClient.Add(new ClientModel("user", "user", 42, "user", "user", 42, "user", "user", 42));
                ClientDAO.SaveClient(ClientFactory.AllClientModelToClient(ListeClient));
                ListeClient = ClientFactory.AllClientToClientModel(ClientDAO.LoadClient());
                
            }


            this.fenetre = fenetre;

            
        }
        #endregion

        #region Actions
        /// <summary>
        /// Commande de connexion
        /// </summary>
        /// <param name="obj"></param>
        private void OnConnexionAction(object obj)
        {
            MainConnexionWindow connexion = new MainConnexionWindow(ListeClient);
            connexion.Show();
            fenetre.Close();
            
        }
        /// <summary>
        /// Commande de création d'un nouveau client
        /// </summary>
        /// <param name="obj"></param>
        private void OnNewClientAction(object obj)
        {
            
            NewClientWindow connexion = new NewClientWindow(ListeClient);
            connexion.Show();
           
            
        }
        #endregion
    }
}
