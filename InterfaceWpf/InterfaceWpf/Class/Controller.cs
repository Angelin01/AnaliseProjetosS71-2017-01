using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (_login == null || _senha == null)
                return;

            login = _login;
            senha = _senha;
        }

        public string Login { get => login; set => login = value; }
        public string Senha { get => senha; set => senha = value; }

        private String login;
        private String senha;
    }
}
