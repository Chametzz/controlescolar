using Docentes_pantalla;
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
    /// Lógica de interacción para PantallaDocentes.xaml
    /// </summary>
    public partial class PantallaDocentes : Window
    {
        public PantallaDocentes()
        {
            InitializeComponent();
            DocenteFrame.Navigate(new PageInicioDo());
        }

        private void BtnInicio_Click(object sender, RoutedEventArgs e)
        {
            DocenteFrame.Navigate(new PageInicioDo());

        }

        private void BtnAggCal_Click(object sender, RoutedEventArgs e)
        {
            DocenteFrame.Navigate(new PageAggCal());

        }
    }
}
