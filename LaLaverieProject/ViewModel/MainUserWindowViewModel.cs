using BusinessLayer.DAO;
using LaLaverie.Model;
using LaLaverieProject.Factory;
using LaLaverieProject.View;
using Library;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaLaverieProject.ViewModel
{
    public class MainUserWindowViewModel : NotifyPropertyChangedBase
    {
        MainUserWindow fenetre;

        public DelegateCommand OnNewClientCommand { get; set; }
        public DelegateCommand OnConnexionCommand { get; set; }

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

        public MainUserWindowViewModel(MainUserWindow fenetre)
        {
            OnNewClientCommand = new DelegateCommand(OnNewClientAction);
            OnConnexionCommand = new DelegateCommand(OnConnexionAction);

            ListeClient = new ObservableCollection<ClientModel>();

            try
            {
                ListeClient = ClientFactory.AllClientToClientModel(ClientDAO.LoadClient());
            }
            catch
            {
                ListeClient.Add(new ClientModel("admin", "admin", 42, "admin", "admin", 42, "admin", "admin", 42));
                ClientDAO.SaveClient(ClientFactory.AllClientModelToClient(ListeClient));
                ListeClient = ClientFactory.AllClientToClientModel(ClientDAO.LoadClient());
                
            }


            this.fenetre = fenetre;

            
        }

        private void OnConnexionAction(object obj)
        {
            MainConnexionWindow connexion = new MainConnexionWindow(ListeClient);
            connexion.Show();
            fenetre.Close();
            
        }

        private void OnNewClientAction(object obj)
        {
            
            NewClientWindow connexion = new NewClientWindow(ListeClient);
            connexion.Show();
           
            
        }
    }
}
