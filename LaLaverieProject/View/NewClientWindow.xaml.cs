using LaLaverie.Model;
using LaLaverieProject.ViewModel;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace LaLaverieProject.View
{
    /// <summary>
    /// Interaction logic for NewClientWindow.xaml
    /// </summary>
    public partial class NewClientWindow : Window
    {
        private NewClientWindowViewModel _viewModel;

        ScrollViewer viewer;

        public NewClientWindow(ObservableCollection<ClientModel> ListeClient)
        {
            _viewModel = new NewClientWindowViewModel(ListeClient, this);
            InitializeComponent();
            DataContext = _viewModel;

            viewer = new ScrollViewer();
            viewer.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
        }
    }
}
