using BusinessLayer.Entities;
using LaLaverie.Model;
using System;
using System.Collections.ObjectModel;

namespace LaLaverieProject.Factory
{
    /// <summary>
    /// Classe de transformation de Client Entity/Model
    /// </summary>
    class ClientFactory
    {
        #region Transformation de clients
        /// <summary>
        /// Transforme un Client en ClientModel
        /// </summary>
        /// <param name="c">Client a transformer</param>
        /// <returns>Client transformé</returns>
        public static ClientModel ClientToClientModel(Client c)
        {
            return new ClientModel
            {
                Nom = c.Nom,
                Prenom = c.Prenom,
                NumeroRue = c.NumeroRue,
                Rue = c.Rue,
                Ville = c.Ville,
                CodePostal = c.CodePostal,
                Mail = c.Mail,
                MotDePasse = c.MotDePasse,
                Age = c.Age
            };
        }

        /// <summary>
        /// Transforme un ClientModel en Client
        /// <param name="c">Client a transformer</param>
        /// <returns>Client transformé</returns>
        public static Client ClientModelToClient(ClientModel c)
        {
            return new Client
            {
                Nom = c.Nom,
                Prenom = c.Prenom,
                NumeroRue = c.NumeroRue,
                Rue = c.Rue,
                Ville = c.Ville,
                CodePostal = c.CodePostal,
                Mail = c.Mail,
                MotDePasse = c.MotDePasse,
                Age = c.Age
            };
        }
        #endregion

        #region Transformation de listes de clients
        /// <summary>
        /// Transforme une ObservableCollection de Client en ClientModel
        /// </summary>
        /// <param name="list">liste a transformer</param>
        /// <returns>Liste transformée</returns>
        public static ObservableCollection<ClientModel> AllClientToClientModel(ObservableCollection<Client> list)
        {
            ObservableCollection<ClientModel> liste = new ObservableCollection<ClientModel>();
            foreach (Client c in list)
            {
                liste.Add(ClientToClientModel(c));
            }
            return liste;
        }

        /// <summary>
        /// Transforme une ObservableCollection de ClientModel en Client
        /// </summary>
        /// <param name="list">liste a transformer</param>
        /// <returns>Liste transformée</returns>
        public static ObservableCollection<Client> AllClientModelToClient(ObservableCollection<ClientModel> list)
        {
            ObservableCollection<Client> liste = new ObservableCollection<Client>();
            foreach (ClientModel c in list)
            {
                liste.Add(ClientModelToClient(c));
            }
            return liste;
        }
        #endregion
    }
}
