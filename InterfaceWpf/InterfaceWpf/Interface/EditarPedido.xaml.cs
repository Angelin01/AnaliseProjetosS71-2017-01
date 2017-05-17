using InterfaceWpf.Class;
using InterfaceWpf.Interface;
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

namespace InterfaceWpf
{
    /// <summary>
    /// Interaction logic for EditarPedido.xaml
    /// </summary>
    public partial class EditarPedido : Window
    {
        public EditarPedido()
        {
            InitializeComponent();
        }
        private void Button_Cancela(object sender, RoutedEventArgs e) {
            App.Current.MainWindow = new ConsultaPedido();
            this.Close();
            App.Current.MainWindow.Show();
        }
        private void Button_AdicionaProd(object sender, RoutedEventArgs e)
        {
            // Abrir um popup
            Window main_window = new AdicionaProdutoPedido();
            main_window.Show();
        }

        private void Button_RemoveProd(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Deseja remover o produto do pedido?", "Confirmação", System.Windows.MessageBoxButton.YesNo);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                // Remover produto da lista
            }
        }

        private void Button_EditaQuant(object sender, RoutedEventArgs e)
        {
            // Abrir um popup
            Window main_window = new EditaQuantidadePedido();
            main_window.Show();
        }

        private void Button_Finaliza(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Deseja confirmar as alterações do pedido?", "Confirmação", System.Windows.MessageBoxButton.YesNo);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                Controller user = Controller.Instance;

                Window main_window;
                if (user.Login == "admin")
                {
                    main_window = new InicioAdministracao();
                }
                else
                {
                    main_window = new InicioFuncionario();
                }
                App.Current.MainWindow = main_window;
                this.Close();
                App.Current.MainWindow.Show();
            }

        }

        private void examList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
