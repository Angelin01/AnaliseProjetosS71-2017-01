using InterfaceWpf.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InterfaceWpf.Class
{
    class InterfaceFuncionario
    {

        public static void MostrarJanelaOpcoes()
        {
            InterfaceAdministrador.MostrarJanelaOpcoes();
        }

        public void MostrarJanelaRegistrarPedido()
        {
            Controller user = Controller.Instance;
            Window current_window = App.Current.MainWindow;
            current_window.Close();
            App.Current.MainWindow = new RegistraPedido();
            App.Current.MainWindow.Show();
        }

        public void MostrarJanelaConsultarPedido()
        {
            Controller user = Controller.Instance;
            Window current_window = App.Current.MainWindow;
            current_window.Close();
            App.Current.MainWindow = new ConsultaPedido();
            App.Current.MainWindow.Show();
        }

        public void MostrarJanelaEditarPedido()
        {
            Controller user = Controller.Instance;
            Window current_window = App.Current.MainWindow;
            current_window.Close();
            App.Current.MainWindow = new EditarPedido();
            App.Current.MainWindow.Show();
        }

        public void MostrarJanelaCancelarPedido()
        {
            // wirow
        }

        public void MostrarJanelaEncerrarPedido()
        {
            // wirow
        }
    }
}