using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Lógica de interacción para PageHorario.xaml
    /// </summary>
    public partial class PageHorario : Page
    {
        public ObservableCollection<HorarioFila> hs { get; set; }
        public PageHorario()
        {
            hs = [];
            InitializeComponent();
            List<Calificacion> cals = DB.Read<Calificacion>(x => x.Id_Alumno == BolsaGlobal.AlumnoLogueado!.Id);
            List<Curso> cursos = [];
            foreach (var item in cals)
            {
                cursos.AddRange(DB.Read<Curso>($"Id = {item.Id_Curso}"));
            }
            List<Horario> hors = [];
            foreach (var item in cursos)
            {
                hors.AddRange(DB.Read<Horario>($"Id_Curso = {item.Id}"));
            }
            foreach (var item in hors)
            {
                Curso c = DB.ReadFirst<Curso>($"Id = {item.Id_Curso}")!;
                Materia m = DB.ReadFirst<Materia>($"Id = {c.Id_Materia}")!;
                Empleado e = DB.ReadFirst<Empleado>($"Id = {c.Id_Docente}")!;
                if (c != null)
                {
                    /*hs.Add(new HorarioFila
                    {
                        Hora = $"{item.HoraInicio:HH:mm} - {item.HoraFin:HH:mm}",
                        Materia = m.Nombre,
                        Docente = $"{e.Nombre} {e.Apellido}",
                        Creditos = c.Creditos

                    });*/

                    AgregarHorario(
                        $"{item.HoraInicio:HH:mm} - {item.HoraFin:HH:mm}",
                        m.Nombre,
                        $"{e.Nombre} {e.Apellido}",
                        c.Creditos,
                        DiasAEnumeracion([item.Dia])
                    );
                }
                
            }
            MatrizHorarios.ItemsSource = hs;

        }
        public static DayOfWeek[] DiasAEnumeracion(IEnumerable<string> diasEnEspañol)
        {
            var mapa = new Dictionary<string, DayOfWeek>(StringComparer.OrdinalIgnoreCase)
            {
                { "domingo", DayOfWeek.Sunday },
                { "lunes", DayOfWeek.Monday },
                { "martes", DayOfWeek.Tuesday },
                { "miércoles", DayOfWeek.Wednesday },
                { "miercoles", DayOfWeek.Wednesday }, // por si no llevan tilde
                { "jueves", DayOfWeek.Thursday },
                { "viernes", DayOfWeek.Friday },
                { "sábado", DayOfWeek.Saturday },
                { "sabado", DayOfWeek.Saturday } // sin tilde también
            };

            return diasEnEspañol
                .Select(dia => 
                    mapa.TryGetValue(dia.Trim().ToLower(), out var day) 
                    ? day 
                    : throw new ArgumentException($"Día inválido: {dia}")
                )
                .ToArray();
        }
        public void AgregarHorario(string hora, string materia, string docente, int creditos, params DayOfWeek[] dias)
        {
            var nuevaFila = new HorarioFila
            {
                Hora = hora,
                Materia = materia,
                Docente = docente,
                Creditos = creditos
            };

            foreach (var dia in dias)
            {
                switch (dia)
                {
                    case DayOfWeek.Monday: nuevaFila.Lun = true; break;
                    case DayOfWeek.Tuesday: nuevaFila.Mar = true; break;
                    case DayOfWeek.Wednesday: nuevaFila.Mie = true; break;
                    case DayOfWeek.Thursday: nuevaFila.Jue = true; break;
                    case DayOfWeek.Friday: nuevaFila.Vie = true; break;
                    case DayOfWeek.Saturday: nuevaFila.Sab = true; break;
                    case DayOfWeek.Sunday: nuevaFila.Dom = true; break;
                }
            }

            hs.Add(nuevaFila);
        }

        private void MatrizHorarios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
    /*public partial class PageHorario : Page
    {
        public PageHorario()
        {
            InitializeComponent();
            CargarHorarioReal();
        }

        private void CargarHorarioReal()
        {
            var horarios = DB.Read<Horario>();
            var cursos = DB.Read<Curso>();
            var materias = DB.Read<Materia>();

            foreach (var horario in horarios)
            {
                var curso = cursos.FirstOrDefault(c => c.Id == horario.Id_Curso);
                if (curso == null) continue;

                var materia = materias.FirstOrDefault(m => m.Id == curso.Id_Materia);
                if (materia == null) continue;

                string dia = ObtenerDiaSemana(horario.Dia);
                string horaInicio = horario.HoraInicio.ToString("HH:mm");
                string horaFin = horario.HoraFin.ToString("HH:mm");

                AsignarDatosAControl(
                    dia: dia,
                    horaInicio: horaInicio,
                    horaFin: horaFin,
                    nombreMateria: materia.Nombre,
                    aula: $"Aula: Curso {curso.Id}",
                    paquete: $"Créditos: {curso.Creditos}"
                );
            }
        }
        private string ObtenerDiaSemana(int diaNumero)
        {
            return diaNumero switch
            {
                1 => "Lun",
                2 => "Mar",
                3 => "Mie",
                4 => "Jue",
                5 => "Vie",
                6 => "Sab",
                7 => "Dom",
                _ => "??"
            };
        }
        private void AsignarDatosAControl(string dia, string horaInicio, string horaFin, string nombreMateria, string aula, string paquete)
        {
            int fila = ObtenerFilaDesdeHora(horaInicio);
            int columna = ObtenerColumnaDesdeDia(dia);

            if (fila == -1 || columna == -1) return;

            Border border = FindName($"materia{fila}") as Border;
            if (border == null) return;

            StackPanel stackPanel = border.Child as StackPanel;
            if (stackPanel != null)
            {
                foreach (TextBlock textBlock in stackPanel.Children)
                {
                    switch (textBlock.Tag?.ToString())
                    {
                        case string tag when tag.Contains("Nom"):
                            textBlock.Text = nombreMateria;
                            break;
                        case string tag when tag.Contains("Aula"):
                            textBlock.Text = aula;
                            break;
                        case string tag when tag.Contains("Paqt"):
                            textBlock.Text = paquete;
                            break;
                        case string tag when tag.Contains("Hr"):
                            textBlock.Text = $"{horaInicio}-{horaFin}";
                            break;
                    }
                }
            }
        }
        private int ObtenerFilaDesdeHora(string hora)
        {
            return hora switch
            {
                "07:00" => 1,
                "08:00" => 2,
                "09:00" => 3,
                "10:00" => 4,
                "11:00" => 5,
                "12:00" => 6,
                _ => -1
            };
        }
        private int ObtenerColumnaDesdeDia(string dia)
        {
            return dia.ToUpper() switch
            {
                "LUN" => 1,
                "MAR" => 2,
                "MIE" => 3,
                "JUE" => 4,
                "VIE" => 5,
                "SAB" => 6,
                "DOM" => 7,
                _ => -1
            };
        }
    }*/
}
