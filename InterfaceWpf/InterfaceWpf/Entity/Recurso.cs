using InterfaceWpf.Class;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceWpf.Entity {
    class Recurso {
        private int idRecurso;
        private string nome;
        private float quantidade;
        private string nomeDoFornecedor;
        private string telefoneDoFornecedor;

        public Recurso(int idRecurso, string nome, float quantidade, string nomeDoFornecedor, string telefoneDoFornecedor) {
            this.idRecurso = idRecurso;
            this.nome = nome;
            this.quantidade = quantidade;
            this.nomeDoFornecedor = nomeDoFornecedor;
            this.telefoneDoFornecedor = telefoneDoFornecedor;
        }

        public int IdRecurso { get => idRecurso; set => idRecurso = value; }
        public string Nome { get => nome; set => nome = value; }
        public float Quantidade { get => quantidade; set => quantidade = value; }
        public string NomeDoFornecedor { get => nomeDoFornecedor; set => nomeDoFornecedor = value; }
        public string TelefoneDoFornecedor { get => telefoneDoFornecedor; set => telefoneDoFornecedor = value; }

        public bool RegistrarRecurso() {
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

				cmd.CommandText = "INSERT INTO Recurso (nome, quantidade, nome_fornecedor, telefone_fornecedor) VALUES (@nome, @quant, @nomeforn, @telforn)";
				cmd.Prepare();
				cmd.Parameters.AddWithValue("@nome", nome);
				cmd.Parameters.AddWithValue("@quant", quantidade);
				cmd.Parameters.AddWithValue("@nomeforn", nomeDoFornecedor);
				cmd.Parameters.AddWithValue("@telforn", telefoneDoFornecedor);

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

        public bool EditarRecurso() {
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

				cmd.CommandText = "UPDATE Recurso SET nome=@nome, quantidade=@quant, nome_fornecedor=@nomeforn, telefone_fornecedor=@telforn WHERE id=@id";
				cmd.Prepare();
				cmd.Parameters.AddWithValue("@id", idRecurso);
				cmd.Parameters.AddWithValue("@nome", nome);
				cmd.Parameters.AddWithValue("@quant", quantidade);
				cmd.Parameters.AddWithValue("@nomeforn", nomeDoFornecedor);
				cmd.Parameters.AddWithValue("@telforn", telefoneDoFornecedor);

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

        public bool DeletarRecurso() {
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

				cmd.CommandText = "DELETE FROM Recurso WHERE id=@id";
				cmd.Prepare();
				cmd.Parameters.AddWithValue("@id", idRecurso);

				try {
					cmd.ExecuteNonQuery();
				}
				catch (MySqlException ex) {
					// Query falhou.
					// Possível razão: não pode deletar porque é usado por algum produto.
					//MessageBox.Show(ex.Message);
					return false;
				}

				conn.Close();
			}
			return true;
		}

        public void VerificarRegrasDeNegocio() { }
    }
}
