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
