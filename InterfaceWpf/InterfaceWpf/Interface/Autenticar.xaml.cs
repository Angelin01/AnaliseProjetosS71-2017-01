using InterfaceWpf.Class;
using InterfaceWpf.Entity;
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
			Funcionario usuario = new Funcionario(_login, _password);
			usuario.AutenticarUsuario();
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
