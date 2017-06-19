using InterfaceWpf.Class;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceWpf.Entity
{
    class Administrador : Funcionario
    {
        public Administrador(string nome, string nomeMae, string nomePai, string cpf, string rg, string ctps, string endereco, string telefonePrincipal, string telefoneCelular, string emailPrincipal, string emailAlternativo, string login, string senha, int salario, string cargo) :
            base(nome, nomeMae, nomePai, cpf, rg, ctps, endereco, telefonePrincipal, telefoneCelular, emailPrincipal, emailAlternativo, login, senha, salario, cargo)
        {
        }

		public static bool ElevarParaAdministrador(Funcionario f)
		{
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

				int idFuncionario = -1;

				using (MySqlCommand cmd = new MySqlCommand()) {
					cmd.Connection = conn;
					cmd.CommandText = "SELECT id_funcionario FROM Funcionario WHERE cpf=@cpf";
					cmd.Prepare();
					cmd.Parameters.AddWithValue("@cpf", f.Cpf);

					MySqlDataReader reader;
					try {
						reader = cmd.ExecuteReader();
					}
					catch (MySqlException ex) {
						// Query falhou.
						return false;
					}

					reader.Read();
					idFuncionario = reader.GetInt32(0);

					reader.Close();
				}

				Console.WriteLine("idFuncionario = " + idFuncionario);
				if (idFuncionario < 0) return false;

				using (MySqlCommand cmd = new MySqlCommand()) {
					cmd.Connection = conn;
					cmd.CommandText = "INSERT INTO Administrador (id_administrador) VALUES (@id)";
					cmd.Prepare();
					cmd.Parameters.AddWithValue("@id", idFuncionario);

					try {
						cmd.ExecuteNonQuery();
					}
					catch (MySqlException ex) {
						Console.WriteLine(ex.Message);
						// Query falhou.
						// Possível razão: chave primária já existe.
						//MessageBox.Show(ex.Message);
						return false;
					}
				}
				conn.Close();
			}
			return true;
		}

	}
}
