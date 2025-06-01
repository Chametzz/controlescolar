public class Materia
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public int Unidades { get; set; }

    public Materia() { }

    public Materia(string nombre, int unidades)
    {
        Nombre = nombre;
        Unidades = unidades;
    }
}

