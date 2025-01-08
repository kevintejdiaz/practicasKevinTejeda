// Clase para gestionar el sistema
public class SistemaAlquiler
{
    private LinkedList<Cliente> clientes = new LinkedList<Cliente>();
    private LinkedList<Empleado> empleados = new LinkedList<Empleado>();
    private LinkedList<Videojuego> videojuegos = new LinkedList<Videojuego>();

    // Métodos para clientes
    public void AltaCliente(Cliente cliente)
    {
        clientes.AddLast(cliente);
    }

    public void BajaCliente(string nombre, string apellido)
    {
        Cliente clienteAEliminar = null;
        foreach (var cliente in clientes)
        {
            if (cliente.Nombre == nombre && cliente.Apellido == apellido)
            {
                clienteAEliminar = cliente;
                break;
            }
        }
        if (clienteAEliminar != null)
        {
            clientes.Remove(clienteAEliminar);
        }
    }

    // Métodos para empleados
    public void AltaEmpleado(Empleado empleado)
    {
        empleados.AddLast(empleado);
    }

    public void BajaEmpleado(string nombre, string apellido)
    {
        Empleado empleadoAEliminar = null;
        foreach (var empleado in empleados)
        {
            if (empleado.Nombre == nombre && empleado.Apellido == apellido)
            {
                empleadoAEliminar = empleado;
                break;
            }
        }
        if (empleadoAEliminar != null)
        {
            empleados.Remove(empleadoAEliminar);
        }
    }

    // Métodos para videojuegos
    public void AltaVideojuego(Videojuego juego)
    {
        videojuegos.AddLast(juego);
    }

    public void BajaVideojuego(string titulo)
    {
        Videojuego juegoAEliminar = null;
        foreach (var juego in videojuegos)
        {
            if (juego.Titulo == titulo)
            {
                juegoAEliminar = juego;
                break;
            }
        }
        if (juegoAEliminar != null)
        {
            videojuegos.Remove(juegoAEliminar);
        }
    }

    // Listados
    public LinkedList<Videojuego> ListarVideojuegosDisponibles()
    {
        LinkedList<Videojuego> disponibles = new LinkedList<Videojuego>();
        foreach (var juego in videojuegos)
        {
            if (juego.VecesAlquilado == 0)
            {
                disponibles.AddLast(juego);
            }
        }
        return disponibles;
    }

    public LinkedList<Videojuego> ListarVideojuegosAlquilados()
    {
        LinkedList<Videojuego> alquilados = new LinkedList<Videojuego>();
        foreach (var juego in videojuegos)
        {
            if (juego.VecesAlquilado > 0)
            {
                alquilados.AddLast(juego);
            }
        }
        return alquilados;
    }

    public LinkedList<Videojuego> ListarVideojuegosPorUsuario(string nombre, string apellido)
    {
        foreach (var cliente in clientes)
        {
            if (cliente.Nombre == nombre && cliente.Apellido == apellido)
            {
                return cliente.JuegosAlquilados;
            }
        }
        return new LinkedList<Videojuego>();
    }

    public LinkedList<Cliente> ListarUsuariosConJuegosPrestados()
    {
        LinkedList<Cliente> usuariosConPrestamos = new LinkedList<Cliente>();
        foreach (var cliente in clientes)
        {
            if (cliente.JuegosAlquilados.Count > 0)
            {
                usuariosConPrestamos.AddLast(cliente);
            }
        }
        return usuariosConPrestamos;
    }

    // Método para alquilar videojuegos
    public void AlquilarVideojuego(string tituloJuego, string nombreCliente, string apellidoCliente)
    {
        // Buscar el cliente
        Cliente cliente = null;
        foreach (var c in clientes)
        {
            if (c.Nombre == nombreCliente && c.Apellido == apellidoCliente)
            {
                cliente = c;
                break;
            }
        }

        if (cliente == null)
        {
            Console.WriteLine("Cliente no encontrado.");
            return;
        }

        // Buscar el videojuego
        Videojuego juego = null;
        foreach (var v in videojuegos)
        {
            if (v.Titulo == tituloJuego && v.VecesAlquilado == 0) // Solo disponibles
            {
                juego = v;
                break;
            }
        }

        if (juego == null)
        {
            Console.WriteLine("Videojuego no disponible o no encontrado.");
            return;
        }

        // Alquilar el juego
        cliente.AlquilarJuego(juego);
        Console.WriteLine($"El juego '{tituloJuego}' ha sido alquilado por {cliente.Nombre} {cliente.Apellido}.");
    }
}
