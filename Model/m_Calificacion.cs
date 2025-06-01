public class Calificacion
{
    public string Periodo { get; set; } = string.Empty;
    public int Id_Curso { get; set; }
    public int Id_Alumno { get; set; }
    public int? U1 { get; set; }
    public int? U2 { get; set; }
    public int? U3 { get; set; }
    public int? U4 { get; set; }
    public int? U5 { get; set; }
    public int? U6 { get; set; }

    public Calificacion() { }

    public Calificacion(string periodo, int idCurso, int idAlumno)
    {
        Periodo = periodo;
        Id_Curso = idCurso;
        Id_Alumno = idAlumno;
    }
}