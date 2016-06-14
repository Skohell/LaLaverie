using LaLaverie.Model;
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


        private  ObservableCollection<BiereModel> _listeBiere;
        public  ObservableCollection<BiereModel> ListeBiere
        {
            get
            {
                return _listeBiere;
            }
            set
            {
                { _listeBiere = value; NotifyPropertyChanged("ListeBiere");}
            }
        }


        private  ObservableCollection<ClientModel> _listeClient;
        public  ObservableCollection<ClientModel> ListeClient
        {
            get
            {
                return _listeClient;
            }
            set
            {
                { _listeClient = value; NotifyPropertyChanged("ListeClient");}
            }
        }

        private  ObservableCollection<StockModel> _listeStock;
        public  ObservableCollection<StockModel> ListeStock
        {
            get
            {
                return _listeStock;
            }
            set
            {
                { _listeStock = value; NotifyPropertyChanged("ListeStock");}
            }
        }

        public MainWindowViewModel(MainWindow fenetre)
        {
            ListeClient = new ObservableCollection<ClientModel>()
            {
                new ClientModel("Gravallon","Guillaume",42,"rue du zouave","Clermont-Ferrand",63000,"guillaume.gravallon@gmail.com","guillaume",19),
                new ClientModel ("Rico","Sébastien",5,"rue du Mirondet","Aubière",63170,"rico.sebastien@gmail.com","sebastien",60)
            };

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
