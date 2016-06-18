using LaLaverieProject.ViewModel;
using System.Windows;

namespace LaLaverieProject.View
{

    public partial class MainUserWindow : Window
    {
        private MainUserWindowViewModel _viewModel;

        public MainUserWindow()
        {
            InitializeComponent();
            _viewModel = new MainUserWindowViewModel(this);
            DataContext = _viewModel;
        }
    }
}
