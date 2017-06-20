using InterfaceWpf.Class;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

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

		// Construtor para login
		public Funcionario(string login, string senha)
		{
			this.Nome = null;
			this.NomeMae = null;
			this.NomePai = null;
			this.Cpf = null;
			this.Rg = null;
			this.Ctps = null;
			this.Endereco = null;
			this.TelefonePrincipal = null;
			this.TelefoneCelular = null;
			this.EmailPrincipal = null;
			this.EmailAlternativo = null;
			this.Login = login;
			this.Senha = senha;
			this.Salario = 0;
			this.Cargo = null;
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
				cmd.Parameters.AddWithValue("@senha", this.criptografarSenha());
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
            if (Cargo.Equals("Administrador"))
            {
                Administrador adm = new Administrador(this);
                adm.Promover();
            }

			return true;
		}

        public bool EditarDadosFuncionario(string oldcpf) {
            if(Cargo.Equals("Administrador"))
            {
                Administrador adm = new Administrador(this);
                adm.Promover();
            }
            else
            {
                Administrador adm = new Administrador(this);
                adm.Rebaixar();
            }
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

				cmd.CommandText = "UPDATE Funcionario SET cpf=@cpf, nome=@nome, nome_da_mae=@nomemae, nome_do_pai=@nomepai, rg=@rg, ctps=@ctps, endereco=@ender, telefone=@tel, telefone_cel=@cel, email=@email, email_alt=@emailalt, login=@login, senha=@senha, salario=@salario WHERE cpf=@oldcpf";
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
				cmd.Parameters.AddWithValue("@senha", this.criptografarSenha());
				cmd.Parameters.AddWithValue("@salario", Salario);
				//cmd.Parameters.AddWithValue("@cargo", Cargo);
				cmd.Parameters.AddWithValue("@oldcpf", oldcpf);

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

            Administrador adm = new Administrador(this);
            adm.Rebaixar();

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
				using (MySqlCommand cmd = new MySqlCommand()) {
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

        public static bool Validar_Numero(string numero)
        {
            if(Regex.Match(numero, @"\(\d{2,2}\)[ ]*(([3|4]\d{3})|([9]\d{4})|([8|9]\d{3}))\-\d{4}$").Success) {
                return true;
            }
            return false;
        }

        public string verificarLogin()
        {
            if (String.IsNullOrEmpty(login))
            {
                if (String.IsNullOrEmpty(senha))
                    return "Login e Senha em branco";
                return "Login em branco";
            }
            else if (String.IsNullOrEmpty(senha))
            {
                return "Senha em branco";
            }
            else
            {
                return "Nada";
            }
        }

        public static string criptografar(string texto_bruto)
        { return SecurePasswordHasher.Hash(texto_bruto); }

        public string criptografarSenha()
        {
            if(!SecurePasswordHasher.IsHashSupported(Senha))
                return Funcionario.criptografar(Senha);
            return Senha;
        }

        public bool verificarSenha(string hash_comparacao)
        { return SecurePasswordHasher.Verify(Senha, hash_comparacao); }

        public void VerificarRegraDeNegocio() { }

		public void AutenticarUsuario()
        {
			Controller user = Controller.Instance;
            string _error = this.verificarLogin();

			if (_error != "Nada") {
				MessageBox.Show(_error, "Falha no login");
                return;
			}
			if (login == "admin" && senha == "admin") {
				user.Login = "admin";
				user.Admin = true;
                user.MostrarJanelaOpcoes();
                return;
			}

			using (MySqlConnection conn = new MySqlConnection(user.connStr)) {
				try { conn.Open(); }
				catch (MySqlException ex) {
					// Conexão com o banco de dados falhou.
					// Possíveis razões: Fora do ar, ou usuário/senha incorretos
					//MessageBox.Show(ex.Message);
					MessageBox.Show("Sem conexão com banco.", "Falha no login");
					return;
				}

				MySqlCommand cmd = new MySqlCommand();
				cmd.Connection = conn;

				cmd.CommandText = "SELECT login, cargo, senha FROM Funcionario WHERE login=@login";
				cmd.Prepare();
				cmd.Parameters.AddWithValue("@login", login);

				MySqlDataReader reader;
				try { reader = cmd.ExecuteReader(); }
				catch (MySqlException ex) {
					// Query falhou.
					MessageBox.Show("Falha na autenticação.", "Falha no login");
					return;
				}

				string temp_login = null;
				bool temp_admin = false;
				string hash_senha = null;

				if (reader.Read()) {
					temp_login = reader.GetString(0);
					temp_admin = (reader.GetString(1) == "Administrador" ? true : false);
					hash_senha = reader.GetString(2);
				}

				conn.Close();

				if (String.IsNullOrEmpty(hash_senha) || !this.verificarSenha(hash_senha)) {
					MessageBox.Show("Login ou senha inválido(s).", "Falha no login");
				}
				else {
					user.Login = temp_login;
					user.Admin = temp_admin;
                    user.MostrarJanelaOpcoes();
				}
			}
		}

        public static List<Funcionario> BuscarFuncionarios(string f_cpf, string f_ctps, string f_login, string f_nome, string f_rg)
        {
            using (MySqlConnection conn = new MySqlConnection(Controller.Instance.connStr))
            {
                try { conn.Open(); }
                catch (MySqlException ex)
                { return null; }

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;

                cmd.CommandText = "SELECT nome, nome_da_mae, nome_do_pai, cpf, rg, ctps, endereco, telefone, telefone_cel, email, email_alt, login, senha, salario, cargo FROM Funcionario WHERE 1";
                cmd.Prepare();
                
                if (!String.IsNullOrEmpty(f_cpf))
                {
                    cmd.CommandText += " AND cpf LIKE @cpf";
                    cmd.Parameters.AddWithValue("@cpf", f_cpf + '%');
                }
                if (!String.IsNullOrEmpty(f_ctps))
                {
                    cmd.CommandText += " AND ctps LIKE @ctps";
                    cmd.Parameters.AddWithValue("@ctps", f_ctps + '%');
                }
                if (!String.IsNullOrEmpty(f_login))
                {
                    cmd.CommandText += " AND login LIKE @login";
                    cmd.Parameters.AddWithValue("@login", '%' + f_login + '%');
                }
                if (!String.IsNullOrEmpty(f_nome))
                {
                    cmd.CommandText += " AND nome LIKE @nome";
                    cmd.Parameters.AddWithValue("@nome", '%' + f_nome + '%');
                }
                if (!String.IsNullOrEmpty(f_rg))
                {
                    cmd.CommandText += " AND rg LIKE @rg";
                    cmd.Parameters.AddWithValue("@rg", f_rg + '%');
                }
                
                MySqlDataReader reader;
                try { reader = cmd.ExecuteReader(); }
                catch (MySqlException ex) { return null; }

                List<Funcionario> funcionarios = new List<Funcionario>();

                while (reader.Read())
                {
                    funcionarios.Add(new Funcionario(
                        reader.GetString(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetString(4),
                        reader.GetString(5),
                        reader.GetString(6),
                        reader.GetString(7),
                        reader.GetString(8),
                        reader.GetString(9),
                        reader.GetString(10),
                        reader.GetString(11),
                        reader.GetString(12),
                        reader.GetInt32(13),
                        reader.GetString(14)
                        ));
                }
                conn.Close();

                return funcionarios;
            }
        }
    }
}