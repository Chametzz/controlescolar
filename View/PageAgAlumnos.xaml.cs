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
            /*txtControl.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtTelefono.Text = string.Empty;

            cbGenero.SelectedIndex = -1;
            cbGrupo.SelectedIndex = -1;*/
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            try
            {
                var data = HandOfGod.ExecuteSubmit(sender, FormAdd);
                data.Add("Id_Carrera", data["Carrera"]);
                data.Add("Semestre", 1);
                data.Add("FechaIng", DateTime.Now);
                data.Add("Estado", "ALTA");
                var item = HandOfGod.GetObject<Alumno>(data!);
                DB.Create(item);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Problema al registrar: {ex}");
            }
            
            /*DB.Create(new Alumno(data["Nombre"].ToString(), data["ApellidoP"].ToString(), data["ApellidoM"].ToString(), DateTime.Parse(data["FechaNac"].ToString()!), data["Curp"].ToString(), data["Sexo"].ToString(), data["Correo"].ToString(), data["CorreoInst"].ToString(), data["Tel"].ToString(), data["Direccion"].ToString(), data["NombrePadre"].ToString(), data["ApellidoPadre"].ToString(), data["NombreMadre"].ToString(), data["ApellidoMadre"].ToString(), Convert.ToInt32(data["Carrera"]), data["Curp"].ToString()!, 1, DateTime.Now, "ALTA"));*/
        }
    }
}
