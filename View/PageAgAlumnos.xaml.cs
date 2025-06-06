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
    /// Lógica de interacción para PageEmpleados.xaml
    /// </summary>
    public partial class PageAgAlumnos : Page
    {
        public PageAgAlumnos()
        {
            InitializeComponent();
        }
        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            var data = HandOfGod.ExecuteSubmit(sender, FormAdd);
            DB.Create(new Alumno(data["Nombre"].ToString(), data["ApellidoP"].ToString(), data["ApellidoM"].ToString(), DateTime.Parse(data["FechaNac"].ToString()!), data["Curp"].ToString(), data["Sexo"].ToString(), data["Correo"].ToString(), data["CorreoInst"].ToString(), data["Tel"].ToString(), data["Direccion"].ToString(), data["NombrePadre"].ToString(), data["ApellidoPadre"].ToString(), data["NombreMadre"].ToString(), data["ApellidoMadre"].ToString(), Convert.ToInt32(data["Carrera"]), data["Curp"].ToString()!, 1, DateTime.Now, "ALTA"));
        }
    }
}
