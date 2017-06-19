using InterfaceWpf.Class;
using InterfaceWpf.Entity;
using MySql.Data.MySqlClient;
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
			AtualizarLista();
		}

		public void AtualizarLista()
		{
			using (MySqlConnection conn = new MySqlConnection(Controller.Instance.connStr)) {
				try {
					conn.Open();
				}
				catch (MySqlException ex) {
					// Conexão com o banco de dados falhou.
					// Possíveis razões: Fora do ar, ou usuário/senha incorretos
					//MessageBox.Show(ex.Message);
					return;
				}

				MySqlCommand cmd = new MySqlCommand();
				cmd.Connection = conn;

				cmd.CommandText = "SELECT id, nome, quantidade, nome_fornecedor, telefone_fornecedor FROM Recurso";

				MySqlDataReader reader;
				try {
					reader = cmd.ExecuteReader();
				}
				catch (MySqlException ex) {
					// Query falhou.
					return;
				}

				while (reader.Read()) {
					Recurso r = new Recurso(
						reader.GetInt32(0),
						reader.GetString(1),
						reader.GetFloat(2),
						reader.GetString(3),
						reader.GetString(4)
						);
					lvUsers.Items.Add(r);
				}

				conn.Close();
			}
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
			Window main_window = new EditaIngrediente();
			App.Current.MainWindow = main_window;
			this.Close();
			App.Current.MainWindow.Show();
		}

		private void Button_Remove(object sender, RoutedEventArgs e)
		{
			MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Deseja realmente remover o produto?", "Confirmação", System.Windows.MessageBoxButton.YesNo);
			if (messageBoxResult == MessageBoxResult.No) return;

			Button button = sender as Button;
			int id = Convert.ToInt32(button.Tag.ToString());

			Recurso r = new Recurso(id, null, 0, null, null);
			if (!r.DeletarRecurso()) {
				MessageBox.Show("Não foi possível remover o recurso do sistema.", "Erro");
				return;
			}

			lvUsers.Items.Clear();
			AtualizarLista();
		}

        private void Button_Filtro(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Resultados filtrados.", "Sucesso!");
        }
    }
}
