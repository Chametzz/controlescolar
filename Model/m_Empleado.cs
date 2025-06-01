public class Empleado
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Horario { get; set; }
    public int? Telefono { get; set; }
    public string? Puesto { get; set; }
    public string? Correo { get; set; }
    public string? Contrasena { get; set; }
    public string? Usuario { get; set; }
    public string? Curp { get; set; }
    public string? Estatus { get; set; }

    public Empleado() { }

    public Empleado(string nombre)
    {
        Nombre = nombre;
    }
}