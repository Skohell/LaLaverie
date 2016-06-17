using BusinessLayer.DAO;
using LaLaverie.Model;
using LaLaverieProject.Factory;

using LaLaverieProject.View;
using Library;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LaLaverieProject.ViewModel
{
    public class ClientProduitWindowViewModel : NotifyPropertyChangedBase
    {
        
        public ClientModel client { get; set; }
        ClientProduitWindow fenetre;

        public DelegateCommand OnAddCommand { get; set; }
        private bool _isEditEnabled = true;
        public DelegateCommand OnEditCommand { get; set; }
        private bool _isDeleteEnabled = true;
        public DelegateCommand OnDeleteCommand { get; set; }
        public DelegateCommand OnModifyCommand { get; set; }
        public DelegateCommand OnLogoutCommand { get; set; }
        public DelegateCommand OnSaveCommand { get; set; }
        public DelegateCommand OnHyperLinkCommand { get; set; }
        public DelegateCommand OnRecetteCommand { get; set; }

        private bool _isUserAdmin=false;


        private ObservableCollection<string> _listeCategorie;
        public ObservableCollection<string> ListeCategorie
        {
            get
            {
                return _listeCategorie;
            }

            set
            {
                { _listeCategorie = value; NotifyPropertyChanged("ListeCategorie"); NotifyPropertyChanged("SelectedCategorie"); }
            }
        }

        private string _selectedCategorie;
        public string SelectedCategorie
        {
            get { return _selectedCategorie; }
            set { _selectedCategorie = value; UpdateListe(); NotifyPropertyChanged("ListeCategorie"); NotifyPropertyChanged("SelectedCategorie"); }
        }

  
        private ObservableCollection<BiereModel> _listeBieres;
        public ObservableCollection<BiereModel> ListeBieres
        {
            get { return _listeBieres; }

            set { _listeBieres = value; NotifyPropertyChanged("ListeBieres"); NotifyPropertyChanged("SelectedBiere"); }

        }

        private ObservableCollection<BiereModel> _listeBieresFiltre;
        public ObservableCollection<BiereModel> ListeBieresFiltre
        {
            get { return _listeBieresFiltre; }

            set { _listeBieresFiltre = value; NotifyPropertyChanged("ListeBieresFiltre"); NotifyPropertyChanged("SelectedBiereFiltre"); }

        }

        private ObservableCollection<ClientModel> _listeClient;
        public ObservableCollection<ClientModel> ListeClient
        {
            get { return _listeClient; }

            set { _listeClient = value;}

        }

        private BiereModel _selectedBiere;
        public BiereModel SelectedBiere
        {
            get { return _selectedBiere; }
            set { _selectedBiere = value; NotifyPropertyChanged("ListeBieres"); NotifyPropertyChanged("SelectedBiere"); }
        }


        public ClientProduitWindowViewModel(ClientModel client, ClientProduitWindow fenetre, ObservableCollection<ClientModel> ListeClient)
        {
            ListeBieres = new ObservableCollection<BiereModel>();
           
             try
             {
                 ListeBieres = BiereFactory.AllBiereToBiereModel(BiereDAO.LoadBieres());
             }
             catch
             {
                 ListeBieres.Add(new BiereModel("test", "test", "test",2,2,2, "test", "test", "test", "test", "test", "test",2));
                 BiereDAO.SaveBieres(BiereFactory.AllBiereModelToBiere(ListeBieres));
                 ListeBieres = BiereFactory.AllBiereToBiereModel(BiereDAO.LoadBieres());
                ListeBieres.Clear();
             }
            ListeBieresFiltre = new ObservableCollection<BiereModel>(ListeBieres);


            this.ListeClient = ListeClient;
            
            ListeCategorie = new ObservableCollection<string>();
            ListeCategorie.Add("Toutes");
            ListeCategorie.Add("Rafraîchissante");
            ListeCategorie.Add("Fruitée/Acidulée");
            ListeCategorie.Add("Riche/Corsée");

            if (ListeBieres.Count()>0)
                SelectedBiere = ListeBieres.First();
            SelectedCategorie = ListeCategorie.First();

            this.client = client;

            OnAddCommand = new DelegateCommand(OnAddAction, CanExecuteAdd);
            OnDeleteCommand = new DelegateCommand(OnDeleteAction, CanExecuteDelete);
            OnEditCommand = new DelegateCommand(OnEditAction, CanExecuteEdit);
            OnModifyCommand = new DelegateCommand(OnModifyAction, CanExecuteModify);
            OnLogoutCommand = new DelegateCommand(OnLogoutAction, CanExecuteLogout);
            OnSaveCommand = new DelegateCommand(OnSaveAction,CanExecuteSave);
            OnHyperLinkCommand = new DelegateCommand(OnHyperLinkAction, CanExecuteHyperLink);
            OnRecetteCommand = new DelegateCommand(OnRecetteAction, CanExecuteRecette);

            this.fenetre = fenetre;

            if (client.Nom.Equals("admin") && client.MotDePasse.Equals("admin"))
                _isUserAdmin = true;
        }

        private bool CanExecuteRecette(object obj)
        {
            if (_isUserAdmin)
            {
                if (ListeBieres.Count() != 0)
                    return true;
                return false;
            }

            return false;
        }

        private void OnRecetteAction(object obj)
        {
            RecetteWindow recette = new RecetteWindow(SelectedBiere);
            recette.Show();
            fenetre.Close();
        }

        private bool CanExecuteHyperLink(object obj)
        {
            return true;
        }

        private void OnHyperLinkAction(object obj)
        {
            Process p = new Process();
            p.StartInfo.FileName = "http://sebastienrico.com/accueil/";
            p.Start();
        }

        private bool CanExecuteSave(object obj)
        {
            if (_isUserAdmin)
                return true;
            return false;
        }

        private void OnSaveAction(object obj)
        {
            BiereDAO.SaveBieres(BiereFactory.AllBiereModelToBiere(ListeBieres));
        }

        private bool CanExecuteLogout(object obj)
        {
            return true;
        }

        private void OnLogoutAction(object obj)
        {
            MainUserWindow home = new MainUserWindow();
            home.Show();
            fenetre.Close();

        }

        private bool CanExecuteModify(object obj)
        {
            if (_isUserAdmin)
            {
                return false;
            }
            return true;
        }

        private void OnModifyAction(object obj)
        {
            ClientProfilWindow profil = new ClientProfilWindow(client);
            profil.ShowDialog();
            ClientDAO.SaveClient(ClientFactory.AllClientModelToClient(ListeClient));
        }

        private bool CanExecuteEdit(object obj)
        {
            if(_isUserAdmin)
                return _isEditEnabled;
            return false;
        }

        private void OnEditAction(object obj)
        {
            ModifierBiereWindow edit = new ModifierBiereWindow(SelectedBiere,ListeCategorie);
            edit.ShowDialog();
            
        }

        private bool CanExecuteDelete(object obj)
        {
            if (_isUserAdmin)
                return _isDeleteEnabled;
            return false;
        }

        private void OnDeleteAction(object obj)
        {
            MessageBox.Show(String.Format("La bière {0} a bien été supprimée !", SelectedBiere.Nom), "Suppression d'une bière");
            ListeBieres.Remove(SelectedBiere);
            ListeBieresFiltre.Remove(SelectedBiere);
            if (ListeBieres.Count() != 0) 
                SelectedBiere = ListeBieres.First();
            else
            {
                _isEditEnabled = false;
                OnEditCommand.RaiseCanExecuteChanged();
                _isDeleteEnabled = false;
                OnDeleteCommand.RaiseCanExecuteChanged();
            }
        }

        private bool CanExecuteAdd(object obj)
        {
            return _isUserAdmin;
        }

        private void OnAddAction(object obj)
        {
            AjouterBiereWindow add = new AjouterBiereWindow(ListeCategorie);
            add.ShowDialog();
            ListeBieres.Add(add.ViewModel.BiereToAdd);
            ListeBieresFiltre.Add(add.ViewModel.BiereToAdd);
        }

        private void UpdateListe()
        {
            if (!SelectedCategorie.Equals("Toutes"))
            {
                List<BiereModel> l = new List<BiereModel>(ListeBieres);
                ListeBieresFiltre = new ObservableCollection<BiereModel>(l.Where(b => b.Categorie.Equals(SelectedCategorie)));
            }
            else
            {
                ListeBieresFiltre = new ObservableCollection<BiereModel>(ListeBieres);
            }
            
        }
       
    }
}
