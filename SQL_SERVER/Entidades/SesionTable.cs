using Control_Escolar_Consola.Crud;
using controlescolar;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Control_Escolar_Consola.Entidades
{
    class Sesion
    {
        private int _IdSesion;
        private int _IdUsario;
        private string _Usuario;
        private string _Contraseña;
        private string _TipoUsuario;
        private static bool Resultado = false;

        public  int IdSeison { get => this._IdSesion; set => this._IdSesion = value; }
        public int IdUsario { get => this._IdUsario; set => this._IdUsario = value; }
        public string Usuario { get => this._Usuario; set => this._Usuario = value; }
        public string Contraseña { get => this._Contraseña; set => this._Contraseña = value; }
        public string TipoUsuario { get => this._TipoUsuario; set => this._TipoUsuario = value; }

        private static string ReadTable = "SELECT * FROM Sesiones WHERE Usuario = @usuario AND Contraseña = @contraseña;";
        private static string conexion = "Data Source=DESKTOP-A26ATF7\\LABASE;Initial Catalog=ControlEscolar;Integrated Security=True;";
    }

    class TableSesion:connection
    {
        public static void Login(string User, string Password)
        {
            Resultado = ValidacionUser(User, Password);
            if(Resultado)
            {
                TableEmpleoye.Empleados = TableEmpleoye.ReadTable();
                //Me falta la Tabla Alumno perame.
                if (sesion.TipoUsuario == "Empleado")
                {
                    UsuarioSeison = TableEmpleoye.Empleados[sesion.IdUsario];
                }
                else if(sesion.TipoUsuario == "Alumno")
                {
                    //Aca va la lectura de Alumno.
                }
            }
            else
            {
                //Aca le ponen por si paso un error o algo asi
            }
        }

        private static bool ValidacionUser(string usuario, string contraseña)
        {
            using (SqlConnection connection = new SqlConnection(conexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(Read, connection))
                {
                    command.Parameters.AddWithValue("@usuario", usuario ?? "");
                    command.Parameters.AddWithValue("@contraseña", contraseña ?? "");
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        if (reader.Read())
                        {
                             sesion = new Sesion()
                            {
                                IdSeison = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                                Usuario = reader.IsDBNull(1) ? "S/A" : reader.GetString(1),
                                Contraseña = reader.IsDBNull(2) ? "S/A" : reader.GetString(2),
                                TipoUsuario = reader.IsDBNull(3) ? "S/A" : reader.GetString(3),
                                IdUsario = reader.IsDBNull(4) ? 0 : reader.GetInt32(4)
                            };
                            RegistroSesion.InsertRegistroSesion(usuario, Resultado, sesion.TipoUsuario, sesion.IdUsario);
                        }
                        else
                        {
                            Resultado = false;
                            RegistroSesion.InsertRegistroSesion(usuario, Resultado, "NULL", 0);
                        }
                    }
                }
            }
            return Resultado;
        }
        public static Object UsuarioSeison;

        private static bool Resultado = true;
        private static Sesion sesion; 
        private static string Read = "SELECT * FROM Sesiones WHERE Usuario = @usuario AND Contraseña = @contraseña;";
    }

    class RegistroSesion
    {

        public static void InsertRegistroSesion(string User, bool Estado, string tipo="", int Id = 0)
        {
            string fecha = DateTime.Now.ToString("dd-MM-yyyy");
            login = new RegistroSesion();
            login.Fecha = Convert.ToDateTime(fecha);
            login.Usuario = User;
            login.TipoUsuario = tipo;
            login.IdUsuario = Id;
            login.Estado = Estado;

            using(SqlConnection connection = new SqlConnection(conexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(InsertTable, connection))
                {
                    command.Parameters.AddWithValue("@fecha", login.Fecha);
                    command.Parameters.AddWithValue("@usuario", login.Usuario);
                    command.Parameters.AddWithValue("@tipoUsuario", login.TipoUsuario);
                    command.Parameters.AddWithValue("@idUsuario", login.IdUsuario);
                    command.Parameters.AddWithValue("@estado", login.Estado);
                    command.ExecuteNonQuery();
                }
            }
        }

        private static string InsertTable = "INSERT INTO RegistroSesiones (Fecha, Usuario, TipoUsuario, IdUsuario, Estado) VALUES (@fecha, @usuario, @tipoUsuario, @idUsuario, @estado);";
        private static string conexion = "Data Source=DESKTOP-A26ATF7\\LABASE;Initial Catalog=ControlEscolar;Integrated Security=True;";
        private static RegistroSesion login;
        private DateTime _Fecha;
        private string _Usuario;
        private string _TipoUsuario;
        private int _IdUsuario;
        private bool _Estado;

        public DateTime Fecha { get => this._Fecha; set => this._Fecha = value; }
        public string Usuario { get => this._Usuario; set => this._Usuario = value; }
        public string TipoUsuario { get => this._TipoUsuario; set => this._TipoUsuario = value; }
        public int IdUsuario { get => this._IdUsuario; set => this._IdUsuario = value; }
        public bool Estado { get => this._Estado; set => this._Estado = value; }


    }
}
