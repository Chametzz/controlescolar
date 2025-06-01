public class Curso
{
    public int Id { get; set; }
    public int? Id_Carrera { get; set; }
    public int? Id_Docente { get; set; }
    public double? Inicio_Clase { get; set; }
    public int? Id_Materia { get; set; }
    public int? Capacidad { get; set; }
    public int? Creditos { get; set; }
    public double? Final_Clase { get; set; }

    public Curso() { }

    public Curso(int idMateria, int idDocente)
    {
        Id_Materia = idMateria;
        Id_Docente = idDocente;
    }
}