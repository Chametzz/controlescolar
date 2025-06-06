public class Departamento
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Clave { get; set; } = string.Empty;
    public bool Activo { get; set; }

    public Departamento() { }

    public Departamento(string nombre, string clave, bool activo)
    {
        Nombre = nombre;
        Clave = clave;
        Activo = activo;
    }
}

public class Empleado
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public DateTime FechaNac { get; set; }
    public string Curp { get; set; } = string.Empty;
    public string Sexo { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public string CorreoCorp { get; set; } = string.Empty;
    public string Tel { get; set; } = string.Empty;
    public string Direccion { get; set; } = string.Empty;
    public DateTime FechaIng { get; set; }
    public string Puesto { get; set; } = string.Empty;
    public string Estado { get; set; } = string.Empty;
    public string Contrato { get; set; } = string.Empty;
    public string Contrasena { get; set; } = string.Empty;
    public int? Id_Departamento { get; set; }

    public Empleado() { }

    public Empleado(string nombre, string apellido, DateTime fechaNac, string curp, string sexo, 
                   string correo, string correoCorp, string tel, string direccion, 
                   DateTime fechaIng, string estado, string puesto, string contrato, string contrasena, int? idDepartamento)
    {
        Nombre = nombre;
        Apellido = apellido;
        FechaNac = fechaNac;
        Curp = curp;
        Sexo = sexo;
        Correo = correo;
        CorreoCorp = correoCorp;
        Tel = tel;
        Direccion = direccion;
        FechaIng = fechaIng;
        Estado = estado;
        Puesto = puesto;
        Contrato = contrato;
        Contrasena = contrasena;
        Id_Departamento = idDepartamento;
    }
}

public class Carrera
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public int Semestres { get; set; }
    public int TotalCreditos { get; set; }

    public Carrera() { }

    public Carrera(string nombre, int semestres, int totalCreditos)
    {
        Nombre = nombre;
        Semestres = semestres;
        TotalCreditos = totalCreditos;
    }
}

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

public class Alumno
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string ApellidoP { get; set; } = string.Empty;
    public string ApellidoM { get; set; } = string.Empty;
    public DateTime FechaNac { get; set; }
    public string Curp { get; set; } = string.Empty;
    public string Sexo { get; set; } = string.Empty;
    public string Correo { get; set; } = string.Empty;
    public string CorreoInst { get; set; } = string.Empty;
    public string Tel { get; set; } = string.Empty;
    public string Direccion { get; set; } = string.Empty;
    public string NombrePadre { get; set; } = string.Empty;
    public string ApellidoPadre { get; set; } = string.Empty;
    public string NombreMadre { get; set; } = string.Empty;
    public string ApellidoMadre { get; set; } = string.Empty;
    public int Id_Carrera { get; set; }
    public string Contrasena { get; set; } = string.Empty;
    public int Semestre { get; set; }
    public DateTime FechaIng { get; set; }
    public string Estado { get; set; } = string.Empty;

    public Alumno() { }

    public Alumno(string nombre, string apellidoP, string apellidoM,
                 DateTime fechaNac, string curp, string sexo, string correo,
                 string correoInst, string tel, string direccion, string nombrePadre,
                 string apellidoPadre, string nombreMadre, string apellidoMadre,
                 int idCarrera, string contrasena, int semestre, DateTime fechaIng, string estado)
    {
        Nombre = nombre;
        ApellidoP = apellidoP;
        ApellidoM = apellidoM;
        FechaNac = fechaNac;
        Curp = curp;
        Sexo = sexo;
        Correo = correo;
        CorreoInst = correoInst;
        Tel = tel;
        Direccion = direccion;
        NombrePadre = nombrePadre;
        ApellidoPadre = apellidoPadre;
        NombreMadre = nombreMadre;
        ApellidoMadre = apellidoMadre;
        Id_Carrera = idCarrera;
        Contrasena = contrasena;
        Semestre = semestre;
        FechaIng = fechaIng;
        Estado = estado;
    }
}

public class Curso
{
    public int Id { get; set; }
    public int Id_Carrera { get; set; }
    public int Id_Materia { get; set; }
    public int? Id_Docente { get; set; }
    public int Capacidad { get; set; }
    public int Creditos { get; set; }
    public string Periodo { get; set; } = string.Empty;

    public Curso() { }

    public Curso(int idCarrera, int idMateria, int? idDocente, int capacidad, 
                int creditos, string periodo)
    {
        Id_Carrera = idCarrera;
        Id_Materia = idMateria;
        Id_Docente = idDocente;
        Capacidad = capacidad;
        Creditos = creditos;
        Periodo = periodo;
    }
}

public class Horario
{
    public int Id { get; set; }
    public int Id_Curso { get; set; }
    public string Dia { get; set; } = String.Empty;
    public DateTime HoraInicio { get; set; }
    public DateTime HoraFin { get; set; }

    public Horario() { }

    public Horario(int idCurso, string dia, DateTime horaInicio, DateTime horaFin)
    {
        Id_Curso = idCurso;
        Dia = dia;
        HoraInicio = horaInicio;
        HoraFin = horaFin;
    }
}

public class Calificacion
{
    public int Id { get; set; }
    public int Id_Alumno { get; set; }
    public int Id_Curso { get; set; }
    public int? U1 { get; set; }
    public int? U2 { get; set; }
    public int? U3 { get; set; }
    public int? U4 { get; set; }
    public int? U5 { get; set; }
    public int? U6 { get; set; }

    public Calificacion() { }

    public Calificacion(int idAlumno, int idCurso, int? u1, int? u2, int? u3,
                       int? u4, int? u5, int? u6)
    {
        Id_Alumno = idAlumno;
        Id_Curso = idCurso;
        U1 = u1;
        U2 = u2;
        U3 = u3;
        U4 = u4;
        U5 = u5;
        U6 = u6;
    }
}

public class Kardex
{
    public int Id { get; set; }
    public int Id_Carrera { get; set; }
    public int Id_Materia { get; set; }
    public int Semestre { get; set; }
    public Kardex() { }
    public Kardex(int idCarrera, int idMateria, int semestre)
    {
        Id_Carrera = idCarrera;
        Id_Materia = idMateria;
        Semestre = semestre;
    }
}