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

		public string Login { get => login; set => login = value; }
        public bool Admin { get => admin; set => admin = value; }

        public void MostrarJanelaOpcoes()
        {
            if (Admin)
                InterfaceAdministrador.MostrarJanelaOpcoes();
            else
                InterfaceFuncionario.MostrarJanelaOpcoes();
        }

        private string login;
        private bool admin;
    }
}
