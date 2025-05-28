using System.Windows;
using System.Collections.Generic;
using Control_Escolar_Consola.Entidades;

namespace controlescolar.View
{
    public partial class AsignaturasWindow : Window
    {
        public AsignaturasWindow()
        {
            InitializeComponent();
            CargarAsignaturas();
        }

        private void CargarAsignaturas()
        {
            List<Asignaturas> lista = AsignaturasTable.ObtenerAsignaturas();
            AsignaturasGrid.ItemsSource = lista;
        }

        private void Agregar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NombreBox.Text) ||
                string.IsNullOrWhiteSpace(ClaveBox.Text) ||
                string.IsNullOrWhiteSpace(CreditosBox.Text) ||
                string.IsNullOrWhiteSpace(CarreraBox.Text))
            {
                MessageBox.Show("Llena todos los campos obligatorios (Nombre, Clave, Créditos, Id Carrera).");
                return;
            }

            if (!int.TryParse(CreditosBox.Text, out int creditos) ||
                !int.TryParse(CarreraBox.Text, out int idCarrera))
            {
                MessageBox.Show("Créditos y Id Carrera deben ser números.");
                return;
            }

            Asignaturas nueva = new Asignaturas
            {
                Nombre = NombreBox.Text,
                ClaveMateria = ClaveBox.Text,
                Creditos = creditos,
                Id_Carrera = idCarrera,
                SemestreSugerido = SemestreBox.Text,
                TipoMateria = TipoBox.Text
            };

            AsignaturasTable.CrearAsignatura(nueva);

            MessageBox.Show("Asignatura agregada correctamente.");
            CargarAsignaturas();

            // Limpiar campos
            NombreBox.Text = "";
            ClaveBox.Text = "";
            CreditosBox.Text = "";
            CarreraBox.Text = "";
            SemestreBox.Text = "";
            TipoBox.Text = "";
        }
    }
}