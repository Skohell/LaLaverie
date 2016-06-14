using LaLaverie.Model;
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

            ListeClient = new ObservableCollection<ClientModel>()
            {
                new ClientModel("Gravallon","Guillaume",42,"rue du zouave","Clermont-Ferrand",63000,"guillaume.gravallon@gmail.com","mdp",19),
                new ClientModel("Rico","Sébastien",5,"rue du Mirondet","Aubière",63170,"rico.sebastien@gmail.com","mdp",42),
                new ClientModel("admin","admin",5,"admin","admin",42,"admin","admin",42)
            };

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
