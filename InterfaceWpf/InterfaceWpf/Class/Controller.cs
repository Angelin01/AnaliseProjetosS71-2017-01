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
			connStr = "server=127.0.0.1;uid=root;pwd=;database=Cafeteria;";
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
                using (MySqlConnection conn = new MySqlConnection(Controller.Instance.connStr))
                {
                    try
                    {
                        conn.Open();
                    }
                    catch (MySqlException ex)
                    {
                        // Conexão com o banco de dados falhou.
                        // Possíveis razões: Fora do ar, ou usuário/senha incorretos
                        //MessageBox.Show(ex.Message);
                        MessageBox.Show("Sem conexão com banco.", "Falha no login");
                        return;
                    }

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;

                    cmd.CommandText = "SELECT login, cargo FROM Funcionario WHERE login LIKE @login AND senha LIKE @senha";
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@login", _login);
                    cmd.Parameters.AddWithValue("@senha", SecurePasswordHasher.Hash(_senha));
                    MySqlDataReader reader;
                    try
                    {
                        reader = cmd.ExecuteReader();
                    }
                    catch (MySqlException ex)
                    {
                        // Query falhou.
                        MessageBox.Show("Falha na autenticação.", "Falha no login");
                        return;
                    }

                    while (reader.Read())
                    {
                        login = reader.GetString(0);
                        
                        admin = ( reader.GetString(1) == "Administrador" ? true : false );
                    }

                    conn.Close();

                    if(login == null)
                    {
                        MessageBox.Show("Login ou senha inválido(s).", "Falha no login");
                    }
                    else
                    {
                        InterfaceFuncionario.MostrarJanelaOpcoes();
                    }
                }
            }
        }

		public string Login { get => login; set => login = value; }
        public bool Admin { get => admin; set => admin = value; }

        private string login;
        private bool admin;
    }
}
