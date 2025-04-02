using System;
using System.Collections.Generic;
using System.Linq;

public class OrdenProduccion<T> where T : Robot
{
    private List<T> ordenes = new List<T>();
    private static Dictionary<string, int> contadores = new Dictionary<string, int>();
    
    public void AgregarOrden(T robot)
    {
        ordenes.Add(robot);
        if (!contadores.ContainsKey(robot.Modelo))
            contadores[robot.Modelo] = 0;
        contadores[robot.Modelo]++;
    }
    
    public IEnumerable<T> ObtenerOrdenes()
    {
        return ordenes;
    }
    
    public int TotalPuntos()
    {
        return ordenes.Sum(robot => robot.Modelo switch
        {
            "R2D2" => 3,
            "C3PO" => 2,
            "BB8" => 1,
            _ => 0
        });
    }
    
    public int PuntuacionMaxima()
    {
        if (!ordenes.Any()) return 0;
        return ordenes.Max(robot => robot.Modelo switch
        {
            "R2D2" => 3,
            "C3PO" => 2,
            "BB8" => 1,
            _ => 0
        });
    }
    
    public int PuntuacionMinima()
    {
        if (!ordenes.Any()) return 0;
        return ordenes.Min(robot => robot.Modelo switch
        {
            "R2D2" => 3,
            "C3PO" => 2,
            "BB8" => 1,
            _ => 0
        });
    }
    
    public void MostrarEstadisticas()
    {
        Console.WriteLine("\n--- Estadísticas de Producción ---");
        
        foreach (var kvp in contadores.OrderBy(x => x.Key))
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value} unidades");
        }
        
        var puntosPorModelo = ordenes
            .GroupBy(r => r.Modelo)
            .Select(g => new {
                Modelo = g.Key,
                Puntos = g.Sum(r => r.Modelo switch {
                    "R2D2" => 3,
                    "C3PO" => 2,
                    "BB8" => 1,
                    _ => 0
                })
            });
        
        foreach (var item in puntosPorModelo)
        {
            Console.WriteLine($"Puntos {item.Modelo}: {item.Puntos}");
        }
        
        Console.WriteLine($"\nPuntuación Total: {TotalPuntos()}");
        Console.WriteLine($"Puntuación Máxima por Robot: {PuntuacionMaxima()}");
        Console.WriteLine($"Puntuación Mínima por Robot: {PuntuacionMinima()}");
    }
}