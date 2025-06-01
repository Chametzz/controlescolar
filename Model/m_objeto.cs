public class Objeto
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public float Precio { get; set; }
    public bool Activo { get; set; }
    public DateTime FechaCreacion { get; set; }
    public double Porcentaje { get; set; }
    public string Inicial { get; set; } = string.Empty;
    public long Codigo { get; set; }
    public Objeto() { }

    // Constructor para creación (sin Id)
    public Objeto(string nombre, float precio, bool activo, DateTime fechaCreacion, double porcentaje, string inicial, long codigo)
    {
        Nombre = nombre;
        Precio = precio;
        Activo = activo;
        FechaCreacion = fechaCreacion;
        Porcentaje = porcentaje;
        Inicial = inicial;
        Codigo = codigo;
    }
}