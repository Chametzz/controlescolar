using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_Escolar_Consola.Entidades
{
    public class Empleado
    {
        private int _Id;
        private string _Id_Empleado;
        private string _Nombre;
        private string _Apellido_Paterno;
        private string _Apellido_Materno;
        private DateTime _FechaNacimiento;
        private string _CURP;
        private string _TelefonoPersonal;
        private string _TelefonoContacto;
        private string _CorreoPersonal;
        private string _Estado;
        private string _Municipio;
        private string _Ciudad;
        private string _Codigo_Postal;
        private string _Colonia;
        private string _Calle;
        private string _Numero_Exterior;
        private string _Numero_Interior;
        private string _Telefono_Casa;
        private string _CorreoCorporativo;
        private DateTime _FechaIngreso;
        private string _TipoEmpleado;
        private string _Estatus;


        public int Id { get => this._Id; set => this._Id = value; }
        public string Id_Empleado { get => this._Id_Empleado; set => this._Id_Empleado = value; }
        public string Nombre { get => this._Nombre; set => this._Nombre = value; }
        public string ApellidoParterno { get => this._Apellido_Paterno; set => this._Apellido_Paterno = value; }
        public string ApellidoMaterno { get => this._Apellido_Materno; set => this._Apellido_Materno = value; }
        public DateTime FechaNacimiento { get => this._FechaNacimiento; set => this._FechaNacimiento = value; }
        public string CURP { get => this._CURP; set => this._CURP = value; }
        public string TelefonoPersonal { get => this._TelefonoPersonal; set => this._TelefonoPersonal = value; }
        public string TelefonoContacto { get => this._TelefonoContacto; set => this._TelefonoContacto = value; }
        public string CorreoPersonal { get => this._CorreoPersonal; set => this._CorreoPersonal = value; }
        public string Estado { get => this._Estado; set => this._Estado = value; }
        public string Municipio { get => this._Municipio; set => this._Municipio = value; }
        public string Ciudad { get => this._Ciudad; set => this._Ciudad = value; }
        public string Codigo_Postal { get => this._Codigo_Postal; set => this._Codigo_Postal = value; }
        public string Colonia { get => this._Colonia; set => this._Colonia = value; }
        public string Calle { get => this._Calle; set => this._Calle = value; }
        public string Numero_Exterior { get => this._Numero_Exterior; set => this._Numero_Exterior = value; }
        public string Numero_Interior { get => this._Numero_Interior; set => this._Numero_Interior = value; }
        public string Telefono_Casa { get => this._Telefono_Casa; set => this._Telefono_Casa = value; }
        public string CorreoCorporativo { get => this._CorreoCorporativo; set => this._CorreoCorporativo = value; }
        public DateTime FechaIngreso { get => this._FechaIngreso; set => this._FechaIngreso = value; }
        public string TipoEmpleado { get => this._TipoEmpleado; set => this._TipoEmpleado = value; }
        public string Estatus { get => this._Estatus; set => this._Estatus = value; }
    }

    class JefeDepartamento
    {
        private Empleado _Empleado;
        private Departamentos _Departamento;
        private DateTime _FechaInicio;
        private DateTime _FechaFin;
        private bool _Estado;

        public Empleado Empleado { get => this._Empleado; set => this._Empleado = value; }
        public Departamentos Departamento { get => this._Departamento; set => this._Departamento = value; }
        public DateTime FechaInicio { get => this._FechaInicio; set => this._FechaInicio = value; }
        public DateTime FechaFin { get => this._FechaFin; set => this._FechaFin = value; }
        public bool Estado { get => this._Estado; set => this._Estado = value; }
    }

    class Docentes
    {
        private Empleado _Docente;
        private int _Asignatura;
        private string _Tipo_Contratro;

        public Empleado Docente { get => this._Docente; set => this._Docente = value; }
        public int Asignatura { get => this._Asignatura; set => this._Asignatura = value; }
        public string Tipo_COntrato { get => this._Tipo_Contratro; set => this._Tipo_Contratro = value; }

    }

    class PersonaLimpieza
    {
        private Empleado _Personal_Limpieza;
        private string _Tipo_Contratro;
        private string _Zona_Asignada;

        public Empleado Personal_Limpieza { get => this._Personal_Limpieza; set => this._Personal_Limpieza = value; }
        public string Tipo_Contratro { get => this._Tipo_Contratro; set => this._Tipo_Contratro = value; }
        public string Zona_Asignada { get => this._Zona_Asignada; set => this._Zona_Asignada = value; }
    }

    class PersonalMatenimiento
    {
        private Empleado _Personal_Matenimiento;
        private string _Especialidad;
        private string _Area_Mantenimiento;

        public Empleado Personal_Mantenimiento { get => this._Personal_Matenimiento; set => this._Personal_Matenimiento = value; }
        public string Especialidad { get => this._Especialidad; set => this._Especialidad = value; }
        public string Area_Mantenimiento { get => this._Area_Mantenimiento; set => this._Area_Mantenimiento = value; }
    }

    class PersonalAdministrativo
    {
        private Empleado _Personal_Administrativo;
        private Departamentos _departamento;
        private string _Puesto;
        private string _Nivel_Acceso;
        private string _Tipo_Contrato;

        public Empleado Personal_Administrativo { get => this._Personal_Administrativo; set => this._Personal_Administrativo = value; }
        public Departamentos departamento { get => this._departamento; set => this._departamento = value; }
        public string Puesto { get => this._Puesto; set => this._Puesto = value; }
        public string Nivel_Acceso { get => this._Nivel_Acceso; set => this._Nivel_Acceso = value; }
        public string Tipo_Contrato { get => this._Tipo_Contrato; set => this._Tipo_Contrato = value; }
    }
}
