using System;
using System.Collections.Generic;

public static class BolsaGlobal
{
    //Propiedades específicas para usuarios logueados
    private static Alumno? _alumnoLogueado;
    private static Empleado? _adminLogueado;
    private static Empleado? _docenteLogueado;

    private static readonly List<KeyValuePair<string, object?>> _datos = new();

    //Propiedades públicas para acceso controlado
    public static Alumno? AlumnoLogueado
    {
        get => _alumnoLogueado;
        set
        {
            _alumnoLogueado = value;
            // Si se asigna un alumno, automáticamente se limpia el docente
            if (value != null) _docenteLogueado = null;
        }
    }
        public static Empleado? AdminLogueado
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
            _docenteLogueado = value;
            // Si se asigna un docente, automáticamente se limpia el alumno
            if (value != null) _alumnoLogueado = null;
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