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
    public static class BiereFactory
    {
        public static BiereModel BiereToBiereModel(Biere b)
        {
            return new BiereModel
            {
                Nom = b.Nom,
                Categorie = b.Categorie,
                Description = b.Description,
                Amertume = b.Amertume,
                Prix = b.Prix,
                Empatage = b.Empatage,
                Brassin = b.Brassin,
                Fermentation = b.Fermentation,
                Embouteillage = b.Embouteillage,
                Conservation = b.Conservation,
                ImageUrl = b.ImageUrl,
                NbBouteille = b.NbBouteille
            };
        }

        public static Biere BiereModelToBiere(BiereModel b)
        {
            return new Biere
            {
                Nom = b.Nom,
                Categorie = b.Categorie,
                Description = b.Description,
                Amertume = b.Amertume,
                Prix = b.Prix,
                Empatage = b.Empatage,
                Brassin = b.Brassin,
                Fermentation = b.Fermentation,
                Embouteillage = b.Embouteillage,
                Conservation = b.Conservation,
                ImageUrl = b.ImageUrl,
                NbBouteille = b.NbBouteille
            };
        }


        public static ObservableCollection<BiereModel> AllBiereToBiereModel(ObservableCollection<Biere> list)
        {
            ObservableCollection<BiereModel> liste = new ObservableCollection<BiereModel>();
            foreach(Biere b in list)
            {
                liste.Add(BiereToBiereModel(b));
            }
            return liste;
        }

        public static ObservableCollection<Biere> AllBiereModelToBiere(ObservableCollection<BiereModel> list)
        {
            ObservableCollection<Biere> liste = new ObservableCollection<Biere>();
            foreach (BiereModel b in list)
            {
                liste.Add(BiereModelToBiere(b));
            }
            return liste;
        }
    }
}
