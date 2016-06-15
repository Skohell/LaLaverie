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
    /// Interaction logic for ClientProduitWindow.xaml
    /// </summary>
    public partial class ClientProduitWindow : Window
    {
        private ClientProduitWindowViewModel _viewModel;
        public ClientProduitWindow(ClientModel client)
        {
            _viewModel = new ClientProduitWindowViewModel(client,this);
            InitializeComponent();
            DataContext = _viewModel;
        }
    }
}
