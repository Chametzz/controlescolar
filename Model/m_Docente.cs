public class Docente : Empleado
{
    //Agregamos datos a la clase.
    public int? Id_Carrera { get; set; }
    public string? Contrato { get; set; }
    public string? NumCtrl { get; set; }

    public Docente() { }

    public Docente(string nombre, string contrato) : base(nombre)
    {
        Contrato = contrato;
    }
}

