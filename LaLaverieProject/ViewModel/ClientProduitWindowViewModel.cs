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
using System.Windows;

namespace LaLaverieProject.ViewModel
{
    /// <summary>
    /// ViewModel de la View ClientProduitWindow
    /// </summary>
    public class ClientProduitWindowViewModel : NotifyPropertyChangedBase
    {
        #region Propriétés de la classe
        /// <summary>
        /// Client actuellement connecté
        /// </summary>
        public ClientModel client { get; set; }

        /// <summary>
        /// Fenetre actuelle
        /// </summary>
        ClientProduitWindow fenetre;

        /// <summary>
        /// Commande d'ajout d'une nouvelle bière
        /// </summary>
        public DelegateCommand OnAddCommand { get; set; }

        /// <summary>
        /// Commande de modification de la bière sélectionnée
        /// </summary>
        public DelegateCommand OnEditCommand { get; set; }
        /// <summary>
        /// Visibilité ou non de la commande de modification
        /// </summary>
        private bool _isEditEnabled = true;

        /// <summary>
        /// Commande de suppression de la bière sélectionnée
        /// </summary>
        public DelegateCommand OnDeleteCommand { get; set; }
        /// <summary>
        /// Visibilité ou non de la commande de suppression
        /// </summary>
        private bool _isDeleteEnabled = true;
        
        /// <summary>
        /// Commande de modification du profil client
        /// </summary>
        public DelegateCommand OnModifyCommand { get; set; }

        /// <summary>
        /// Commande de déconnexion du client
        /// </summary>
        public DelegateCommand OnLogoutCommand { get; set; }

        /// <summary>
        /// Commande de sauvegarde des changements effectués aux bières
        /// </summary>
        public DelegateCommand OnSaveCommand { get; set; }

        /// <summary>
        /// Commande de redirection vers le site internet
        /// </summary>
        public DelegateCommand OnHyperLinkCommand { get; set; }

        /// <summary>
        /// Commande d'affichage de la recette de la bière sélectionnée
        /// </summary>
        public DelegateCommand OnRecetteCommand { get; set; }
        /// <summary>
        /// Visibilité ou non de la commande de recette
        /// </summary>
        private bool _isRecetteEnabled = true;

        /// <summary>
        /// Etat administrateur ou non de la personne connectée
        /// </summary>
        private bool _isUserAdmin=false;

        /// <summary>
        /// Chaine de caracteres entrée dans la barre de recherche
        /// </summary>
        private string _recherche;
        public string Recherche
        {
            get
            {
                return _recherche;
            }

            set
            {
                _recherche = value;NotifyPropertyChanged(Recherche);UpdateListeRecherche();
            }
        }

        /// <summary>
        /// Liste des catégories de bière
        /// </summary>
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

        /// <summary>
        /// Catégorie de bière actuellement sélectionnée
        /// </summary>
        private string _selectedCategorie;
        public string SelectedCategorie
        {
            get { return _selectedCategorie; }
            set { _selectedCategorie = value; UpdateListe(); NotifyPropertyChanged("ListeCategorie"); NotifyPropertyChanged("SelectedCategorie"); }
        }

        /// <summary>
        /// Liste des Bières
        /// </summary>
        private ObservableCollection<BiereModel> _listeBieres;
        public ObservableCollection<BiereModel> ListeBieres
        {
            get { return _listeBieres; }

            set { _listeBieres = value; NotifyPropertyChanged("ListeBieres"); NotifyPropertyChanged("SelectedBiere"); }

        }

        /// <summary>
        /// Biere actuellement sélectionnée
        /// </summary>
        private BiereModel _selectedBiere;
        public BiereModel SelectedBiere
        {
            get { return _selectedBiere; }
            set { _selectedBiere = value; NotifyPropertyChanged("ListeBieres"); NotifyPropertyChanged("SelectedBiere"); }
        }

        /// <summary>
        /// Liste des Bières correspondant au filtre
        /// </summary>
        private ObservableCollection<BiereModel> _listeBieresFiltre;
        public ObservableCollection<BiereModel> ListeBieresFiltre
        {
            get { return _listeBieresFiltre; }

            set { _listeBieresFiltre = value; NotifyPropertyChanged("ListeBieresFiltre"); NotifyPropertyChanged("SelectedBiereFiltre"); }

        }

        /// <summary>
        /// Liste des clients
        /// </summary>
        private ObservableCollection<ClientModel> _listeClient;
        public ObservableCollection<ClientModel> ListeClient
        {
            get { return _listeClient; }

            set { _listeClient = value;}

        }

        #endregion

