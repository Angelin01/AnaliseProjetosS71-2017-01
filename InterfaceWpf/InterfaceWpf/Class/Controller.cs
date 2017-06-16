using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InterfaceWpf.Class
{
    class Controller
    {
        private static Controller instance;

        private Controller()
        {
            login = null;
            senha = null;
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

        private string login;
        private string senha;
    }
}
