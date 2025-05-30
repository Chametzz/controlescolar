using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_Escolar_Consola.Entidades
{
    class Alumno
    {
        private int _Id_Alumno;
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
        private string _PromedioGeneral;


        public int Id_Alumno { get => this._Id_Alumno; set => this._Id_Alumno = value; }
        public string Nombre { get => this._Nombre; set => this._Nombre = value; }
        public string Apellido_Paterno { get => this._ApellidoPaterno; set => this._ApellidoPaterno = value; }
        public string Apellido_Materno { get => this._ApellidoMaterno; set => this._ApellidoMaterno = value; }
        public string CURP { get => this._CURP; set => this._CURP = value; }
        public string CorreoPersonal { get => this._CorreoPersonal; set => this._CorreoPersonal = value; }
        public string Telefono { get => this._Telefono; set => this._Telefono = value; }
        public string Direccion { get => this._Direccion; set => this._Direccion = value; }
        public DateTime FechaNacimiento { get => this._FechaNacimiento; set => this._FechaNacimiento = value; }
        public string Sexo { get => this._Sexo; set => this._Sexo = value; }
        public string TelefonoContac { get => this._TelefonoContac; set => this.TelefonoContac = value; }
        public string Nombre_Padre { get => this._Nombre_Padre; set => this._Nombre_Padre = value; }
        public string Apellido_Padre { get => this._Apellido_Padre; set => this._Apellido_Padre = value; }
        public string Nombre_Madre { get => this._Nombre_Madre; set => this._Nombre_Madre = value; }
        public string Apellido_Madre { get => this._Apellido_Madre; set => this._Apellido_Madre = value; }
        public DateTime FechaIngreso { get => this._FechaIngreso; set => this._FechaIngreso = value; }
        public string Matricula { get => this._Matricula; set => this._Matricula = value; }
        public int Semestre { get => this._Semestre; set => this._Semestre = value; }
        public string Estatus { get => this._Estatus; set => this._Estatus = value; }
        public string CorreoInstitucional { get => this._CorreoInstitucional; set => this._CorreoInstitucional = value; }
        public string PromedioGeneral { get => this._PromedioGeneral; set => this._PromedioGeneral = value; }
    }
}
