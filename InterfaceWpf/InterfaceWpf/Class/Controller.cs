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
                login = _login;
                senha = _senha;
            }
        }

		public string Login { get => login; set => login = value; }
        public string Senha { get => senha; set => senha = value; }
        public bool Admin { get => admin; set => admin = value; }

        private string login;
        private string senha;
        private bool admin;
    }
}
