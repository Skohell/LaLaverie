using BusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DAO
{

    /// <summary>
    /// Classe permettant de charger et sauvegarder les listes de bières.
    /// </summary>
    class BiereDAO
    {

        /// <summary>
        /// Enregistre dans un fichier bieres.bin la liste passée en argument
        /// </summary>
        /// <param name="listeBiere">Liste a enregistrer</param>
        public void SaveBieres(List<Biere> listeBiere)
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
        public List<Biere> LoadBieres()
        {
            List<Biere> listeBiere = new List<Biere>();
            IFormatter format = new BinaryFormatter();

            using (Stream flux = new FileStream("bieres.bin", FileMode.Open, FileAccess.Read))
            {
                listeBiere = (List<Biere>)format.Deserialize(flux);
            }
            return listeBiere;
        }

    }
}