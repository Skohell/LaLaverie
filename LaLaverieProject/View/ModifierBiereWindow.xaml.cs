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
