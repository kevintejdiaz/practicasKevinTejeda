class Program
{
    static void Main()
    {
        var apiProductos = new ApiGenerica<Producto>();
        var apiClientes = new ApiGenerica<Cliente>();
        var apiEmpleados = new ApiGenerica<Empleado>();

        bool continuar = true;
        while (continuar)
        {
            Console.WriteLine("Seleccione una opción:");
            Console.WriteLine("1. Agregar Producto");
            Console.WriteLine("2. Mostrar Productos");
            Console.WriteLine("3. Agregar Cliente");
            Console.WriteLine("4. Mostrar Clientes");
            Console.WriteLine("5. Agregar Empleado");
            Console.WriteLine("6. Mostrar Empleados");
            Console.WriteLine("7. Salir");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese ID: ");
                    int idP = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese Nombre: ");
                    string nombreP = Console.ReadLine();
                    Console.Write("Ingrese Precio: ");
                    decimal precio = decimal.Parse(Console.ReadLine());
                    apiProductos.AgregarElemento(new Producto { Id = idP, Nombre = nombreP, Precio = precio });
                    break;
                case "2":
                    apiProductos.MostrarElementos();
                    break;
                case "3":
                    Console.Write("Ingrese ID: ");
                    int idC = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese Nombre: ");
                    string nombreC = Console.ReadLine();
                    apiClientes.AgregarElemento(new Cliente { Id = idC, Nombre = nombreC });
                    break;
                case "4":
                    apiClientes.MostrarElementos();
                    break;
                case "5":
                    Console.Write("Ingrese ID: ");
                    int idE = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese Nombre: ");
                    string nombreE = Console.ReadLine();
                    Console.Write("Ingrese Puesto: ");
                    string puesto = Console.ReadLine();
                    apiEmpleados.AgregarElemento(new Empleado { Id = idE, Nombre = nombreE, Puesto = puesto });
                    break;
                case "6":
                    apiEmpleados.MostrarElementos();
                    break;
                case "7":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
}