using System;
using System.Collections.Generic;

public static class BolsaGlobal
{
    //Propiedades específicas para usuarios logueados
    private static Alumno? _alumnoLogueado;
    private static Administrativo? _adminLogueado;
    private static Empleado? _docenteLogueado;

    private static readonly List<KeyValuePair<string, object?>> _datos = new();

    //Propiedades públicas para acceso controlado
    public static Alumno? AlumnoLogueado
    {
        get => _alumnoLogueado;
        set
        {
            if (value != null)
            {
                _alumnoLogueado = value;
                _docenteLogueado = null;
                _adminLogueado = null;
            }
            else
            {
                _alumnoLogueado = null;
            }
        }
    }
        public static Administrativo? AdminLogueado
    {
        get => _adminLogueado;
        set
        {
            if (value != null)
            {
                _adminLogueado = value;
                _alumnoLogueado = null;
                _docenteLogueado = null;
            }
            else
            {
                _adminLogueado = null;
            }
        }
    }

    public static Empleado? DocenteLogueado
    {
        get => _docenteLogueado;
        set
        {
            if (value != null)
            {
                _docenteLogueado = value;
                _alumnoLogueado = null;
                _adminLogueado = null;
            }
            else
            {
                _docenteLogueado = null;
            }
        }
    }

    //Métodos para el almacenamiento genérico
    public static void Set(string key, object? value)
    {
        Remove(key); // Elimina si ya existe
        _datos.Add(new KeyValuePair<string, object?>(key, value));
    }
    public static T? Get<T>(string key)
    {
        foreach (var item in _datos)
        {
            if (item.Key == key && item.Value is T typedValue)
            {
                return typedValue;
            }
        }
        return default;
    }
    public static bool Contains(string key)
    {
        foreach (var item in _datos)
        {
            if (item.Key == key) return true;
        }
        return false;
    }
    public static bool Remove(string key)
    {
        return _datos.RemoveAll(item => item.Key == key) > 0;
    }
    public static void CerrarSesion()
    {
        _alumnoLogueado = null;
        _docenteLogueado = null;
        _adminLogueado = null;
    }
    public static bool HayUsuarioLogueado => _alumnoLogueado != null || _docenteLogueado != null || _adminLogueado != null;
    public static void Clear()
    {
        _datos.Clear();
        CerrarSesion();
    }
    public static int Count() => _datos.Count;
    public static IEnumerable<string> GetKeys()
    {
        foreach (var item in _datos)
        {
            yield return item.Key;
        }
    }
}