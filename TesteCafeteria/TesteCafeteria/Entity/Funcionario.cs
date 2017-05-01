using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteCafeteria
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
        protected float salario;
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
        public float Salario { get => salario; set => salario = value; }
        public string Cargo { get => cargo; set => cargo = value; }

        public Funcionario(string nome, string nomeMae, string nomePai, string cpf, string rg, string ctps, string endereco, string telefonePrincipal, string telefoneCelular, string emailPrincipal, string emailAlternativo, string login, string senha, float salario, string cargo)
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
#pragma warning disable IDE1006 // Estilos de Nomenclatura
        public void cadastrarDadosFuncionario() { }
        public void editarDadosFuncionario() { }
        public void deletarDadosFuncionario() { }
        public void verificarRegraDeNegocio() { }
#pragma warning restore IDE1006 // Estilos de Nomenclatura
    }
}
