using LaLaverie.Model;
using LaLaverieProject.ViewModel;
using System.Windows;

namespace LaLaverieProject.View
{
    /// <summary>
    /// Interaction logic for RecetteWindow.xaml
    /// </summary>
    public partial class RecetteWindow : Window
    {
        private RecetteWindowViewModel _viewModel;

        public RecetteWindow(BiereModel b)
        {
            InitializeComponent();

            _viewModel = new RecetteWindowViewModel(b);
            DataContext = _viewModel;

        }
    }
}
