using InterfaceWpf.Class;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceWpf.Entity
{
    class Funcionario
    {
        protected string nome;
        protected string nomeMae;
        protected string nomePai;
        protected string cpf;
        protected string rg;
        protected string ctps;
        protected string endereco;
        protected string telefonePrincipal;
        protected string telefoneCelular;
        protected string emailPrincipal;
        protected string emailAlternativo;
        protected string login;
        protected string senha;
        protected int salario;
        protected string cargo;

        public string Nome { get => nome; set => nome = value; }
        public string NomeMae { get => nomeMae; set => nomeMae = value; }
        public string NomePai { get => nomePai; set => nomePai = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public string Rg { get => rg; set => rg = value; }
        public string Ctps { get => ctps; set => ctps = value; }
        public string Endereco { get => endereco; set => endereco = value; }
        public string TelefonePrincipal { get => telefonePrincipal; set => telefonePrincipal = value; }
        public string TelefoneCelular { get => telefoneCelular; set => telefoneCelular = value; }
        public string EmailPrincipal { get => emailPrincipal; set => emailPrincipal = value; }
        public string EmailAlternativo { get => emailAlternativo; set => emailAlternativo = value; }
        public string Login { get => login; set => login = value; }
        public string Senha { get => senha; set => senha = value; }
        public int Salario { get => salario; set => salario = value; }
        public string Cargo { get => cargo; set => cargo = value; }

        public Funcionario(string nome, string nomeMae, string nomePai, string cpf, string rg, string ctps, string endereco, string telefonePrincipal, string telefoneCelular, string emailPrincipal, string emailAlternativo, string login, string senha, int salario, string cargo)
        {
            this.Nome = nome;
            this.NomeMae = nomeMae;
            this.NomePai = nomePai;
            this.Cpf = cpf;
            this.Rg = rg;
            this.Ctps = ctps;
            this.Endereco = endereco;
            this.TelefonePrincipal = telefonePrincipal;
            this.TelefoneCelular = telefoneCelular;
            this.EmailPrincipal = emailPrincipal;
            this.EmailAlternativo = emailAlternativo;
            this.Login = login;
            this.Senha = senha;
            this.Salario = salario;
            this.Cargo = cargo;
        }

		// Métodos
		public bool CadastrarDadosFuncionario() {
			using (MySqlConnection conn = new MySqlConnection(Controller.Instance.connStr)) {
				try {
					conn.Open();
				}
				catch (MySqlException ex) {
					// Conexão com o banco de dados falhou.
					// Possíveis razões: Fora do ar, ou usuário/senha incorretos
					//MessageBox.Show(ex.Message);
					return false;
				}

				MySqlCommand cmd = new MySqlCommand();
				cmd.Connection = conn;

				cmd.CommandText = "INSERT INTO Funcionario (cpf, nome, nome_da_mae, nome_do_pai, rg, ctps, endereco, telefone, telefone_cel, email, email_alt, login, senha, salario, cargo) VALUES (@cpf, @nome, @nomemae, @nomepai, @rg, @ctps, @ender, @tel, @cel, @email, @emailalt, @login, @senha, @salario, @cargo)";
				cmd.Prepare();
				cmd.Parameters.AddWithValue("@cpf", Cpf);
				cmd.Parameters.AddWithValue("@nome", Nome);
				cmd.Parameters.AddWithValue("@nomemae", NomeMae);
				cmd.Parameters.AddWithValue("@nomepai", NomePai);
				cmd.Parameters.AddWithValue("@rg", Rg);
				cmd.Parameters.AddWithValue("@ctps", Ctps);
				cmd.Parameters.AddWithValue("@ender", Endereco);
				cmd.Parameters.AddWithValue("@tel", TelefonePrincipal);
				cmd.Parameters.AddWithValue("@cel", TelefoneCelular);
				cmd.Parameters.AddWithValue("@email", EmailPrincipal);
				cmd.Parameters.AddWithValue("@emailalt", EmailAlternativo);
				cmd.Parameters.AddWithValue("@login", Login);
				cmd.Parameters.AddWithValue("@senha", Senha);
				cmd.Parameters.AddWithValue("@salario", Salario);
				cmd.Parameters.AddWithValue("@cargo", Cargo);

				try {
					cmd.ExecuteNonQuery();
				}
				catch (MySqlException ex) {
					// Query falhou.
					// Possível razão: chave primária já existe.
					//MessageBox.Show(ex.Message);
					return false;
				}

				conn.Close();
			}
			return true;
		}

        public bool EditarDadosFuncionario() {
			using (MySqlConnection conn = new MySqlConnection(Controller.Instance.connStr)) {
				try {
					conn.Open();
				}
				catch (MySqlException ex) {
					// Conexão com o banco de dados falhou.
					// Possíveis razões: Fora do ar, ou usuário/senha incorretos
					//MessageBox.Show(ex.Message);
					return false;
				}

				MySqlCommand cmd = new MySqlCommand();
				cmd.Connection = conn;

				cmd.CommandText = "UPDATE Funcionario SET nome=@nome, nome_da_mae=@nomemae, nome_do_pai=@nomepai, rg=@rg, ctps=@ctps, endereco=@ender, telefone=@tel, telefone_cel=@cel, email=@email, email_alt=@emailalt, login=@login, senha=@senha, salario=@salario, cargo=@cargo WHERE cpf=@cpf";
				cmd.Prepare();
				cmd.Parameters.AddWithValue("@cpf", Cpf);
				cmd.Parameters.AddWithValue("@nome", Nome);
				cmd.Parameters.AddWithValue("@nomemae", NomeMae);
				cmd.Parameters.AddWithValue("@nomepai", NomePai);
				cmd.Parameters.AddWithValue("@rg", Rg);
				cmd.Parameters.AddWithValue("@ctps", Ctps);
				cmd.Parameters.AddWithValue("@ender", Endereco);
				cmd.Parameters.AddWithValue("@tel", TelefonePrincipal);
				cmd.Parameters.AddWithValue("@cel", TelefoneCelular);
				cmd.Parameters.AddWithValue("@email", EmailPrincipal);
				cmd.Parameters.AddWithValue("@emailalt", EmailAlternativo);
				cmd.Parameters.AddWithValue("@login", Login);
				cmd.Parameters.AddWithValue("@senha", Senha);
				cmd.Parameters.AddWithValue("@salario", Salario);
				cmd.Parameters.AddWithValue("@cargo", Cargo);

				try {
					cmd.ExecuteNonQuery();
				}
				catch (MySqlException ex) {
					// Query falhou.
					//MessageBox.Show(ex.Message);
					return false;
				}

				conn.Close();
			}
			return true;
		}

        public bool DeletarDadosFuncionario() {
			using (MySqlConnection conn = new MySqlConnection(Controller.Instance.connStr)) {
				try {
					conn.Open();
				}
				catch (MySqlException ex) {
					// Conexão com o banco de dados falhou.
					// Possíveis razões: Fora do ar, ou usuário/senha incorretos
					//MessageBox.Show(ex.Message);
					return false;
				}

				MySqlCommand cmd = new MySqlCommand();
				cmd.Connection = conn;

				cmd.CommandText = "DELETE FROM Funcionario WHERE cpf=@cpf";
				cmd.Prepare();
				cmd.Parameters.AddWithValue("@cpf", Cpf);

				try {
					cmd.ExecuteNonQuery();
				}
				catch (MySqlException ex) {
					// Query falhou.
					//MessageBox.Show(ex.Message);
					return false;
				}

				conn.Close();
			}
			return true;
		}

        public static bool Validar_Cpf(string cpf) {

            int[] mult1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] mult2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
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

        public void VerificarRegraDeNegocio() { }
    }
}