        #region Constructeur
        /// <summary>
        /// Constructeur du ViewModel
        /// </summary>
        /// <param name="client">Client actuellement connecté</param>
        /// <param name="fenetre">fenetre actuelle</param>
        /// <param name="ListeClient">Liste des clients</param>
        public ClientProduitWindowViewModel(ClientModel client, ClientProduitWindow fenetre, ObservableCollection<ClientModel> ListeClient)
        {
            //On charge les bières à partir du fichier ou on le créer à la première utilisation
            ListeBieres = new ObservableCollection<BiereModel>();
             try
             {
                 ListeBieres = BiereFactory.AllBiereToBiereModel(BiereDAO.LoadBieres());
             }
             catch
             {
                /* ListeBieres.Add(new BiereModel("test", "test", "test",2,2,2, "test", "test", "test", "test", "test", "test",2));
                 BiereDAO.SaveBieres(BiereFactory.AllBiereModelToBiere(ListeBieres));
                 ListeBieres = BiereFactory.AllBiereToBiereModel(BiereDAO.LoadBieres());
                 ListeBieres.Clear();
                 */
             }
            //On donne cette liste complète à notre liste qui suit les filtres
            ListeBieresFiltre = new ObservableCollection<BiereModel>(ListeBieres);

            //On récupère la liste des clients
            this.ListeClient = ListeClient;
            
            //Attribution des catégories de bière, fixes pour le moment
            ListeCategorie = new ObservableCollection<string>();
            ListeCategorie.Add("Toutes");
            ListeCategorie.Add("Rafraîchissante");
            ListeCategorie.Add("Fruitée/Acidulée");
            ListeCategorie.Add("Riche/Corsée");

            //Attribution des éléments sélectionnés par défaut
            if (ListeBieres.Count()>0)
                SelectedBiere = ListeBieres.First();
            SelectedCategorie = ListeCategorie.First();

            //On récupère le client actuellement connecté
            this.client = client;

            //Attribution des commandes
            OnAddCommand = new DelegateCommand(OnAddAction, CanExecuteAdd);
            OnDeleteCommand = new DelegateCommand(OnDeleteAction, CanExecuteDelete);
            OnEditCommand = new DelegateCommand(OnEditAction, CanExecuteEdit);
            OnModifyCommand = new DelegateCommand(OnModifyAction, CanExecuteModify);
            OnLogoutCommand = new DelegateCommand(OnLogoutAction, CanExecuteLogout);
            OnSaveCommand = new DelegateCommand(OnSaveAction,CanExecuteSave);
            OnHyperLinkCommand = new DelegateCommand(OnHyperLinkAction, CanExecuteHyperLink);
            OnRecetteCommand = new DelegateCommand(OnRecetteAction, CanExecuteRecette);

            //on récupère la fenetre actuelle
            this.fenetre = fenetre;

            //On regarde si l'utilisateur connecté est admin
            if (client.Nom.Equals("admin") && client.MotDePasse.Equals("admin"))
                _isUserAdmin = true;
        }
        #endregion

        #region Actions
        private bool CanExecuteRecette(object obj)
        {
            if (_isUserAdmin)
            {
                return _isRecetteEnabled;
            }


            return false;
        }
        /// <summary>
        /// Commande d'affichage de la recette
        /// </summary>
        /// <param name="obj"></param>
        private void OnRecetteAction(object obj)
        {
            RecetteWindow recette = new RecetteWindow(SelectedBiere);
            recette.ShowDialog();
        }

        private bool CanExecuteHyperLink(object obj)
        {
            return !_isUserAdmin;
        }
        /// <summary>
        /// Commande de redirection vers le site internet
        /// </summary>
        /// <param name="obj"></param>
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
        /// <summary>
        /// Commande de sauvegarde des bières
        /// </summary>
        /// <param name="obj"></param>
        private void OnSaveAction(object obj)
        {
            BiereDAO.SaveBieres(BiereFactory.AllBiereModelToBiere(ListeBieres));
        }

        private bool CanExecuteLogout(object obj)
        {
            return true;
        }
        /// <summary>
        /// Commande de déconnexion
        /// </summary>
        /// <param name="obj"></param>
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
        /// <summary>
        /// Commande de modification du profil utilisateur
        /// </summary>
        /// <param name="obj"></param>
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
        /// <summary>
        /// Commande de modification de la bière sélectionnée
        /// </summary>
        /// <param name="obj"></param>
        private void OnEditAction(object obj)
        {
            ModifierBiereWindow edit = new ModifierBiereWindow(SelectedBiere,ListeCategorie);
            edit.ShowDialog();

            //fix pour la liste qui ne s'actualise pas toute seule lors d'une modif
            string save = SelectedCategorie;
            SelectedCategorie = ListeCategorie.First();
            SelectedCategorie = save;


        }

        private bool CanExecuteDelete(object obj)
        {
            if (_isUserAdmin)
                return _isDeleteEnabled;
            return false;
        }
        /// <summary>
        /// Commande de supression de la bière sélectionnée
        /// </summary>
        /// <param name="obj"></param>
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
                _isRecetteEnabled = false;
                OnRecetteCommand.RaiseCanExecuteChanged();
            }
        }

        private bool CanExecuteAdd(object obj)
        {
            return _isUserAdmin;
        }
        /// <summary>
        /// Commande d'ajout d'une nouvelle bière
        /// </summary>
        /// <param name="obj"></param>
        private void OnAddAction(object obj)
        {
            AjouterBiereWindow add = new AjouterBiereWindow(ListeCategorie);
            add.ShowDialog();
            ListeBieres.Add(add.ViewModel.BiereToAdd);
            ListeBieresFiltre.Add(add.ViewModel.BiereToAdd);
            SelectedBiere = ListeBieres.First();

            _isEditEnabled = true;
            OnEditCommand.RaiseCanExecuteChanged();
            _isDeleteEnabled = true;
            OnDeleteCommand.RaiseCanExecuteChanged();
            _isRecetteEnabled = true;
            OnRecetteCommand.RaiseCanExecuteChanged();
        }
        #endregion

        #region Méthodes
        /// <summary>
        /// Met à jour la liste de bière filtrée en fonction de la catégorie demandée
        /// </summary>
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

        /// <summary>
        /// Met à jour la liste de bière filtrée en fonction de la barre de recherche
        /// </summary>
        private void UpdateListeRecherche()
        {
            SelectedCategorie = ListeCategorie.First();
            List<BiereModel> l = new List<BiereModel>(ListeBieres);
            ListeBieresFiltre = new ObservableCollection<BiereModel>(l.Where(b => b.Nom.ToUpper().Contains(Recherche.ToUpper())));
            
        }
        #endregion
    }
}
