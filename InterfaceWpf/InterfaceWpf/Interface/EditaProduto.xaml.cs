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
    /// Interaction logic for EditaProduto.xaml
    /// </summary>
    public partial class EditaProduto : Window
    {
        public EditaProduto()
        {
            InitializeComponent();

			List<IngrProduto> items = new List<IngrProduto>();
			items.Add(new IngrProduto() { Ingrediente = "Ingredientes de teste", Quantidade = 14});
			examList.ItemsSource = items;
		}

        private void Button_Cancela(object sender, RoutedEventArgs e) {
            AutenticarSingleton user = AutenticarSingleton.Instance;

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
        private void Button_AdicionaIngrediente(object sender, RoutedEventArgs e)
        {

		}

        private void Button_Finaliza(object sender, RoutedEventArgs e)
        {
			MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Deseja confirmar a edição?", "Confirmação", System.Windows.MessageBoxButton.YesNo);
			if (messageBoxResult == MessageBoxResult.No) return;

			App.Current.MainWindow = new ConsultaProduto();
			this.Close();
			App.Current.MainWindow.Show();
		}

        private void examList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

	public class IngrProduto
	{
		public string Ingrediente { get; set; }
		public int Quantidade { get; set; }
	}
}
