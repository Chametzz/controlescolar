using System;
using System.IO;
using System.Data.SQLite;
using System.Collections.Generic;
public class DB
{
    protected static string dbPath = "";
    protected static string dsn = "";
    protected SQLiteConnection connection;
    protected string table = "";
    public DB()
    {
        Console.WriteLine(dbPath);
        Console.WriteLine(dsn);
        connection = new SQLiteConnection(dsn);
    }

    public static void SETDATABASE(string path)
    {//PONERLO ARRIBA DEL TODO
        dbPath = path;
        dsn = $"Data Source={dbPath};Version=3";
        if (!File.Exists(dbPath))
        {
            SQLiteConnection.CreateFile(dbPath);
        }
        CreateTables();
    }

    private static void CreateTables()
    {
        using (var connection = new SQLiteConnection(dsn))
        {
            connection.Open();

            // Crear las tablas
            string[] createTableCommands = new string[]
        {
            @"
                CREATE TABLE IF NOT EXISTS EMPLEADO (
                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                    NOMBRE TEXT NOT NULL,
                    APELLIDO TEXT NOT NULL,
                    FECHA_NACIMIENTO DATETIME,
                    CURP TEXT,
                    TELEFONO_PERSONAL TEXT,
                    TELEFONO_CONTACTO TEXT,
                    CORREO_PERSONAL TEXT,
                    DIRRECION TEXT,
                    CORREO_CORPORTATIVO TEXT,
                    FECHA_INGRESO DATETIME,
                    TIPO_EMPLEADO TEXT,
                    ESTATUS TEXT
                );
            ",
            @"
                CREATE TABLE IF NOT EXISTS DEPARTAMENTO (
                    ID_DEPARTAMENTO INTEGER PRIMARY KEY AUTOINCREMENT,
                    ID_JEFEDEPARTAMENTO INTEGER,
                    NOMBRE TEXT,
                    CLAVE TEXT,
                    ACTIVO BIT,
                    FOREIGN KEY (ID_JEFEDEPARTAMENTO) REFERENCES EMPLEADO(ID)
                );
            ",
            @"
                CREATE TABLE IF NOT EXISTS JEFE_DE_DEPARTAMENTO (
                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                    ID_EMPLEADO INTEGER,
                    ID_DEPARTAMENTO INTEGER,
                    FECHA_INICIO DATETIME,
                    FECHA_FIN DATETIME,
                    ESTATUS BIT,
                    FOREIGN KEY (ID_EMPLEADO) REFERENCES EMPLEADO(ID),
                    FOREIGN KEY (ID_DEPARTAMENTO) REFERENCES DEPARTAMENTO(ID_DEPARTAMENTO)
                );
            ",
            @"
                CREATE TABLE IF NOT EXISTS DOCENTES (
                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                    ID_EMPLEADO INTEGER,
                    ID_ASIGNATURA INTEGER,
                    TIPO_CONTRATO TEXT,
                    FOREIGN KEY (ID_EMPLEADO) REFERENCES EMPLEADO(ID),
                    FOREIGN KEY (ID_ASIGNATURA) REFERENCES ASIGNATURA(ID_ASIGNATURA)
                );
            ",
            @"
                CREATE TABLE IF NOT EXISTS PERSONAL_ADMINISTRATIVO (
                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                    ID_EMPLEADO INTEGER,
                    ID_DEPARTAMENTO INTEGER,
                    PUESTO TEXT,
                    NIVEL_ACCESO TEXT,
                    TIPO_CONTRATO TEXT,
                    FOREIGN KEY (ID_EMPLEADO) REFERENCES EMPLEADO(ID),
                    FOREIGN KEY (ID_DEPARTAMENTO) REFERENCES DEPARTAMENTO(ID_DEPARTAMENTO)
                );
            ",
            @"
                CREATE TABLE IF NOT EXISTS PERSONAL_MANTENIMIENTO (
                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                    ID_EMPLEADO INTEGER,
                    ESPECIALIDAD TEXT,
                    AREA_DE_MANTENIMIENTO TEXT,
                    FOREIGN KEY (ID_EMPLEADO) REFERENCES EMPLEADO(ID)
                );
            ",
            @"
                CREATE TABLE IF NOT EXISTS PERSONAL_LIMPIEZA (
                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                    ID_EMPLEADO INTEGER,
                    TIPO_CONTRATO TEXT,
                    ZONA_ASIGNADA TEXT,
                    FOREIGN KEY (ID_EMPLEADO) REFERENCES EMPLEADO(ID)
                );
            ",
            @"
                CREATE TABLE IF NOT EXISTS CARRERA (
                    ID_CARRERA INTEGER PRIMARY KEY AUTOINCREMENT,
                    ID_DEPARTAMENTO INTEGER,
                    NOMBRE TEXT,
                    CLAVE TEXT,
                    SEMESTRES INT,
                    TOTALCREDITOS INT,
                    FOREIGN KEY (ID_DEPARTAMENTO) REFERENCES DEPARTAMENTO(ID_DEPARTAMENTO)
                );
            ",
            @"
                CREATE TABLE IF NOT EXISTS ASIGNATURA (
                    ID_ASIGNATURA INTEGER PRIMARY KEY AUTOINCREMENT,
                    ID_CARRERA INTEGER,
                    NOMBRE TEXT,
                    CLAVEMATERIA TEXT,
                    CREDITOS INT,
                    SEMESTRE_SUGERIDO TEXT,
                    TIPOMATERIA TEXT,
                    FOREIGN KEY (ID_CARRERA) REFERENCES CARRERA(ID_CARRERA)
                );
            ",
            @"
                CREATE TABLE IF NOT EXISTS GRUPO (
                    ID_GRUPO INTEGER PRIMARY KEY AUTOINCREMENT,
                    ID_ASIGNATURA INTEGER,
                    ID_CARRERA INTEGER,
                    ID_DOCENTE INTEGER,
                    ID_AULA INTEGER,
                    CICLO_ESCOLAR TEXT,
                    CAPACIDAD INT,
                    FOREIGN KEY (ID_ASIGNATURA) REFERENCES ASIGNATURA(ID_ASIGNATURA),
                    FOREIGN KEY (ID_CARRERA) REFERENCES CARRERA(ID_CARRERA),
                    FOREIGN KEY (ID_DOCENTE) REFERENCES EMPLEADO(ID)
                );
            ",
            @"
                CREATE TABLE IF NOT EXISTS HORARIO_GRUPO (
                    ID_HORARIOGRUPO INTEGER PRIMARY KEY AUTOINCREMENT,
                    ID_GRUPO INTEGER,
                    DIASEMANA TEXT,
                    HORAINICIO TIME,
                    HORAFIN TIME,
                    FOREIGN KEY (ID_GRUPO) REFERENCES GRUPO(ID_GRUPO)
                );
            ",
            @"
                CREATE TABLE IF NOT EXISTS ALUMNO (
                    ID_ALUMNO INTEGER PRIMARY KEY AUTOINCREMENT,
                    ID_CARRERA INTEGER,
                    NOMBRE TEXT,
                    APELLIDO_PATERNO TEXT,
                    APELLIDO_MATERNO TEXT,
                    CURP TEXT,
                    CORREO_PERSONAL TEXT,
                    TELEFONO TEXT,
                    DIRRECCION TEXT,
                    FECHA_NACIMIENTO DATETIME,
                    SEXO TEXT,
                    TELEFONO_CONTAC TEXT,
                    NOMBRE_PADRE TEXT,
                    APELLIDO_PADRE TEXT,
                    NOMBRE_MADRE TEXT,
                    APELLIDO_MADRE TEXT,
                    FECHA_INGRESO DATETIME,
                    MATRICULA TEXT,
                    SEMESTRE INT,
                    ESTATUS TEXT,
                    CORREO_INSTITUCIONAL TEXT,
                    PROMEDIO_GENERAL DECIMAL(4, 2),
                    FOREIGN KEY (ID_CARRERA) REFERENCES CARRERA(ID_CARRERA)
                );
            ",
            @"
                CREATE TABLE IF NOT EXISTS INSCRIPCION_GRUPO (
                    ID_INSCRIPCION INTEGER PRIMARY KEY AUTOINCREMENT,
                    ID_ALUMNO INTEGER,
                    ID_GRUPO INTEGER,
                    FECHA_INSCRIPCION DATETIME,
                    ESTADO TEXT,
                    CALIFICACION_FINAL DECIMAL(5, 2),
                    FOREIGN KEY (ID_ALUMNO) REFERENCES ALUMNO(ID_ALUMNO),
                    FOREIGN KEY (ID_GRUPO) REFERENCES GRUPO(ID_GRUPO)
                );
            ",
            @"
                CREATE TABLE IF NOT EXISTS DOCENTE_SESION (
                    USUARIO TEXT PRIMARY KEY,
                    CONTRASEÑA TEXT,
                    CODIGO_CONTROL TEXT,
                    ID_DOCENTE INTEGER,
                    FOREIGN KEY (ID_DOCENTE) REFERENCES EMPLEADO(ID)
                );
            ",
            @"
                CREATE TABLE IF NOT EXISTS ESTUDIANTES_SESION (
                    USUARIO TEXT PRIMARY KEY,
                    CONTRASEÑA TEXT,
                    ID_ESTUDIANTE INTEGER,
                    FOREIGN KEY (ID_ESTUDIANTE) REFERENCES ALUMNO(ID_ALUMNO)
                );
            "
        };


            foreach (var commandText in createTableCommands)
            {
                using (var command = new SQLiteCommand(commandText, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }

    public bool Create(string columns, string values)
    {
        string query = $"INSERT INTO {table} ({columns}) VALUES ({values})";
        return ExecuteQuery(query);
    }

    public List<Dictionary<string, object?>> Read(string condition = "1=1")
    {
        string query = $"SELECT * FROM {table} WHERE {condition}";
        var result = new List<Dictionary<string, object?>>();

        using (var connection = new SQLiteConnection(dsn))
        {
            connection.Open();
            using (var command = new SQLiteCommand(query, connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var row = new Dictionary<string, object?>();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string columnName = reader.GetName(i);
                        object? value = reader.IsDBNull(i) ? null : reader.GetValue(i);
                        row[columnName] = value;
                    }

                    result.Add(row);
                }
            }
        }
        return result;
    }

    public bool Update(string setColumns, string condition)
    {
        string query = $"UPDATE {table} SET {setColumns} WHERE {condition}";
        return ExecuteQuery(query);
    }

    public bool Delete(string condition)
    {
        string query = $"DELETE FROM {table} WHERE {condition}";
        return ExecuteQuery(query);
    }

    protected bool ExecuteQuery(string query)
    {
        try
        {
            connection.Open();
            using (var command = new SQLiteCommand(query, connection))
            {
                command.ExecuteNonQuery();
                return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error executing query: {ex.Message}");
            return false;
        }
        finally
        {
            connection.Close();
        }
    }
}