using BusinessLayer.Entities;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace BusinessLayer.DAO
{
    /// <summary>
    /// Classe permettant de charger et sauvegarder les clients.
    /// </summary>
    public class ClientDAO
    {

        #region Save/load dans le fichier binaire "client.bin"
        /// <summary>
        /// Enregistre dans un fichier client.bin la liste passée en argument
        /// </summary>
        /// <param name="listeClient">Liste a enregistrer</param>
        public static void SaveClient(ObservableCollection<Client> listeClient)
        {
            IFormatter format = new BinaryFormatter();
            using (Stream flux = new FileStream("client.bin", FileMode.OpenOrCreate, FileAccess.Write))
            {
                format.Serialize(flux, listeClient);
            }
        }

        /// <summary>
        /// Charge depuis un fichier client.bin la liste de clients et la retourne
        /// </summary>
        /// <returns>liste de clients chargée</returns>
        public static ObservableCollection<Client> LoadClient()
        {
            ObservableCollection<Client> listeClient = new ObservableCollection<Client>();
            IFormatter format = new BinaryFormatter();

            using (Stream flux = new FileStream("client.bin", FileMode.Open, FileAccess.Read))
            {
                listeClient = (ObservableCollection<Client>)format.Deserialize(flux);
            }
            return listeClient;
        }
        #endregion
    }
}