using LaLaverie.Model;
using LaLaverieProject.View;
using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LaLaverieProject.ViewModel
{

    public class ClientProfilWindowViewModel
    {

        public ClientModel ClientToEdit { get; set; }
        ClientProfilWindow fenetre;

        public DelegateCommand OnEditCommand { get; set; }

        public ClientProfilWindowViewModel(ClientModel c, ClientProfilWindow fenetre)
        {
         
            OnEditCommand = new DelegateCommand(OnEditAction);

            ClientToEdit = c;
            this.fenetre = fenetre;
        }

        private void OnEditAction(object obj)
        {
            fenetre.Close();
            MessageBox.Show(String.Format("Profil modifié !"),"Modification de profil");
        }
    }
}
