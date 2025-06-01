using Control_Escolar_Consola.Entidades;
using controlescolar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_Escolar_Consola.Relaciones_de_Consultas
{
    class Carrera_Asignatura
    {
        private Carrera _carrera;
        private Asignatura _asignatura;

        public Carrera  carrera{ get => this._carrera; set => this._carrera = value; }
        public Asignatura asignatura { get => this._asignatura; set => this._asignatura = value; }
    }

    class Table_Carrera_Asignatura:connection
    {
        public static void InsertTable(Carrera Obj1,Asignatura Obj2)
        {
            using (SqlConnection connection = new SqlConnection(conexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(Insert, connection))
                {
                    command.Parameters.AddWithValue("@IdC", Obj1.IdCarrera);
                    command.Parameters.AddWithValue("@IdA", Obj2.Id_Asignatura);
                    command.Parameters.AddWithValue("@Semestre", Obj2.Semestre);
                    command.Parameters.AddWithValue("@Cadena", Obj2.TipoMateria);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static Dictionary<int, Carrera_Asignatura> ReadTable()
        {
            TableCarrera.ReadDate = TableCarrera.ReadTable();
            TableAsignatura.DataTable = TableAsignatura.ReadTable();
            using (SqlConnection connection = new SqlConnection(conexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(Read, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Carrera_Asignatura relaciones = new Carrera_Asignatura()
                            {
                                carrera = TableCarrera.ReadDate[reader.GetInt32(0)],
                                asignatura = TableAsignatura.DataTable[reader.GetInt32(1)]
                            };
                            DateTable.Add(relaciones.asignatura.Id_Asignatura, relaciones);
                        }
                        return DateTable;
                    }
                }
            }
        }



        #region comandos:

        static string Insert = "Insert  INTO Carrera_Asignatura (Id_Carrera,Id_Asignatura,Semestre,Cadena) " +
            "VALUES " +
            "(@IdC, @IdA, @Semestre, @Cadena)";

        static string Read = "SELECT * FROM Carrera_Asignatura";

        #endregion


        #region Diccionari de Objeto Carrera_Asignatura y mas:

        public static Dictionary<int, Carrera_Asignatura> DateTable = new Dictionary<int, Carrera_Asignatura>();

        #endregion
    }
}
