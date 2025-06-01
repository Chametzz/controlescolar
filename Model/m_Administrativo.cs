public class Administrativo : Empleado
{
    public int? Id_Carrera { get; set; }

    public Administrativo() { }

    public Administrativo(string nombre) : base(nombre)
    {
    }
}

