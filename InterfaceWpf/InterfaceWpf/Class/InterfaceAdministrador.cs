using InterfaceWpf.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InterfaceWpf.Class
{
    class InterfaceAdministrador
    {
        public static void MostrarJanelaOpcoes()
        {
            Controller user = Controller.Instance;
            Window current_window = App.Current.MainWindow;

            Window main_window;
            if (user.Admin)
            {
                main_window = new InicioAdministracao();
            }
            else
            {
                main_window = new InicioFuncionario();
            }
            App.Current.MainWindow = main_window;
            current_window.Close();
            App.Current.MainWindow.Show();
        }

        public static void MostrarJanelaConsultarFuncionario()
        {
            Controller user = Controller.Instance;
            Window current_window = App.Current.MainWindow;
            App.Current.MainWindow = new ConsultaFuncionario();
            current_window.Close();
            App.Current.MainWindow.Show();
        }

        public static void MostrarJanelaCadastroFuncionario()
        {
            Controller user = Controller.Instance;
            Window current_window = App.Current.MainWindow;
            App.Current.MainWindow = new RegistraFuncionario();
            current_window.Close();
            App.Current.MainWindow.Show();
        }

        public static void MostrarJanelaEditarFuncionario(string cpf)
        {
            Controller user = Controller.Instance;
            Window current_window = App.Current.MainWindow;
            App.Current.MainWindow = new EditaFuncionario(cpf);
            current_window.Close();
            App.Current.MainWindow.Show();
        }

        public static MessageBoxResult MostrarJanelaDeletarFuncionario()
        {
            return System.Windows.MessageBox.Show("Deseja realmente remover o Funcionário?", "Confirmação", System.Windows.MessageBoxButton.YesNo);
        }

        public static void MostrarJanelaRegistrarProduto()
        {
            Controller user = Controller.Instance;
            Window current_window = App.Current.MainWindow;
            App.Current.MainWindow = new RegistraProduto();
            current_window.Close();
            App.Current.MainWindow.Show();
        }

        public static void MostrarJanelaEditarProduto()
        {
            Controller user = Controller.Instance;
            Window current_window = App.Current.MainWindow;
            App.Current.MainWindow = new EditaProduto();
            current_window.Close();
            App.Current.MainWindow.Show();
        }

        public static MessageBoxResult MostrarJanelaDeletarProduto()
        {
            return System.Windows.MessageBox.Show("Deseja realmente remover o Produto?", "Confirmação", System.Windows.MessageBoxButton.YesNo);
        }

        public static void MostrarJanelaConsultarProduto()
        {
            Controller user = Controller.Instance;
            Window current_window = App.Current.MainWindow;
            App.Current.MainWindow = new ConsultaProduto();
            current_window.Close();
            App.Current.MainWindow.Show();
        }

        public static void MostrarJanelaRegistrarRecurso()
        {
            Controller user = Controller.Instance;
            Window current_window = App.Current.MainWindow;
            App.Current.MainWindow = new RegistraIngrediente();
            current_window.Close();
            App.Current.MainWindow.Show();
        }

        public static void MostrarJanelaEditarRecurso()
        {
            Controller user = Controller.Instance;
            Window current_window = App.Current.MainWindow;
            App.Current.MainWindow = new EditaIngrediente();
            current_window.Close();
            App.Current.MainWindow.Show();
        }

        public static MessageBoxResult MostrarJanelaDeletarRecurso()
        {
            return System.Windows.MessageBox.Show("Deseja realmente remover o Recurso?", "Confirmação", System.Windows.MessageBoxButton.YesNo);
        }

        public static void MostrarJanelaConsultarRecurso()
        {
            Controller user = Controller.Instance;
            Window current_window = App.Current.MainWindow;
            App.Current.MainWindow = new ConsultaIngrediente();
            current_window.Close();
            App.Current.MainWindow.Show();
        }

        public static void MostrarJanelaAdicionarTransacao()
        {
            Controller user = Controller.Instance;
            Window current_window = App.Current.MainWindow;
            App.Current.MainWindow = new AdicionaTransacao();
            current_window.Close();
            App.Current.MainWindow.Show();
        }

        public static void MostrarJanelaRelatorioOrcamentario()
        {
            Controller user = Controller.Instance;
            Window current_window = App.Current.MainWindow;
            App.Current.MainWindow = new ConsultaRelatorio();
            current_window.Close();
            App.Current.MainWindow.Show();
        }
    }
}
