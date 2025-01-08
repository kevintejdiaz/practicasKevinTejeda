// Clase para Persona (base para clientes y empleados)
public class Persona
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public int Edad { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
}

// Clase para Cliente
public class Cliente : Persona
{
    public LinkedList<Videojuego> JuegosAlquilados { get; private set; } = new LinkedList<Videojuego>();

    public void AlquilarJuego(Videojuego juego)
    {
        JuegosAlquilados.AddLast(juego);
        juego.IncrementarAlquiler();
    }

    public void DevolverJuego(Videojuego juego)
    {
        JuegosAlquilados.Remove(juego);
    }
}

// Clase para Empleado
public class Empleado : Persona
{
    public string Categoria { get; set; }
    public decimal Salario { get; set; }
}