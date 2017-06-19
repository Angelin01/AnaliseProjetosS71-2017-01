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

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        private bool ValidateForm()
        {
            foreach (TextBox tb in FindVisualChildren<TextBox>(grid))
            {
                if (String.IsNullOrEmpty(tb.Text))
                {
                    return false;
                }
            }
            return true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Controller user = Controller.Instance;

            if (!ValidateForm())
            {
                MessageBox.Show("Todos os campos devem estar preenchidos.", "Erro");
                return;
            }

            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Confirma os dados inseridos?", "Confirmação", System.Windows.MessageBoxButton.YesNo);
			if (messageBoxResult == MessageBoxResult.Yes) {

                if(!Funcionario.Validar_Cpf(box_cpf.Text)) {
                    MessageBox.Show("O CPF inserido não é válido.\nPor favor, insira um CPF válido.", "Erro");
                    return;
                }

                if(!Funcionario.Validar_Numero(box_telefone.Text)) {
                    MessageBox.Show("O telefone inserido não é válido.\nPor favor, insira um telefone válido.", "Erro");
                    return;
                }

                if (!Funcionario.Validar_Numero(box_telefone_cel.Text)) {
                    MessageBox.Show("O telefone celular inserido não é válido.\nPor favor, insira um telefone celular válido.", "Erro");
                    return;
                }

                var hash_senha = SecurePasswordHasher.Hash(box_senha.Text);

				Funcionario f = new Funcionario(box_nome.Text, box_nome_da_mae.Text, box_nome_do_pai.Text, box_cpf.Text, box_rg.Text, box_ctps.Text, box_endereco.Text, box_telefone.Text, box_telefone_cel.Text, box_email.Text, box_email_alt.Text, box_login.Text, hash_senha, Convert.ToInt32(box_salario.Text), box_cargo.Text);

				if(!f.CadastrarDadosFuncionario()) {
					MessageBox.Show("Já existe um funcionário cadastrado com este CPF.\nPor favor, retorne à tela de consulta e selecione a operação de Editar ou Remover.", "Erro");
					return;
				}

				if(box_cargo.Text.Equals("Administrador")) {
					if (!Administrador.ElevarParaAdministrador(f)) {
						MessageBox.Show("O funcionário foi cadastrado, mas não foi possível dar permissões de administrador a ele.", "Erro");
					};
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
