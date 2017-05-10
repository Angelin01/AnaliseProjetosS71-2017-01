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
    /// Interaction logic for ConsultaIngrediente.xaml
    /// </summary>
    public partial class ConsultaIngrediente : Window
    {
        public ConsultaIngrediente()
        {
            InitializeComponent();

			List<Ingrediente> items = new List<Ingrediente>();
			items.Add(new Ingrediente() { Nome = "Ingrediente Teste", Quantidade = 42, Fornecedor = "Thiago Bispo", Telefone = "(11) 99999-9999" });
			lvUsers.ItemsSource = items;
		}

        private void Button_Click(object sender, RoutedEventArgs e) {
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

		private void Button_Edit(object sender, RoutedEventArgs e)
		{
			Window main_window = new EditaIngrediente();
			App.Current.MainWindow = main_window;
			this.Close();
			App.Current.MainWindow.Show();
		}

		private void Button_Remove(object sender, RoutedEventArgs e)
		{
			MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Deseja realmente remover o produto?", "Confirmação", System.Windows.MessageBoxButton.YesNo);
			if (messageBoxResult == MessageBoxResult.No) return;
		}
	}

	public class Ingrediente
	{
		public string Nome { get; set; }
		public int Quantidade { get; set; }
		public string Fornecedor { get; set; }
		public string Telefone { get; set; }
	}
}
