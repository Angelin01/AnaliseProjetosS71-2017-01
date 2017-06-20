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

		public void FiltrarLista()
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

				cmd.CommandText = "SELECT nome, nome_da_mae, nome_do_pai, cpf, rg, ctps, endereco, telefone, telefone_cel, email, email_alt, login, senha, salario, cargo FROM Funcionario WHERE 1";
				cmd.Prepare();
				if (!String.IsNullOrEmpty(txtFiltroCPF.Text)) {
					cmd.CommandText += " AND cpf=@cpf";
					cmd.Parameters.AddWithValue("@cpf", txtFiltroCPF.Text);
				}
				if (!String.IsNullOrEmpty(txtFiltroCTPS.Text)) {
					cmd.CommandText += " AND ctps=@ctps";
					cmd.Parameters.AddWithValue("@ctps", txtFiltroCTPS.Text);
				}
				if (!String.IsNullOrEmpty(txtFiltroLogin.Text)) {
					cmd.CommandText += " AND login=@login";
					cmd.Parameters.AddWithValue("@login", txtFiltroLogin.Text);
				}
				if (!String.IsNullOrEmpty(txtFiltroNome.Text)) {
					cmd.CommandText += " AND nome=@nome";
					cmd.Parameters.AddWithValue("@nome", txtFiltroNome.Text);
				}
				if (!String.IsNullOrEmpty(txtFiltroRG.Text)) {
					cmd.CommandText += " AND rg=@rg";
					cmd.Parameters.AddWithValue("@rg", txtFiltroRG.Text);
				}

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
            MessageBoxResult messageBoxResult = InterfaceAdministrador.MostrarJanelaDeletarFuncionario();
			if (messageBoxResult == MessageBoxResult.No) return;

			Button button = sender as Button;
			string cpf = button.Tag.ToString();

			Funcionario f = new Funcionario(null, null, null, cpf, null, null, null, null, null, null, null, null, null, 0, null);
			if (!f.DeletarDadosFuncionario()) {
				MessageBox.Show("Não foi possível remover o funcionário do sistema.", "Erro");
				return;
			}

			lvUsers.Items.Clear();
			AtualizarLista();
		}

		private void Button_Edit(object sender, RoutedEventArgs e)
        {
			Button button = sender as Button;
			string cpf = button.Tag.ToString();

            InterfaceAdministrador.MostrarJanelaEditarFuncionario(cpf);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            Controller user = Controller.Instance;

            if (user.Admin)
            { // Deveria ser se entrou nessa janela, mas por garantia neh...
                InterfaceAdministrador.MostrarJanelaOpcoes();
            }
            else
            {
                InterfaceFuncionario.MostrarJanelaOpcoes();
            }
        }

        private void lvUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Filtro(object sender, RoutedEventArgs e)
        {
			lvUsers.Items.Clear();
			FiltrarLista();
			MessageBox.Show("Resultados filtrados.", "Sucesso!");
        }
    }
}
