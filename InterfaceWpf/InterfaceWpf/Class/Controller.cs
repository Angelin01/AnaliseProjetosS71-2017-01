using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using InterfaceWpf.Interface;
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
                if(_login == "admin" && _senha == "admin")
                {
                    login = "admin";
                    admin = true;
                    if (admin)
                    {
                        InterfaceAdministrador.MostrarJanelaOpcoes();
                    }
                    else
                    {
                        InterfaceFuncionario.MostrarJanelaOpcoes();
                    }
                    return;
                }

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

                    cmd.CommandText = "SELECT login, cargo, senha FROM Funcionario WHERE login=@login";
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@login", _login);

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

					string temp_login = null;
					bool temp_admin = false;
					string hash_senha = null;

                    if(reader.Read())
                    {
						temp_login = reader.GetString(0);
						temp_admin = (reader.GetString(1) == "Administrador" ? true : false);
						hash_senha = reader.GetString(2);
                    }

                    conn.Close();

                    if(hash_senha == null || !SecurePasswordHasher.Verify(_senha, hash_senha))
                    {
                        MessageBox.Show("Login ou senha inválido(s).", "Falha no login");
                    }
                    else
                    {
						login = temp_login;
						admin = temp_admin;

                        if (admin) {
                            InterfaceAdministrador.MostrarJanelaOpcoes();
                        }
                        else {
                            InterfaceFuncionario.MostrarJanelaOpcoes();
                        }
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
