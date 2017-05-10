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
    /// Interaction logic for ConsultaProduto.xaml
    /// </summary>
    public partial class ConsultaProduto : Window
    {
        public ConsultaProduto()
        {
            InitializeComponent();

			List<Produto> items = new List<Produto>();
			items.Add(new Produto() { Nome = "Produto Teste", PReco = 42, Ingredientes = "Ingredientes de teste" });
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
			App.Current.MainWindow = new EditaProduto();
			this.Close();
			App.Current.MainWindow.Show();
		}
    }

	// Temporário
	public class Produto
	{
		public string Nome { get; set; }
		public int PReco { get; set; }
		public string Ingredientes { get; set; }
	}
}
