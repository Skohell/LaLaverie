using LaLaverie.Model;
using LaLaverieProject.ViewModel;
using System;
using System.Collections.Generic;
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

        public ModifierBiereWindow(BiereModel biere)
        {
            _viewModel = new ModifierBiereWindowViewModel( biere,this);
            InitializeComponent();
            DataContext = _viewModel;
        }
    }
}
