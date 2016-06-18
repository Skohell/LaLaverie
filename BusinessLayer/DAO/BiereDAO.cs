using BusinessLayer.Entities;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace BusinessLayer.DAO
{

    /// <summary>
    /// Classe permettant de charger et sauvegarder les bières.
    /// </summary>
    public static class BiereDAO
    {
        #region Save/load dans le fichier binaire "bieres.bin"
        /// <summary>
        /// Enregistre dans un fichier bieres.bin la liste passée en argument
        /// </summary>
        /// <param name="listeBiere">Liste a enregistrer</param>
        public static void SaveBieres(ObservableCollection<Biere> listeBiere)
        {
            IFormatter format = new BinaryFormatter();
            using (Stream flux = new FileStream("bieres.bin", FileMode.OpenOrCreate, FileAccess.Write))
            {
                format.Serialize(flux, listeBiere);
            }
        }

        /// <summary>
        /// Charge depuis un fichier bieres.bin la liste de bière et la retourne
        /// </summary>
        /// <returns>liste de bière chargée</returns>
        public static ObservableCollection<Biere> LoadBieres()
        {
            ObservableCollection<Biere> listeBiere = new ObservableCollection<Biere>();
            IFormatter format = new BinaryFormatter();

            using (Stream flux = new FileStream("bieres.bin", FileMode.Open, FileAccess.Read))
            {
                listeBiere = (ObservableCollection<Biere>)format.Deserialize(flux);
            }
            return listeBiere;
        }
        #endregion
    }
}