using Library;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaLaverie.Model
{
    public class ClientModel : NotifyPropertyChangedBase
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
                    throw new Exception("Le nom du client est invalide.");
                else
                {
                    _nom = value;
                    NotifyPropertyChanged("Nom");
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
                    throw new Exception("Le prenom du client est invalide.");
                else
                {
                    _prenom = value;
                    NotifyPropertyChanged("Prenom");
                }
            }
        }

        /// <summary>
        /// Age du client
        /// </summary>
        private int _age;
        public int  Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value.Equals(null))
                    throw new Exception("L'age du client est invalide.");
                else
                {
                    _age = value;
                    NotifyPropertyChanged("Age");
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
                NotifyPropertyChanged("NumeroRue");
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
                    NotifyPropertyChanged("Rue");
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
                    NotifyPropertyChanged("Ville");
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
                    NotifyPropertyChanged("CodePostal");
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
                    NotifyPropertyChanged("Mail");
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
                    NotifyPropertyChanged("MotDePasse");
                }
            }
        }
        #endregion

        #region Constructeur
        /// <summary>
        /// Constructeur du client
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

        public ClientModel(){}
        #endregion

        #region Methodes
        /// <summary>
        /// Détermine si le client en création existe déjà
        /// </summary>
        /// <param name="client">Client existant potentiellement déjà</param>
        /// <returns>True si la personne existe sinon false</returns>
        public bool Equals(ClientModel client)
        {
            if (this.CompareTo(client) == 0)
                return true;
            return false;
        }

        /// <summary>
        /// Compare deux clients existants
        /// </summary>
        /// <param name="client">Un autre client</param>
        /// <returns>1, 0 ou -1</returns>
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
