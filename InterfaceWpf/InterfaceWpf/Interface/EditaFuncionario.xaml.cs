using InterfaceWpf.Class;
using InterfaceWpf.Entity;
using InterfaceWpf.Interface;
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

namespace InterfaceWpf
{
    /// <summary>
    /// Interaction logic for EditaFuncionario.xaml
    /// </summary>
    public partial class EditaFuncionario : Window
    {
		private Funcionario f;

        public EditaFuncionario()
        {
            InitializeComponent();
        }

		public EditaFuncionario(string cpf)
		{
			InitializeComponent();
            List<Funcionario> list = Funcionario.BuscarFuncionarios(cpf, null, null, null, null);
            this.f = list[0];

            txt_celular.Text = f.TelefoneCelular;
            txt_cpf.Text = f.Cpf;
            txt_ctps.Text = f.Ctps;
            txt_email.Text = f.EmailPrincipal;
            txt_email_alt.Text = f.EmailAlternativo;
            txt_endereco.Text = f.Endereco;
            txt_login.Text = f.Login;
            txt_mae.Text = f.NomeMae;
            txt_name.Text = f.Nome;
            txt_pai.Text = f.NomePai;
            txt_rg.Text = f.Rg;
            txt_salario.Text = f.Salario.ToString();
            txt_telefone.Text = f.TelefonePrincipal;
            select_cargo.Text = (f.Cargo == "Funcionario" ? "Funcionário" : f.Cargo);
		}

        private void Button_Cancela(object sender, RoutedEventArgs e) {
            Controller user = Controller.Instance;
            user.MostrarJanelaOpcoes();
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
			if (!ValidateForm()) {
				MessageBox.Show("Todos os campos devem estar preenchidos.", "Erro");
				return;
			}

			MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Confirma os dados inseridos?", "Confirmação", System.Windows.MessageBoxButton.YesNo);
			if (messageBoxResult == MessageBoxResult.Yes) {
				Controller user = Controller.Instance;

				if (!Funcionario.Validar_Cpf(txt_cpf.Text)) {
					MessageBox.Show("O CPF inserido não é válido.\nPor favor, insira um CPF válido.", "Erro");
					return;
				}
				if (!Funcionario.Validar_Numero(txt_telefone.Text)) {
					MessageBox.Show("O telefone inserido não é válido.\nPor favor, insira um telefone válido.", "Erro");
					return;
				}
				if (!Funcionario.Validar_Numero(txt_celular.Text)) {
					MessageBox.Show("O telefone celular inserido não é válido.\nPor favor, insira um telefone celular válido.", "Erro");
					return;
				}

				var hash_senha = SecurePasswordHasher.Hash(txt_senha.Text);
				string oldcpf = f.Cpf;

				f.Nome = txt_name.Text;
				f.NomeMae = txt_mae.Text;
				f.NomePai = txt_pai.Text;
				f.Cpf = txt_cpf.Text;
				f.Rg = txt_rg.Text;
				f.Ctps = txt_ctps.Text;
				f.Endereco = txt_endereco.Text;
				f.TelefonePrincipal = txt_telefone.Text;
				f.TelefoneCelular = txt_celular.Text;
				f.EmailPrincipal = txt_email.Text;
				f.EmailAlternativo = txt_email_alt.Text;
				f.Login = txt_login.Text;
				f.Senha = hash_senha;
				f.Salario = Convert.ToInt32(txt_salario.Text);
				f.Cargo = (select_cargo.Text == "Funcionário" ? "Funcionario" : select_cargo.Text);

				if (!f.EditarDadosFuncionario(oldcpf)) {
					MessageBox.Show("Já existe outro funcionário cadastrado com este CPF.", "Erro");
					return;
				}
                user.MostrarJanelaOpcoes();
			}
		}
    }
}
