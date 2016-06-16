using System;
using Library;

namespace LaLaverie.Model
{

    public class BiereModel : NotifyPropertyChangedBase
    {


        #region Propriétés de la classe

        /// <summary>
        /// Lien vers l'image de la bière
        /// </summary>
        private string _imageUrl;
        public string ImageUrl
        {
            get
            {
                return _imageUrl;
            }

            set
            {
                _imageUrl = value;
                NotifyPropertyChanged("ImageUrl");
            }
        }

        /// <summary>
        /// Nom de la bière
        /// </summary>
        private string _nom;
        public string Nom
        {
            get
            {
                return _nom;
            }
            set
            {
                if (value.Equals(null))
                    throw new Exception("Le nom de la bière ne peut être nul.");
                else
                {
                    _nom = value;
                    NotifyPropertyChanged("Nom");
                }
            }
        }

        /// <summary>
        /// Catégorie de la bière
        /// </summary>
        private string _categorie;
        public string Categorie
        {
            get
            {
                return _categorie;
            }
            set
            {
                //if (!categories.Contains(value))
                //    throw new Exception("Cette catégorie de bière n'existe pas.");
                //else
                //{
                    _categorie = value;
                    NotifyPropertyChanged("Categorie");
                //}
            }
        }

        /// <summary>
        /// Descritpion de la bière
        /// </summary>
        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (value.Equals(null))
                    _description = "Aucune description pour cette bière.";
                else
                {
                    _description = value;
                    NotifyPropertyChanged("Description");
                }
            }
        }

        /// <summary>
        /// Taux d'alcool de la bière
        /// </summary>
        private float _alcool;
        public float Alcool
        {
            get
            {
                return _alcool;
            }
            set
            {
                if (!(value >= 0 && value <= 100))
                    throw new Exception("Le taux d'alcool doit être compris entre 0 et 100.");
                else
                {
                    _alcool = value;
                    NotifyPropertyChanged("Alcool");
                }
            }
        }
        
        /// <summary>
        /// Taux d'amertume de la bière
        /// </summary>
        private int _amertume;
        public int Amertume
        {
            get
            {
                return _amertume;
            }
            set
            {
                if (!(value >= 0 && value <= 10))
                    throw new Exception("L'amertume doit être comprise entre 0 et 10.");
                else
                {
                    _amertume = value;
                    NotifyPropertyChanged("Amertume");
                }
            }
        }

        /// <summary>
        /// Prix de la bière
        /// </summary>
        private float _prix;
        public float Prix
        {
            get
            {
                return _prix;
            }
            set
            {
                if (value <= 0 || value.Equals(null))
                    throw new Exception("Le prix ne peut être nul.");
                else
                {
                    _prix = value;
                    NotifyPropertyChanged("Prix");
                }

            }
        }

        /// <summary>
        /// Nombre de bouteilles disponibles
        /// </summary>
        private int _nbBouteille;
        public int NbBouteille
        {
            get
            {
                return _nbBouteille;
            }
            set
            {
                if (!value.Equals(null))
                    _nbBouteille = value;
                NotifyPropertyChanged("NbBouteille");
            }
        }


        /// <summary>
        /// Empatage
        /// </summary>
        private string _empatage;
        public string Empatage
        {
            get
            {
                return _empatage;
            }
            set
            {
                if (value.Equals(null))
                    throw new Exception("Le maltage doit avoir des consignes.");
                else
                {
                    _empatage = value;
                    NotifyPropertyChanged("Empatage");
                }
            }
        }

        /// <summary>
        /// Brassin
        /// </summary>
        private string _brassin;
        public string Brassin
        {
            get
            {
                return _brassin;
            }
            set
            {
                if (value.Equals(null))
                    throw new Exception("Le houblonnage doit avoir des consignes.");
                else
                {
                    _brassin = value;
                    NotifyPropertyChanged("Brassin");
                }
            }
        }

        /// <summary>
        /// Fermentation
        /// </summary>
        private string _fermentation;
        public string Fermentation
        {
            get
            {
                return _fermentation;
            }
            set
            {
                if (value.Equals(null))
                    throw new Exception("La fermentation doit avoir des consignes.");
                else
                {
                    _fermentation = value;
                    NotifyPropertyChanged("Fermentation");
                }
            }
        }

        /// <summary>
        /// Embouteillage
        /// </summary>
        private string _embouteillage;
        public string Embouteillage
        {
            get
            {
                return _embouteillage;
            }
            set
            {
                if (value.Equals(null))
                    throw new Exception("L'embouteillage doit avoir des consignes.");
                else
                {
                    _embouteillage = value;
                    NotifyPropertyChanged("Embouteillage");
                }
            }
        }

        /// <summary>
        /// Conservation
        /// </summary>
        private string _conservation;
        public string Conservation
        {
            get
            {
                return _conservation;
            }
            set
            {
                if (value.Equals(null))
                    throw new Exception("La conservation doit avoir des consignes.");
                else
                {
                    _conservation = value;
                    NotifyPropertyChanged("Conservation");
                }
            }
        }
        #endregion

        #region Constructeur
        /// <summary>
        /// Constructeur d'une Bière
        /// </summary>
        /// <param name="nom">Nom de la bière</param>
        /// <param name="categorie">Catégorie de la bière</param>
        /// <param name="description">Descritpion de la bière</param>
        /// <param name="alcool">Taux d'alcool de la bière</param>
        /// <param name="amertume">Amertume de la bière</param>
        /// <param name="prix">Prix de la bière</param>
        /// <param name="empatage">Description de l'empatage</param>
        /// <param name="brassin">Descritpion du brassin</param>
        /// <param name="fermentation">Description de la frmentation de la bière</param>
        /// <param name="embouteillage">Description de l'embouteillage de la bière</param>
        /// <param name="conservation">Description de la conservation de la bière</param>
        /// <param name="nbbouteille">Nombre de bouteilles en stock </param>
        public BiereModel(string nom, string categorie, string description, float alcool, int amertume, float prix, string empatage, string brassin, string fermentation, string embouteillage, string conservation, string image, int nbbouteille)
        {
            try
            {
                Nom = nom;
                Categorie = categorie;
                Description = description;
                Alcool = alcool;
                Amertume = amertume;
                Prix = prix;
                Empatage = empatage;
                Brassin = brassin;
                Fermentation = fermentation;
                Embouteillage = embouteillage;
                Conservation = conservation;
                ImageUrl = ImageUrl;
                NbBouteille = nbbouteille;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur dans au moins un des arguments lors de la création d'une bière : {0}", e);
            }
        }

        public BiereModel()
        {
        }
        #endregion

        #region Affichages
        /// <summary>
        /// Affichage d'une bière
        /// </summary>
        /// <returns>Affichage d'une bière</returns>
        public override string ToString()
        {
            return string.Format("{0}", Nom);
        }

        /// <summary>
        /// Affichage formatté du prix
        /// </summary>
        /// <returns>Affichage formatté du prix</returns>
        public string AfficherPrix()
        {
            return string.Format("{0} euros", Prix);
        }

        /// <summary>
        /// Affichage formatté de l'alcool
        /// </summary>
        /// <returns>Affichage formatté de l'alcool</returns>
        public string AfficherAlcool()
        {
            return string.Format("{0}%", Alcool);
        }

        /// <summary>
        /// Affichage formatté de l'amertume
        /// </summary>
        /// <returns>Affichage formatté de l'amertume</returns>
        public string AfficherAmertume()
        {
            return string.Format("{0} sur 10", Amertume);
        }

        /// <summary>
        /// Affichage formatté de la quantité disponible
        /// </summary>
        /// <returns>Affichage formatté de la quantité disponible</returns>
        public string AfficherNbBouteille()
        {
            if(NbBouteille <= 0)
                return string.Format("{0} bouteille", NbBouteille);
            else
                return string.Format("{0} bouteilles", NbBouteille);
        }


        #endregion

    }
}
