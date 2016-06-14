﻿using LaLaverie.Model;
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
    public class MainConnexionWindowViewModel
    {
        MainConnexionWindow fenetre;

        public DelegateCommand OnConnexionCommand { get; set; }

        public ObservableCollection<ClientModel> ListeClient;

        public string NomClient { get; set; }
        public string MdpClient { get; set; }

        public MainConnexionWindowViewModel(ObservableCollection<ClientModel> ListeClient, MainConnexionWindow fenetre)
        {
            OnConnexionCommand = new DelegateCommand(OnConnexionAction, CanExecuteConnexion);
            this.ListeClient = ListeClient;
            this.fenetre = fenetre;
        }

        private bool CanExecuteConnexion(object obj)
        {
             return true;
        }

        private void OnConnexionAction(object obj)
        {
            foreach(ClientModel c in ListeClient)
            {
                if(c.Nom.Equals(NomClient) && c.MotDePasse.Equals(MdpClient))
                {
                    ClientProduitWindow page = new ClientProduitWindow(c);
                    page.Show();
                    fenetre.Close();
                    return;
                }
            }
            MessageBox.Show(String.Format("Login et/ou mot de passe incorrect(s)."));
        }
    }
}