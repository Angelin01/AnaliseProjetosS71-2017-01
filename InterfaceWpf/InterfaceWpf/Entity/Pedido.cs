using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceWpf.Entity
{
    class Pedido {
        private int idPedido;
        private char estadoPedido;
        private DateTime HoraPedido;
        private string observacao;

        public int IdPedido { get => idPedido; set => idPedido = value; }
        public char EstadoPedido { get => estadoPedido; set => estadoPedido = value; }
        public DateTime HoraPedido1 { get => HoraPedido; set => HoraPedido = value; }
        public string Observacao { get => observacao; set => observacao = value; }

        public Pedido(int idPedido, char estadoPedido, DateTime horaPedido, string observacao) {
            this.IdPedido = idPedido;
            this.EstadoPedido = estadoPedido;
            HoraPedido1 = horaPedido;
            this.Observacao = observacao;
        }

        public void registrarPedido() { }
        public void editarPedido() { }
        public void encerrarPedido() { }
        public void cancelarPedido() { }
        public void verificarRegrasDeNegocio() { }
    }
}
