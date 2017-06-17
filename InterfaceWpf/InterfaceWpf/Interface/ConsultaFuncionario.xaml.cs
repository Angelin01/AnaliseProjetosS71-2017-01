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
    /// Interaction logic for ConsultaFuncionario.xaml
    /// </summary>
    public partial class ConsultaFuncionario : Window
    {
        public ConsultaFuncionario()
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

				cmd.CommandText = "SELECT nome, nome_da_mae, nome_do_pai, cpf, rg, ctps, endereco, telefone, telefone_cel, email, email_alt, login, senha, salario, cargo FROM Funcionario";

				MySqlDataReader reader;
				try {
					reader = cmd.ExecuteReader();
				}
				catch (MySqlException ex) {
					// Query falhou.
					return;
				}

				while (reader.Read()) {
					Funcionario f = new Funcionario(
						reader.GetString(0),
						reader.GetString(1),
						reader.GetString(2),
						reader.GetString(3),
						reader.GetString(4),
						reader.GetString(5),
						reader.GetString(6),
						reader.GetString(7),
						reader.GetString(8),
						reader.GetString(9),
						reader.GetString(10),
						reader.GetString(11),
						reader.GetString(12),
						reader.GetInt32(13),
						reader.GetString(14)
						);
					lvUsers.Items.Add(f);
				}

				conn.Close();
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

		private void Button_Remove(object sender, RoutedEventArgs e)
		{
			MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Deseja realmente remover o Funcionário?", "Confirmação", System.Windows.MessageBoxButton.YesNo);
			if (messageBoxResult == MessageBoxResult.No) return;
			else {
				Button button = sender as Button;
				string cpf = button.Tag.ToString();

				Funcionario f = new Funcionario(null, null, null, cpf, null, null, null, null, null, null, null, null, null, 0, null);
				f.DeletarDadosFuncionario();

				lvUsers.Items.Clear();
				AtualizarLista();
			}
		}

		private void Button_Edit(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow = new EditaFuncionario();
            this.Close();
            App.Current.MainWindow.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
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

        private void lvUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Filtro(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Resultados filtrados.", "Sucesso!");
        }
    }
}
