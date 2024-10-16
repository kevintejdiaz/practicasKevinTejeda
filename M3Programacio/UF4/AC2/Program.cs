public class Robot {
    public string Nombre { get; set; }
    public string TipoUnidad { get; set; }
    public double NivelBateria { get; set; }

    public Robot() {}
    public virtual string ObtenerInfo() {
        return $"Nombre: {Nombre}, Tipo de unidad: {TipoUnidad}, Nivel de bateria: {NivelBateria}%";
    }
}

// Clase derivada DroideProtocolo
public class DroideProtocolo : Robot {
    public DroideProtocolo(string nombre, string tipoUnidad, double nivelBateria) {
        this.Nombre = nombre;
        this.TipoUnidad = tipoUnidad;
        this.NivelBateria = nivelBateria;
    }

    public override string ObtenerInfo() {
        return base.ObtenerInfo() + " (Droide protocolo)";
    }
}

public class DroideCombate : Robot {
    public int NivelPotenciaFuego { get; set; }

    public DroideCombate(string nombre, string tipoUnidad, double nivelBateria, int nivelPotenciaFuego) {
        this.Nombre = nombre;
        this.TipoUnidad = tipoUnidad;
        this.NivelBateria = nivelBateria;
        this.NivelPotenciaFuego = nivelPotenciaFuego;
    }

    public override string ObtenerInfo() {
        return base.ObtenerInfo() + $", Nivel de Potencia de Fuego: {NivelPotenciaFuego} (Droide Combate)";
    }

    public int GenerarCombatesRealizados() {
        Random random = new Random();
        return random.Next(1, 100);
    }
}

public class DroideAstromecanico : Robot {
    public string UltimaReparacion { get; set; }

    public DroideAstromecanico(string nombre, string tipoUnidad, double nivelBateria, string ultimaReparacion) {
        this.Nombre = nombre;
        this.TipoUnidad = tipoUnidad;
        this.NivelBateria = nivelBateria;
        this.UltimaReparacion = ultimaReparacion;
    }

    public override string ObtenerInfo() {
        return base.ObtenerInfo() + $", Ultima reparacion: {UltimaReparacion} (Droide Astromecánico)";
    }

    public int GenerarNavesReparadas() {
        Random random = new Random();
        return random.Next(1, 50);
    }
}

internal class Program {
    static List<Robot> robots = new List<Robot>();

    private static void Main(string[] args) {
        bool salir = false;

        while (!salir) {
            Console.WriteLine("1. Añadir nuevo robot");
            Console.WriteLine("2. Mostrar todos los robots");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion) {
                case "1":
                    AñadirRobot();
                    break;
                case "2":
                    MostrarRobots();
                    break;
                case "3":
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                    break;
            }
        }
    }

    static void AñadirRobot() {
        Console.WriteLine("\n Agregar nuevo robot");
        Console.WriteLine("Seleccione el tipo de robot:");
        Console.WriteLine("1. Droide Protocolo");
        Console.WriteLine("2. Droide Combate");
        Console.WriteLine("3. Droide Astromecánico");
        string tipo = Console.ReadLine();

        Console.Write("Nombre del robot: ");
        string nombre = Console.ReadLine();

        Console.Write("Nivel de bateria: ");
        double nivelBateria = double.Parse(Console.ReadLine());

        switch (tipo) {
            case "1":
                robots.Add(new DroideProtocolo(nombre, "Protocolo", nivelBateria));
                Console.WriteLine("Droide protocolo agregado.");
                break;
            case "2":
                Console.Write("Nivel de potencia de fuego: ");
                int nivelPotenciaFuego = int.Parse(Console.ReadLine());
                robots.Add(new DroideCombate(nombre, "Combate", nivelBateria, nivelPotenciaFuego));
                Console.WriteLine("Droide combate agregado.");
                break;
            case "3":
                Console.Write("Ultima reparación: ");
                string ultimaReparacion = Console.ReadLine();
                robots.Add(new DroideAstromecanico(nombre, "Astromecanico", nivelBateria, ultimaReparacion));
                Console.WriteLine("Droide astromecanico agregado.");
                break;
            default:
                Console.WriteLine("Tipo de robot no reconocido.");
                break;
        }
    }

    static void MostrarRobots() {
        Console.WriteLine("\nMostrar Robots");

        foreach (var robot in robots) {
            Console.WriteLine(robot.ObtenerInfo());

            if (robot is DroideCombate combate) {
                Console.WriteLine($"Combates realizados: {combate.GenerarCombatesRealizados()}");
            } else if (robot is DroideAstromecanico astromecanico) {
                Console.WriteLine($"Naves reparadas: {astromecanico.GenerarNavesReparadas()}");
            }
        }
    }
}
