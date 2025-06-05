using System.Data.SQLite;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using MaterialDesignThemes.Wpf;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
public static class DB{
    public static string path = Path.Combine(Directory.GetCurrentDirectory(), "database.db");
    public static string dsn = $"Data Source={path};Version=3";
    public static bool active = SETDATABASE(path);

    public static bool SETDATABASE(string path)
    {
        if (!File.Exists(path))
        {
            SQLiteConnection.CreateFile(path);
        }
        CreateTables();
        return true;
    }

    public static void CreateTables()
    {
        using (var connection = new SQLiteConnection(dsn))
        {
            connection.Open();

            string[] createTableCommands = new string[]
            {
                "PRAGMA foreign_keys = ON;",

                // Tabla Departamento
                @"CREATE TABLE IF NOT EXISTS Departamento (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nombre TEXT NOT NULL,
                    Clave TEXT NOT NULL,
                    Activo BOOLEAN NOT NULL
                );",

                // Tabla Empleado (base para Docente)
                @"CREATE TABLE IF NOT EXISTS Empleado (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nombre TEXT NOT NULL,
                    Apellido TEXT NOT NULL,
                    FechaNac DATETIME NOT NULL,
                    Curp TEXT NOT NULL,
                    Sexo TEXT NOT NULL,
                    Correo TEXT,
                    CorreoCorp TEXT,
                    Tel TEXT,
                    Direccion TEXT,
                    FechaIng DATETIME,
                    Puesto TEXT,
                    Estado TEXT,
                    Contrato TEXT,
                    Contrasena TEXT,
                    Id_Departamento INTEGER,
                    FOREIGN KEY (Id_Departamento) REFERENCES Departamento(Id) ON DELETE SET NULL
                );",

                // Tabla Carrera
                @"CREATE TABLE IF NOT EXISTS Carrera (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nombre TEXT NOT NULL,
                    Semestres INTEGER NOT NULL,
                    TotalCreditos INTEGER NOT NULL
                );",

