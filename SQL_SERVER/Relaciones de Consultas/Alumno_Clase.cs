using Control_Escolar_Consola.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controlescolar.SQL_SERVER.Relaciones_de_Consultas
{
    class Alumno_Clase
    {
        int Id;
        Alumno _AlumnoDate;
        Clase _ClaseDate;
        DateTime _FechaInscripcion;

        public int IdPropiedad
        {
            get => Id;
            set => Id = value;
        }

        public Alumno AlumnoDate
        {
            get => _AlumnoDate;
            set => _AlumnoDate = value;
        }

        public Clase ClaseDate
        {
            get => _ClaseDate;
            set => _ClaseDate = value;
        }

        public DateTime FechaInscripcion
        {
            get => _FechaInscripcion;
            set => _FechaInscripcion = value;
        }
    }

    class Table_Alumno_Clase:connection
    {
        public void InsertDate(Alumno_Clase Obj)
        {
            using (SqlConnection sql = new SqlConnection(conexion))
            {
                sql.Open();
                using (SqlCommand command = new SqlCommand(Insert, sql))
                {
                    command.Parameters.AddWithValue("@Id_Alumno",Obj.AlumnoDate.Id_Alumno);
                    command.Parameters.AddWithValue("@Id_Clase", Obj.ClaseDate.Id);
                    command.Parameters.AddWithValue("@FechaInscripcion",Obj.FechaInscripcion);
                    command.ExecuteNonQuery();
                }
            }
        }




       static string Insert = "Insert into Alumno_Clase (Id_Alumno,Id_Clase,FechaInscripcion) values (@Id_Alumno,@Id_Clase,@FechaInscripcion)";
    }
}
