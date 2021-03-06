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
    /// Interaction logic for ConsultaProduto.xaml
    /// </summary>
    public partial class ConsultaProduto : Window
    {
        public ConsultaProduto()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
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

		private void Button_Edit(object sender, RoutedEventArgs e)
		{
			App.Current.MainWindow = new EditaProduto();
			this.Close();
			App.Current.MainWindow.Show();
		}

		private void Button_Remove(object sender, RoutedEventArgs e)
		{
			MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Deseja realmente remover o produto?", "Confirmação", System.Windows.MessageBoxButton.YesNo);
			if (messageBoxResult == MessageBoxResult.No) return;
		}

        private void Button_Filtro(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Resultados filtrados.", "Sucesso!");
        }
    }

	// Temporário
	public class Produto
	{
		public string Nome { get; set; }
		public int PReco { get; set; }
		public string Ingredientes { get; set; }
	}
}
