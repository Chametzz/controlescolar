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
    /// Lógica de interacción para PageHorario.xaml
    /// </summary>
    public partial class PageHorario : Page
    {
        public PageHorario()
        {
            InitializeComponent();
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
