using System;
using System.Data.SqlClient;
using System.Collections.Generic;

public class DB
{
    protected static string connStr = "Data Source=localhost;Initial Catalog=ControlEscolar;Integrated Security=True;";
    protected SqlConnection connection;
    protected string table = "";
    public static ModelAlumno modelAlumno = new ModelAlumno();
    public static ModelAsignatura modelAsignatura = new ModelAsignatura();
    public static ModelDepartamento modelDepartamento = new ModelDepartamento();
    public static ModelDocentes modelDocentes = new ModelDocentes();
    public static ModelEmpleado modelEmpleado = new ModelEmpleado();
    public static ModelGrupo modelGrupo = new ModelGrupo();
    public static ModelHorarioGrupo ModelHorarioGrupo = new ModelHorarioGrupo();
    public static ModelInscripcionGrupo modelInscripcionGrupo = new ModelInscripcionGrupo();
    public static ModelJefe_de_Departamento modelJDD = new ModelJefe_de_Departamento();
    public static ModelPersonaLimpieza modelPersonaLimpieza = new ModelPersonaLimpieza();
    public static ModelPersonalMantenimiento modelPersonalMantenimiento = new ModelPersonalMantenimiento();

    public DB()
    {
        Console.WriteLine(connStr);
        connection = new SqlConnection(connStr);
    }

    public static void SETDATABASE(string server, string database, string user, string password)
    {
        connStr = $"Data Source={server};Initial Catalog={database};User ID={user};Password={password}";
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

        using (var conn = new SqlConnection(connStr))
        {
            conn.Open();
            using (var command = new SqlCommand(query, conn))
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
    public Dictionary<string, object?>? ReadFirst(string condition)
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
            using (var command = new SqlCommand(query, connection))
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
