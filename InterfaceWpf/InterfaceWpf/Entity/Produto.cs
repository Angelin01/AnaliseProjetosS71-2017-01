﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceWpf.Entity
{
    class Produto
    {
        private string nome;
        private int preco; // EM CENTAVOS
        private int id;

        protected string Nome { get => nome; set => nome = value; }
        protected int Preco { get => preco; set => preco = value; }
        protected int Id { get => id; set => id = value; }

        public Produto(string nome, int preco, int id)
        {
            this.Nome = nome;
            this.Preco = preco;
            this.Id = id;
        }

        public void RegistrarProduto() { }
        public void EditarProduto() { }
        public void DeletarProduto() { }
        public void VerificarRegrasDeNegocio() { }
    }
}
