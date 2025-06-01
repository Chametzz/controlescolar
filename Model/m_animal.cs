public class Animal
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;

    public Animal() { }

    public Animal(string nombre)
    {
        Nombre = nombre;
    }
}

public class Perro : Animal
{
    public string Raza { get; set; } = string.Empty;

    public Perro() { }

    public Perro(string nombre, string raza) : base(nombre)
    {
        Raza = raza;
    }
}

public class Gato : Animal
{
    public bool EsCasero { get; set; }

    public Gato() { }

    public Gato(string nombre, bool esCasero) : base(nombre)
    {
        EsCasero = esCasero;
    }
}

public class Pajaro : Animal
{
    public double Envergadura { get; set; }

    public Pajaro() { }

    public Pajaro(string nombre, double envergadura) : base(nombre)
    {
        Envergadura = envergadura;
    }
}
