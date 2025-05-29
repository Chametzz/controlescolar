using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Control_Escolar_Consola.Entidades
{
    class Departamentos
    {
        private int _IdDepartamento;
        private JefeDepartamento _JefeDepartamento;
        private string _Nombre;
        private string _Clave;
        private bool _Activo;

        public int IdDepartamento { get => this._IdDepartamento; set => this._IdDepartamento = value; }
        public JefeDepartamento JefeDepartamento { get => this._JefeDepartamento; set => this._JefeDepartamento = value; }
        public string Nombre { get => this._Nombre; set => this._Nombre = value; }
        public string Clave { get => this._Clave; set => this._Clave = value; }
        public bool Activo { get => this._Activo; set => this._Activo = value; }
    }

    class TableDepartamento
    {
        public static void InsertData(Departamentos Obj)
        {
            Obj.Activo = true;
            using (SqlConnection connection = new SqlConnection(MiConexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(Insert, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", Obj.Nombre);
                    command.Parameters.AddWithValue("@Activo", Obj.Activo);
                    Obj.IdDepartamento = (int)command.ExecuteScalar();
                    ClaveGenerator(Obj);
                }
            }
        }

        public static Dictionary<string, Departamentos> ReadTable()
        {
            using (SqlConnection Connection = new SqlConnection(MiConexion))
            {
                Connection.Open();
                using (SqlCommand Query = new SqlCommand(Read,Connection))
                {
                    using (SqlDataReader reader = Query.ExecuteReader())
                    {
                        int i = 1;
                        while (reader.Read())
                        {
                            Departamento = new Departamentos();
                            Departamento.IdDepartamento = reader.GetInt32(0);
                            Departamento.Nombre = reader["Nombre"].ToString();
                            Departamento.Clave = reader["Clave"].ToString();
                            Departamento.Activo = (bool)reader["Activo"];
                            Departamento.JefeDepartamento = new JefeDepartamento()
                            {
                                FechaInicio = reader.IsDBNull(4) ? DateTime.MinValue : reader.GetDateTime(4),
                                Estado = reader.IsDBNull(5) ? false : reader.GetBoolean(5),
                                FechaFin = reader.IsDBNull(6) ? DateTime.MinValue : (DateTime)reader["Fecha_Fin"],
                                Empleado = new Empleado()
                                {
                                    Id = reader.IsDBNull(7) ? 0 : reader.GetInt32(7),
                                    Id_Empleado = reader.IsDBNull(8) ? "S/A" : reader["Id_Empleado"].ToString(),
                                    Nombre = reader.IsDBNull(9) ? "S/A" : reader.GetString(9),
                                    ApellidoParterno = reader.IsDBNull(10) ? "S/A" : reader["Apellido_Paterno"].ToString(),
                                    ApellidoMaterno = reader.IsDBNull(11) ? "S/A" : reader["Apellido_Materno"].ToString(),
                                    FechaNacimiento = reader.IsDBNull(12) ? DateTime.MinValue : reader.GetDateTime(12),
                                    CURP = reader.IsDBNull(13) ? "S/A" : reader["CURP"].ToString(),
                                    TelefonoPersonal = reader.IsDBNull(14) ? "S/A" : reader["Telefono_Personal"].ToString(),
                                    TelefonoContacto = reader.IsDBNull(15) ? "S/A" : reader["Telefono_Contacto"].ToString(),
                                    CorreoPersonal = reader.IsDBNull(16) ? "S/A" : reader["Correo_Personal"].ToString(),
                                    Estado = reader.IsDBNull(17) ? "S/A" : reader["Estado"].ToString(),
                                    Municipio = reader.IsDBNull(18) ? "S/A" : reader["Municipio"].ToString(),
                                    Ciudad = reader.IsDBNull(19) ? "S/A" : reader["Ciudad"].ToString(),
                                    Codigo_Postal = reader.IsDBNull(20) ? "S/A" : reader["Codigo_Postal"].ToString(),
                                    Colonia = reader.IsDBNull(21) ? "S/A" : reader["Colonia"].ToString(),
                                    Calle = reader.IsDBNull(22) ? "S/A" : reader["Calle"].ToString(),
                                    Numero_Exterior = reader.IsDBNull(23) ? "S/A" : reader["Numero_Exterior"].ToString(),
                                    Numero_Interior = reader.IsDBNull(24) ? "S/A" : reader["Numero_Interior"].ToString(),
                                    Telefono_Casa = reader.IsDBNull(25) ? "S/A" : reader["Telefono_Casa"].ToString(),
                                    CorreoCorporativo = reader.IsDBNull(26) ? "S/A" : reader["Correo_Corportativo"].ToString(),
                                    FechaIngreso = reader.IsDBNull(27) ? DateTime.MinValue : reader.GetDateTime(27),
                                    TipoEmpleado = reader.IsDBNull(28) ? "S/A" : reader["Tipo_Empleado"].ToString(),
                                    Estatus = reader.IsDBNull(29) ? "S/A" : reader["Estatus"].ToString()

                                }
                            };
                            DataTable.Add(Departamento.Clave, Departamento);
                            ClaveDepartamento.Add(Departamento.IdDepartamento, Departamento.Clave);
                        }
                        return DataTable;
                    }
                }
            }
        }

        public static void UpdateData(Departamentos Obj)
        {
            using (SqlConnection connection = new SqlConnection(MiConexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(Update, connection))
                {
                    command.Parameters.AddWithValue("@Id", Obj.IdDepartamento);
                    command.Parameters.AddWithValue("@Nombre", Obj.Nombre);
                    command.Parameters.AddWithValue("@Activo", Obj.Activo);
                    command.ExecuteNonQuery();
                    ClaveGenerator(Obj);
                }
            }
        }

        public static void DeleteData(Departamentos Obj)
        {
            using (SqlConnection connection = new SqlConnection(MiConexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("DELETE FROM Departamento WHERE Id = @Id ADN Clave = @Clave", connection))
                {
                    command.Parameters.AddWithValue("@Id", Obj.IdDepartamento);
                    command.Parameters.AddWithValue("@Clave", Obj.Clave);
                    command.ExecuteNonQuery();
                }
            }
            DataTable.Remove(Obj.Clave);
        }


        private static void ClaveGenerator(Departamentos Obj)
        {
            int indice = Obj.Nombre.IndexOf(' '); char caracter = ' ';
            if (indice != -1 && indice + 1 < Obj.Nombre.Length)
            {
                caracter = Obj.Nombre[indice + 1];
            }
            string CLAVE = $"{Obj.Nombre.Substring(0,1).ToUpper()}{caracter}TCNM{Obj.IdDepartamento.ToString("D3")}";
            using (SqlConnection sql = new SqlConnection(MiConexion))
            {
                sql.Open();
                using (SqlCommand command = new SqlCommand("UPDATE Departamento SET Clave = @Clave WHERE Id = @Id", sql))
                {
                    command.Parameters.AddWithValue("@Clave", CLAVE);
                    command.Parameters.AddWithValue("@Id", Obj.IdDepartamento);
                    command.ExecuteNonQuery();
                }
            }
        }


        public static Dictionary<string, Departamentos> DataTable = new Dictionary<string, Departamentos>();
        public static Dictionary<int,string> ClaveDepartamento = new Dictionary<int,string>();
        private static Departamentos Departamento;


        #region Conexion y comandos

        static string Insert = "INSERT INTO Departamento (Nombre,Activo) OUTPUT INSERTED.Id values (@Nombre,@Activo)";

        static string Read = "SELECT D.*, Jefe_de_Departamento.Fecha_Incio,Jefe_de_Departamento.Estatus,Jefe_de_Departamento.Fecha_Fin,E.*\r\n" +
            "FROM Departamento D\r\n" +
            "Left JOIN Jefe_de_Departamento\r\n" +
            "ON D.Id = Jefe_de_Departamento.Id_Departamento\r\n" +
            "Left JOIN Empleado E ON E.Id = Jefe_de_Departamento.Id_EMPLEADO";

        static string Update = "UPDATE Departamento SET Nombre = @Nombre, Activo = @Activo WHERE Id = @Id";

        static string MiConexion = "Data Source=DESKTOP-A26ATF7\\LABASE;Initial Catalog=ControlEscolar;Integrated Security=True;";

        #endregion
    }
}
