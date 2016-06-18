using LaLaverie.Model;
using LaLaverieProject.ViewModel;
using System.Collections.ObjectModel;
using System.Windows;

namespace LaLaverieProject.View
{
    /// <summary>
    /// Logique d'interaction pour ModifierBiereWindow.xaml
    /// </summary>
    public partial class ModifierBiereWindow : Window
    {
        private ModifierBiereWindowViewModel _viewModel;

        public ModifierBiereWindow(BiereModel biere, ObservableCollection<string> ListeCategorie)
        {
            _viewModel = new ModifierBiereWindowViewModel( biere,this,ListeCategorie);
            InitializeComponent();
            DataContext = _viewModel;
        }
    }
}
