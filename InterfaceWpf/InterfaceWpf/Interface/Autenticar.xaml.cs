﻿using InterfaceWpf.Class;
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
    /// Lógica interna para Autenticar.xaml
    /// </summary>
    public partial class Autenticar : Window
    {
        public Autenticar()
        {
            InitializeComponent();
			input_login.Focus();
        }

        private void AutenticarUsuario(object sender, RoutedEventArgs e)
		{ 
            // Pegar as informações dos inputs (textbox)
            String _login = input_login.Text.ToString();
            String _password = input_password.Password.ToString();

            Controller user = Controller.Instance;

            // Tentar logar
            user.AutenticarUsuario(_login, _password);

            // Ver se logou
            if (user.Login == null || user.Login == "")
                return; // Sair se não deu


            // Trocar para aplicação
            Window main_window;

            if (user.Login == "admin")
                main_window = new InicioAdministracao();
            else
                main_window = new InicioFuncionario();
            
            App.Current.MainWindow = main_window;
            this.Close();
            App.Current.MainWindow.Show();
        }

		private void AutenticarEnter(object sender, KeyEventArgs e)
		{
			if(e.Key == Key.Return) {
				AutenticarUsuario(null, null);
				e.Handled = true;
			}
		}

    }
}
