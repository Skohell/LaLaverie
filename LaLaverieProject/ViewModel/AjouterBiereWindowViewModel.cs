﻿using LaLaverie.Model;
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
    public class AjouterBiereWindowViewModel
    { 
        public DelegateCommand OnNewBiereCommand { get; set; }
        public AjouterBiereWindow fenetre { get; set; }

        public BiereModel BiereToAdd
        {
            get;
            set;
        }

        public AjouterBiereWindowViewModel(AjouterBiereWindow fenetre)
        {
            BiereToAdd = new BiereModel();
            OnNewBiereCommand = new DelegateCommand(OnAddAction, CanExecuteAdd);
            this.fenetre = fenetre;
        }

        private bool CanExecuteAdd(object obj)
        {
            return true;
        }

        private void OnAddAction(object obj)
        {
            fenetre.Close();
            MessageBox.Show(String.Format("La bière {0} a bien été ajoutée !", BiereToAdd.Nom), "Ajout d'une bière");
        }
    }
}