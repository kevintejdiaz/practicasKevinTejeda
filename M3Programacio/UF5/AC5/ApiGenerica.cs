using System;
using System.Collections.Generic;
using System.Linq;

public class ApiGenerica<T> where T : IEntidad
{
    private List<T> elementos;
    
    public ApiGenerica()
    {
        elementos = new List<T>();
    }

    public void AgregarElemento(T elemento)
    {
        elementos.Add(elemento);
    }

    public void EliminarElemento(int id)
    {
        var elemento = elementos.FirstOrDefault(e => e.Id == id);
        if (elemento != null)
        {
            elementos.Remove(elemento);
        }
        else
        {
            Console.WriteLine("Elemento no encontrado.");
        }
    }

    public T ObtenerElemento(int id)
    {
        return elementos.FirstOrDefault(e => e.Id == id);
    }

    public void ActualizarElemento(int id, T nuevoElemento)
    {
        var index = elementos.FindIndex(e => e.Id == id);
        if (index != -1)
        {
            elementos[index] = nuevoElemento;
        }
        else
        {
            Console.WriteLine("Elemento no encontrado.");
        }
    }

    public void MostrarElementos()
    {
        foreach (var elemento in elementos)
        {
            Console.WriteLine(elemento);
        }
    }
}