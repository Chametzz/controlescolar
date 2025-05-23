using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_Escolar_Consola.Entidades
{
    class Departamentos
    {
        private int _IdDepartamento;
        private int _IdJefeDepartamento;
        private string _Nombre;
        private string _Clave;
        private bool _Activo;

        public int IdDepartamento { get => this._IdDepartamento; set => this._IdDepartamento = value; }
        public int IdJefeDepartamento { get => this._IdJefeDepartamento; set => this._IdJefeDepartamento = value; }
        public string Nombre { get => this._Nombre; set => this._Nombre = value; }
        public string Clave { get => this._Clave; set => this._Clave = value; }
        public bool Activo { get => this._Activo; set => this._Activo = value; }
    }
}
