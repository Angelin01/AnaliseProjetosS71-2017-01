using InterfaceWpf.Class;
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
        String login;
        String password;

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

			// Checar se login é válido
			if ((_login == "") || (_password == "")) {
				MessageBox.Show("Login ou senha inválidos.", "Falha no login");
				return;
			}

            Controller user = Controller.Instance;

            user.Login = _login;
            user.Password = _password;

            Window main_window;
            // Fazer login (trocar tela)
            if (user.Login == "admin") {
                main_window = new InicioAdministracao();
            }
            else {
                main_window = new InicioFuncionario();
            }
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
