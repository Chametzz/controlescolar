using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_Escolar_Consola.Entidades
{
    class Grupo
    {

        private int _Id_Grupo;
        private int _Id_Asignatura;
        private int _Id_Carrera;
        private int _Id_Docente;
        private int _Id_Aula;
        private string _CicloEscolar;
        private int _Capacidad;

        public int Id_Grupo { get => this._Id_Grupo; set => this._Id_Grupo = value; }
        public int Id_Asignatura { get => this._Id_Asignatura; set => this._Id_Asignatura = value; }
        public int Id_Carrera { get => this._Id_Carrera; set => this._Id_Carrera = value; }
        public int Id_Docente { get => this._Id_Docente; set => this._Id_Docente = value; }
        public int Id_Aula { get => this._Id_Aula; set => this._Id_Aula = value; }
        public string CicloEscolar { get => this._CicloEscolar; set => this._CicloEscolar = value; }
        public int Capacidad { get => this._Capacidad; set => this._Capacidad = value; }
    }
}
