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
    /// Interaction logic for InicioAdministracao.xaml
    /// </summary>
    public partial class InicioAdministracao : Window
    {
        public InicioAdministracao()
        {
            InitializeComponent();
        }

        private void RegistrarPedido(object sender, RoutedEventArgs e)
        {
            InterfaceFuncionario.MostrarJanelaRegistrarPedido();
        }

        private void ConsultarPedidos(object sender, RoutedEventArgs e)
        {
            InterfaceFuncionario.MostrarJanelaConsultarPedido();
        }

        private void RegistrarFuncionario(object sender, RoutedEventArgs e)
        {
            InterfaceAdministrador.MostrarJanelaCadastroFuncionario();
        }

        private void ConsultarFuncionarios(object sender, RoutedEventArgs e)
        {
            InterfaceAdministrador.MostrarJanelaConsultarFuncionario();
        }

        private void RegistrarProduto(object sender, RoutedEventArgs e)
        {
            InterfaceAdministrador.MostrarJanelaRegistrarProduto();
        }

        private void ConsultarProdutos(object sender, RoutedEventArgs e)
        {
            InterfaceAdministrador.MostrarJanelaConsultarProduto();
        }

        private void RegistrarIngrediente(object sender, RoutedEventArgs e)
        {
            InterfaceAdministrador.MostrarJanelaRegistrarRecurso();
        }

        private void ConsultarIngredientes(object sender, RoutedEventArgs e)
        {
            InterfaceAdministrador.MostrarJanelaConsultarRecurso();
        }

        private void AdicionarTransacao(object sender, RoutedEventArgs e)
        {
            Window main_window = new AdicionaTransacao();
            App.Current.MainWindow = main_window;
            //this.Close();
            App.Current.MainWindow.Show();
        }

        private void ConsultaRelatorio(object sender, RoutedEventArgs e)
        {
            Window main_window = new DadosRelatorio();
            App.Current.MainWindow = main_window;
            //this.Close();
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
