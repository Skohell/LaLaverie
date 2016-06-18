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
    /// ViewModel de la View AjouterBiereWindow
    /// </summary>
    public class AjouterBiereWindowViewModel
    {
        #region propriétés de la classe
        /// <summary>
        /// Commande d'ajout d'une nouvelle bière
        /// </summary>
        public DelegateCommand OnNewBiereCommand { get; set; }

        /// <summary>
        /// Commande d'ajout d'une Image
        /// </summary>
        public DelegateCommand OnImageCommand { get; set; }

        /// <summary>
        /// Fenetre actuelle
        /// </summary>
        public AjouterBiereWindow fenetre { get; set; }

        /// <summary>
        /// Catégorie sélectionnée actuellement
        /// </summary>
        private string _selectedCategorie;
        public string SelectedCategorie
        {
            get { return _selectedCategorie; }
            set { _selectedCategorie = value; BiereToAdd.Categorie = value; }
        }

        /// <summary>
        /// Liste des catégories
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
                { _listeCategorie = value;}
            }
        }

        /// <summary>
        /// Biere à ajouter
        /// </summary>
        public BiereModel BiereToAdd
        {
            get;
            set;
        }
        #endregion

        #region Constructeur
        /// <summary>
        /// Constructeur du ViewModel
        /// </summary>
        /// <param name="fenetre">Fenetre actuelle</param>
        /// <param name="ListeCategorie">Liste des catégories de bière</param>
        public AjouterBiereWindowViewModel(AjouterBiereWindow fenetre, ObservableCollection<string> ListeCategorie)
        {
            BiereToAdd = new BiereModel();
            OnNewBiereCommand = new DelegateCommand(OnAddAction);
            OnImageCommand = new DelegateCommand(OnImageAction);
            this.fenetre = fenetre;
            this.ListeCategorie = ListeCategorie;
        }
        #endregion

        #region Actions
        /// <summary>
        /// Action d'ajout d'une image
        /// </summary>
        /// <param name="obj"></param>
        private void OnImageAction(object obj)
        {
            //Ouverture d'une fenetre de parcours de fichiers image
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Fichiers image (.png)|*.png|Fichiers image (.jpg)|*.jpg";
            file.ShowDialog();

            //On récupère le chemin de l'image choisie et on la copie dans un répertoire ou elle ne sera pas supprimée par mégarde
            string path = String.Format(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/" + file.SafeFileName);
            try
            {
                System.IO.File.Copy(file.FileName, path);
            }
            catch //Si on utilise deux fois une même image on évite l'exception mais on ne fait rien de plus, la bière prendra le même path en ImageUrl
            {

            }

            //Attribution de l'image a la bière
            BiereToAdd.ImageUrl = path;
        }

        /// <summary>
        /// Action du clic sur "ajouter"
        /// </summary>
        /// <param name="obj"></param>
        private void OnAddAction(object obj)
        {
            //On ferme la fenetre et on confirme que l'ajout est effectué ( dans le viewmodel père )
            fenetre.Close();
            MessageBox.Show(String.Format("La bière {0} a bien été ajoutée !", BiereToAdd.Nom), "Ajout d'une bière");
        }
        #endregion
    }
}
