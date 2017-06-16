using InterfaceWpf.Class;
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

namespace InterfaceWpf.Interface
{
    /// <summary>
    /// Lógica interna para InicioFuncionario.xaml
    /// </summary>
    public partial class InicioFuncionario : Window
    {
        public InicioFuncionario()
        {
            InitializeComponent();
        }

        private void RegistrarPedido(object sender, RoutedEventArgs e)
        {
            Window main_window = new RegistraPedido();
            App.Current.MainWindow = main_window;
            this.Close();
            App.Current.MainWindow.Show();
        }

        private void ConsultarPedidos(object sender, RoutedEventArgs e)
        {
            Window main_window = new ConsultaPedido();
            App.Current.MainWindow = main_window;
            this.Close();
            App.Current.MainWindow.Show();
        }

        bool _shown;

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);

            if (_shown)
                return;

            _shown = true;
            Controller user = Controller.Instance;
            // Your code here.
            BannerBemVindo.Content = user.Login;
        }
    }
}
