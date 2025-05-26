using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
public class DB {
    protected static string connectionString = SetConnectionString("localhost", "controlescolar_db", "root", "123");
    protected SqlConnection connection;
    protected string table = "";

    public DB()
    {
        connection = new SqlConnection(connectionString);
    }

    public static string SetConnectionString(string server, string database, string user, string password) {
        return $"Server={server};Database={database};User Id={user};Password={password};TrustServerCertificate=True;";
    }

    public bool Create(string columns, string values) {
        string query = $"INSERT INTO {table} ({columns}) VALUES ({values})";
        return ExecuteQuery(query);
    }

    public List<Dictionary<string, object?>> Read(string condition = "1=1") {
        string query = $"SELECT * FROM {table} WHERE {condition}";
        var result = new List<Dictionary<string, object?>>();

        using (var conn = new SqlConnection(connectionString)) {
            conn.Open();
            using (var command = new SqlCommand(query, conn))
            using (var reader = command.ExecuteReader()) {
                while (reader.Read()) {
                    var row = new Dictionary<string, object?>();
                    for (int i = 0; i < reader.FieldCount; i++) {
                        row[reader.GetName(i)] = reader.IsDBNull(i) ? null : reader.GetValue(i);
                    }
                    result.Add(row);
                }
            }
        }
        return result;
    }
    public Dictionary<string, object?>? ReadFirst(string condition = "1=1")
    {
        var data = Read(condition);
        if (data.Count > 0)
        {
            return data[0];
        }
        else
        {
            return null;
        }
    }

    public bool Update(string setColumns, string condition)
    {
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
            using (var command = new SqlCommand(query, connection)) {
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
