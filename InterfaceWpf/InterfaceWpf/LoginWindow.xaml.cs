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

namespace InterfaceWpf
{
    /// <summary>
    /// Lógica interna para LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void AutenticarUsuario(object sender, RoutedEventArgs e)
        {
            // Pegar as informações dos inputs (textbox)
            String login = input_login.Text.ToString();
            String password = input_password.Text.ToString();

            // Checar se login é válido
            if ((login != "Wirow") || (password != "Barow"))
                return;

            // Fazer login (trocar tela)
            Window main_window = new MainWindow();
            App.Current.MainWindow = main_window;
            this.Close();
            main_window.Show();
        }
    }
}
