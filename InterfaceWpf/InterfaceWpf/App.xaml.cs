using InterfaceWpf.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace InterfaceWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>

    public partial class App : Application
    {
        private Funcionario current_user;

        public void SetFuncionario(string login, string password)
        {
            current_user.Login = login;
            current_user.Senha = password;
        }
    }
}
