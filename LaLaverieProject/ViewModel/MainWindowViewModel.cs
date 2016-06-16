using BusinessLayer.DAO;
using LaLaverie.Model;
using LaLaverieProject.Factory;
using LaLaverieProject.View;
using Library;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace LaLaverieProject.ViewModel
{

    public class MainWindowViewModel : NotifyPropertyChangedBase
    {

        MainWindow fenetre;

        public DelegateCommand OnClickCommand {get; set;}


        public MainWindowViewModel(MainWindow fenetre)
        {
            OnClickCommand = new DelegateCommand(OnClickAction);
            this.fenetre = fenetre;
        }

        private void OnClickAction(object obj)
        {
            MainUserWindow nextFenetre = new MainUserWindow();
            nextFenetre.Show();
            fenetre.Close();
        }
    }
}
