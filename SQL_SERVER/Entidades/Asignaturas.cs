using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_Escolar_Consola.Entidades
{
    class Asignatura
    {
        private int _Id_Asignatura;
        private string _Nombre;
        private string _Clave;
        private int _Creditos;
        private int _No_Unidades;
        private int _Semestre;
        private string _TipoMateria;

        public int Id_Asignatura { get => this._Id_Asignatura; set => this._Id_Asignatura = value; }
        public string Nombre { get => this._Nombre; set => this._Nombre = value; }
        public string ClaveMateria { get => this._Clave; set => this._Clave = value; }
        public int Creditos { get => this._Creditos; set => this._Creditos = value; }
        public int No_Unidades { get => this._No_Unidades; set => this._No_Unidades = value; }
        public int Semestre { get => this._Semestre; set => this._Semestre = value; }
        public string TipoMateria { get => this._TipoMateria; set => this._TipoMateria = value; }
    }

    class TableAsignatura
    {
        public static void InsertAsignatura(Asignatura Obj)
        {

        }

        private void GeneratoClave(Asignatura Obj)
        {
            string Clave = $"AT{Abreviaciones[Obj.TipoMateria]}{Obj.Id_Asignatura.ToString("D4")}";

        }

        string Insert = "INSERT INTO Asignatura (Nombre,Creditos,No_Unidades,Semestre,TipoMateria) OUTPUT INSERTED.Id_Aginatura VALUES (@Nombre,@Creditos,@No_Unidades,@Semestre,@TipoMateria)";

        private Dictionary<string, string> Abreviaciones = new Dictionary<string, string>()
        {
            {"Cadena","CAD"},
            {"No Cadena","NCAD"}
        };
    }
}
