using controlescolar.Model.Conexiones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Serialization;
using Microsoft.Data.SqlClient;
using System.Windows;

namespace Control_Escolar_Consola.Entidades
{
    public class Empleado
    {


        public static Empleado ReadEmpleado(int IdEmpleado)
        {
            Empleado sesionActive = new Empleado();

            using (SqlConnection connection = new SqlConnection(Connection.CadenaConexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(ReadTable, connection))
                {
                    command.Parameters.AddWithValue("@IdEmpleado", IdEmpleado);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        sesionActive.Id = reader.GetInt32(0);
                        sesionActive.Nombre = reader.GetString(1);
                        sesionActive.Apellido = reader.GetString(2);
                        sesionActive.FechaNacimiento = reader.GetDateTime(3);
                        sesionActive.CURP = reader.GetString(4);
                        sesionActive.TelefonoPersonal = reader.GetString(5);
                        sesionActive.TelefonoContacto = reader.GetString(6);
                        sesionActive.CorreoPersonal = reader.GetString(7);
                        sesionActive.Direccion = reader.GetString(8);
                        sesionActive.CorreoCorporativo = reader.GetString(9);
                        sesionActive.FechaIngreso = reader.GetDateTime(10);
                        sesionActive.TipoEmpleado = reader.GetString(11);
                        sesionActive.Estatus = reader.GetString(12);
                        return sesionActive;
                    }
                }
            }
        }

        static string ReadTable = "SELECT * FROM Empleado WHERE Id = @IdEmpleado";

        private int _Id;
        private string _Nombre;
        private string _Apellido;
        private DateTime _FechaNacimiento;
        private string _CURP;
        private string _TelefonoPersonal;
        private string _TelefonoContacto;
        private string _CorreoPersonal;
        private string _Direccion;
        private string _CorreoCorporativo;
        private DateTime _FechaIngreso;
        private string _TipoEmpleado;
        private string _Estatus;


        public int Id { get => this._Id; set => this._Id = value; }
        public string Nombre { get => this._Nombre; set => this._Nombre = value; }
        public string Apellido { get => this._Apellido; set => this._Apellido = value; }
        public DateTime FechaNacimiento { get => this._FechaNacimiento; set => this._FechaNacimiento = value; }
        public string CURP { get => this._CURP; set => this._CURP = value; }
        public string TelefonoPersonal { get => this._TelefonoPersonal; set => this._TelefonoPersonal = value; }
        public string TelefonoContacto { get => this._TelefonoContacto; set => this._TelefonoContacto = value; }
        public string CorreoPersonal { get => this._CorreoPersonal; set => this._CorreoPersonal = value; }
        public string Direccion { get => this._Direccion; set => this._Direccion = value; }
        public string CorreoCorporativo { get => this._CorreoCorporativo; set => this._CorreoCorporativo = value; }
        public DateTime FechaIngreso { get => this._FechaIngreso; set => this._FechaIngreso = value; }
        public string TipoEmpleado { get => this._TipoEmpleado; set => this._TipoEmpleado = value; }
        public string Estatus { get => this._Estatus; set => this._Estatus = value; }
    }

    class JefeDepartamento
    {
        private Empleado _JefeEmpleado;
        private DateTime _FechaInicio;
        private DateTime _FechaFin;
        private bool _Estado;

        public Empleado JefeEmpleado { get => this._JefeEmpleado; set => this._JefeEmpleado = value; }
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
        private string _Puesto;
        private string _Nivel_Acceso;
        private string _Tipo_Contrato;

        public Empleado Personal_Administrativo { get => this._Personal_Administrativo; set => this._Personal_Administrativo = value; }
        public string Puesto { get => this._Puesto; set => this._Puesto = value; }
        public string Nivel_Acceso { get => this._Nivel_Acceso; set => this._Nivel_Acceso = value; }
        public string Tipo_Contrato { get => this._Tipo_Contrato; set => this._Tipo_Contrato = value; }
    }
}
