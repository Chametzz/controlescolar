using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_Escolar_Consola.Entidades
{
    class InscripcionGrupo
    {
        private int _Id_Inscripcion;
        private int _Id_Alumno;
        private int _Id_Grupo;
        private DateTime _FechaInscripcion;
        private string _Estado;
        private decimal _CalificacionFinal;

        public int Id_Inscripcion { get => this._Id_Inscripcion; set => this._Id_Inscripcion = value; }
        public int Id_Alumno { get => this._Id_Alumno; set => this._Id_Alumno = value; }
        public int Id_Grupo { get => this._Id_Grupo; set => this._Id_Grupo = value; }
        public DateTime FechaInscripcion { get => this._FechaInscripcion; set => this._FechaInscripcion = value; }
        public string Estado { get => this._Estado; set => this._Estado = value; }
        public decimal CalificacionFinal { get => this._CalificacionFinal; set => this._CalificacionFinal = value; }
    }
}
