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
    /// Interaction logic for AdicionaIngrediente.xaml
    /// </summary>
    public partial class AdicionaIngrediente : Window
    {
        public AdicionaIngrediente()
        {
            InitializeComponent();
        }

        private void Button_Confirma(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Cancela(object sender, RoutedEventArgs e)
        {

            this.Close();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
