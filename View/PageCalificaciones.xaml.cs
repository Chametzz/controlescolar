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
    /// Lógica de interacción para PageCalificaciones.xaml
    /// </summary>
    public partial class PageCalificaciones : Page
    {
        public PageCalificaciones()
        {
            InitializeComponent();
        }
        private void DescargarBoleta_Click(object sender, RoutedEventArgs e)
        {
        string periodo = ((ComboBoxItem)PeriodoCombo.SelectedItem)?.Content.ToString();

        if (periodo == "Seleccione periodo")
        {
        MessageBox.Show("Por favor, selecciona un período válido.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
        return;
        }

        // Aqui voy a poner para el pdf, que dios me ayude 
        MessageBox.Show($"Descargando boleta para el período: {periodo}", "Descarga", MessageBoxButton.OK, MessageBoxImage.Information);
}

        }
}
