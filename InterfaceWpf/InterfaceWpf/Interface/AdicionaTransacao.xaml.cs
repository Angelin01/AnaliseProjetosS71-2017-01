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
    /// Interaction logic for Adiciona_Transação.xaml
    /// </summary>
    public partial class AdicionaTransacao : Window
    {
        public AdicionaTransacao()
        {
            InitializeComponent();
        }

		private void Button_Confirma(object sender, RoutedEventArgs e)
        {
			if(!String.IsNullOrEmpty(txt_valor.Text)) {
				MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Confirma os dados inseridos?", "Confirmação", System.Windows.MessageBoxButton.YesNo);
				if (messageBoxResult == MessageBoxResult.Yes) {
					Controller user = Controller.Instance;
                    /*
					Window main_window;
					if (user.Login == "admin") {
						main_window = new InicioAdministracao();
					}
					else {
						main_window = new InicioFuncionario();
					}
					App.Current.MainWindow = main_window;
					*/
                    this.Close();
					//App.Current.MainWindow.Show();
				}
			}
			else {
				MessageBox.Show("O campo \"Valor\" deve estar preenchido.", "Erro");
			}
		}

        private void Button_Cancela(object sender, RoutedEventArgs e) {
            Controller user = Controller.Instance;
            /*
            Window main_window;
            if (user.Login == "admin") {
                main_window = new InicioAdministracao();
            }
            else {
                main_window = new InicioFuncionario();
            }
            App.Current.MainWindow = main_window;
            */
            this.Close();
            //App.Current.MainWindow.Show();
        }
    }
}
