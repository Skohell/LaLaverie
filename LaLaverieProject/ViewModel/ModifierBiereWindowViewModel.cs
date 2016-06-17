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
    public class ModifierBiereWindowViewModel
    {
        public BiereModel BiereToEdit { get; set; }

        public ModifierBiereWindow fenetre { get; set; }

        public DelegateCommand OnEditCommand { get; set; }
        public DelegateCommand OnImageCommand { get; set; }

        private string _selectedCategorie;
        public string SelectedCategorie
        {
            get { return _selectedCategorie; }
            set { _selectedCategorie = value; BiereToEdit.Categorie = value; }
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
                { _listeCategorie = value; }
            }
        }

        public ModifierBiereWindowViewModel(BiereModel biere, ModifierBiereWindow window,ObservableCollection<string> ListeCategorie)
        {

            fenetre = window;
            BiereToEdit = biere;
            OnEditCommand = new DelegateCommand(OnEditAction, CanExecuteEdit);
            this.ListeCategorie = ListeCategorie;
            SelectedCategorie = BiereToEdit.Categorie;
            OnImageCommand = new DelegateCommand(OnImageAction);
        }

        private bool CanExecuteEdit(object obj)
        {
            return true;
        }

        private void OnEditAction(object obj)
        {
            fenetre.Close();
            MessageBox.Show(String.Format("La bière {0} a bien été modifiée !", BiereToEdit.Nom), "Modification d'une bière");
        }


        private void OnImageAction(object obj)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Fichiers image (.png)|*.png|Fichiers image (.jpg)|*.jpg";
            file.ShowDialog();
            string path = String.Format(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/" + file.SafeFileName);
            System.IO.File.Copy(file.FileName, path);
            BiereToEdit.ImageUrl = path;
        }
    }
}
