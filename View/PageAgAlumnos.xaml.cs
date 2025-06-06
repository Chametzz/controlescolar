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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;


namespace controlescolar
{
    public partial class PageAgAlumnos : Page
    {
        private ObservableCollection<Alumno> ListaAlumnos = new();

        public PageAgAlumnos()
        {
            InitializeComponent();
            CargarAlumnos();
        }
<<<<<<< HEAD
        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            
=======

        private void CargarAlumnos()
        {
            ListaAlumnos = new ObservableCollection<Alumno>(DB.Read<Alumno>());
            DatosAlumnos.ItemsSource = ListaAlumnos;
>>>>>>> cabdc23f1dc2a4837795291eb8e60b2f2aae5c24
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            try
            {
<<<<<<< HEAD
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
=======
                var data = HandOfGod.ExecuteSubmit(sender);
                Alumno alumno = new Alumno
                {
                    Nombre = $"{data["Nombre"]}",
                    ApellidoP = $"{data["ApellidoP"]}",
                    ApellidoM = $"{data["ApellidoM"]}",
                    FechaNac = DateTime.Parse($"{data["FechaNac"]}"),
                    Curp = $"{data["Curp"]}",
                    Sexo = $"{data["Sexo"]}",
                    Correo = $"{data["Correo"]}",
                    CorreoInst = $"{data["CorreoInst"]}",
                    Tel = $"{data["Tel"]}",
                    Direccion = $"{data["Direccion"]}",
                    NombrePadre = $"{data["NombrePadre"]}",
                    ApellidoPadre = $"{data["ApellidoPadre"]}",
                    NombreMadre = $"{data["NombreMadre"]}",
                    ApellidoMadre = $"{data["ApellidoMadre"]}",
                    Id_Carrera = int.TryParse($"{data["Id_Carrera"]}", out int carrera) ? carrera : null,
                    Semestre = int.TryParse($"{data["Semestre"]}", out int semestre) ? semestre : null,
                    FechaIng = DateTime.Parse($"{data["FechaIng"]}"),
                    Estado = $"{data["Estado"]}",
                    Contrasena = $"{data["Contrasena"]}"
                };

                DB.Create(alumno);
                MessageBox.Show("Alumno añadido correctamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                CargarAlumnos();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al añadir: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            foreach (var ctrl in HandOfGod.GetTagsWidgets(FormAdd))
            {
                switch (ctrl)
                {
                    case TextBox tb:
                        tb.Clear();
                        break;
                    case PasswordBox pb:
                        pb.Clear();
                        break;
                    case ComboBox cb:
                        cb.SelectedIndex = -1;
                        break;
                }
            }

            DatosAlumnos.UnselectAll();
        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            if (DatosAlumnos.SelectedItem is Alumno alumno)
            {
                if (MessageBox.Show("¿Estás seguro de eliminar este alumno?", "Confirmar", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    DB.Delete<Alumno>("Id = @Id", ("@Id", alumno.Id));
                    MessageBox.Show("Alumno eliminado.");
                    CargarAlumnos();
                    LimpiarFormulario();
                }
            }
            else
            {
                MessageBox.Show("Selecciona un alumno primero.");
            }
        }

        private void Actualizar_Click(object sender, RoutedEventArgs e)
        {
            if (DatosAlumnos.SelectedItem is Alumno alumno)
            {
                try
                {
                    var data = HandOfGod.ExecuteSubmit(sender);
                    DB.Update<Alumno>(
                        "Id = @Id",
                        "Nombre=@Nombre,ApellidoP=@ApellidoP,ApellidoM=@ApellidoM,FechaNac=@FechaNac,Curp=@Curp,Sexo=@Sexo,Correo=@Correo,CorreoInst=@CorreoInst,Tel=@Tel,Direccion=@Direccion,NombrePadre=@NombrePadre,ApellidoPadre=@ApellidoPadre,NombreMadre=@NombreMadre,ApellidoMadre=@ApellidoMadre,Id_Carrera=@Id_Carrera,Semestre=@Semestre,FechaIng=@FechaIng,Estado=@Estado,Contrasena=@Contrasena",
                        ("@Id", alumno.Id),
                        ("@Nombre", data["Nombre"]),
                        ("@ApellidoP", data["ApellidoP"]),
                        ("@ApellidoM", data["ApellidoM"]),
                        ("@FechaNac", DateTime.Parse($"{data["FechaNac"]}")),
                        ("@Curp", data["Curp"]),
                        ("@Sexo", data["Sexo"]),
                        ("@Correo", data["Correo"]),
                        ("@CorreoInst", data["CorreoInst"]),
                        ("@Tel", data["Tel"]),
                        ("@Direccion", data["Direccion"]),
                        ("@NombrePadre", data["NombrePadre"]),
                        ("@ApellidoPadre", data["ApellidoPadre"]),
                        ("@NombreMadre", data["NombreMadre"]),
                        ("@ApellidoMadre", data["ApellidoMadre"]),
                        ("@Id_Carrera", int.TryParse($"{data["Id_Carrera"]}", out int carrera) ? carrera : null),
                        ("@Semestre", int.TryParse($"{data["Semestre"]}", out int semestre) ? semestre : null),
                        ("@FechaIng", DateTime.Parse($"{data["FechaIng"]}")),
                        ("@Estado", data["Estado"]),
                        ("@Contrasena", data["Contrasena"])
                    );
                    MessageBox.Show("Alumno actualizado.");
                    CargarAlumnos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Selecciona un alumno para actualizar.");
            }
        }

        private void DatosAlumnos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DatosAlumnos.SelectedItem is Alumno alumno)
            {
                HandOfGod.SetTags(FormAdd, alumno);
            }
        }

        private void FiltroCampos_Changed(object sender, EventArgs e)
        {
            var filtros = HandOfGod.ExecuteSubmit(sender);

            var filtrados = ListaAlumnos.Where(a =>
                (string.IsNullOrWhiteSpace(filtros["Nombre"]?.ToString()) || a.Nombre.Contains(filtros["Nombre"].ToString(), StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrWhiteSpace(filtros["ApellidoP"]?.ToString()) || a.ApellidoP.Contains(filtros["ApellidoP"].ToString(), StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrWhiteSpace(filtros["ApellidoM"]?.ToString()) || a.ApellidoM.Contains(filtros["ApellidoM"].ToString(), StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrWhiteSpace(filtros["Curp"]?.ToString()) || a.Curp.Contains(filtros["Curp"].ToString(), StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrWhiteSpace(filtros["Correo"]?.ToString()) || a.Correo.Contains(filtros["Correo"].ToString(), StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrWhiteSpace(filtros["CorreoInst"]?.ToString()) || a.CorreoInst.Contains(filtros["CorreoInst"].ToString(), StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrWhiteSpace(filtros["Tel"]?.ToString()) || a.Tel.Contains(filtros["Tel"].ToString(), StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrWhiteSpace(filtros["Direccion"]?.ToString()) || a.Direccion.Contains(filtros["Direccion"].ToString(), StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrWhiteSpace(filtros["Estado"]?.ToString()) || a.Estado.Contains(filtros["Estado"].ToString(), StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrWhiteSpace(filtros["Sexo"]?.ToString()) || a.Sexo.Equals(filtros["Sexo"].ToString(), StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrWhiteSpace(filtros["Id_Carrera"]?.ToString()) || a.Id_Carrera?.ToString().Contains(filtros["Id_Carrera"].ToString()) == true) &&
                (string.IsNullOrWhiteSpace(filtros["Semestre"]?.ToString()) || a.Semestre?.ToString().Contains(filtros["Semestre"].ToString()) == true)
            ).ToList();

            DatosAlumnos.ItemsSource = filtrados;
>>>>>>> cabdc23f1dc2a4837795291eb8e60b2f2aae5c24
        }
    }
}