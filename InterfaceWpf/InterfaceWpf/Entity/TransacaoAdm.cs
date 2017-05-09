using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteCafeteria.Entity
{
    class TransacaoAdm : ITransacao
    {
        private int valor;
        private DateTime data;
        private string descricao;

        public TransacaoAdm(int valor, DateTime data, string descricao)
        {
            this.valor = valor;
            this.data = data;
            this.descricao = descricao;
        }

        public int Valor { get => valor; set => valor = value; }
        public DateTime Data { get => data; set => data = value; }
        public string Descricao { get => descricao; set => descricao = value; }

        public void RegistraTransacao() { }
        public void VerificarRegraDeNegocio() { }
    }
}