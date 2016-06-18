using LaLaverie.Model;
using LaLaverieProject.ViewModel;
using System.Collections.ObjectModel;
using System.Windows;

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
