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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace controlescolar
{
    /// <summary>
    /// Lógica de interacción para PageAgEmpleado.xaml
    /// </summary>
    public partial class PageAgEmpleado : Page
    {
        public PageAgEmpleado()
        {
            InitializeComponent();
        }
        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
    {
        txtID.Text = string.Empty;
        txtNombre.Text = string.Empty;
        txtTelefono.Text = string.Empty;

        cbGenero.SelectedIndex = -1;
        cbPosiscion.SelectedIndex = -1;
    }
    }
}
