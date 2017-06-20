using InterfaceWpf.Class;
using InterfaceWpf.Entity;
using MySql.Data.MySqlClient;
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
    /// Interaction logic for ConsultaFuncionario.xaml
    /// </summary>
    public partial class ConsultaFuncionario : Window
    {
        public ConsultaFuncionario()
        {
            InitializeComponent();
			AtualizarLista();
        }

		public void AtualizarLista()
		{
            List<Funcionario> list = Funcionario.BuscarFuncionarios(null, null, null, null, null);

            foreach (Funcionario f in list)
                lvUsers.Items.Add(f);
		}

		public void FiltrarLista()
		{
            List<Funcionario> list = Funcionario.BuscarFuncionarios(txtFiltroCPF.Text, txtFiltroCTPS.Text, txtFiltroLogin.Text, txtFiltroNome.Text, txtFiltroRG.Text);

            foreach (Funcionario f in list)
                lvUsers.Items.Add(f);
        }

		private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

		private void Button_Remove(object sender, RoutedEventArgs e)
		{
            MessageBoxResult messageBoxResult = InterfaceAdministrador.MostrarJanelaDeletarFuncionario();
			if (messageBoxResult == MessageBoxResult.No) return;

			Button button = sender as Button;
			string cpf = button.Tag.ToString();

			Funcionario f = new Funcionario(null, null, null, cpf, null, null, null, null, null, null, null, null, null, 0, null);
			if (!f.DeletarDadosFuncionario()) {
				MessageBox.Show("Não foi possível remover o funcionário do sistema.", "Erro");
				return;
			}

			lvUsers.Items.Clear();
			AtualizarLista();
		}

		private void Button_Edit(object sender, RoutedEventArgs e)
        {
			Button button = sender as Button;
			string cpf = button.Tag.ToString();

            InterfaceAdministrador.MostrarJanelaEditarFuncionario(cpf);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            Controller user = Controller.Instance;

            if (user.Admin)
            { // Deveria ser se entrou nessa janela, mas por garantia neh...
                InterfaceAdministrador.MostrarJanelaOpcoes();
            }
            else
            {
                InterfaceFuncionario.MostrarJanelaOpcoes();
            }
        }

        private void lvUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Filtro(object sender, RoutedEventArgs e)
        {
			lvUsers.Items.Clear();
			FiltrarLista();
			MessageBox.Show("Resultados filtrados.", "Sucesso!");
        }
    }
}
