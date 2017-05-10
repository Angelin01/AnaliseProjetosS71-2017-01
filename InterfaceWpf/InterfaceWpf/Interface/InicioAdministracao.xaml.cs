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

        private void RegistrarFuncionario(object sender, RoutedEventArgs e)
        {
            //Window main_window = new RegistraFuncionario();
            //App.Current.MainWindow = main_window;
            //this.Close();
            //App.Current.MainWindow.Show();
        }

        private void ConsultarFuncionarios(object sender, RoutedEventArgs e)
        {
            Window main_window = new ConsultaFuncionario();
            App.Current.MainWindow = main_window;
            this.Close();
            App.Current.MainWindow.Show();
        }

        private void RegistrarProduto(object sender, RoutedEventArgs e)
        {

        }

        private void ConsultarProdutos(object sender, RoutedEventArgs e)
        {

        }

        private void RegistrarIngrediente(object sender, RoutedEventArgs e)
        {

        }

        private void ConsultarIngredientes(object sender, RoutedEventArgs e)
        {

        }

        private void AdicionarTransacao(object sender, RoutedEventArgs e)
        {

        }

        private void ConsultaRelatorio(object sender, RoutedEventArgs e)
        {

        }
    }
}
