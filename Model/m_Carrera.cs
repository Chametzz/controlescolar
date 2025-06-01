public class Carrera
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public int? Semestre { get; set; }

    public Carrera() { }

    public Carrera(string nombre)
    {
        Nombre = nombre;
    }
}