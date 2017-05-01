using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteCafeteria.Entity {
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

        public void RegistrarRecurso() { }
        public void EditarRecurso() { }
        public void DeletarRecurso() { }
        public void VerificarRegrasDeNegocio() { }
    }
}
