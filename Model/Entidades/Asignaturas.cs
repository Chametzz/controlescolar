using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_Escolar_Consola.Entidades
{
    class Asignaturas
    {
        private int _Id_Asignatura;
        private int _Id_Carrera;
        private string _Nombre;
        private string _ClaveMateria;
        private int _Creditos;
        private string _SemestreSugerido;
        private string _TipoMateria;

        public int Id_Asignatura { get => this._Id_Asignatura; set => this._Id_Asignatura = value; }
        public int Id_Carrera { get => this._Id_Carrera; set => this._Id_Carrera = value; }
        public string Nombre { get => this._Nombre; set => this._Nombre = value; }
        public string ClaveMateria { get => this._ClaveMateria; set => this._ClaveMateria = value; }
        public int Creditos { get => this._Creditos; set => this._Creditos = value; }
        public string SemestreSugerido { get => this._SemestreSugerido; set => this._SemestreSugerido = value; }
        public string TipoMateria { get => this._TipoMateria; set => this._TipoMateria = value; }
    }
}
