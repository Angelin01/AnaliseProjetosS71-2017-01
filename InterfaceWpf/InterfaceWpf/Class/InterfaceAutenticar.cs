using InterfaceWpf.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InterfaceWpf.Class
{
    class InterfaceAutenticar
    {
        public static void MostrarJanelaAutenticar()
        {
            Controller user = Controller.Instance;
            Window current_window = App.Current.MainWindow;
            Window main_window = new Autenticar();
            App.Current.MainWindow = main_window;
            current_window.Close();
            App.Current.MainWindow.Show();
        }
    }
}
