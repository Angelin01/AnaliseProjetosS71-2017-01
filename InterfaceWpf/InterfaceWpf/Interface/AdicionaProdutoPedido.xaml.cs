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
    /// Interaction logic for AdicionaProdutoPedido.xaml
    /// </summary>
    public partial class AdicionaProdutoPedido : Window
    {
        public AdicionaProdutoPedido()
        {
            InitializeComponent();
        }

        private void Button_Confirma(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Deseja confirmar o produto?", "Confirmação", System.Windows.MessageBoxButton.YesNo);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                if (String.IsNullOrEmpty(txtNovaQnt.Text) || String.IsNullOrEmpty(comboProduto.Text))
                {
                    MessageBox.Show("Há campo(s) vazio(s)", "Erro");
                    return;
                }

                MessageBox.Show("Produto adicionado.", "Sucesso!");

                this.Close();
            }

            this.Close();
		}

        private void Button_Cancela(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ComboBoxItem_Espresso(object sender, RoutedEventArgs e)
        {

        }
        

        private void ComboBoxItem_Macchiatto(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
