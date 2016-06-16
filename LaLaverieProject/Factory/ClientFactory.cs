using BusinessLayer.Entities;
using LaLaverie.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaLaverieProject.Factory
{
    class ClientFactory
    {
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


        public static ObservableCollection<ClientModel> AllClientToClientModel(ObservableCollection<Client> list)
        {
            ObservableCollection<ClientModel> liste = new ObservableCollection<ClientModel>();
            foreach (Client c in list)
            {
                liste.Add(ClientToClientModel(c));
            }
            return liste;
        }

        internal static ObservableCollection<ClientModel> AllClientToClientModel(object p)
        {
            throw new NotImplementedException();
        }

        public static ObservableCollection<Client> AllClientModelToClient(ObservableCollection<ClientModel> list)
        {
            ObservableCollection<Client> liste = new ObservableCollection<Client>();
            foreach (ClientModel c in list)
            {
                liste.Add(ClientModelToClient(c));
            }
            return liste;
        }
    }
}
