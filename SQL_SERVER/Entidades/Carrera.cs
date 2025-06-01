using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_Escolar_Consola.Entidades
{
    class Carrera
    {
        private int _IdCarrera;
        private string _Nombre;
        private string _Clave;
        private int _Semestres;
        private int _TotalCreditos;
        private Departamentos _Departamento;

        public int IdCarrera { get => this._IdCarrera; set => this._IdCarrera = value; }
        public string Nombre { get => this._Nombre; set => this._Nombre = value; }
        public string Clave { get => this._Clave; set => this._Clave = value; }
        public int Semestres { get => this._Semestres; set => this._Semestres = value; }
        public int TotalCreditos { get => this._TotalCreditos; set => this._TotalCreditos = value; }
        public Departamentos Departamento { get => _Departamento; set => _Departamento = value; }
    }

    class TableCarrera
    {
        public static void InsertData(Carrera Obj)
        {
            using (SqlConnection connection = new SqlConnection(conexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(Insert,connection))
                {
                    command.Parameters.AddWithValue("@Id_Departamento", Obj.Departamento.IdDepartamento);
                    command.Parameters.AddWithValue("@Nombre", Obj.Nombre);
                    command.Parameters.AddWithValue("@Semestres", Obj.Semestres);
                    command.Parameters.AddWithValue("@TotalCreditos", Obj.TotalCreditos);
                    Obj.IdCarrera = (int)command.ExecuteScalar();
                    ClaveGenerator(Obj, connection);
                }
            }
        }

        public static Dictionary<int, Carrera> ReadTable()
        {
            ReadDate.Clear();
            using (SqlConnection connection = new SqlConnection(conexion))
            {
                connection.Open();
                using (SqlCommand Query = new SqlCommand(Read,connection))
                {
                    using (SqlDataReader read = Query.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            Departamentos departamento = new Departamentos()
                            {
                                IdDepartamento = read.IsDBNull(1) ? 0 : read.GetInt32(1),
                                Nombre = read.IsDBNull(7) ? "S/A" : read.GetString(7),
                                Clave = read.IsDBNull(8) ? "S/A" : read.GetString(8),
                                Activo = read.IsDBNull(9) ? false : read.GetBoolean(9),
                            };
                            JefeDepartamento Jefe = new JefeDepartamento()
                            {
                                Empleado = new Empleado()
                                {
                                    Id = read.IsDBNull(10) ? 0 : read.GetInt32(10),
                                    Id_Empleado = read.IsDBNull(16) ? "S/A" : read.GetString(16),
                                    Nombre = read.IsDBNull(17) ? "S/A" : read.GetString(17),
                                    ApellidoParterno = read.IsDBNull(18) ? "S/A" : read.GetString(18),
                                    ApellidoMaterno = read.IsDBNull(19) ? "S/A" : read.GetString(19),
                                    FechaNacimiento = read.IsDBNull(20) ? DateTime.MinValue : read.GetDateTime(20),
                                    CURP = read.IsDBNull(21) ? "S/A" : read.GetString(21),
                                    TelefonoPersonal = read.IsDBNull(22) ? "S/A" : read.GetString(22),
                                    TelefonoContacto = read.IsDBNull(23) ? "S/A" : read.GetString(23),
                                    CorreoPersonal = read.IsDBNull(24) ? "S/A" : read.GetString(24),
                                    Estado = read.IsDBNull(25) ? "S/A" : read.GetString(25),
                                    Municipio = read.IsDBNull(26) ? "S/A" : read.GetString(26),
                                    Ciudad = read.IsDBNull(27) ? "S/A" : read.GetString(27),
                                    Codigo_Postal = read.IsDBNull(28) ? "S/A" : read.GetString(28),
                                    Colonia = read.IsDBNull(29) ? "S/A" : read.GetString(29),
                                    Calle = read.IsDBNull(30) ? "S/A" : read.GetString(30),
                                    Numero_Exterior = read.IsDBNull(31) ? "S/A" : read.GetString(31),
                                    Numero_Interior = read.IsDBNull(32) ? "S/A" : read.GetString(32),
                                    Telefono_Casa = read.IsDBNull(33) ? "S/A" : read.GetString(33),
                                    CorreoCorporativo = read.IsDBNull(34) ? "S/A" : read.GetString(34),
                                    FechaIngreso = read.IsDBNull(35) ? DateTime.MinValue : read.GetDateTime(35),
                                    TipoEmpleado = read.IsDBNull(36) ? "S/A" : read.GetString(36),
                                    Estatus = read.IsDBNull(37) ? "S/A" : read.GetString(37)
                                },
                                FechaInicio = read.IsDBNull(12) ? DateTime.MinValue : read.GetDateTime(12),
                                FechaFin = read.IsDBNull(13) ? DateTime.MinValue : read.GetDateTime(13),
                                Estado = read.IsDBNull(14) ? false : read.GetBoolean(14),
                                Departamento = departamento,
                            };
                            departamento.JefeDepartamento = Jefe;
                            Carrera data = new Carrera()
                            {
                                IdCarrera = read.GetInt32(0),
                                Departamento = departamento,
                                Nombre = read.GetString(2),
                                Clave = read.GetString(3),
                                Semestres = read.GetInt32(4),
                                TotalCreditos = read.GetInt32(5)
                            };
                            ReadDate.Add(data.IdCarrera, data);
                        }
                        return ReadDate;
                    }
                }
            }
        }

        public static void UpdateData(Carrera Obj)
        {
            using (SqlConnection connection = new SqlConnection(conexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(Update,connection))
                {
                    command.Parameters.AddWithValue("@Id", Obj.IdCarrera);
                    command.Parameters.AddWithValue("@Id_Departamento",Obj.Departamento.IdDepartamento);
                    command.Parameters.AddWithValue("@Nombre", Obj.Nombre);
                    command.Parameters.AddWithValue("@Semestres", Obj.Semestres);
                    command.Parameters.AddWithValue("@TotalCreditos", Obj.TotalCreditos);
                    command.ExecuteNonQuery();
                    ClaveGenerator(Obj,connection);
                }
            }
        }


        //Falta el delete:

        public static void DeleteData()
        {

        }


        #region Comandos y Conexion:

        static string Insert = "INSERT INTO Carrera (Id_Departamento,Nombre,Semestres,TotalCreditos) " +
            "OUTPUT INSERTED.Id_Carrera values (@Id_Departamento,@Nombre,@Semestres,@TotalCreditos)";

        static string Read = "SELECT \r\nC.*,\r\nD.*,\r\nJ.*,\r\nE.*\r\n" +
            "FROM Carrera C\r\n" +
            "Left JOIN Departamento D\r\n" +
            "ON C.Id_Departamento = D.Id\r\n" +
            "Left JOIN Jefe_de_Departamento J\r\n" +
            "ON D.Id = J.Id_Departamento\r\n" +
            "Left JOIN Empleado E\r\n" +
            "ON J.Id_EMPLEADO = E.Id";

        static string Update = "UPDATE Carrera SET Id_Departamento = @Id_Departamento, " +
            "Nombre = @Nombre, Semestres = @Semestres, TotalCreditos = @TotalCreditos WHERE Id_Carrera = @Id";

        static string conexion = "Data Source=DESKTOP-A26ATF7\\LABASE;Initial Catalog=ControlEscolar;Integrated Security=True;";
        #endregion


        #region Atributos,/Propiedades y Generadores

        private static void ClaveGenerator(Carrera Obj,SqlConnection connection )
        {

            List<string> palabrasIgnoradas = new List<string> { "en", "de", "la", "el", "del", "y", "para" };

            string[] palabras = Obj.Nombre.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var palabrasFiltradas = palabras.Where(p => !palabrasIgnoradas.Contains(p.ToLower())).ToList();

            string clave = string.Concat(palabrasFiltradas.Take(3).Select(p => p[0])).ToUpper();

            if (clave.Length < 3)
                clave = Obj.Nombre.Substring(0, Math.Min(3, Obj.Nombre.Length)).ToUpper();
            clave = $"{clave}CARR{Obj.IdCarrera.ToString("D3")}";
            using (connection)
            {
                using (SqlCommand command = new SqlCommand("UPDATE Carrera SET Clave = @Clave WHERE Id_Carrera = @Id_Carrera", connection))
                {
                    command.Parameters.AddWithValue("@Clave", clave);
                    command.Parameters.AddWithValue("@Id_Carrera", Obj.IdCarrera);
                    command.ExecuteNonQuery();
                }
            }

        }

        public static Dictionary<int, Carrera> ReadDate = new Dictionary<int, Carrera>();

        #endregion

    }
}
