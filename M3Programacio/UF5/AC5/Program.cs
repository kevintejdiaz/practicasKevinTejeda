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
            Console.WriteLine("3. Eliminar Producto");
            Console.WriteLine("4. Agregar Cliente");
            Console.WriteLine("5. Mostrar Clientes");
            Console.WriteLine("6. Eliminar Cliente");
            Console.WriteLine("7. Agregar Empleado");
            Console.WriteLine("8. Mostrar Empleados");
            Console.WriteLine("9. Eliminar Empleado");
            Console.WriteLine("10. Salir");
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
                    Console.Write("Ingrese ID del Producto a eliminar: ");
                    int idEliminarP = int.Parse(Console.ReadLine());
                    apiProductos.EliminarElemento(idEliminarP);
                    break;
                case "4":
                    Console.Write("Ingrese ID: ");
                    int idC = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese Nombre: ");
                    string nombreC = Console.ReadLine();
                    apiClientes.AgregarElemento(new Cliente { Id = idC, Nombre = nombreC });
                    break;
                case "5":
                    apiClientes.MostrarElementos();
                    break;
                case "6":
                    Console.Write("Ingrese ID del Cliente a eliminar: ");
                    int idEliminarC = int.Parse(Console.ReadLine());
                    apiClientes.EliminarElemento(idEliminarC);
                    break;
                case "7":
                    Console.Write("Ingrese ID: ");
                    int idE = int.Parse(Console.ReadLine());
                    Console.Write("Ingrese Nombre: ");
                    string nombreE = Console.ReadLine();
                    Console.Write("Ingrese Puesto: ");
                    string puesto = Console.ReadLine();
                    apiEmpleados.AgregarElemento(new Empleado { Id = idE, Nombre = nombreE, Puesto = puesto });
                    break;
                case "8":
                    apiEmpleados.MostrarElementos();
                    break;
                case "9":
                    Console.Write("Ingrese ID del Empleado a eliminar: ");
                    int idEliminarE = int.Parse(Console.ReadLine());
                    apiEmpleados.EliminarElemento(idEliminarE);
                    break;
                case "10":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
}
