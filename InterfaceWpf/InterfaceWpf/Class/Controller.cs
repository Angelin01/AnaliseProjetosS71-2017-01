using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
using InterfaceWpf.Entity;

namespace InterfaceWpf.Class
{
    class Controller
    {
        private static Controller instance;
		public string connStr;

		private Controller()
        {
            login = null;
            senha = null;

			connStr = "server=127.0.0.1;uid=root;pwd=;database=TesteCSharp;";
		}

        public static Controller Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Controller();
                }
                return instance;
            }
        }

        public void AutenticarUsuario (string _login, string _senha)
        {
            string _error;

            if (_login == null || _login == "")
            {
                _error = "Login em branco";

                if (_senha == null || _senha == "")
                    _error = "Login e Senha em branco";
            }
            else if (_senha == null || _senha == "")
            {
                _error = "Senha em branco";
            }
            else
            {
                _error = "Nada";
            }


            if (_error != "Nada")
            {
                MessageBox.Show(_error, "Falha no login");
            }
            else
            {
                login = _login;
                senha = _senha;
            }
        }

		public bool CadastrarFuncionario(ref Funcionario f)
		{
			using (MySqlConnection conn = new MySqlConnection(connStr)) {
				try {
					conn.Open();
				}
				catch (MySqlException ex) {
					// Conexão com o banco de dados falhou.
					// Possíveis razões: Fora do ar, ou usuário/senha incorretos
					MessageBox.Show(ex.Message);
					return false;
				}

				MySqlCommand cmd = new MySqlCommand();
				cmd.Connection = conn;

				cmd.CommandText = "INSERT INTO Funcionario VALUES (@cpf, @nome, @nomemae, @nomepai, @rg, @ctps, @ender, @tel, @cel, @email, @emailalt, @login, @senha, @salario, @cargo)";
				cmd.Prepare();
				cmd.Parameters.AddWithValue("@cpf", f.Cpf);
				cmd.Parameters.AddWithValue("@nome", f.Nome);
				cmd.Parameters.AddWithValue("@nomemae", f.NomeMae);
				cmd.Parameters.AddWithValue("@nomepai", f.NomePai);
				cmd.Parameters.AddWithValue("@rg", f.Rg);
				cmd.Parameters.AddWithValue("@ctps", f.Ctps);
				cmd.Parameters.AddWithValue("@ender", f.Endereco);
				cmd.Parameters.AddWithValue("@tel", f.TelefonePrincipal);
				cmd.Parameters.AddWithValue("@cel", f.TelefoneCelular);
				cmd.Parameters.AddWithValue("@email", f.EmailPrincipal);
				cmd.Parameters.AddWithValue("@emailalt", f.EmailAlternativo);
				cmd.Parameters.AddWithValue("@login", f.Login);
				cmd.Parameters.AddWithValue("@senha", f.Senha);
				cmd.Parameters.AddWithValue("@salario", f.Salario);
				cmd.Parameters.AddWithValue("@cargo", f.Cargo);

				try {
					cmd.ExecuteNonQuery();
				}
				catch (MySqlException ex) {
					// Query falhou.
					// Possível razão: chave primária já existe.
					MessageBox.Show(ex.Message);
					return false;
				}

				conn.Close();
			}
			return true;
		}

		public string Login { get => login; set => login = value; }
        public string Senha { get => senha; set => senha = value; }

        private string login;
        private string senha;
    }
}
