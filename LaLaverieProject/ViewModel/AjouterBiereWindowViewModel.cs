using LaLaverie.Model;
using LaLaverieProject.View;
using Library;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LaLaverieProject.ViewModel
{
    public class AjouterBiereWindowViewModel
    { 
        public DelegateCommand OnNewBiereCommand { get; set; }
        public DelegateCommand OnImageCommand { get; set; }
        public AjouterBiereWindow fenetre { get; set; }

        private string _selectedCategorie;
        public string SelectedCategorie
        {
            get { return _selectedCategorie; }
            set { _selectedCategorie = value; BiereToAdd.Categorie = value; }
        }


        private ObservableCollection<string> _listeCategorie;
        public ObservableCollection<string> ListeCategorie
        {
            get
            {
                return _listeCategorie;
            }

            set
            {
                { _listeCategorie = value;}
            }
        }

        public BiereModel BiereToAdd
        {
            get;
            set;
        }

        public AjouterBiereWindowViewModel(AjouterBiereWindow fenetre, ObservableCollection<string> ListeCategorie)
        {
            BiereToAdd = new BiereModel();
            OnNewBiereCommand = new DelegateCommand(OnAddAction, CanExecuteAdd);
            OnImageCommand = new DelegateCommand(OnImageAction);
            this.fenetre = fenetre;
            this.ListeCategorie = ListeCategorie;
        }

        private void OnImageAction(object obj)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Fichiers image (.png)|*.png|Fichiers image (.jpg)|.jpg";
            file.ShowDialog();
            string path = String.Format(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/" + file.SafeFileName);
            System.IO.File.Copy(file.FileName, path);
            BiereToAdd.ImageUrl = path;
        }

        private bool CanExecuteAdd(object obj)
        {
            return true;
        }

        private void OnAddAction(object obj)
        {
            fenetre.Close();
            MessageBox.Show(String.Format("La bière {0} a bien été ajoutée !", BiereToAdd.Nom), "Ajout d'une bière");
        }
    }
}
