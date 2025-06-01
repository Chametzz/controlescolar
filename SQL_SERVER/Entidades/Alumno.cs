using controlescolar;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Control_Escolar_Consola.Entidades
{
    class Alumno
    {
        private int _Id_Alumno;
        private Carrera _carrera;
        private string _Nombre;
        private string _ApellidoPaterno;
        private string _ApellidoMaterno;
        private string _CURP;
        private string _CorreoPersonal;
        private string _Telefono;
        private string _Direccion;
        private DateTime _FechaNacimiento;
        private string _Sexo;
        private string _TelefonoContac;
        private string _Nombre_Padre;
        private string _Apellido_Padre;
        private string _Nombre_Madre;
        private string _Apellido_Madre;
        private DateTime _FechaIngreso;
        private string _Matricula;
        private int _Semestre;
        private string _Estatus;
        private string _CorreoInstitucional;
        private double _PromedioGeneral;


        public int Id_Alumno { get => this._Id_Alumno; set => this._Id_Alumno = value; }
        public Carrera carrera { get => this._carrera; set => this._carrera = value;}
        public string Nombre { get => this._Nombre; set => this._Nombre = value; }
        public string Apellido_Paterno { get => this._ApellidoPaterno; set => this._ApellidoPaterno = value; }
        public string Apellido_Materno { get => this._ApellidoMaterno; set => this._ApellidoMaterno = value; }
        public string CURP { get => this._CURP; set => this._CURP = value; }
        public string CorreoPersonal { get => this._CorreoPersonal; set => this._CorreoPersonal = value; }
        public string Telefono { get => this._Telefono; set => this._Telefono = value; }
        public string Direccion { get => this._Direccion; set => this._Direccion = value; }
        public DateTime FechaNacimiento { get => this._FechaNacimiento; set => this._FechaNacimiento = value; }
        public string Sexo { get => this._Sexo; set => this._Sexo = value; }
        public string TelefonoContac { get => this._TelefonoContac; set => this._TelefonoContac = value; }
        public string Nombre_Padre { get => this._Nombre_Padre; set => this._Nombre_Padre = value; }
        public string Apellido_Padre { get => this._Apellido_Padre; set => this._Apellido_Padre = value; }
        public string Nombre_Madre { get => this._Nombre_Madre; set => this._Nombre_Madre = value; }
        public string Apellido_Madre { get => this._Apellido_Madre; set => this._Apellido_Madre = value; }
        public DateTime FechaIngreso { get => this._FechaIngreso; set => this._FechaIngreso = value; }
        public string Matricula { get => this._Matricula; set => this._Matricula = value; }
        public int Semestre { get => this._Semestre; set => this._Semestre = value; }
        public string Estatus { get => this._Estatus; set => this._Estatus = value; }
        public string CorreoInstitucional { get => this._CorreoInstitucional; set => this._CorreoInstitucional = value; }
        public double PromedioGeneral { get => this._PromedioGeneral; set => this._PromedioGeneral = value; }
    }

    class TableAlumno:connection
    {
        public static void InsertData(Alumno Obj)
        {
            Obj.Estatus = string.IsNullOrEmpty(Obj.Estatus) ? "Activo": Obj.Estatus;
            using (SqlConnection sql = new SqlConnection(conexion))
            {
                sql.Open();
                using (SqlCommand command = new SqlCommand(Insert, sql))
                {
                    command.Parameters.AddWithValue("@Id_Carrera", Obj.carrera.IdCarrera);
                    command.Parameters.AddWithValue("@Nombre", Obj.Nombre);
                    command.Parameters.AddWithValue("@ApellidoPaterno", Obj.Apellido_Paterno);
                    command.Parameters.AddWithValue("@ApellidoMaterno", Obj.Apellido_Materno);
                    command.Parameters.AddWithValue("@CURP", Obj.CURP);
                    command.Parameters.AddWithValue("@CorreoPersonal", Obj.CorreoPersonal);
                    command.Parameters.AddWithValue("@Telefono", Obj.Telefono);
                    command.Parameters.AddWithValue("@Dirreccion", Obj.Direccion);
                    command.Parameters.AddWithValue("@FechaNacimiento", Obj.FechaNacimiento);
                    command.Parameters.AddWithValue("@Sexo", Obj.Sexo);
                    command.Parameters.AddWithValue("@TelefonoContac", Obj.TelefonoContac);
                    command.Parameters.AddWithValue("@Nombre_Padre", Obj.Nombre_Padre);
                    command.Parameters.AddWithValue("@Apellido_Padre", Obj.Apellido_Padre);
                    command.Parameters.AddWithValue("@Nombre_Madre", Obj.Nombre_Madre);
                    command.Parameters.AddWithValue("@Apellido_Madre", Obj.Apellido_Madre);
                    command.Parameters.AddWithValue("@FechaIngreso", Obj.FechaIngreso);
                    command.Parameters.AddWithValue("@Semestre", Obj.Semestre);
                    command.Parameters.AddWithValue("@Estatus", Obj.Estatus);
                    command.Parameters.AddWithValue("@PromedioGeneral", Obj.PromedioGeneral);
                    Obj.Id_Alumno = (int)command.ExecuteScalar();
                    MatriculaAlumno(Obj, sql);
                    CorreroAlumno(Obj);
                }
            }
        }

        public static void ReadTable()
        {

        }

        public static void UpdateDate(Alumno Obj)
        {

        }

        public static void DeleteDate(Alumno Obj)
        {

        }


        public static string Insert = "Insert Into Alumno (Id_Carrera,Nombre,ApellidoPaterno,ApellidoMaterno,CURP,CorreoPersonal,Telefono,Dirreccion,FechaNacimiento,Sexo,TelefonoContac,Nombre_Padre,Apellido_Padre,Nombre_Madre,Apellido_Madre,FechaIngreso,Semestre,Estatus,PromedioGeneral) OUTPUT INSERTED.Id_Alumno VALUES (\r\n    @Id_Carrera,\r\n    @Nombre,\r\n    @ApellidoPaterno,\r\n    @ApellidoMaterno,\r\n    @CURP,\r\n    @CorreoPersonal,\r\n    @Telefono,\r\n    @Dirreccion,\r\n    @FechaNacimiento,\r\n    @Sexo,\r\n    @TelefonoContac,\r\n    @Nombre_Padre,\r\n    @Apellido_Padre,\r\n    @Nombre_Madre,\r\n    @Apellido_Madre,\r\n    @FechaIngreso,\r\n    @Semestre,\r\n    @Estatus,\r\n    @PromedioGeneral\r\n) ";



        private static void MatriculaAlumno(Alumno Obj,SqlConnection sql)
        {
            TableCarrera.ReadDate = TableCarrera.ReadTable();
            string carrera = TableCarrera.ReadDate[Obj.carrera.IdCarrera].Clave;
            string m = $"{carrera.Remove(3,carrera.Length - 3)}{DateTime.Now.Year}{Obj.Id_Alumno.ToString("D8")}ATCNM";
            Obj.Matricula = m;
            using (sql)
            {
                using (SqlCommand command = new SqlCommand($"Update Alumno SET Matricula = '{m}' WHERE Id_Alumno = {Obj.Id_Alumno}", sql))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private static void CorreroAlumno(Alumno Obj)
        {
            string correo = $"L{Obj.Matricula}@Tecnm.Acapulco.mx";
            using (SqlConnection sql = new SqlConnection(conexion))
            {
                sql.Open();
                using (SqlCommand command = new SqlCommand($"Update Alumno SET CorreoInstitucional = '{correo}' WHERE Id_Alumno = {Obj.Id_Alumno}", sql))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
