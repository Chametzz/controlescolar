public class Alumno
{
    public int Id { get; set; }
    public int? NumCtrl { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string? Direccion { get; set; }
    public int? Edad { get; set; }
    public int? Telefono { get; set; }
    public string? Curp { get; set; }
    public string? Status { get; set; }
    public int? Id_Carrera { get; set; }
    public string? Contrasena { get; set; }
    public string? Correo_Inst { get; set; }
    public int? Creditos { get; set; }

    public Alumno() {}
    public Alumno(
        int numCtrl,
        string nombre,
        string direccion,
        int edad,
        int telefono,
        string curp,
        string status,
        int? id_Carrera,
        string contrasena,
        string correo_Inst,
        int creditos
    )
    {
        NumCtrl = numCtrl;
        Nombre = nombre;
        Direccion = direccion;
        Edad = edad;
        Telefono = telefono;
        Curp = curp;
        Status = status;
        Id_Carrera = id_Carrera;
        Contrasena = contrasena;
        Correo_Inst = correo_Inst;
        Creditos = creditos;
    }
}