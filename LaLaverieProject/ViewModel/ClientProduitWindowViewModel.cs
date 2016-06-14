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
    public class ClientProduitWindowViewModel : NotifyPropertyChangedBase
    {
        
        public ClientModel client { get; set; }

        public DelegateCommand OnAddCommand { get; set; }
        private bool _isEditEnabled = true;
        public DelegateCommand OnEditCommand { get; set; }
        private bool _isDeleteEnabled = true;
        public DelegateCommand OnDeleteCommand { get; set; }

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
            set { _selectedCategorie = value; NotifyPropertyChanged("ListeCategorie"); NotifyPropertyChanged("SelectedCategorie"); }
        }

        private ObservableCollection<BiereModel> _listeBieres;
        public ObservableCollection<BiereModel> ListeBieres
        {
            get { return _listeBieres; }

            set { _listeBieres = value; NotifyPropertyChanged("ListeBieres"); NotifyPropertyChanged("SelectedBiere"); }

        }

        private BiereModel _selectedBiere;
        public BiereModel SelectedBiere
        {
            get { return _selectedBiere; }
            set { _selectedBiere = value; NotifyPropertyChanged("ListeBieres"); NotifyPropertyChanged("SelectedBiere"); }
        }


        public ClientProduitWindowViewModel(ClientModel client)
        {
            ListeBieres = new ObservableCollection<BiereModel>(){
                new BiereModel(){
                    Nom = "Patersbier",
                    Categorie = "Rafraîchissante",
                    Type = "Pal Ale",
                    Description = "Moelleuse avec une amertume subtile. Elle à un aspect jaune paille clair à doré léger, avec un col de mousse ferme. Son goût est crémeux et son arôme légèrement malté et houblonné. Le houblon anglais donne des notes florales. Cette bière peut être peu amère et peut avoir un goût de caramel en fin de bouche, comme forte avec des saveurs d’épices, ou encore citronnée et sèche en fin de bouche.",
                    Alcool = 5,
                    Amertume = 3,
                    Prix = 4,
                    Empatage = "Description de l'empatage de la Patersbier",
                    Brassin = "Une description du brassin de la Patersbier",
                    Fermentation = "Une description de la fermentation de la Patersbier",
                    Embouteillage = "Une description de l'embouteillage de la Patersbier",
                    Conservation = "Une description de la conservation de la Patersbier",
                    ImageUrl = "https://www.eebria.com/media/products/1737/20160210110751830/450x450.jpg",
                    NbBouteille = 42
        },
                new BiereModel (){
                    Nom = "Ale d'été",
                    Categorie = "Rafraîchissante",
                    Type = "Bitter",
                    Description = "Son aspect est doré pâle à cuivre profond, très limpide avec une mousse légère. Son goût est plutôt amer, mais bien équilibré. Elle a parfois des saveurs caramélisées ou légèrement fruitées. Son arôme est houblonné léger avec des notes de malt et parfois de caramel. Elles peuvent parfois être un peu sèche en bouche.",
                    Alcool = 4,
                    Amertume = 5,
                    Prix = 10,
                    Empatage = "Description de l'empatage de la Ale d'été",
                    Brassin = "Une description du brassin de la Ale d'été",
                    Fermentation = "Une description de la fermentation de la Ale d'été",
                    Embouteillage = "Une description de l'embouteillage de la Ale d'été",
                    Conservation = "Une description de la conservation de la Ale d'été",
                    ImageUrl="http://1.bp.blogspot.com/-Pmc-1EyCcx8/TY8Sw0BItZI/AAAAAAAAACo/lVB5lgoubog/s320/Sierra-Nevada-Pale-Ale.png",
                    NbBouteille = 43
        },
                new BiereModel (){
                    Nom = "Biere aux fruits",
                    Categorie = "Fruitée",
                    Type = "Fruits",
                    Description = "Cette bière me permet de tester la catéforie fruitée alors elle a un goût fort en fruits voilà.",
                    Alcool = 4,
                    Amertume = 6,
                    Prix = 8,
                    Empatage = "Description de l'empatage ",
                    Brassin = "Une description du brassin ",
                    Fermentation = "Une description de la fermentation ",
                    Embouteillage = "Une description de l'embouteillage ",
                    Conservation = "Une description de la conservation ",
                    ImageUrl="http://2.bp.blogspot.com/-Zbj5vhll92I/UmQXDyTDvbI/AAAAAAABMwQ/HcuYbCrnv1w/s640/Capture+d%E2%80%99e%CC%81cran+2013-10-20+a%CC%80+19.45.20.png",
                    NbBouteille = 666
        }

            };

            ListeCategorie = new ObservableCollection<string>();
            ListeCategorie.Add("Toutes");
            ListeCategorie.Add("Rafraîchissante");
            ListeCategorie.Add("Fruitée");

            SelectedBiere = ListeBieres.First();
            SelectedCategorie = ListeCategorie.First();

            this.client = client;

            OnAddCommand = new DelegateCommand(OnAddAction, CanExecuteAdd);
            OnDeleteCommand = new DelegateCommand(OnDeleteAction, CanExecuteDelete);
            OnEditCommand = new DelegateCommand(OnEditAction, CanExecuteEdit);



            if (client.Nom.Equals("admin") && client.MotDePasse.Equals("admin"))
                _isUserAdmin = true;
        }

        private bool CanExecuteEdit(object obj)
        {
            if(_isUserAdmin)
                return _isEditEnabled;
            return false;
        }

        private void OnEditAction(object obj)
        {
            ModifierBiereWindow edit = new ModifierBiereWindow(SelectedBiere);
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
            AjouterBiereWindow add = new AjouterBiereWindow();
            add.ShowDialog();
            ListeBieres.Add(add.ViewModel.BiereToAdd);
        }
    }
}
