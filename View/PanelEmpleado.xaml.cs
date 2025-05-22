using Control_Escolar_Consola.Entidades;
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

namespace controlescolar.View
{
    /// <summary>  
    /// Lógica de interacción para PanelEmpleado.xaml  
    /// </summary>  
    public partial class PanelEmpleado : Window
    {
        public PanelEmpleado(Empleado sesionActive)
        {
            InitializeComponent();
            empleoye = sesionActive;
            DtFechanacimento.Text = empleoye.FechaNacimiento.ToString("yyyy-MM-dd");
            DtCurp.Text = empleoye.CURP;
            DtTelefonoPersonal.Text = empleoye.TelefonoPersonal;
            DtContacto.Text = empleoye.TelefonoContacto;
            DtCorreoElectronica.Text = empleoye.CorreoPersonal;
            DtTipoEmpleado.Text = empleoye.TipoEmpleado;
            NameUser.Text = $"{sesionActive.Nombre} {sesionActive.Apellido}";
        }

        private void BtnDatos_Click(object sender, RoutedEventArgs e)
        {
            ModelOverlay.Visibility = Visibility.Visible;
        }

        private void Closepanel_Click(object sender, RoutedEventArgs e)
        {
            ModelOverlay.Visibility = Visibility.Collapsed;
        }

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }

        Empleado empleoye;

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
             // Aqui se colocan los tooltip mediante la condicion de la cual si el boton Tg esta activo no mostrara el Tool tip:
            if (Tg_Btn.IsChecked == true)
            {
               tt_Asignaturas.Visibility = Visibility.Collapsed;
               tt_GtCalificaciones.Visibility = Visibility.Collapsed;
               tt_HorarioClases.Visibility = Visibility.Collapsed;
               tt_Reportes.Visibility = Visibility.Collapsed;
            }
            else
            {
                tt_Asignaturas.Visibility = Visibility.Visible;
                tt_GtCalificaciones.Visibility = Visibility.Visible;
                tt_HorarioClases.Visibility = Visibility.Visible;
                tt_Reportes.Visibility = Visibility.Visible;
            }
        }

        private void ListViewItem_Selected(object sender, SelectionChangedEventArgs e)
        {
            if (LV.SelectedItem is ListViewItem item)
            {
                string nombre = item.Name; // Este es el x:Name="Item_Asignaturas"
                MessageBox.Show("Seleccionaste: " + nombre);
            }
        }
    }
}
