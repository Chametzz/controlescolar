using controlescolar;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
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

    class TableAsignatura:connection
    {

        public static void InsertAsignatura(Asignatura Obj)
        {
            using (SqlConnection connection = new SqlConnection(conexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(Insert, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", Obj.Nombre);
                    command.Parameters.AddWithValue("@Creditos", Obj.Creditos);
                    command.Parameters.AddWithValue("@No_Unidades", Obj.No_Unidades);
                    command.Parameters.AddWithValue("@Semestre", Obj.Semestre);
                    command.Parameters.AddWithValue("@TipoMateria", Obj.TipoMateria);
                    Obj.Id_Asignatura = (int)command.ExecuteScalar();
                    GeneratoClave(Obj,connection);
                }
            }
        }

        public static Dictionary<int, Asignatura> ReadTable()
        {
            using (SqlConnection connection = new SqlConnection(conexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(Read, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Asignatura asignatura = new Asignatura()
                            {
                                Id_Asignatura = reader.GetInt32(0),
                                Nombre = reader.GetString(1),
                                ClaveMateria = reader.GetString(2),
                                Creditos = reader.GetInt32(3),
                                No_Unidades = reader.GetInt32(4),
                                Semestre = reader.GetInt32(5),
                                TipoMateria = reader.GetString(6),
                            };
                            DataTable.Add(asignatura.Id_Asignatura, asignatura);
                        }
                        return DataTable;
                    }
                }
            }
        }

        public static void UpdateData(Asignatura Obj)
        {
            using (SqlConnection connection = new SqlConnection(conexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(Update, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", Obj.Nombre);
                    command.Parameters.AddWithValue("@Creditos", Obj.Creditos);
                    command.Parameters.AddWithValue("@No_Unidades", Obj.No_Unidades);
                    command.Parameters.AddWithValue("@Semestre", Obj.Semestre);
                    command.Parameters.AddWithValue("@TipoMateria", Obj.TipoMateria);
                    command.Parameters.AddWithValue("@Id_Aginatura", Obj.Id_Asignatura);
                    command.ExecuteNonQuery();
                    GeneratoClave(Obj, connection);
                }
            }
        }

        public static void DeleteTable(Asignatura Obj)
        {
            using (SqlConnection connection = new SqlConnection(conexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(Delete, connection))
                {
                    command.Parameters.AddWithValue("@Id_Aginatura", Obj.Id_Asignatura);
                    command.ExecuteNonQuery();
                }
            }
        }

        private static void GeneratoClave(Asignatura Obj,SqlConnection connection)
        {
            string Clave = $"AT{Abreviaciones[Obj.TipoMateria]}{Obj.Id_Asignatura.ToString("D4")}";
            using (connection)
            {
                using (SqlCommand command = new SqlCommand("Update Asignatura SET Clave = @Clave WHERE Id_Aginatura = @Id_Aginatura", connection))
                {
                    command.Parameters.AddWithValue("@Clave", Clave);
                    command.Parameters.AddWithValue("@Id_Aginatura", Obj.Id_Asignatura);
                    command.ExecuteNonQuery();
                }
            }
        }

        static string Insert = "INSERT INTO Asignatura (Nombre,Creditos,No_Unidades,Semestre,TipoMateria) OUTPUT INSERTED.Id_Aginatura VALUES (@Nombre,@Creditos,@No_Unidades,@Semestre,@TipoMateria)";

        static string Update = "Update Asignatura SET Nombre = @Nombre, Creditos = @Creditos, No_Unidades = @No_Unidades, Semestre = @Semestre, TipoMateria = @TipoMateria" +
            " WHERE Id_Aginatura = @Id_Aginatura ";

        static string Read = "SELECT * FROM Asignatura";

        static string Delete = "Delete Asignatura WHERE Id_Aginatura = @Id_Aginatura";

        private static Dictionary<string, string> Abreviaciones = new Dictionary<string, string>()
        {
            {"Cadena","CAD"},
            {"No Cadena","NCAD"}
        };
        public static Dictionary<int, Asignatura> DataTable = new Dictionary<int, Asignatura>();
    }
}
