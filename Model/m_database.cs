using System;
using System.IO;
using System.Data.SQLite;
using System.Collections.Generic;
public class DB{
    protected static string dbPath = "";
    protected static string dsn = "";
    protected SQLiteConnection connection;
    protected string table = "";
    public DB() {
        Console.WriteLine(dbPath);
        Console.WriteLine(dsn);
        connection = new SQLiteConnection(dsn);
    }

    public static void SETDATABASE(string path) {//PONERLO ARRIBA DEL TODO
        dbPath = path;
        dsn = $"Data Source={dbPath};Version=3";
        if (!File.Exists(dbPath)) {
            SQLiteConnection.CreateFile(dbPath);
        }
        CreateTables();
    }

    private static void CreateTables() {
        using (var connection = new SQLiteConnection(dsn)) {
            connection.Open();

            // Crear las tablas
            string[] createTableCommands = new string[] {
                @"
                    CREATE TABLE IF NOT EXISTS EMPLOYEES (
                        ID INTEGER PRIMARY KEY AUTOINCREMENT, 
                        FIRSTNAME TEXT NOT NULL, 
                        LASTNAME TEXT NOT NULL, 
                        SEX TEXT NOT NULL, 
                        BIRTHDATE DATE NOT NULL, 
                        PHONENO TEXT, 
                        EMAIL TEXT NOT NULL,
                        PASSWORD TEXT NOT NULL,
                        ADDRESS TEXT,
                        HIREDATE DATE NOT NULL, 
                        WORKDEPT TEXT, 
                        JOB TEXT, 
                        SALARY DECIMAL(9, 2)
                    );
                ",
                @"
                    CREATE TABLE IF NOT EXISTS PLAYCARDS (
                        ID INTEGER PRIMARY KEY AUTOINCREMENT, 
                        STATUS TEXT NOT NULL, 
                        BALANCE DECIMAL(9, 2), 
                        POINTS INT, 
                        ISSUEDATE TEXT NOT NULL, 
                        EXPDATE TEXT
                    );
                ",
                @"
                    CREATE TABLE IF NOT EXISTS PRIZES (
                        ID INTEGER PRIMARY KEY AUTOINCREMENT, 
                        NAME TEXT NOT NULL, 
                        PRICE DECIMAL(9, 2), 
                        AMOUNT INT
                    );
                ",
                @"
                    CREATE TABLE IF NOT EXISTS GAMES (
                        ID INTEGER PRIMARY KEY AUTOINCREMENT, 
                        NAME TEXT NOT NULL, 
                        TYPE TEXT NOT NULL, 
                        STATUS TEXT, 
                        CAPACITY INT, 
                        PRICE DECIMAL(9, 2)
                    );
                "
            };

            foreach (var commandText in createTableCommands) {
                using (var command = new SQLiteCommand(commandText, connection)) {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
    
    public bool Create(string columns, string values) {
        string query = $"INSERT INTO {table} ({columns}) VALUES ({values})";
        return ExecuteQuery(query);
    }

    public List<Dictionary<string, object?>> Read(string condition = "1=1") {
        string query = $"SELECT * FROM {table} WHERE {condition}";
        var result = new List<Dictionary<string, object?>>();

        using (var connection = new SQLiteConnection(dsn)) {
            connection.Open();
            using (var command = new SQLiteCommand(query, connection))
            using (var reader = command.ExecuteReader()) {
                while (reader.Read()) {
                    var row = new Dictionary<string, object?>();

                    for (int i = 0; i < reader.FieldCount; i++) {
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

    public bool Update(string setColumns, string condition) {
        string query = $"UPDATE {table} SET {setColumns} WHERE {condition}";
        return ExecuteQuery(query);
    }

    public bool Delete(string condition) {
        string query = $"DELETE FROM {table} WHERE {condition}";
        return ExecuteQuery(query);
    }

    protected bool ExecuteQuery(string query) {
        try {
            connection.Open();
            using (var command = new SQLiteCommand(query, connection)) {
                command.ExecuteNonQuery();
                return true;
            }
        } catch (Exception ex) {
            Console.WriteLine($"Error executing query: {ex.Message}");
            return false;
        } finally {
            connection.Close();
        }
    }
}