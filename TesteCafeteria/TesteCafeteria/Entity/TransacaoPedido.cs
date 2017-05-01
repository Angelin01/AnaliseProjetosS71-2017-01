using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteCafeteria.Entity
{
    class TransacaoPedido : ITransacao
    {
        private int valor;
        private DateTime data;

        public TransacaoPedido(int valor, DateTime data)
        {
            this.valor = valor;
            this.data = data;
        }

        public int Valor { get => valor; set => valor = value; }
        public DateTime Data { get => data; set => data = value; }
    }
}