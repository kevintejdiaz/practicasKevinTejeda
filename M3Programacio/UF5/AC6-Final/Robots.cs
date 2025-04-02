using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Robot
{
    public int Id { get; protected set; }
    public string Modelo { get; protected set; }
    public DateTime FechaCreacion { get; protected set; }
    
    public abstract void ShowData();
}

public class C3PO : Robot
{
    public C3PO(int id)
    {
        Id = id;
        Modelo = "C3PO";
        Random random = new Random();
        FechaCreacion = DateTime.Now.AddDays(-random.Next(365));
    }
    
    public int NumberOfRepairs()
    {
        return new Random().Next(1, 10);
    }
    
    public override void ShowData()
    {
        Console.WriteLine($"[{Id}] {Modelo} - Creado: {FechaCreacion:d} - Reparaciones: {NumberOfRepairs()}");
    }
}

public class R2D2 : Robot
{
    public int Version { get; }
    
    public R2D2(int id)
    {
        Id = id;
        Modelo = "R2D2";
        Random random = new Random();
        FechaCreacion = DateTime.Now.AddDays(-random.Next(365));
        Version = random.Next(1, 5);
    }
    
    public int NumberOfBattles()
    {
        return new Random().Next(0, 50);
    }
    
    public override void ShowData()
    {
        Console.WriteLine($"[{Id}] {Modelo} v{Version} - Creado: {FechaCreacion:d} - Batallas: {NumberOfBattles()}");
    }
}

public class BB8 : Robot
{
    public float Version { get; }
    
    public BB8(int id)
    {
        Id = id;
        Modelo = "BB8";
        Random random = new Random();
        FechaCreacion = DateTime.Now.AddDays(-random.Next(365));
        Version = (float)Math.Round(random.NextDouble() * 2 + 1, 1);
    }
    
    public int NumberOfFlights()
    {
        return new Random().Next(10, 100);
    }
    
    public int NumberOfRepairs()
    {
        return new Random().Next(1, 5);
    }
    
    public override void ShowData()
    {
        Console.WriteLine($"[{Id}] {Modelo} v{Version} - Creado: {FechaCreacion:d} - Vuelos: {NumberOfFlights()} - Reparaciones: {NumberOfRepairs()}");
    }
}