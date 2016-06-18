using LaLaverie.Model;
using LaLaverieProject.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace LaLaverieProject.View
{
    /// <summary>
    /// Logique d'interaction pour ClientProfilWindow.xaml
    /// </summary>
    public partial class ClientProfilWindow : Window
    {
        private ClientProfilWindowViewModel _viewModel;

        ScrollViewer viewer;

        public ClientProfilWindow(ClientModel c)
        {
            _viewModel = new ClientProfilWindowViewModel(c,this);
            InitializeComponent();
            DataContext = _viewModel;

            viewer = new ScrollViewer();
            viewer.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
        }
    }
}
