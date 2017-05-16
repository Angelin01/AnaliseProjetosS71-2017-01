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
            Controller user = Controller.Instance;

            Window main_window;
            if (user.Login == "admin") {
                main_window = new InicioAdministracao();
            }
            else {
                main_window = new InicioFuncionario();
            }
            App.Current.MainWindow = main_window;
            this.Close();
            App.Current.MainWindow.Show();
        }
        private void Button_AdicionaProd(object sender, RoutedEventArgs e)
        {

        }

        private void Button_RemoveProd(object sender, RoutedEventArgs e)
        {

        }

        private void Button_EditaQuant(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Finaliza(object sender, RoutedEventArgs e)
        {

        }

        private void examList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
