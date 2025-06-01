public class Docente : Empleado
{
    public int? Id_Carrera { get; set; }
    public string? Contrato { get; set; }

    public Docente() { }

    public Docente(string nombre, string contrato) : base(nombre)
    {
        Contrato = contrato;
    }
}

