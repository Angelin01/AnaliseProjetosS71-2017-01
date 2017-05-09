using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceWpf.Class
{
    public class AutenticarSingleton
    {
        private static AutenticarSingleton instance;

        private AutenticarSingleton() { }

        public static AutenticarSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AutenticarSingleton();
                }
                return instance;
            }
        }

        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }

        private String login;
        private String password;
    }
}