// Programa principal actualizado
class Program
{
    static void Main(string[] args)
    {
        SistemaAlquiler sistema = new SistemaAlquiler();
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1. Alta de usuarios");
            Console.WriteLine("2. Baja de usuarios");
            Console.WriteLine("3. Alta de empleados");
            Console.WriteLine("4. Baja de empleados");
            Console.WriteLine("5. Alta de videojuegos");
            Console.WriteLine("6. Baja de videojuegos");
            Console.WriteLine("7. Alquilar videojuego");
            Console.WriteLine("8. Listar videojuegos disponibles");
            Console.WriteLine("9. Listar videojuegos alquilados");
            Console.WriteLine("10. Listar videojuegos por usuario");
            Console.WriteLine("11. Listar usuarios con juegos prestados");
            Console.WriteLine("12. Salir");

            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Cliente cliente = new Cliente();
                    Console.Write("Nombre: "); cliente.Nombre = Console.ReadLine();
                    Console.Write("Apellido: "); cliente.Apellido = Console.ReadLine();
                    Console.Write("Edad: "); cliente.Edad = int.Parse(Console.ReadLine());
                    Console.Write("Dirección: "); cliente.Direccion = Console.ReadLine();
                    Console.Write("Teléfono: "); cliente.Telefono = Console.ReadLine();
                    sistema.AltaCliente(cliente);
                    break;

                case 2:
                    Console.Write("Nombre: "); string nombreCliente = Console.ReadLine();
                    Console.Write("Apellido: "); string apellidoCliente = Console.ReadLine();
                    sistema.BajaCliente(nombreCliente, apellidoCliente);
                    break;

                case 3:
                    Empleado empleado = new Empleado();
                    Console.Write("Nombre: "); empleado.Nombre = Console.ReadLine();
                    Console.Write("Apellido: "); empleado.Apellido = Console.ReadLine();
                    Console.Write("Edad: "); empleado.Edad = int.Parse(Console.ReadLine());
                    Console.Write("Dirección: "); empleado.Direccion = Console.ReadLine();
                    Console.Write("Teléfono: "); empleado.Telefono = Console.ReadLine();
                    Console.Write("Categoría: "); empleado.Categoria = Console.ReadLine();
                    Console.Write("Salario: "); empleado.Salario = decimal.Parse(Console.ReadLine());
                    sistema.AltaEmpleado(empleado);
                    break;

                case 4:
                    Console.Write("Nombre: "); string nombreEmpleado = Console.ReadLine();
                    Console.Write("Apellido: "); string apellidoEmpleado = Console.ReadLine();
                    sistema.BajaEmpleado(nombreEmpleado, apellidoEmpleado);
                    break;

                case 5:
                    Videojuego juego = new Videojuego();
                    Console.Write("Título: "); juego.Titulo = Console.ReadLine();
                    Console.Write("Año de lanzamiento: "); juego.AnioLanzamiento = int.Parse(Console.ReadLine());
                    Console.Write("Temática: "); juego.Tematica = Console.ReadLine();
                    Console.Write("Estudio de desarrollo: "); juego.EstudioDesarrollo = Console.ReadLine();
                    sistema.AltaVideojuego(juego);
                    break;

                case 6:
                    Console.Write("Título: "); string tituloJuego = Console.ReadLine();
                    sistema.BajaVideojuego(tituloJuego);
                    break;
    
                case 7:
                Console.Write("Título del videojuego: ");
                string tituloAlquiler = Console.ReadLine();
                Console.Write("Nombre del cliente: ");
                string nombreAlquiler = Console.ReadLine();
                Console.Write("Apellido del cliente: ");
                string apellidoAlquiler = Console.ReadLine();
                sistema.AlquilarVideojuego(tituloAlquiler, nombreAlquiler, apellidoAlquiler);
                break;

                case 8:
                    foreach (var v in sistema.ListarVideojuegosDisponibles())
                    {
                        Console.WriteLine(v.Titulo);
                    }
                    break;

                case 9:
                    foreach (var v in sistema.ListarVideojuegosAlquilados())
                    {
                        Console.WriteLine(v.Titulo);
                    }
                    break;

                case 10:
                    Console.Write("Nombre: "); string nombreUsuario = Console.ReadLine();
                    Console.Write("Apellido: "); string apellidoUsuario = Console.ReadLine();
                    var juegosUsuario = sistema.ListarVideojuegosPorUsuario(nombreUsuario, apellidoUsuario);
                    foreach (var juegoUsuario in juegosUsuario)
                    {
                        Console.WriteLine(juegoUsuario.Titulo);
                    }
                    break;

                case 11:
                    var usuariosConPrestamos = sistema.ListarUsuariosConJuegosPrestados();
                    foreach (var usuario in usuariosConPrestamos)
                    {
                        Console.WriteLine($"{usuario.Nombre} {usuario.Apellido}");
                    }
                    break;

                case 12:
                    salir = true;
                    break;

                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }
        }
    }
}
