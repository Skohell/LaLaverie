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
    public class ModifierBiereWindowViewModel
    {
        public BiereModel BiereToEdit { get; set; }

        public ModifierBiereWindow fenetre { get; set; }

        public DelegateCommand OnEditCommand { get; set; }

        public ModifierBiereWindowViewModel(BiereModel biere, ModifierBiereWindow window)
        {

            fenetre = window;
            BiereToEdit = biere;
            OnEditCommand = new DelegateCommand(OnEditAction, CanExecuteEdit);

        }

        private bool CanExecuteEdit(object obj)
        {
            return true;
        }

        private void OnEditAction(object obj)
        {
            fenetre.Close();
            MessageBox.Show(String.Format("La bière {0} a bien été modifiée !", BiereToEdit.Nom), "Modification d'une bière");
        }



    }
}
