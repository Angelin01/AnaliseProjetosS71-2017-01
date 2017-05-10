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
        }

        private void AutenticarUsuario(object sender, RoutedEventArgs e)
        {
            // Pegar as informações dos inputs (textbox)
            String _login = input_login.Text.ToString();
            String _password = input_password.Text.ToString();

            // Checar se login é válido
            if ((_login == "") || (_password == ""))
                return;

            AutenticarSingleton user = AutenticarSingleton.Instance;

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
    }
}
