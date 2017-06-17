using InterfaceWpf.Class;
using InterfaceWpf.Entity;
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
    /// Interaction logic for RegistraIngrediente.xaml
    /// </summary>
    public partial class RegistraIngrediente : Window
    {
        public RegistraIngrediente()
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

		public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
		{
			if (depObj != null) {
				for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++) {
					DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
					if (child != null && child is T) {
						yield return (T)child;
					}

					foreach (T childOfChild in FindVisualChildren<T>(child)) {
						yield return childOfChild;
					}
				}
			}
		}

		private bool ValidateForm()
		{
			foreach (TextBox tb in FindVisualChildren<TextBox>(grid)) {
				if (String.IsNullOrEmpty(tb.Text)) {
					return false;
				}
			}
			return true;
		}

		private void Button_Confirma(object sender, RoutedEventArgs e)
        {
			Controller user = Controller.Instance;

			if (!ValidateForm()) {
				MessageBox.Show("Todos os campos devem estar preenchidos.", "Erro");
				return;
			}

			MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Confirma os dados inseridos?", "Confirmação", System.Windows.MessageBoxButton.YesNo);
			if (messageBoxResult == MessageBoxResult.Yes) {

				// Talvez deva vir alguma validação aqui

				Recurso r = new Recurso(0, txt_nome.Text, Convert.ToSingle(txt_quant.Text), txt_fornecedor.Text, txt_tel_fornecedor.Text);

				if (!r.RegistrarRecurso()) {
					MessageBox.Show("Não foi possível adicionar o recurso.", "Erro");
					return;
				}

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
