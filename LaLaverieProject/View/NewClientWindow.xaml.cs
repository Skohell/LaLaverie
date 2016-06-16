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
