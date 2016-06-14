using LaLaverie.Model;
using LaLaverieProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LaLaverieProject.View
{
    /// <summary>
    /// Interaction logic for MainConnexionWindow.xaml
    /// </summary>
    public partial class MainConnexionWindow : Window
    {
        private MainConnexionWindowViewModel _viewModel;
       

        public MainConnexionWindow(ObservableCollection<ClientModel> ListeClient)
        {
            _viewModel = new MainConnexionWindowViewModel(ListeClient,this);
            InitializeComponent();
            DataContext = _viewModel;
        }
    }
}
