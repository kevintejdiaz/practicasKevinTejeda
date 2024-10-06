public class Proyecto
{
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public int DiasRestantes { get; set; }
    public List<Empleado> EmpleadosAsignados { get; set; }
    public List<Tarea> Tareas { get; set; }
    public decimal CostoAprox { get; set; }
    public string Estado { get; set; }

    private const decimal PrecioPorDia = 50; 

    public Proyecto(string nombre, string descripcion, int diasRestantes, string estado)
    {
        Nombre = nombre;
        Descripcion = descripcion;
        DiasRestantes = diasRestantes;
        Estado = estado;
        EmpleadosAsignados = new List<Empleado>();
        Tareas = new List<Tarea>();
        CostoAprox = diasRestantes * PrecioPorDia; 
    }

    public void AgregarEmpleado(Empleado empleado)
    {
        EmpleadosAsignados.Add(empleado);
    }

    public void AgregarTarea(Tarea tarea)
    {
        Tareas.Add(tarea);
    }
}

public class Empleado
{
    public string NombreE { get; set; }
    public string Cargo { get; set; }
    public decimal Salario { get; set; }

    public Empleado(string nombre, string cargo, decimal salario)
    {
        NombreE = nombre;
        Cargo = cargo;
        Salario = salario;
    }
}

public class Tarea
{
    public string NombreT { get; set; }
    public string EstadoT { get; set; }
    public string DescripcionT { get; set; }

    public Tarea(string nombre, string estado, string descripcion)
    {
        NombreT = nombre;
        EstadoT = estado;
        DescripcionT = descripcion;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Añade el nombre del proyecto:");
        string nombreProyecto = Console.ReadLine();

        Console.WriteLine("Añade la descripción del proyecto:");
        string descripcionProyecto = Console.ReadLine();

        Console.WriteLine("Añade los dias restantes para completar el proyecto:");
        int diasRestantes = int.Parse(Console.ReadLine());

        Console.WriteLine("Añade el estado del proyecto (En progreso/Completado):");
        string estadoProyecto = Console.ReadLine();

        Proyecto proyecto = new Proyecto(nombreProyecto, descripcionProyecto, diasRestantes, estadoProyecto);

        Console.WriteLine(" Cuantos empleados quiere agregar al proyecto?");
        int numeroEmpleados = int.Parse(Console.ReadLine());

        for (int i = 0; i < numeroEmpleados; i++)
        {
            Console.WriteLine($"\nAñade el nombre del empleado {i + 1}:");
            string nombreEmpleado = Console.ReadLine();

            Console.WriteLine("Añade el cargo del empleado:");
            string cargoEmpleado = Console.ReadLine();

            Console.WriteLine("Añade el salario del empleado:");
            decimal salarioEmpleado = decimal.Parse(Console.ReadLine());

            proyecto.AgregarEmpleado(new Empleado(nombreEmpleado, cargoEmpleado, salarioEmpleado));
        }

        Console.WriteLine(" Cuántas tareas quiere agregar al proyecto?");
        int numeroTareas = int.Parse(Console.ReadLine());

        for (int i = 0; i < numeroTareas; i++)
        {
            Console.WriteLine($"\nAñade el nombre de la tarea {i + 1}:");
            string nombreTarea = Console.ReadLine();

            Console.WriteLine("Añade el estado de la tarea:");
            string estadoTarea = Console.ReadLine();

            Console.WriteLine("Añade la descripción de la tarea:");
            string descripcionTarea = Console.ReadLine();

            proyecto.AgregarTarea(new Tarea(nombreTarea, estadoTarea, descripcionTarea));
        }

        Console.WriteLine($"\nProyecto: {proyecto.Nombre}");
        Console.WriteLine($"Descripción: {proyecto.Descripcion}");
        Console.WriteLine($"dias restantes: {proyecto.DiasRestantes}");
        Console.WriteLine($"Costo aproximado: {proyecto.CostoAprox}");
        Console.WriteLine($"Estado: {proyecto.Estado}");

        Console.WriteLine("\nEmpleados asignados:");
        foreach (var empleado in proyecto.EmpleadosAsignados)
        {
            Console.WriteLine($"- {empleado.NombreE}, Cargo: {empleado.Cargo}, Salario: {empleado.Salario}");
        }

        Console.WriteLine("\nTareas:");
        foreach (var tarea in proyecto.Tareas)
        {
            Console.WriteLine($"- {tarea.NombreT}, Estado: {tarea.EstadoT}, Descripción: {tarea.DescripcionT}");
        }
    }
}
