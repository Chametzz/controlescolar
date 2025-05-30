using Control_Escolar_Consola.Crud;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_Escolar_Consola.Entidades
{
    class Clase
    {
        private int _Id;
        private Docentes _docente;
        private Asignatura _asignatura;
        private string _Periodo;
        private string _Turno;
        private string _Salon;
       
        public int Id { get => this._Id; set => this._Id = value; }
        public Docentes Empleado { get => this._docente; set => this._docente = value; }
        public Asignatura asignatura { get => this._asignatura; set => this._asignatura = value; }
        public string Periodo { get => this._Periodo; set => this._Periodo = value; }
        public string Turno { get => this._Turno; set => this._Turno = value; }
        public string Salon { get => this._Salon; set => this._Salon = value; }
    }

    class TableClase : connection
    {
        public static void InsertData(Clase Obj)
        {
            using (SqlConnection sql = new SqlConnection(conexion))
            {
                sql.Open();
                using (SqlCommand command = new SqlCommand(Insert, sql))
                {
                    command.Parameters.AddWithValue("@Id_Asignatura", Obj.asignatura.Id_Asignatura);
                    command.Parameters.AddWithValue("@Id_Docente", Obj.Empleado.Docente.Id);
                    command.Parameters.AddWithValue("@Periodo", Obj.Periodo);
                    command.Parameters.AddWithValue("@Turno", Obj.Turno);
                    command.Parameters.AddWithValue("@Salon", Obj.Salon);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static Dictionary<int, Clase> ReadTable()
        {
            using (SqlConnection sql = new SqlConnection(conexion))
            {
                TableAsignatura.DataTable = TableAsignatura.ReadTable();
                TableDocentes.DataRead = TableDocentes.ReadData();
                sql.Open();
                using (SqlCommand command = new SqlCommand(Read, sql))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Asignatura A = TableAsignatura.DataTable[reader.GetInt32(1)];
                            Docentes d = TableDocentes.DataRead[reader.GetInt32(2)];

                            Clase Mi = new Clase()
                            {
                                Id = reader.GetInt32(0),
                                Empleado = d,
                                asignatura = A,
                                Periodo = reader.GetString(3),
                                Turno = reader.GetString(4),
                                Salon = reader.GetString(5),
                            };
                            DataTable.Add(Mi.Id, Mi);
                        }
                        return DataTable;
                    }
                }
            }
        }

        public static void UpdateData(Clase Obj)
        {
            using (SqlConnection sql = new SqlConnection(conexion))
            {
                sql.Open();
                using (SqlCommand command = new SqlCommand(Update, sql))
                {
                    command.Parameters.AddWithValue("@a", Obj.asignatura.Id_Asignatura);
                    command.Parameters.AddWithValue("@d", Obj.Empleado.Docente.Id);
                    command.Parameters.AddWithValue("@Periodo", Obj.Periodo);
                    command.Parameters.AddWithValue("@t", Obj.Turno);
                    command.Parameters.AddWithValue("@S", Obj.Salon);
                    command.Parameters.AddWithValue("@Clase", Obj.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteData(Clase Obj)
        {
            using (SqlConnection sql = new SqlConnection(conexion))
            {
                sql.Open();
                using (SqlCommand command = new SqlCommand(Delete, sql))
                {
                    command.Parameters.AddWithValue("@Clase", Obj.Id);
                    command.ExecuteNonQuery();
                }
            }
        }


        #region comandos:

        static string Insert = "Insert Into Clase (Id_Asignatura,Id_Docente,Periodo,Turno,Salon ) values (@Id_Asignatura, @Id_Docente,@Periodo, @Turno, @Salon)";

        static string Read = "SELECT * FROM Clase";

        static string Update = "Update Clase SET Id_Asignatura = @a, Id_Docente = @d, Periodo = @Periodo, @Turno = @t, Salon = @S WHERE Id_Clase = @Clase";

        static string Delete = "Delete Clase Where Id_Clase = @Clase";
        #endregion

        #region Diccionario:

        public static Dictionary<int,Clase> DataTable = new Dictionary<int,Clase>();
         
        #endregion
    }
}
