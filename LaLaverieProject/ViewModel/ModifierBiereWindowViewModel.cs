using LaLaverie.Model;
using LaLaverieProject.View;
using Library;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows;

namespace LaLaverieProject.ViewModel
{
    /// <summary>
    /// ViewModel de la View ModifierBiereWindow
    /// </summary>
    public class ModifierBiereWindowViewModel
    {

        #region propriétés
        /// <summary>
        /// Biere à éditer
        /// </summary>
        public BiereModel BiereToEdit { get; set; }

        /// <summary>
        /// fenetre actuelle
        /// </summary>
        public ModifierBiereWindow fenetre { get; set; }

        /// <summary>
        /// Commande de modification
        /// </summary>
        public DelegateCommand OnEditCommand { get; set; }

        /// <summary>
        /// Commande de modification de l'image
        /// </summary>
        public DelegateCommand OnImageCommand { get; set; }

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
                { _listeCategorie = value; }
            }
        }

        /// <summary>
        /// Catégorie sélectionnée
        /// </summary>
        private string _selectedCategorie;
        public string SelectedCategorie
        {
            get { return _selectedCategorie; }
            set { _selectedCategorie = value; BiereToEdit.Categorie = value; }
        }
        #endregion

        #region Constructeur
        /// <summary>
        /// Constructeur du ViewModel
        /// </summary>
        /// <param name="biere">Biere a editer</param>
        /// <param name="window">fenetre actuelle</param>
        /// <param name="ListeCategorie">liste des catégories de bières</param>
        public ModifierBiereWindowViewModel(BiereModel biere, ModifierBiereWindow window,ObservableCollection<string> ListeCategorie)
        {

            fenetre = window;
            BiereToEdit = biere;
            OnEditCommand = new DelegateCommand(OnEditAction);
            this.ListeCategorie = ListeCategorie;
            SelectedCategorie = BiereToEdit.Categorie;
            OnImageCommand = new DelegateCommand(OnImageAction);
        }
        #endregion

        #region Actions  
        /// <summary>
        /// Commande de modification
        /// </summary>
        /// <param name="obj"></param>
        private void OnEditAction(object obj)
        {
            fenetre.Close();
            MessageBox.Show(String.Format("La bière {0} a bien été modifiée !", BiereToEdit.Nom), "Modification d'une bière");
        }

        /// <summary>
        /// Commande de modification de l'image
        /// </summary>
        /// <param name="obj"></param>
        private void OnImageAction(object obj)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Fichiers image (.png)|*.png|Fichiers image (.jpg)|*.jpg";
            file.ShowDialog();
            string path = String.Format(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/" + file.SafeFileName);
            try
            {
                System.IO.File.Copy(file.FileName, path);
            }
            catch //Si on utilise deux fois la même image on évite l'exception mais on ne fait rien de plus, la bière prendra comme ImageUrl celle existante
            {

            }
           
            BiereToEdit.ImageUrl = path;
        }
        #endregion
    }
}
