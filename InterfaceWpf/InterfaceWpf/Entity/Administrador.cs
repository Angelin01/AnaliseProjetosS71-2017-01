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
    }
}
