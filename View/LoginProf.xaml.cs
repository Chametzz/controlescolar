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
    public partial class LoginProf : Window
    {
        public LoginProf()
        {
            InitializeComponent();
        }
        private void ButtonLogprof_Click(object sender, RoutedEventArgs e)
        {
            Administracion ventanaEmpleados = new Administracion();
            ventanaEmpleados.Show(); 
            this.Close(); 
        }
    }
}
