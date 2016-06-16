using LaLaverie.Model;
using LaLaverieProject.View;
using Library;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LaLaverieProject.ViewModel
{
    public class NewClientWindowViewModel : NotifyPropertyChangedBase
    {
        public DelegateCommand OnNewClientCommand { get; set; }
        public DelegateCommand OnRetourCommand { get; set; }
        NewClientWindow fenetre;

        public ClientModel client { get; set; }
        public ObservableCollection<ClientModel> ListeClient;

        public NewClientWindowViewModel(ObservableCollection<ClientModel> listeClients, NewClientWindow fenetre)
        {
            OnNewClientCommand = new DelegateCommand(OnNewClientAction, CanExecuteNewClient);
            OnRetourCommand = new DelegateCommand(OnRetourAction);
            client = new ClientModel("Nom", "Prénom", 0, "Nom de la Rue", "Ville", 00000, "mail", "mot de passe", 18);
            this.ListeClient = listeClients;
            this.fenetre = fenetre;
        }

        private void OnRetourAction(object obj)
        {
            fenetre.Close();
        }

        private bool CanExecuteNewClient(object obj)
        {
            return true;
        }

        private void OnNewClientAction(object obj)
        {
            ListeClient.Add(client);
            MessageBox.Show(String.Format("Vous êtes maintenant enregistré dans notre base de donnée !"));
            fenetre.Close();

        }
    }
}
