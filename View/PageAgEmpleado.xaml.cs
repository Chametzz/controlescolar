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
        DB.Create(new Empleado(
    data["Nombre"].ToString(),
    data["Apellido"].ToString(),
    DateTime.Parse(data["FechaNac"].ToString()!),
    data["Curp"].ToString(),
    data["Sexo"].ToString(),
    data["Correo"].ToString(),
    data["CorreoCorp"].ToString(),
    data["Tel"].ToString(),
    data["Direccion"].ToString(),
    DateTime.Now,                  
    "ALTA",                      
    data["Puesto"].ToString(),          data["Contrato"].ToString(),    
    data["Contrasena"].ToString(),  
    Convert.ToInt32(data["Departamento"]) 
));


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
