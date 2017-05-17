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
    /// Interaction logic for ConsultaPedido.xaml
    /// </summary>
    public partial class ConsultaPedido : Window
    {
        public ConsultaPedido()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
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

		private void Button_Edit(object sender, RoutedEventArgs e)
		{
			Window main_window = new EditarPedido();
			App.Current.MainWindow = main_window;
			this.Close();
			App.Current.MainWindow.Show();
		}

		private void Button_Cancel(object sender, RoutedEventArgs e)
		{
			MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Deseja cancelar o pedido?", "Confirmação", System.Windows.MessageBoxButton.YesNo);
			if (messageBoxResult == MessageBoxResult.No) return;
		}

		private void Button_Finish(object sender, RoutedEventArgs e)
		{
			MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Deseja encerrar o pedido?", "Confirmação", System.Windows.MessageBoxButton.YesNo);
			if (messageBoxResult == MessageBoxResult.No) return;
		}

        private void Button_Filtro(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Resultados filtrados.", "Sucesso!");
        }

        private void ComboBoxItem_Encerrado(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBoxItem_Andamento(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBoxItem_Cancelado(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
