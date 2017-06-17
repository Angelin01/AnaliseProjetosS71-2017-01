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

        private bool Validar_Cpf(string cpf) {

            int[] mult1 = new int[9] {10, 9, 8, 7, 6, 5, 4, 3, 2};
            int[] mult2 = new int[10] {11, 10, 9, 8, 7, 6, 5, 4, 3, 2};
            string tempCpf;
            string digito;
            int soma = 0;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", ""); // Tirar espaços, "."s e "-"s

            if (cpf.Length != 11) {
                return false;
            }
            foreach (char c in cpf) { 
                if (c < '0' || c > '9') { // Só pode ter sobrado números
                    return false;
                }
            }

            tempCpf = cpf.Substring(0, 9);

            for (int i = 0; i < 9; i++) {
                soma += int.Parse(tempCpf[i].ToString()) * mult1[i]; // Fazendo as primeiras multiplicações
            }

            resto = soma % 11;
            if (resto < 2) {
                resto = 0;
            }
            else {
                resto = 11 - resto;
            }

            digito = resto.ToString();

            tempCpf = tempCpf + digito;

            soma = 0;
            for (int i = 0; i < 10; i++) {
                soma += int.Parse(tempCpf[i].ToString()) * mult2[i];
            }

            resto = soma % 11;
            if (resto < 2) {
                resto = 0;
            }
            else {
                resto = 11 - resto;
            }

            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
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

                if(!Validar_Cpf(box_cpf.Text)) {
                    MessageBox.Show("O CPF inserido não é válido.\nPor favor, insira um CPF válido.", "Erro");
                    return;
                }

				var hash_senha = SecurePasswordHasher.Hash(box_senha.Text);

				Funcionario f = new Funcionario(box_nome.Text, box_nome_da_mae.Text, box_nome_do_pai.Text, box_cpf.Text, box_rg.Text, box_ctps.Text, box_endereco.Text, box_telefone.Text, box_telefone_cel.Text, box_email.Text, box_email_alt.Text, box_login.Text, hash_senha, Convert.ToInt32(box_salario.Text), box_cargo.Text);

				if(!f.CadastrarDadosFuncionario()) {
					MessageBox.Show("Já existe um funcionário cadastrado com este CPF.\nPor favor, retorne à tela de consulta e selecione a operação de Editar ou Remover.", "Erro");
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