                // Tabla Materia
                @"CREATE TABLE IF NOT EXISTS Materia (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nombre TEXT NOT NULL,
                    Unidades INTEGER NOT NULL
                );",

                // Tabla Alumno
                @"CREATE TABLE IF NOT EXISTS Alumno (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nombre TEXT NOT NULL,
                    ApellidoP TEXT NOT NULL,
                    ApellidoM TEXT NOT NULL,
                    FechaNac DATETIME NOT NULL,
                    Curp TEXT NOT NULL,
                    Sexo TEXT NOT NULL,
                    Correo TEXT,
                    CorreoInst TEXT,
                    Tel TEXT,
                    Direccion TEXT,
                    NombrePadre TEXT,
                    ApellidoPadre TEXT,
                    NombreMadre TEXT,
                    ApellidoMadre TEXT,
                    Id_Carrera INTEGER NOT NULL,
                    Contrasena TEXT,
                    Semestre INTEGER NOT NULL,
                    FechaIng DATETIME NOT NULL,
                    Estado TEXT NOT NULL,
                    FOREIGN KEY (Id_Carrera) REFERENCES Carrera(Id) ON DELETE SET NULL
                );",

                // Tabla Curso
                @"CREATE TABLE IF NOT EXISTS Curso (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Id_Carrera INTEGER NOT NULL,
                    Id_Materia INTEGER NOT NULL,
                    Id_Docente INTEGER,
                    Capacidad INTEGER NOT NULL,
                    Creditos INTEGER NOT NULL,
                    Periodo TEXT NOT NULL,
                    FOREIGN KEY (Id_Carrera) REFERENCES Carrera(Id) ON DELETE CASCADE,
                    FOREIGN KEY (Id_Materia) REFERENCES Materia(Id) ON DELETE CASCADE,
                    FOREIGN KEY (Id_Docente) REFERENCES Docente(Id) ON DELETE SET NULL
                );",

                // Tabla Horario
                @"CREATE TABLE IF NOT EXISTS Horario (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Id_Curso INTEGER NOT NULL,
                    Dia INTEGER NOT NULL,
                    HoraInicio DATETIME NOT NULL,
                    HoraFin DATETIME NOT NULL,
                    FOREIGN KEY (Id_Curso) REFERENCES Curso(Id) ON DELETE CASCADE
                );",

                // Tabla Calificacion
                @"CREATE TABLE IF NOT EXISTS Calificacion (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Id_Alumno INTEGER NOT NULL,
                    Id_Curso INTEGER NOT NULL,
                    U1 INTEGER,
                    U2 INTEGER,
                    U3 INTEGER,
                    U4 INTEGER,
                    U5 INTEGER,
                    U6 INTEGER,
                    FOREIGN KEY (Id_Alumno) REFERENCES Alumno(Id) ON DELETE CASCADE,
                    FOREIGN KEY (Id_Curso) REFERENCES Curso(Id) ON DELETE CASCADE
                );"
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

    public static T? Create<T>(T item)
    {
        try
        {
            Type type = typeof(T);
            Type? parent = type.BaseType;
            Type[] types = (parent != null && parent != typeof(object))
                ? [parent, type]
                : [type];
            int lastId = -1;
            using (var connection = new SQLiteConnection(dsn))
            {
                connection.Open();
                ForeignKeysOn(connection);
                for (int i = 0; i < types.Length; i++)
                {
                    Type t = types[i];
                    List<string> cols = [];
                    Dictionary<string, object?> values = [];
                    string q_cols = "";
                    string q_params = "";
                    using (var command = new SQLiteCommand($"PRAGMA table_info({t.Name})", connection))
                    {
                        if (lastId >= 0)
                        {
                            cols.Add("Id");
                            values.Add("@Id", lastId);
                        }
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (!string.Equals(reader["name"].ToString()!, "id", StringComparison.OrdinalIgnoreCase))
                                {
                                    cols.Add(reader["name"].ToString()!);
                                }
                            }
                        }
                        q_cols = string.Join(", ", cols);
                        q_params = string.Join(", ", cols.Select(c => "@" + c));
                        foreach (var c in cols)
                        {
                            if (c != "Id")
                            {
                                Console.WriteLine(c);
                                var prop = t.GetProperty(c);
                                values.Add("@" + c, prop?.GetValue(item));
                            }
                        }
                    }
                    string query = $"INSERT INTO {t.Name} ({q_cols}) VALUES ({q_params})";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        foreach (var (k, v) in values)
                        {
                            command.Parameters.AddWithValue(k, v ?? DBNull.Value);
                        }

                        command.ExecuteNonQuery();
                        if (lastId < 0)
                        {
                            command.CommandText = "SELECT last_insert_rowid();";
                            lastId = Convert.ToInt32((long)command.ExecuteScalar()!);

                            var idProp = type.GetProperty("Id");
                            if (idProp != null && idProp.CanWrite)
                            {
                                idProp.SetValue(item, Convert.ChangeType(lastId, idProp.PropertyType));
                            }
                        }
                    }
                }
            }
            return item;
        }
        catch (Exception e)
        {
            Console.WriteLine($"ERRRORRORR: {e.Message} : {e.StackTrace}");
            return default!;
        }
    }

    public static List<T> Read<T>(string condition = "1=1", params (string name, object? value)[] parameters) where T : new()
    {
        Type type = typeof(T);
        Type? parent = type.BaseType;
        string query = $"SELECT * FROM {type.Name} WHERE {condition}";
        if (parent != null && parent != typeof(object))
        {
            string newCondition = Regex.Replace(condition, @"\bId\b", $"{parent.Name}.Id");
            query = $"SELECT {parent.Name}.*, {type.Name}.* FROM {type.Name} INNER JOIN {parent.Name} ON {parent.Name}.Id = {type.Name}.Id WHERE {newCondition}";
        }
        var result = new List<T>();

        using (var connection = new SQLiteConnection(dsn))
        {
            connection.Open();
            using (var command = new SQLiteCommand(query, connection))
            {

                foreach (var (name, value) in parameters)
                {
                    command.Parameters.AddWithValue(name, value ?? DBNull.Value);
                }

                using (var reader = command.ExecuteReader())
                {
                    var properties = typeof(T).GetProperties();

                    while (reader.Read())
                    {
                        var data = new Dictionary<string, object?>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            string columnName = reader.GetName(i);
                            object? value = reader.IsDBNull(i) ? null : reader.GetValue(i);
                            data[columnName.ToLower()] = value; // evitar problemas con mayúsculas
                        }

                        T instance = new T();

                        foreach (var prop in properties)
                        {
                            if (!prop.CanWrite) continue;

                            if (data.TryGetValue(prop.Name.ToLower(), out var valor) && valor != null)
                            {
                                try
                                {
                                    Type targetType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                                    object converted = Convert.ChangeType(valor, targetType);
                                    prop.SetValue(instance, converted);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"No se pudo asignar '{prop.Name}': {ex.Message}");
                                }
                            }
                        }

                        result.Add(instance);
                    }
                }
            }
        }
        return result;
    }
    public static List<T> Read<T>(Func<T, bool> condition) where T : new()
    {
        var list = Read<T>();
        return list.Where(condition).ToList();
    }

    public static T? ReadFirst<T>(string condition = "1=1", params (string name, object? value)[] parameters) where T : new()
    {
        var list = Read<T>(condition, parameters);
        return list.Count > 0 ? list[0] : default;
    }

    public static T? ReadFirst<T>(Func<T, bool> condition) where T : new()
    {
        var list = Read<T>(condition);
        return list.Where(condition).FirstOrDefault();
    }
    public static bool Update<T>(string condition, string setColumns = "1=1", params (string name, object? value)[] parameters) where T : class
    {
        Type type = typeof(T);
        Type? parent = type.BaseType;
        bool hasParent = parent != null && parent != typeof(object);
        Type[] types = hasParent ? [parent!, type] : [type];

        List<string> queries = [];
        string[] sentences = setColumns.Split(",");
        try
        {
            using (var connection = new SQLiteConnection(dsn))
            {
                connection.Open();
                ForeignKeysOn(connection);
                foreach(var ty in types)
                {
                    List<string> columns = GetColumnNames(ty, connection);
                    List<string> clauses = sentences
                        .Where(s => columns.Any(c => Regex.IsMatch(s, $@"\b{Regex.Escape(c)}\b")))
                        .ToList();

                    if (clauses.Count <= 0) continue;
                    string setter = string.Join(",", clauses);

                    if (!hasParent)
                    {
                        queries.Add($"UPDATE {type.Name} SET {setter} WHERE {condition}");
                    }
                    else
                    {
                        string newCondition = Regex.Replace(condition, @"\bId\b", $"{(parent != null ? parent.Name : type.Name)}.Id");
                        queries.Add($@"
                        UPDATE {ty.Name}
                        SET {setter}
                        WHERE Id IN (
                            SELECT {parent!.Name}.Id
                            FROM {parent.Name}
                            INNER JOIN {type.Name} ON {parent.Name}.Id = {type.Name}.Id
                            WHERE {newCondition}
                        );");
                    }
                }
                foreach (string query in queries)
                {
                    Console.WriteLine(query);
                    using var cmd = new SQLiteCommand(query, connection);
                    foreach (var (name, value) in parameters)
                        cmd.Parameters.AddWithValue(name, value ?? DBNull.Value);
                    cmd.ExecuteNonQuery();
                }

                return true;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"ERROR Update<{typeof(T).Name}>: {e.Message}");
            return false;
        }
    }
    public static bool Update<T>(string setColumns, params (string name, object? value)[] parameters) where T : class
    {
        return Update<T>("1=1", setColumns, parameters);
    }

    public static bool Delete<T>(string condition, params (string name, object? value)[] parameters)
    {
        Type type = typeof(T);
        Type? parent = type.BaseType;
        string query = $"DELETE FROM {typeof(T).Name} WHERE {condition}";
        if (parent != null && parent != typeof(object))
        {
            string newCondition = Regex.Replace(condition, @"\bId\b", $"{parent.Name}.Id");
            query = $@"
            DELETE FROM {parent.Name}
            WHERE Id IN (
                SELECT {parent.Name}.Id
                FROM {parent.Name}
                INNER JOIN {type.Name} ON {parent.Name}.Id = {type.Name}.Id
                WHERE {newCondition}
            );";
        }
        try
        {
            using var connection = new SQLiteConnection(dsn);
            connection.Open();
            ForeignKeysOn(connection);
            using var command = new SQLiteCommand(query, connection);
            foreach (var (name, value) in parameters)
            {
                command.Parameters.AddWithValue(name, value ?? DBNull.Value);
            }

            int affectedRows = command.ExecuteNonQuery();
            return affectedRows > 0;
        }
        catch (Exception e)
        {
            Console.WriteLine($"ERROR Delete<{typeof(T).Name}>: {e.Message}");
            return false;
        }
    }
    //EN PROCESO
    /*public static bool Delete<T>(Func<T, bool> condition) where T : new() 
    {
        try
        {
            List<T> list = Read<T>(condition);
            foreach (var item in list)
            {
                var idProp = item?.GetType().GetProperty("Id");
                if (idProp != null)
                {
                    var idValue = idProp.GetValue(item);
                    Delete<T>($"Id = {idValue}");
                }
                else
                {
                    Console.WriteLine($"ERROR: {typeof(T).Name} no tiene propiedad 'Id'");
                }
            }
            return false;
        }
        catch (Exception e)
        {
            Console.WriteLine($"ERROR Delete<{typeof(T).Name}>: {e.Message}");
            return false;
        }
    }*/

    public static void ForeignKeysOn(SQLiteConnection connection)
    {
        using (var pragmaCmd = new SQLiteCommand("PRAGMA foreign_keys = ON;", connection))
        {
            pragmaCmd.ExecuteNonQuery();
        }
    }

    public static List<string> GetColumnNames<T>()
    {
        Type type = typeof(T);
        bool hasParent = type.BaseType != null && type.BaseType != typeof(object);

        string tableName = typeof(T).Name;
        List<string> columnNames = new();

        using (var connection = new SQLiteConnection(dsn)) // asegúrate de tener tu cadena de conexión en 'dsn'
        {
            connection.Open();
            using (var command = new SQLiteCommand($"PRAGMA table_info({tableName})", connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    string columnName = reader["name"].ToString()!;
                    if (hasParent && string.Equals(columnName, "Id", StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }
                    columnNames.Add(columnName);
                }
            }
        }
        return columnNames;
    }
    public static List<string> GetColumnNames<T>(SQLiteConnection connection)
    {
        Type type = typeof(T);
        bool hasParent = type.BaseType != null && type.BaseType != typeof(object);

        string tableName = typeof(T).Name;
        List<string> columnNames = new();

        using (var command = new SQLiteCommand($"PRAGMA table_info({tableName})", connection))
        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                string columnName = reader["name"].ToString()!;
                if (hasParent && string.Equals(columnName, "Id", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }
                columnNames.Add(columnName);
            }
        }
        return columnNames;
    }
    public static List<string> GetColumnNames(Type type, SQLiteConnection connection)
    {
        bool hasParent = type.BaseType != null && type.BaseType != typeof(object);

        string tableName = type.Name;
        List<string> columnNames = new();

        using (var command = new SQLiteCommand($"PRAGMA table_info({tableName})", connection))
        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                string columnName = reader["name"].ToString()!;
                if (hasParent && string.Equals(columnName, "Id", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }
                columnNames.Add(columnName);
            }
        }
        return columnNames;
    }
}