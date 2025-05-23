using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_Escolar_Consola.Entidades
{
    class Carrera
    {
        private int _IdCarrera;
        private int _IdDepartamento;
        private string _Nombre;
        private string _Clave;
        private int _Semestres;
        private int _TotalCreditos;

        public int IdCarrera { get => this._IdCarrera; set => this._IdCarrera = value; }
        public int IdDepartamento { get => this._IdDepartamento; set => this._IdDepartamento = value; }
        public string Nombre { get => this._Nombre; set => this._Nombre = value; }
        public string Clave { get => this._Clave; set => this._Clave = value; }
        public int Semestres { get => this._Semestres; set => this._Semestres = value; }
        public int TotalCreditos { get => this._TotalCreditos; set => this._TotalCreditos = value; }

    }
}
