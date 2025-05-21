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
            AlumnoFrame.Navigate(new InicioE());
        }

        private void BtnInicio_Click(object sender, RoutedEventArgs e)
        {
            AlumnoFrame.Navigate(new InicioE());
        }

        private void BtnEditarDatos_Click(object sender, RoutedEventArgs e)
        {
            AlumnoFrame.Navigate(new PageEditarDatos());
        }

        private void BtnHorario_Click(object sender, RoutedEventArgs e)
        {
            AlumnoFrame.Navigate(new PageHorario());

        }
        private void BtnCalificaciones_Click(object sender, RoutedEventArgs e)
        {
            AlumnoFrame.Navigate(new PageCalificaciones());

        }

        private void BtnKardex_Click(object sender, RoutedEventArgs e)
        {
            AlumnoFrame.Navigate(new PageKardex());
        }

        private void BtnHistoricos_Click(object sender, RoutedEventArgs e)
        {
            AlumnoFrame.Navigate(new PageHistoricos());
        }

        private void BtnRecibos_Click(object sender, RoutedEventArgs e)
        {
            AlumnoFrame.Navigate(new PageRecibos());
        }

        private void BtnCargaMateria_Click(object sender, RoutedEventArgs e)
        {
            AlumnoFrame.Navigate(new PageCargaMateria());
        }
        private void BtnTickets_Click(object sender, RoutedEventArgs e)
        {
            AlumnoFrame.Navigate(new PageTickets());
        }

    }
}
