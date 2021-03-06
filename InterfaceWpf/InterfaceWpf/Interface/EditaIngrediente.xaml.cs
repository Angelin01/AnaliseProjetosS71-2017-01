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
    /// Interaction logic for EditaIngrediente.xaml
    /// </summary>
    public partial class EditaIngrediente : Window
    {
        public EditaIngrediente()
        {
            InitializeComponent();
        }
        private void Button_Cancela(object sender, RoutedEventArgs e) {
			Window main_window = new ConsultaIngrediente();
			App.Current.MainWindow = main_window;
			this.Close();
			App.Current.MainWindow.Show();
		}
        private void Button_Confirma(object sender, RoutedEventArgs e)
        {
			MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Confirma os dados inseridos?", "Confirmação", System.Windows.MessageBoxButton.YesNo);
			if (messageBoxResult == MessageBoxResult.Yes) {
				Window main_window = new ConsultaIngrediente();
				App.Current.MainWindow = main_window;
				this.Close();
				App.Current.MainWindow.Show();
			}
		}
    }
}
