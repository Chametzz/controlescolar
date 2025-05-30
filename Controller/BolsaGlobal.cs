using controlescolar;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;

public static class BolsaGlobal
{
    private static readonly Dictionary<string, object?> _bolsaGlobal = new Dictionary<string, object?>(); //Diccionario para almacenar datos globales (key-value pairs)
    public static void Set(string key, object? value) //Método para guardar un valor
    {
        if (_bolsaGlobal.ContainsKey(key))
        {
            _bolsaGlobal[key] = value; //Actualizar si ya es existente.
        }
        else
        {
            _bolsaGlobal.Add(key, value); //Agrega un valor si es nuevo.
        }
    }
    public static bool Contains(string key) //Método para verificar si una clase es existente.
    {
        return _bolsaGlobal.ContainsKey(key);
    }
    public static void Remove(string key) //Método para eliminar un dato.
    {
        _bolsaGlobal.Remove(key);
    }
    public static void Clear()
    {
        _bolsaGlobal.Clear();
    }
}