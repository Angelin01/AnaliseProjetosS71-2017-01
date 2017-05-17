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
    /// Interaction logic for DadosRelatorio.xaml
    /// </summary>
    public partial class DadosRelatorio : Window
    {
        public DadosRelatorio()
        {
            InitializeComponent();
        }

        private void Button_Confirma(object sender, RoutedEventArgs e)
        {

            Window main_window = new ConsultaRelatorio();
            App.Current.MainWindow = main_window;
            this.Close();
            App.Current.MainWindow.Show();
        }

        private void Button_Cancela(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
