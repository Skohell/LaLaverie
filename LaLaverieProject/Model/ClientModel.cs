using System;

namespace LaLaverie.Model
{
    /// <summary>
    /// Classe représentant un ClientModel
    /// </summary>
   
    public class ClientModel
    {
        #region Attributs et propriétés
        /// <summary>
        /// Nom du client
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
                    throw new Exception("Le nom du client ne peut être nul.");
                else
                {
                    _nom = value;

                }

            }
        }

        /// <summary>
        /// Prenom du client
        /// </summary>
        private string _prenom;
        public string Prenom
        {
            get
            {
                return _prenom;
            }
            set
            {
                if (value.Equals(null))
                    throw new Exception("Le prenom du client ne peut etre nul.");
                else
                {
                    _prenom = value;

                }
            }
        }

        /// <summary>
        /// Age du client
        /// </summary>
        private int _age;
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value.Equals(null))
                    throw new Exception("L'age du client ne peut etre nul.");
                else if (value < 18)
                    throw new Exception("Le client doit être majeur.");
                else
                {
                    _age = value;

                }
            }
        }

        /// <summary>
        /// Numéro de rue du client
        /// </summary>
        private int _numeroRue;
        public int NumeroRue
        {
            get
            {
                return _numeroRue;
            }
            set
            {
                _numeroRue = value;

            }
        }

        /// <summary>
        /// Rue de l'adresse du client
        /// </summary>
        private string _rue;
        public string Rue
        {
            get
            {
                return _rue;
            }
            set
            {
                if (value.Equals(null))
                    throw new Exception("La rue de l'adresse du client est invalide.");
                else
                {
                    _rue = value;

                }

            }
        }

        /// <summary>
        /// Ville du client
        /// </summary>
        private string _ville;
        public string Ville
        {
            get
            {
                return _ville;
            }
            set
            {
                if (value.Equals(null))
                    throw new Exception("La ville du client est invalide.");
                else
                {
                    _ville = value;

                }
            }
        }

        /// <summary>
        /// Code postal du client
        /// </summary>
        private int _codePostal;
        public int CodePostal
        {
            get
            {
                return _codePostal;
            }
            set
            {
                if (!(value > 0 && value <= 99999))
                    throw new Exception("Le code postal n'est pas correcte.");
                else
                {
                    _codePostal = value;

                }
            }
        }

        /// <summary>
        /// Adresse mail du client
        /// </summary>
        private string _mail;
        public string Mail
        {
            get
            {
                return _mail;
            }
            set
            {
                if (value.Equals(null))
                    _mail = "Ce client ne possède pas d'adresse mail";
                else
                {
                    _mail = value;

                }
            }
        }

        /// <summary>
        /// Mot de passe du client
        /// </summary>
        private string _motDePasse;
        public string MotDePasse
        {
            get
            {
                return _motDePasse;
            }
            set
            {
                if (value.Equals(null))
                    throw new Exception("Le mot de passe ne peut être nul.");
                else
                {
                    _motDePasse = value;

                }
            }
        }
        #endregion

        #region Constructeurs
        /// <summary>
        /// Constructeur du ClientModel
        /// </summary>
        /// <param name="nom">Nom du client</param>
        /// <param name="prenom">Prenom du client</param>
        /// <param name="num">Numéro de rue du client</param>
        /// <param name="rue">Rue de l'adresse du client</param>
        /// <param name="ville">Ville du client</param>
        /// <param name="codePostal">Code postal du client</param>
        /// <param name="mail">Adresse mail du client</param>
        /// <param name="mdp">Mot de passe du client</param>
        /// <param name="age">Age du client</param>
        public ClientModel(string nom, string prenom, int num, string rue, string ville, int codePostal, string mail, string mdp, int age)
        {
            try
            {
                Nom = nom;
                Prenom = prenom;
                NumeroRue = num;
                Rue = rue;
                Ville = ville;
                CodePostal = codePostal;
                Mail = mail;
                MotDePasse = mdp;
                Age = age;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur dans au moins un des arguments lors de la création d'un client : {0}", e);
            }

        }

        public ClientModel() { }
        #endregion

        #region Methodes

        public bool Equals(ClientModel client)
        {
            if (this.CompareTo(client) == 0)
                return true;
            return false;
        }


        public int CompareTo(ClientModel client)
        {

            if (client.Nom == Nom)
            {
                if (client.Prenom == Prenom)
                {
                    if (client.Rue == Rue)
                    {
                        if (client.NumeroRue == NumeroRue)
                            return 0;
                    }
                }
            }
            else if (string.Compare(client.Nom, Nom) > 0)
            {
                if (string.Compare(client.Prenom, Prenom) > 0)
                {
                    if (string.Compare(client.Rue, Rue) > 0)
                    {
                        if (client.NumeroRue >= NumeroRue)
                            return 1;
                    }
                }
            }
            return -1;
        }
        #endregion

        #region Affichages
        /// <summary>
        /// Affichage d'un client
        /// </summary>
        /// <returns>Les coordonnées du client au complet en format lettre</returns>
        public override string ToString()
        {
            return string.Format("{0} {1}", Nom, Prenom);
        }
        #endregion
    }
}
