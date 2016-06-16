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
