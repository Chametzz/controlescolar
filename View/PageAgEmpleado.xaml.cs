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
using System.Collections.ObjectModel;

namespace controlescolar
{
    /// <summary>
    /// Lógica de interacción para PageEmpleados.xaml
    /// </summary>
    public partial class PageAgEmpleado : Page
    {
        private ObservableCollection<Empleado> ListaEmpleados = new();
        public PageAgEmpleado()
        {
            InitializeComponent();
            CargarEmpleados();
        }

        private void CargarEmpleados()
        {
            ListaEmpleados = new ObservableCollection<Empleado>(DB.Read<Empleado>());
            DatosEmpleado.ItemsSource = ListaEmpleados;
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            try
            {
                var data = HandOfGod.ExecuteSubmit(sender);
                Empleado emp = new Empleado
                {
                    Nombre = $"{data["Nombre"]}",
                    Apellido = $"{data["Apellido"]}",
                    FechaNac = DateTime.Parse($"{data["FechaNac"]}"),
                    Curp = $"{data["Curp"]}",
                    Sexo = $"{data["Sexo"]}",
                    Correo = $"{data["Correo"]}",
                    CorreoCorp = $"{data["CorreoCorp"]}",
                    Tel = $"{data["Tel"]}",
                    Direccion = $"{data["Direccion"]}",
                    FechaIng = DateTime.Parse($"{data["FechaIng"]}"),
                    Puesto = $"{data["Puesto"]}",
                    Estado = $"{data["Estado"]}",
                    Contrato = $"{data["Contrato"]}",
                    Contrasena = $"{data["Contrasena"]}",
                    Id_Departamento = int.TryParse($"{data["Departamento"]}", out int idDepto) ? idDepto : null
                };

                DB.Create(emp);
                MessageBox.Show("Empleado añadido correctamente", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                CargarEmpleados();
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

            DatosEmpleado.UnselectAll();
        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            if (DatosEmpleado.SelectedItem is Empleado emp)
            {
                if (MessageBox.Show("¿Estás seguro de eliminar este empleado?", "Confirmar", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    DB.Delete<Empleado>("Id = @Id", ("@Id", emp.Id));
                    MessageBox.Show("Empleado eliminado.");
                    CargarEmpleados();
                    LimpiarFormulario();
                }
            }
            else
            {
                MessageBox.Show("Selecciona un empleado primero.");
            }
        }

        private void Actualizar_Click(object sender, RoutedEventArgs e)
        {
            if (DatosEmpleado.SelectedItem is Empleado emp)
            {
                try
                {
                    var data = HandOfGod.ExecuteSubmit(sender);
                    DB.Update<Empleado>(
                        "Id = @Id",
                        "Nombre=@Nombre,Apellido=@Apellido,FechaNac=@FechaNac,Curp=@Curp,Sexo=@Sexo,Correo=@Correo,CorreoCorp=@CorreoCorp,Tel=@Tel,Direccion=@Direccion,FechaIng=@FechaIng,Puesto=@Puesto,Estado=@Estado,Contrato=@Contrato,Contrasena=@Contrasena,Id_Departamento=@Departamento",
                        ("@Id", emp.Id),
                        ("@Nombre", data["Nombre"]),
                        ("@Apellido", data["Apellido"]),
                        ("@FechaNac", DateTime.Parse($"{data["FechaNac"]}")),
                        ("@Curp", data["Curp"]),
                        ("@Sexo", data["Sexo"]),
                        ("@Correo", data["Correo"]),
                        ("@CorreoCorp", data["CorreoCorp"]),
                        ("@Tel", data["Tel"]),
                        ("@Direccion", data["Direccion"]),
                        ("@FechaIng", DateTime.Parse($"{data["FechaIng"]}")),
                        ("@Puesto", data["Puesto"]),
                        ("@Estado", data["Estado"]),
                        ("@Contrato", data["Contrato"]),
                        ("@Contrasena", data["Contrasena"]),
                        ("@Departamento", int.TryParse($"{data["Departamento"]}", out int idDepto) ? idDepto : null)
                    );
                    MessageBox.Show("Empleado actualizado.");
                    CargarEmpleados();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Selecciona un empleado para actualizar.");
            }
        }

        private void DatosEmpleado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DatosEmpleado.SelectedItem is Empleado emp)
            {
                HandOfGod.SetTags(FormAdd, emp);
            }
        }
        private void FiltroCampos_Changed(object sender, EventArgs e)
        {
            // Obtenemos los valores actuales del formulario
            var filtros = HandOfGod.ExecuteSubmit(sender);

            // Filtramos la lista base de empleados
            var empleadosFiltrados = ListaEmpleados.Where(emp =>
                (string.IsNullOrWhiteSpace(filtros["Nombre"]?.ToString()) || emp.Nombre.Contains(filtros["Nombre"].ToString(), StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrWhiteSpace(filtros["Apellido"]?.ToString()) || emp.Apellido.Contains(filtros["Apellido"].ToString(), StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrWhiteSpace(filtros["Curp"]?.ToString()) || emp.Curp.Contains(filtros["Curp"].ToString(), StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrWhiteSpace(filtros["Correo"]?.ToString()) || emp.Correo.Contains(filtros["Correo"].ToString(), StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrWhiteSpace(filtros["CorreoCorp"]?.ToString()) || emp.CorreoCorp.Contains(filtros["CorreoCorp"].ToString(), StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrWhiteSpace(filtros["Tel"]?.ToString()) || emp.Tel.Contains(filtros["Tel"].ToString(), StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrWhiteSpace(filtros["Direccion"]?.ToString()) || emp.Direccion.Contains(filtros["Direccion"].ToString(), StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrWhiteSpace(filtros["Puesto"]?.ToString()) || emp.Puesto.Contains(filtros["Puesto"].ToString(), StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrWhiteSpace(filtros["Estado"]?.ToString()) || emp.Estado.Contains(filtros["Estado"].ToString(), StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrWhiteSpace(filtros["Contrato"]?.ToString()) || emp.Contrato.Contains(filtros["Contrato"].ToString(), StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrWhiteSpace(filtros["Sexo"]?.ToString()) || emp.Sexo.Equals(filtros["Sexo"].ToString(), StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrWhiteSpace(filtros["Departamento"]?.ToString()) || emp.Id_Departamento?.ToString().Contains(filtros["Departamento"].ToString()) == true)
            ).ToList();

            // Actualizamos el DataGrid
            DatosEmpleado.ItemsSource = empleadosFiltrados;
        }

    }

}

