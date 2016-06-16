using BusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DAO
{
    public class ClientDAO
    {
 
        public static void SaveClient(ObservableCollection<Client> listeClient)
        {
            IFormatter format = new BinaryFormatter();
            using (Stream flux = new FileStream("client.bin", FileMode.OpenOrCreate, FileAccess.Write))
            {
                format.Serialize(flux, listeClient);
            }
        }

 
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

    }
}