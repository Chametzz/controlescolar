using Control_Escolar_Consola.Crud;
using Control_Escolar_Consola.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace controlescolar.SQL_SERVER.Relaciones_de_Consultas
{
    class Clase_Horario
    {
        int _Id;
        private Clase _clase;
        private bool _Lunes;
        private bool _Martes;
        private bool _Miercoles;
        private bool _Jueves;
        private bool _Viernes;
        private string _HoraInicio;
        private string _HoraFin;

        public int Id_Horario { get => this._Id; set => this._Id = value; }
        public Clase clase { get => this._clase; set => this._clase = value; }
        public bool Lunes { get => this._Lunes; set => this._Lunes = value; }
        public bool Martes { get => this._Martes; set => this._Martes = value;}
        public bool Miercoles { get => this._Miercoles; set => this._Miercoles = value; }
        public bool Jueves { get => this._Jueves; set => this._Jueves = value; }
        public bool Viernes { get => this._Viernes; set => this._Viernes = value; }
        public string HoraInicio { get => this._HoraInicio; set => this._HoraInicio = value; }
        public string HoraFin { get => this._HoraFin; set => this._HoraFin = value; }
    }

    class Table_Clase_Horario:connection
    {
        public static void InserTable(Clase_Horario Obj)
        {
            using (SqlConnection connection = new SqlConnection(conexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(Insert, connection))
                {
                    command.Parameters.AddWithValue("@Id_Clase",Obj.clase.Id);
                    command.Parameters.AddWithValue("@Lunes", Obj.Lunes);
                    command.Parameters.AddWithValue("@Martes", Obj.Martes);
                    command.Parameters.AddWithValue("@Miercoles", Obj.Miercoles);
                    command.Parameters.AddWithValue("@Jueves", Obj.Jueves);
                    command.Parameters.AddWithValue("@Viernes", Obj.Viernes);
                    command.Parameters.AddWithValue("@HoraInicio", Obj.HoraInicio);
                    command.Parameters.AddWithValue("@HoraFin", Obj.HoraFin);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static Dictionary<int, Clase_Horario> ReadTable()
        {
            TableClase.DataTable = TableClase.ReadTable();
            using (SqlConnection sql = new SqlConnection(conexion))
            {
                sql.Open();
                using (SqlCommand command = new SqlCommand(Read, sql))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                        }
                        return DateRead;
                    }
                }
            }
        }


        static string Insert = "Insert Into Clase_Horario (Id_Clase, Lunes, Martes, Miercoles, Jueves, Viernes, HoraInicio, HoraFin) Values (@Id_Clase, @Lunes, @Martes, @Miercoles, @Jueves, @Viernes, @HoraInicio, @HoraFin)";

        static string Read = "SELECT * FROM Clase_Horario";



        public static Dictionary<int, Clase_Horario> DateRead = new Dictionary<int, Clase_Horario>();
    }
}
