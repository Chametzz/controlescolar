using System;
using System.CodeDom;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using controlescolar;
using controlescolar.View;

namespace Control_Escolar_Consola.Entidades
{
    class SesionTable
    {
        private static SesionTable sesion;
        private int _IdUsario;
        private string _Usuario;
        private string _Contraseña;
        private string _TipoUsuario;
        private static bool Resultado = false;

        public int IdUsario { get => this._IdUsario; set => this._IdUsario = value; }
        public string Usuario { get => this._Usuario; set => this._Usuario = value; }
        public string Contraseña { get => this._Contraseña; set => this._Contraseña = value; }
        public string TipoUsuario { get => this._TipoUsuario; set => this._TipoUsuario = value; }

        public static void SesionLogin(string usuario, string contraseña, MainWindow mainWindow)
        {
            Resultado = ValidacionUser(usuario, contraseña);
            if (Resultado)
            {
                PanelEmpleado ventanaEmpleado = new PanelEmpleado(Empleado.ReadEmpleado(sesion.IdUsario));
                mainWindow.Close();
                ventanaEmpleado.Show();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error de inicio de sesion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private static bool ValidacionUser(string usuario, string contraseña)
        {
            using (SqlConnection connection = new SqlConnection(conexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(ReadTable, connection))
                {
                    command.Parameters.AddWithValue("@usuario", usuario ?? "");
                    command.Parameters.AddWithValue("@contraseña", contraseña ?? "");
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            sesion = new SesionTable();
                            sesion.IdUsario = reader.GetInt32(0);
                            sesion.TipoUsuario = reader.GetString(3);
                            Resultado = true;
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

        private static string ReadTable = "SELECT * FROM Sesiones WHERE Usuario = @usuario AND Contraseña = @contraseña;";
        private static string conexion = "Data Source=DESKTOP-A26ATF7\\LABASE;Initial Catalog=ControlEscolar;Integrated Security=True;Trust Server Certificate=True";
    }

    class RegistroSesion
    {

        public static void InsertRegistroSesion(string User, bool Estado, string tipo = "", int Id = 0)
        {
            string fecha = DateTime.Now.ToString("dd-MM-yyyy");
            login = new RegistroSesion();
            login.Fecha = Convert.ToDateTime(fecha);
            login.Usuario = User;
            login.TipoUsuario = tipo;
            login.IdUsuario = Id;
            login.Estado = Estado;

            using (SqlConnection connection = new SqlConnection(conexion))
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
        private static string conexion = "Data Source=DESKTOP-A26ATF7\\LABASE;Initial Catalog=ControlEscolar;Integrated Security=True;Trust Server Certificate=True";
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
