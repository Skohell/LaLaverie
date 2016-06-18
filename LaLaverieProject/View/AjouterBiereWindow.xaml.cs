using LaLaverieProject.ViewModel;
using System.Collections.ObjectModel;
using System.Windows;

namespace LaLaverieProject.View
{
    /// <summary>
    /// Logique d'interaction pour AjouterBiereWindow.xaml
    /// </summary>
    public partial class AjouterBiereWindow : Window
    {
        public AjouterBiereWindowViewModel ViewModel;

        public AjouterBiereWindow(ObservableCollection<string> ListeCategorie)
        {
            ViewModel = new AjouterBiereWindowViewModel(this,ListeCategorie);
            InitializeComponent();
            DataContext = ViewModel;
        }
    }
}
