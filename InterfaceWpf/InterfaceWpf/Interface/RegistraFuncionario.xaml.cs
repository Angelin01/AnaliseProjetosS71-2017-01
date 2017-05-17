﻿using InterfaceWpf.Class;
using InterfaceWpf.Interface;
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
    /// Interaction logic for RegistraFuncionario.xaml
    /// </summary>
    public partial class RegistraFuncionario : Window
    {
        public RegistraFuncionario()
        {
            InitializeComponent();
        }
        private void Button_Cancela(object sender, RoutedEventArgs e) {
            Controller user = Controller.Instance;

            Window main_window;
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
        private void TextBox_Nome(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_Endereco(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_Email(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_EmailA(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_rg(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_Cpf(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_Telefone(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TelefoneCel(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_ctps(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_nomeDoPai(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_NomeDaMae(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_Login(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_Senha(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_Salario(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboBoxItem_Funcionario(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBoxItem_Admin(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
			MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Confirma os dados inseridos?", "Confirmação", System.Windows.MessageBoxButton.YesNo);
			if (messageBoxResult == MessageBoxResult.Yes) {
				Controller user = Controller.Instance;

				Window main_window;
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
}
