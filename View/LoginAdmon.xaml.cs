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

namespace controlescolar
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class LoginAdmon : Window
    {
        public LoginAdmon()
        {
            InitializeComponent();
        }
        private void ButtonLogAdmon_Click(object sender, RoutedEventArgs e)
        {
            Administracion ventanaAdministracion = new Administracion();
            ventanaAdministracion.Show();
            this.Close();
        }
                private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Show();
            this.Close();
        }
    }
}
