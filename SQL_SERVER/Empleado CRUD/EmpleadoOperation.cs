using Control_Escolar_Consola.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Http.Headers;
//using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Control_Escolar_Consola.Crud
{
    class TableEmpleoye
    {
        public static Empleado DataEmpleoye;

        public static void InsertTable(Empleado Obj)
        {
            DataEmpleoye = Obj;
            Obj.CorreoCorporativo = CorreoGenerator(Obj);
            Obj.Estado = "Activo";
            using (SqlConnection connection = new SqlConnection(conexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(Insert, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", Obj.Nombre);
                    command.Parameters.AddWithValue("@Apellido_Paterno", Obj.ApellidoParterno);
                    command.Parameters.AddWithValue("@Apellido_Materno", Obj.ApellidoMaterno);
                    command.Parameters.AddWithValue("@Fecha_Nacimiento", Obj.FechaNacimiento);
                    command.Parameters.AddWithValue("@CURP", Obj.CURP);
                    command.Parameters.AddWithValue("@Telefono_Personal", Obj.TelefonoPersonal);
                    command.Parameters.AddWithValue("@Telefono_Contacto", Obj.TelefonoContacto);
                    command.Parameters.AddWithValue("@Correo_Personal", Obj.CorreoPersonal);
                    command.Parameters.AddWithValue("@Estado", Obj.Estado);
                    command.Parameters.AddWithValue("@Municipio", Obj.Municipio);
                    command.Parameters.AddWithValue("@Ciudad", Obj.Ciudad);
                    command.Parameters.AddWithValue("@Codigo_Postal", Obj.Codigo_Postal);
                    command.Parameters.AddWithValue("@Colonia", Obj.Colonia);
                    command.Parameters.AddWithValue("@Calle", Obj.Calle);
                    command.Parameters.AddWithValue("@Numero_Exterior", Obj.Numero_Exterior);
                    command.Parameters.AddWithValue("@Numero_Interior", Obj.Numero_Interior);
                    command.Parameters.AddWithValue("@Telefono_Casa", Obj.Telefono_Casa);
                    command.Parameters.AddWithValue("@Correo_Corportativo", Obj.CorreoCorporativo);
                    command.Parameters.AddWithValue("@Fecha_Ingreso", Obj.FechaIngreso);
                    command.Parameters.AddWithValue("@Tipo_Empleado", Obj.TipoEmpleado);
                    command.Parameters.AddWithValue("@Estatus", Obj.Estatus);
                    DataEmpleoye.Id = (int)command.ExecuteScalar();
                    IdGenerator(DataEmpleoye.Id);
                }
            }
        }

        public static Dictionary<int, Empleado> ReadTable()
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
                            Empleado empleado = new Empleado
                            {
                                Id = reader.GetInt32(0),
                                Id_Empleado = reader.GetString(1),
                                Nombre = reader.GetString(2),
                                ApellidoParterno = reader.GetString(3),
                                ApellidoMaterno = reader.GetString(4),
                                FechaNacimiento = reader.GetDateTime(5),
                                CURP = reader.GetString(6),
                                TelefonoPersonal = reader.GetString(7),
                                TelefonoContacto = reader.GetString(8),
                                CorreoPersonal = reader.GetString(9),
                                Estado = reader.GetString(10),
                                Municipio = reader.GetString(11),
                                Ciudad = reader.GetString(12),
                                Codigo_Postal = reader.GetString(13),
                                Colonia = reader.GetString(14),
                                Calle = reader.GetString(15),
                                Numero_Exterior = reader.GetString(16),
                                Numero_Interior = reader.IsDBNull(17) ? "S/A" : reader.GetString(17),
                                Telefono_Casa = reader.GetString(18),
                                CorreoCorporativo = reader.GetString(19),
                                FechaIngreso = reader.GetDateTime(20),
                                TipoEmpleado = reader.GetString(21),
                                Estatus = reader.GetString(22)
                            };
                            Empleados.Add(empleado.Id, empleado);
                        }
                        return Empleados;
                    }
                }
            }
        }

        public static void UpdateEmpleoye(Empleado Obj)
        {
            using (SqlConnection connection = new SqlConnection(conexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(Update, connection))
                {
                    command.Parameters.AddWithValue("@Id", Obj.Id);
                    command.Parameters.AddWithValue("@Nombre", Obj.Nombre);
                    command.Parameters.AddWithValue("@Apellido_Paterno", Obj.ApellidoParterno);
                    command.Parameters.AddWithValue("@Apellido_Materno", Obj.ApellidoMaterno);
                    command.Parameters.AddWithValue("@Fecha_Nacimiento", Obj.FechaNacimiento);
                    command.Parameters.AddWithValue("@CURP", Obj.CURP);
                    command.Parameters.AddWithValue("@Telefono_Personal", Obj.TelefonoPersonal);
                    command.Parameters.AddWithValue("@Telefono_Contacto", Obj.TelefonoContacto);
                    command.Parameters.AddWithValue("@Correo_Personal", Obj.CorreoPersonal);
                    command.Parameters.AddWithValue("@Estado", Obj.Estado);
                    command.Parameters.AddWithValue("@Municipio", Obj.Municipio);
                    command.Parameters.AddWithValue("@Ciudad", Obj.Ciudad);
                    command.Parameters.AddWithValue("@Codigo_Postal", Obj.Codigo_Postal);
                    command.Parameters.AddWithValue("@Colonia", Obj.Colonia);
                    command.Parameters.AddWithValue("@Calle", Obj.Calle);
                    command.Parameters.AddWithValue("@Numero_Exterior", Obj.Numero_Exterior);
                    command.Parameters.AddWithValue("@Numero_Interior", Obj.Numero_Interior);
                    command.Parameters.AddWithValue("@Telefono_Casa", Obj.Telefono_Casa);
                    command.Parameters.AddWithValue("@Tipo_Empleado", Obj.TipoEmpleado);
                    command.Parameters.AddWithValue("@Estatus", Obj.Estatus);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteEmpleoye(Empleado Obj)
        {
            using (SqlConnection connection = new SqlConnection(conexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("DELETE FROM Empleado WHERE Id = @Id ADN Id_Empleado = @Id_Empleado", connection))
                {
                    command.Parameters.AddWithValue("@Id", Obj.Id);
                    command.Parameters.AddWithValue("@Id_Empleado", Obj.Id_Empleado);
                    command.ExecuteNonQuery();
                }
            }
        }


        private static string CorreoGenerator(Empleado Obj)
        {
            string correo = $"{Abreviaciones[Obj.TipoEmpleado]}{Obj.CURP.Remove(0,4)}@Tecnm.Acapulco.mx";
            return correo;
        }
        private static void IdGenerator(int Id)
        {
            string IdEmpleoye = $"{Abreviaciones[DataEmpleoye.TipoEmpleado]}{Id.ToString("D6")}";

            using (SqlConnection sql = new SqlConnection(conexion))
            {
                sql.Open();
                using (SqlCommand command = new SqlCommand("UPDATE Empleado SET Id_Empleado = @Id_Empleado WHERE Id = @Id", sql))
                {
                    command.Parameters.AddWithValue("@Id_Empleado", IdEmpleoye);
                    command.Parameters.AddWithValue("@Id", Id);
                    command.ExecuteNonQuery();
                }
            }
        }



        private static string Insert = "INSERT INTO Empleado (Nombre, Apellido_Paterno,Apellido_Materno, Fecha_Nacimiento, CURP, Telefono_Personal, Telefono_Contacto, Correo_Personal,Estado,Municipio,Ciudad,Codigo_Postal,Colonia,Calle,Numero_Exterior,Numero_Interior,Telefono_Casa, Correo_Corportativo, Fecha_Ingreso, Tipo_Empleado,Estatus) OUTPUT INSERTED.Id VALUES (@Nombre, @Apellido_Paterno,@Apellido_Materno,@Fecha_Nacimiento,@CURP,@Telefono_Personal,@Telefono_Contacto,@Correo_Personal,@Estado,@Municipio,@Ciudad,@Codigo_Postal,@Colonia,@Calle,@Numero_Exterior,@Numero_Interior,@Telefono_Casa,@Correo_Corportativo,@Fecha_Ingreso,@Tipo_Empleado,@Estatus)";

        private static string Read = "SELECT * FROM Empleado";

        private static string Update = "Update Empleado SET Nombre = " +
            "@Nombre, Apellido_Paterno = @Apellido_Paterno, Apellido_Materno = @Apellido_Materno, " +
            "Fecha_Nacimiento = @Fecha_Nacimiento, CURP = @CURP,Telefono_Personal = @Telefono_Personal," +
            "Telefono_Contacto = @Telefono_Contacto, Correo_Personal = @Correo_Personal, Estado = @Estado, " +
            "Municipio = @Municipio, Ciudad = @Ciudad, Codigo_Postal = @Codigo_Postal, Colonia = @Colonia, Calle = @Calle, " +
            "Numero_Exterior = @Numero_Exterior, Numero_Interior = @Numero_Interior,Telefono_Casa = @Telefono_Casa," +
            "Tipo_Empleado = @Tipo_Empleado, Estatus = @Estatus WHERE Id = @Id";



        private static string conexion = "Data Source=DESKTOP-A26ATF7\\LABASE;Initial Catalog=ControlEscolar;Integrated Security=True;";

        private static Dictionary<string, string> Abreviaciones = new Dictionary<string, string>()
        {
            {"Jefe de Departamento", "JDP"},
            {"Docente", "DOC"},
            {"Limpieza", "LIP"},
            {"Mantenimiento", "MAT"},
            {"Administracion", "ADM"},
        };
       
        public static Dictionary<int,Empleado> Empleados = new Dictionary<int, Empleado>();
    }

    class TableJfDepartamento
    {
        public Empleado Data;
        public Departamentos Departament;

        public static void InsertTable(int Id_Empleado, int Id_Departamento)
        {
            using (SqlConnection connection = new SqlConnection(conexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(Insert, connection))
                {
                    command.Parameters.AddWithValue("@Id_Empleado", Id_Empleado);
                    command.Parameters.AddWithValue("@Id_Departamento", Id_Departamento);
                    command.Parameters.AddWithValue("@Fecha", DateTime.Now);
                    command.Parameters.AddWithValue("@Estatus", true);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static Dictionary<int, JefeDepartamento> ReadTable()
        {
            int NullId = -1;
            using (SqlConnection conection = new SqlConnection(conexion))
            { 
                conection.Open();
                using (SqlCommand Query = new SqlCommand(Read, conection))
                {
                    using (SqlDataReader reader = Query.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            JefeDepartamento jefe = new JefeDepartamento
                            {
                                Empleado = new Empleado()
                                {
                                    Id = reader.IsDBNull(0) ? NullId : reader.GetInt32(0),
                                    Id_Empleado = reader.IsDBNull(1) ? "S/A" : reader["Id_Empleado"].ToString(),
                                    Nombre = reader.IsDBNull(2) ? "S/A" : reader.GetString(2),
                                    ApellidoParterno = reader.IsDBNull(3) ? "S/A" : reader["Apellido_Paterno"].ToString(),
                                    ApellidoMaterno = reader.IsDBNull(4) ? "S/A" : reader["Apellido_Materno"].ToString(),
                                    FechaNacimiento = reader.IsDBNull(5) ? DateTime.MinValue : reader.GetDateTime(5),
                                    CURP = reader.IsDBNull(6) ? "S/A" : reader["CURP"].ToString(),
                                    TelefonoPersonal = reader.IsDBNull(7) ? "S/A" : reader["Telefono_Personal"].ToString(),
                                    TelefonoContacto = reader.IsDBNull(8) ? "S/A" : reader["Telefono_Contacto"].ToString(),
                                    CorreoPersonal = reader.IsDBNull(9) ? "S/A" : reader["Correo_Personal"].ToString(),
                                    Estado = reader.IsDBNull(10) ? "S/A" : reader["Estado"].ToString(),
                                    Municipio = reader.IsDBNull(11) ? "S/A" : reader["Municipio"].ToString(),
                                    Ciudad = reader.IsDBNull(12) ? "S/A" : reader["Ciudad"].ToString(),
                                    Codigo_Postal = reader.IsDBNull(13) ? "S/A" : reader["Codigo_Postal"].ToString(),
                                    Colonia = reader.IsDBNull(14) ? "S/A" : reader["Colonia"].ToString(),
                                    Calle = reader.IsDBNull(15) ? "S/A" : reader["Calle"].ToString(),
                                    Numero_Exterior = reader.IsDBNull(16) ? "S/A" : reader["Numero_Exterior"].ToString(),
                                    Numero_Interior = reader.IsDBNull(17) ? "S/A" : reader["Numero_Interior"].ToString(),
                                    Telefono_Casa = reader.IsDBNull(18) ? "S/A" : reader["Telefono_Casa"].ToString(),
                                    CorreoCorporativo = reader.IsDBNull(19) ? "S/A" : reader["Correo_Corportativo"].ToString(),
                                    FechaIngreso = reader.IsDBNull(20) ? DateTime.MinValue : reader.GetDateTime(20),
                                    TipoEmpleado = reader.IsDBNull(21) ? "S/A" : reader["Tipo_Empleado"].ToString(),
                                    Estatus = reader.IsDBNull(22) ? "S/A" : reader["Estatus"].ToString()
                                },
                                FechaInicio = reader.IsDBNull(23) ? DateTime.MinValue : reader.GetDateTime(23),
                                FechaFin = reader.IsDBNull(24) ? DateTime.MinValue : reader.GetDateTime(24),
                                Estado = reader.IsDBNull(25) ? false : reader.GetBoolean(25),
                                Departamento = new Departamentos()
                                {
                                    Clave = reader.IsDBNull(26) ? "S/A" : reader["Clave"].ToString(),
                                    Nombre = reader.IsDBNull(27) ? "S/A" : reader["Nombre"].ToString(),
                                }
                            };
                            JefesDepartamentos.Add(jefe.Empleado.Id, jefe);
                            NullId  -= 1;
                        }
                        return JefesDepartamentos;
                    }
                }
            }
        }

        public static void UpdateData(JefeDepartamento Obj)
        {
            using (SqlConnection connection = new SqlConnection(conexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(Update, connection))
                {
                    command.Parameters.AddWithValue("@Id_Empleado", Obj.Empleado.Id);
                    command.Parameters.AddWithValue("@Id_Departamento", Obj.Departamento.IdDepartamento);
                    command.Parameters.AddWithValue("@Fecha_Incio", Obj.FechaInicio);
                    command.Parameters.AddWithValue("@Fecha_Fin", Obj.FechaFin);
                    command.Parameters.AddWithValue("@Estatus", Obj.Estado);
                    command.ExecuteNonQuery();
                }
            }
        }


        #region Conexion y Comandos
        private static string conexion = "Data Source=DESKTOP-A26ATF7\\LABASE;Initial Catalog=ControlEscolar;Integrated Security=True;";

        private static string Insert = "INSERT INTO Jefe_de_Departamento (Id_EMPLEADO,Id_Departamento,Fecha_Incio,Estatus) VALUES (@Id_Empleado, @Id_Departamento,@Fecha,@Estatus)";

        private static string Read = "SELECT E.*," +
            "\r\nJefe_de_Departamento.Fecha_Incio," +
            "\r\nJefe_de_Departamento.Fecha_Fin," +
            "\r\nJefe_de_Departamento.Estatus," +
            "\r\nDepartamento.Clave," +
            "\r\nDepartamento.Nombre" +
            "\r\nFROM Jefe_de_Departamento" +
            " \r\nRight JOIN Departamento\r\n" +
            "ON Jefe_de_Departamento.Id_Departamento = Departamento.Id\r\n" +
            "Left JOIN Empleado E\r\n" +
            "ON Jefe_de_Departamento.Id_EMPLEADO = E.Id \r\n";

        private static string Update = "UPDATE Jefe_de_Departamento SET Fecha_Incio = @Fecha_Incio, Fecha_Fin = @Fecha_Fin, Estatus = @Estatus WHERE Id_EMPLEADO = @Id_Empleado AND Id_Departamento = @Id_Departamento";
        #endregion


        public static Dictionary<int, JefeDepartamento> JefesDepartamentos = new Dictionary<int, JefeDepartamento>();
    }

    //Falta la Lectura y Update de esta tabla
    class TableDocentes
    {
        public static void InsertTable(int Id, string Contrato)
        {
            using (SqlConnection connection = new SqlConnection(conexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(InsertCommand, connection))
                {
                    command.Parameters.AddWithValue("@Id_Empleado", Id);
                    command.Parameters.AddWithValue("@Tipo_Contrato", Contrato);
                    command.ExecuteNonQuery();
                }
            }
        }
        public static Dictionary<int, Docentes> ReadData()
        {
            using (SqlConnection connection = new SqlConnection(conexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(Read, connection))
                {
                    using (SqlDataReader read = command.ExecuteReader())
                    {
                        TableEmpleoye.Empleados = TableEmpleoye.ReadTable();
                        while(read.Read())
                        {
                            Empleado data = TableEmpleoye.Empleados[read.GetInt32(0)];

                            Docentes docente = new Docentes()
                            {
                                Docente = data,
                                Tipo_COntrato = read.GetString(1),
                            };
                            DataRead.Add(docente.Docente.Id, docente);
                        }
                        return DataRead;
                    }
                }
            }
        }

        static string InsertCommand = "INSERT INTO Docentes VALUES (@Id_Empleado, @Tipo_Contrato)";
        static string Read = "SELECT * FROM Docentes";
        static string conexion = "Data Source=DESKTOP-A26ATF7\\LABASE;Initial Catalog=ControlEscolar;Integrated Security=True;";


        public static Dictionary<int, Docentes> DataRead = new Dictionary<int, Docentes>();
    }

    class TablePersonalLimpieza
    {
        public static void InsertData(int Id, string Contrato, string ZonaAsignada)
        {
            using (SqlConnection connection = new SqlConnection(conexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(InsertCommand, connection))
                {
                    command.Parameters.AddWithValue("@Id_Empleado", Id);
                    command.Parameters.AddWithValue("@Tipo_Contrato", Contrato);
                    command.Parameters.AddWithValue("@Zona_Asignada", ZonaAsignada);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static Dictionary<int,PersonaLimpieza> ReadTable()
        {
            using (SqlConnection connection = new SqlConnection(conexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(Read,connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Empleado dataEmpleoye = new Empleado()
                            {
                                Id = reader.GetInt32(0),
                                Id_Empleado = reader.GetString(1),
                                Nombre = reader.GetString(2),
                                ApellidoParterno = reader.GetString(3),
                                ApellidoMaterno = reader.GetString(4),
                                FechaNacimiento = reader.GetDateTime(5),
                                CURP = reader.GetString(6),
                                TelefonoPersonal = reader.GetString(7),
                                TelefonoContacto = reader.GetString(8),
                                CorreoPersonal = reader.GetString(9),
                                Estado = reader.GetString(10),
                                Municipio = reader.GetString(11),
                                Ciudad = reader.GetString(12),
                                Codigo_Postal = reader.GetString(13),
                                Colonia = reader.GetString(14),
                                Calle = reader.GetString(15),
                                Numero_Exterior = reader.GetString(16),
                                Numero_Interior = reader.IsDBNull(17) ? "S/A" : reader.GetString(17),
                                Telefono_Casa = reader.GetString(18),
                                CorreoCorporativo = reader.GetString(19),
                                FechaIngreso = reader.GetDateTime(20),
                                TipoEmpleado = reader.GetString(21),
                                Estatus = reader.GetString(22)
                            };
                            PersonaLimpieza personaLimpieza = new PersonaLimpieza()
                            {
                                Personal_Limpieza = dataEmpleoye,
                                Tipo_Contratro = reader.GetString(23),
                                Zona_Asignada = reader.GetString(24),
                            };
                            DataRead.Add(personaLimpieza.Personal_Limpieza.Id,personaLimpieza);
                        }
                        return DataRead;
                    }
                }
            }
        }

        public static void UpdateData(PersonaLimpieza Obj)
        {
            using (SqlConnection connection = new SqlConnection(conexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(Update, connection))
                {
                    command.Parameters.AddWithValue("@Contrato",Obj.Tipo_Contratro);
                    command.Parameters.AddWithValue("@Asignacion", Obj.Zona_Asignada);
                    command.Parameters.AddWithValue("@Id", Obj.Personal_Limpieza.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static Dictionary<int, PersonaLimpieza> DataRead = new Dictionary<int, PersonaLimpieza>();

        static string InsertCommand = "INSERT INTO PersonaLimpieza VALUES (@Id_Empleado, @Tipo_Contrato,@Zona_Asignada)";
        static string conexion = "Data Source=DESKTOP-A26ATF7\\LABASE;Initial Catalog=ControlEscolar;Integrated Security=True;";
        static string Read = "SELECT " +
            "\r\nE.*," +
            "\r\nPersonaLimpieza.Tipo_Contrato," +
            "\r\nPersonaLimpieza.Zona_Asignada" +
            "\r\nFROM PersonaLimpieza" +
            " \r\nINNER JOIN Empleado E " +
            "\r\nON PersonaLimpieza.Id_Empleado = E.Id";

        public static string Update = "Update PersonaLimpieza SET Tipo_Contrato = @Contrato," +
            "Zona_Asignada = @Asignacion WHERE Id_Empleado = @Id";
    }

    class TableMantenimiento
    {
        public static void InsertTable(int Id, string Especilidad, string Area)
        {
            using (SqlConnection connection = new SqlConnection(conexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(InsertCommand, connection))
                {
                    command.Parameters.AddWithValue("@Id_Empleado", Id);
                    command.Parameters.AddWithValue("@Especilidad", Especilidad);
                    command.Parameters.AddWithValue("@Area_Mantenimiento", Area);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static Dictionary<int, PersonalMatenimiento> ReadTable()
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
                            Empleado dataEmpleoye = new Empleado()
                            {
                                Id = reader.GetInt32(0),
                                Id_Empleado = reader.GetString(1),
                                Nombre = reader.GetString(2),
                                ApellidoParterno = reader.GetString(3),
                                ApellidoMaterno = reader.GetString(4),
                                FechaNacimiento = reader.GetDateTime(5),
                                CURP = reader.GetString(6),
                                TelefonoPersonal = reader.GetString(7),
                                TelefonoContacto = reader.GetString(8),
                                CorreoPersonal = reader.GetString(9),
                                Estado = reader.GetString(10),
                                Municipio = reader.GetString(11),
                                Ciudad = reader.GetString(12),
                                Codigo_Postal = reader.GetString(13),
                                Colonia = reader.GetString(14),
                                Calle = reader.GetString(15),
                                Numero_Exterior = reader.GetString(16),
                                Numero_Interior = reader.IsDBNull(17) ? "S/A" : reader.GetString(17),
                                Telefono_Casa = reader.GetString(18),
                                CorreoCorporativo = reader.GetString(19),
                                FechaIngreso = reader.GetDateTime(20),
                                TipoEmpleado = reader.GetString(21),
                                Estatus = reader.GetString(22)
                            };

                            PersonalMatenimiento matenimiento = new PersonalMatenimiento()
                            {
                                Personal_Mantenimiento = dataEmpleoye,
                                Especialidad = reader.GetString(24),
                                Area_Mantenimiento = reader.GetString(25),
                            };

                            DataRead.Add(matenimiento.Personal_Mantenimiento.Id, matenimiento);
                        }
                        return DataRead;
                    }
                }
            }
        }

        public static void UpdateData(PersonalMatenimiento Obj)
        {
            using (SqlConnection connection = new SqlConnection(conexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(Update, connection))
                {
                    command.Parameters.AddWithValue("@Especialidad", Obj.Especialidad);
                    command.Parameters.AddWithValue("@Area", Obj.Area_Mantenimiento);
                    command.Parameters.AddWithValue("@Id", Obj.Personal_Mantenimiento.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static Dictionary<int, PersonalMatenimiento> DataRead = new Dictionary<int, PersonalMatenimiento>();

        static string InsertCommand = "INSERT INTO PersonalMantenimiento VALUES (@Id_Empleado, @Especilidad,@Area_Mantenimiento)";

        static string Read = "SELECT E.*,\r\nP.*\r\nFROM PersonalMantenimiento P\r\nINNER JOIN Empleado E\r\nON P.Id_Empleado = E.Id";

        static string Update = "Update PersonalMantenimiento SET Especialidad = @Especialidad, Area_de_Mantenimiento = @Area " +
            "WHERE Id_Empleado = @Id";

        static string conexion = "Data Source=DESKTOP-A26ATF7\\LABASE;Initial Catalog=ControlEscolar;Integrated Security=True;";
    }

    class TablePersonalAdministrativo
    {
        public static void InsertTable(int Id_Empleado, int Id_Departamento,string Puesto, string Nivel_Acceso, string Tipo_Contrato)
        {
            using (SqlConnection connection = new SqlConnection(conexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(InsertCommand, connection))
                {
                    command.Parameters.AddWithValue("@Id_Empleado", Id_Empleado);
                    command.Parameters.AddWithValue("@Id_Departamento", Id_Departamento);
                    command.Parameters.AddWithValue("@Puesto", Puesto);
                    command.Parameters.AddWithValue("@Nivel_Acceso", Nivel_Acceso);
                    command.Parameters.AddWithValue("@Tipo_Contrato", Tipo_Contrato);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static Dictionary<int, PersonalAdministrativo> ReadTable()
        {
            using (SqlConnection connection = new SqlConnection(conexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(Read, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        TableDepartamento.DataTable = TableDepartamento.ReadTable();
                        while (reader.Read())
                        {
                            Empleado dataEmpleoye = new Empleado()
                            {
                                Id = reader.GetInt32(0),
                                Id_Empleado = reader.GetString(1),
                                Nombre = reader.GetString(2),
                                ApellidoParterno = reader.GetString(3),
                                ApellidoMaterno = reader.GetString(4),
                                FechaNacimiento = reader.GetDateTime(5),
                                CURP = reader.GetString(6),
                                TelefonoPersonal = reader.GetString(7),
                                TelefonoContacto = reader.GetString(8),
                                CorreoPersonal = reader.GetString(9),
                                Estado = reader.GetString(10),
                                Municipio = reader.GetString(11),
                                Ciudad = reader.GetString(12),
                                Codigo_Postal = reader.GetString(13),
                                Colonia = reader.GetString(14),
                                Calle = reader.GetString(15),
                                Numero_Exterior = reader.GetString(16),
                                Numero_Interior = reader.IsDBNull(17) ? "S/A" : reader.GetString(17),
                                Telefono_Casa = reader.GetString(18),
                                CorreoCorporativo = reader.GetString(19),
                                FechaIngreso = reader.GetDateTime(20),
                                TipoEmpleado = reader.GetString(21),
                                Estatus = reader.GetString(22)
                            };
                            Departamentos Dep = TableDepartamento.DataTable[TableDepartamento.ClaveDepartamento[reader.GetInt32(24)]];
                            Dep.JefeDepartamento.Departamento = Dep;
                            Dep.JefeDepartamento.Departamento.JefeDepartamento = Dep.JefeDepartamento;
                            PersonalAdministrativo Administracion = new PersonalAdministrativo()
                            {
                                Personal_Administrativo = dataEmpleoye,
                                departamento = Dep,
                                Puesto = reader.GetString(25),
                                Nivel_Acceso = reader.GetString(26),
                                Tipo_Contrato = reader.GetString(27),
                            };

                            DataRead.Add(Administracion.Personal_Administrativo.Id, Administracion);
                        }
                        return DataRead;
                    }
                }
            }
        }

        public static void UpdateData(PersonalAdministrativo Obj)
        {
            using (SqlConnection connection = new SqlConnection(conexion))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(Update, connection))
                {
                    command.Parameters.AddWithValue("@Id_Departamento", Obj.departamento.IdDepartamento);
                    command.Parameters.AddWithValue("@Puesto", Obj.Puesto);
                    command.Parameters.AddWithValue("@Nivel_Acceso",Obj.Nivel_Acceso);
                    command.Parameters.AddWithValue("@Tipo_Contrato", Obj.Tipo_Contrato);
                    command.Parameters.AddWithValue("@Id", Obj.Personal_Administrativo.Id);
                    command.ExecuteNonQuery();
                }
            }
        }

        static string InsertCommand = "INSERT INTO Personal_Administrativo VALUES (@Id_Empleado, @Id_Departamento,@Puesto,@Nivel_Acceso,@Tipo_Contrato)";
        static string Read = "SELECT E.*,\r\nP.*\r\nFROM Personal_Administrativo P\r\nINNER JOIN Empleado E\r\nON P.Id_Empleado = E.Id";
        static string Update = "Update Personal_Administrativo " +
            "SET Id_Departamento = @Id_Departamento, Puesto = @Puesto, Nivel_Acceso = @Nivel_Acceso, Tipo_Contrato = @Tipo_Contrato" +
            " WHERE Id_Empleado = @Id";
        static string conexion = "Data Source=DESKTOP-A26ATF7\\LABASE;Initial Catalog=ControlEscolar;Integrated Security=True;";

        public static Dictionary<int,PersonalAdministrativo> DataRead = new Dictionary<int,PersonalAdministrativo>();
    }
}

