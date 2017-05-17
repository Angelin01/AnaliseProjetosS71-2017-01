using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace InterfaceWpf.Interface
{
    /// <summary>
    /// Lógica interna para EditaQuantidadeIngrediente.xaml
    /// </summary>
    public partial class EditaQuantidadeIngrediente : Window
    {
        public EditaQuantidadeIngrediente()
        {
            InitializeComponent();
        }

        private void Button_Cancela(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Button_Confirma(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Deseja confirmar as alterações do ingrediente?", "Confirmação", System.Windows.MessageBoxButton.YesNo);

            string mudanca = String.IsNullOrEmpty(txtNovaQnt.Text) ? "Nada foi atualizado" : "Quantidade atualizada";

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                // Salva alteração

                MessageBox.Show(mudanca, "Edição confirmada");

                this.Close();
            }
        }
    }
}
