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
    public static SQLiteConnection connection = SETDATABASE(path);

    public static SQLiteConnection SETDATABASE(string path)
    {
        if (!File.Exists(path))
        {
            SQLiteConnection.CreateFile(path);
        }
        CreateTables();
        return new SQLiteConnection(dsn);
    }

    public static void CreateTables()
    {
        using (var connection = new SQLiteConnection(dsn))
        {
            connection.Open();

            string[] createTableCommands = new string[]
            {   
                "PRAGMA foreign_keys = ON;",
                @"CREATE TABLE IF NOT EXISTS Animal (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nombre TEXT NOT NULL
                );",

                @"CREATE TABLE IF NOT EXISTS Perro (
                    Id INTEGER PRIMARY KEY,
                    Raza TEXT NOT NULL,
                    FOREIGN KEY (Id) REFERENCES Animal(Id) ON DELETE CASCADE
                );",

                @"CREATE TABLE IF NOT EXISTS Gato (
                    Id INTEGER PRIMARY KEY,
                    EsCasero BOOLEAN NOT NULL,
                    FOREIGN KEY (Id) REFERENCES Animal(Id) ON DELETE CASCADE
                );",

                @"CREATE TABLE IF NOT EXISTS Pajaro (
                    Id INTEGER PRIMARY KEY,
                    Envergadura REAL NOT NULL,
                    FOREIGN KEY (Id) REFERENCES Animal(Id) ON DELETE CASCADE
                );",
                @"
                    CREATE TABLE IF NOT EXISTS Objeto (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nombre TEXT NOT NULL,
                    Precio REAL,
                    Activo INTEGER, -- SQLite no tiene tipo BOOL, se usa INTEGER (0 o 1)
                    FechaCreacion TEXT, -- SQLite guarda fechas como TEXT (ISO 8601)
                    Porcentaje REAL,
                    Inicial TEXT,
                    Codigo INTEGER
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
                                var prop = type.GetProperty(c);
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
    public static bool ExecuteQuery(string query)
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