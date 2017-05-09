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

            // Fazer login (trocar tela)
            Window login_window = new Autenticar();
            this.Hide();
            login_window.Show();
        }

        private void RegistrarPedido(object sender, RoutedEventArgs e)
        {

        }

        private void ConsultarPedidos(object sender, RoutedEventArgs e)
        {

        }

        bool _shown;

        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);

            if (_shown)
                return;

            _shown = true;
            AutenticarSingleton user = AutenticarSingleton.Instance;
            // Your code here.
            BannerBemVindo.Content = user.Login;
        }
    }
}
