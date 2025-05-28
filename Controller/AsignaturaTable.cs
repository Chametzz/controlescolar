using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using controlescolar.Model.Conexiones;

namespace Control_Escolar_Consola.Entidades
{
    public static class AsignaturasTable
    {
        public static void CrearAsignatura(Asignaturas asignatura)
        {
            using (SqlConnection connection = new SqlConnection(Connection.CadenaConexion))
            {
                connection.Open();
                string query = @"INSERT INTO Asignaturas (Id_Carrera, Nombre, ClaveMateria, Creditos, SemestreSugerido, TipoMateria)
                                 VALUES (@Id_Carrera, @Nombre, @ClaveMateria, @Creditos, @SemestreSugerido, @TipoMateria)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id_Carrera", asignatura.Id_Carrera);
                    command.Parameters.AddWithValue("@Nombre", asignatura.Nombre ?? "");
                    command.Parameters.AddWithValue("@ClaveMateria", asignatura.ClaveMateria ?? "");
                    command.Parameters.AddWithValue("@Creditos", asignatura.Creditos);
                    command.Parameters.AddWithValue("@SemestreSugerido", asignatura.SemestreSugerido ?? "");
                    command.Parameters.AddWithValue("@TipoMateria", asignatura.TipoMateria ?? "");
                    command.ExecuteNonQuery();
                }
            }
        }

        public static List<Asignaturas> ObtenerAsignaturas()
        {
            var lista = new List<Asignaturas>();
            using (SqlConnection connection = new SqlConnection(Connection.CadenaConexion))
            {
                connection.Open();
                string query = "SELECT Id_Asignatura, Id_Carrera, Nombre, ClaveMateria, Creditos, SemestreSugerido, TipoMateria FROM Asignaturas";
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Asignaturas
                        {
                            Id_Asignatura = reader.GetInt32(0),
                            Id_Carrera = reader.GetInt32(1),
                            Nombre = reader.GetString(2),
                            ClaveMateria = reader.GetString(3),
                            Creditos = reader.GetInt32(4),
                            SemestreSugerido = reader.GetString(5),
                            TipoMateria = reader.GetString(6)
                        });
                    }
                }
            }
            return lista;
        }

        public static void ActualizarAsignatura(Asignaturas asignatura)
        {
            using (SqlConnection connection = new SqlConnection(Connection.CadenaConexion))
            {
                connection.Open();
                string query = @"UPDATE Asignaturas 
                                 SET Id_Carrera = @Id_Carrera, Nombre = @Nombre, ClaveMateria = @ClaveMateria, 
                                     Creditos = @Creditos, SemestreSugerido = @SemestreSugerido, TipoMateria = @TipoMateria
                                 WHERE Id_Asignatura = @Id_Asignatura";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id_Asignatura", asignatura.Id_Asignatura);
                    command.Parameters.AddWithValue("@Id_Carrera", asignatura.Id_Carrera);
                    command.Parameters.AddWithValue("@Nombre", asignatura.Nombre ?? "");
                    command.Parameters.AddWithValue("@ClaveMateria", asignatura.ClaveMateria ?? "");
                    command.Parameters.AddWithValue("@Creditos", asignatura.Creditos);
                    command.Parameters.AddWithValue("@SemestreSugerido", asignatura.SemestreSugerido ?? "");
                    command.Parameters.AddWithValue("@TipoMateria", asignatura.TipoMateria ?? "");
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void EliminarAsignatura(int idAsignatura)
        {
            using (SqlConnection connection = new SqlConnection(Connection.CadenaConexion))
            {
                connection.Open();
                string query = "DELETE FROM Asignaturas WHERE Id_Asignatura = @Id_Asignatura";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id_Asignatura", idAsignatura);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}