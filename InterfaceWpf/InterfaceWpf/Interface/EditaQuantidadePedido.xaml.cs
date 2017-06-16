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
    /// Interaction logic for EditaQuantidadePedido.xaml
    /// </summary>
    public partial class EditaQuantidadePedido : Window
    {
        public EditaQuantidadePedido()
        {
            InitializeComponent();
        }
        private void Button_Cancela(object sender, RoutedEventArgs e) {
            //Controller user = Controller.Instance;

            //Window main_window;
            //if (user.Login == "admin") {
            //    main_window = new InicioAdministracao();
            //}
            //else {
            //    main_window = new InicioFuncionario();
            //}
            //App.Current.MainWindow = main_window;
            this.Close();
            //App.Current.MainWindow.Show();
        }
        private void Button_Confirma(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Deseja confirmar as alterações do produto?", "Confirmação", System.Windows.MessageBoxButton.YesNo);

            string mudanca = String.IsNullOrEmpty(txtNovaQnt.Text) ? "Nada foi atualizado" : "Quantidade atualizada";

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                // Salva alteração

                MessageBox.Show(mudanca, "Edição confirmada");

                this.Close();
            }
        }
    }
}
