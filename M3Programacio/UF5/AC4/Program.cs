using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<Persona> personas = new List<Persona>
        {
            new Persona("Juan", 30),
            new Persona("Pedro", 31),
            new Persona("Miguel", 25),
            new Persona("Luís", 36),
            new Persona("José", 25),
        };

        Persona masJoven = personas.OrderBy(p => p.Edad).First();
        Console.WriteLine($"Persona más joven: {masJoven.Nombre}");

        double edadPromedio = personas.Average(p => p.Edad);
        Console.WriteLine($"Edad promedio: {edadPromedio}");

        var mayoresDe25 = personas.Where(p => p.Edad > 25).OrderBy(p => p.Nombre);
        Console.WriteLine("Personas mayores de 25 ordenadas por nombre:");
        foreach (var p in mayoresDe25) Console.WriteLine(p.Nombre);

        var nombresConM = personas.Where(p => p.Nombre.StartsWith("M")).OrderByDescending(p => p.Edad);
        Console.WriteLine("Personas con 'M' ordenadas por edad descendente:");
        foreach (var p in nombresConM) Console.WriteLine(p.Nombre);

        bool todosMayoresDe18 = personas.All(p => p.Edad > 18);
        Console.WriteLine($"Todos son mayores de 18: {todosMayoresDe18}");

        Persona jovenConA = personas.Where(p => p.Nombre.Contains("a")).OrderBy(p => p.Edad).FirstOrDefault();
        Console.WriteLine($"Persona más joven con 'a' en el nombre: {jovenConA?.Nombre}");

        var agrupados = personas.GroupBy(p => p.Nombre[0])
                                .Select(g => new { Letra = g.Key, Cantidad = g.Count() });
        Console.WriteLine("Cantidad de personas por primera letra:");
        foreach (var g in agrupados) Console.WriteLine($"{g.Letra}: {g.Cantidad} personas");

        Persona jovenImpar = personas.Where(p => p.Edad % 2 != 0).OrderBy(p => p.Edad).FirstOrDefault();
        Console.WriteLine($"Persona más joven con edad impar: {jovenImpar?.Nombre}");

        personas.RemoveAll(p => p.Edad % 5 == 0);
        Console.WriteLine("Lista después de eliminar múltiplos de 5:");
        foreach (var p in personas) Console.WriteLine(p.Nombre);

        int diferenciaEdad = personas.Max(p => p.Edad) - personas.Min(p => p.Edad);
        Console.WriteLine($"Diferencia de edad entre el más joven y el más viejo: {diferenciaEdad}");
    }
}
