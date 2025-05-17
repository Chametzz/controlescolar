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
    /// Lógica de interacción para EstudiantePantalla.xaml
    /// </summary>
    public partial class EstudiantePantalla : Window
    {
        public EstudiantePantalla()
        {
            InitializeComponent();
        }

        private void BtnInicio_Click(object sender, RoutedEventArgs e)
        {
            AlumnoFrame.Navigate(new InicioE());
        }

        private void BtnEditarDatos_Click(object sender, RoutedEventArgs e)
        {
            AlumnoFrame.Navigate(new PageEditarDatos());
        }

        private void AlumnoFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }
    }
}
