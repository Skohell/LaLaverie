using LaLaverie.Model;
using LaLaverieProject.ViewModel;
using System.Collections.ObjectModel;
using System.Windows;

namespace LaLaverieProject.View
{
    /// <summary>
    /// Interaction logic for ClientProduitWindow.xaml
    /// </summary>
    public partial class ClientProduitWindow : Window
    {
        private ClientProduitWindowViewModel _viewModel;

        public ClientProduitWindow(ClientModel client, ObservableCollection<ClientModel> ListeClient)
        {
            _viewModel = new ClientProduitWindowViewModel(client,this, ListeClient);
            InitializeComponent();
            DataContext = _viewModel;
        }
    }
}
