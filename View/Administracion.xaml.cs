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
    /// Lógica de interacción para Administracion.xaml
    /// </summary>
    public partial class Administracion : Window
    {
        public Administracion()
        {
            InitializeComponent();
            AdmonFrame.Navigate(new PageAgEmpleado());
        }

        private void BtnAgEmpleado_Click(object sender, RoutedEventArgs e)
        {
            AdmonFrame.Navigate(new PageAgEmpleado());

        }
        private void BtnAgAlumno_Click(object sender, RoutedEventArgs e)
        {
            AdmonFrame.Navigate(new PageAgAlumnos());

        }


        private void BtnSalario_Click(object sender, RoutedEventArgs e)
        {
            AdmonFrame.Navigate(new PageEmpleados());
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Show();
            this.Close(); 
        }
    }
}
