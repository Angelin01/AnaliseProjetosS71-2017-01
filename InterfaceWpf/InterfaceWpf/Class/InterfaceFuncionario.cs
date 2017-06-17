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

        public static void MostrarJanelaRegistrarPedido()
        {
            Controller user = Controller.Instance;
            Window current_window = App.Current.MainWindow;
            App.Current.MainWindow = new RegistraPedido();
            current_window.Close();
            App.Current.MainWindow.Show();
        }

        public static void MostrarJanelaConsultarPedido()
        {
            Controller user = Controller.Instance;
            Window current_window = App.Current.MainWindow;
            App.Current.MainWindow = new ConsultaPedido();
            current_window.Close();
            App.Current.MainWindow.Show();
        }

        public static void MostrarJanelaEditarPedido()
        {
            Controller user = Controller.Instance;
            Window current_window = App.Current.MainWindow;
            App.Current.MainWindow = new EditarPedido();
            current_window.Close();
            App.Current.MainWindow.Show();
        }

        public static void MostrarJanelaCancelarPedido()
        {
            // wirow
        }

        public static void MostrarJanelaEncerrarPedido()
        {
            // wirow
        }
    }
}