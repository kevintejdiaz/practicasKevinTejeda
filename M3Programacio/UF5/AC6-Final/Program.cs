using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

class Program
{
    private static readonly HttpClient client = new HttpClient()
    {
        Timeout = TimeSpan.FromSeconds(5)
    };
    private static int puntosTotales = 0;
    private static int tiradasRestantes = 10;
    private static OrdenProduccion<Robot> produccion = new OrdenProduccion<Robot>();
    private static Dictionary<string, int> modelosIds = new Dictionary<string, int>();

    static async Task Main(string[] args)
    {
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Add("User-Agent", "RobotSlotsGame");

        Console.WriteLine("BIENVENIDO A ROBOT TRAGAPERRAS!");

        bool salir = false;
        while (!salir)
        {
            MostrarMenu();
            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    await JugarPartida();
                    break;
                case "2":
                    MostrarResultados();
                    break;
                case "3":
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }

        Console.WriteLine("¡Gracias por jugar!");
    }

    static void MostrarMenu()
    {
        Console.WriteLine("\nMENÚ PRINCIPAL");
        Console.WriteLine("1) Jugar partida (10 tiradas)");
        Console.WriteLine("2) Mostrar resultados anteriores");
        Console.WriteLine("3) Salir");
        Console.Write("Seleccione una opción: ");
    }

    static async Task JugarPartida()
    {
        puntosTotales = 0;
        tiradasRestantes = 10;
        produccion = new OrdenProduccion<Robot>();
        modelosIds.Clear();

        Console.WriteLine("\n¡NUEVA PARTIDA!");
        Console.WriteLine("Presiona cualquier tecla para hacer una tirada...");

        while (tiradasRestantes > 0)
        {
            Console.ReadKey(true);
            await RealizarTirada();
            tiradasRestantes--;
            Console.WriteLine($"\nTiradas restantes: {tiradasRestantes} | Puntos: {puntosTotales}");
        }

        FinalizarJuego();
    }

    static void MostrarResultados()
    {
        if (!File.Exists("puntuaciones.txt"))
        {
            Console.WriteLine("\nNo hay resultados guardados todavía.");
            return;
        }

        Console.WriteLine("\nRESULTADOS ANTERIORES:");
        Console.WriteLine("=====================");

        var lineas = File.ReadAllLines("puntuaciones.txt");
        foreach (var linea in lineas)
        {
            var partes = linea.Split(',');
            if (partes.Length == 3)
            {
                Console.WriteLine($"Jugador: {partes[0]} - Puntos: {partes[1]} - Fecha: {partes[2]}");
            }
        }

        var top3 = lineas.Select(l => l.Split(','))
                        .Where(p => p.Length == 3)
                        .OrderByDescending(p => int.Parse(p[1]))
                        .Take(3);

        Console.WriteLine("\nTOP 3 PUNTUACIONES:");
        int posicion = 1;
        foreach (var item in top3)
        {
            Console.WriteLine($"{posicion}. {item[0]} - {item[1]} puntos ({item[2]})");
            posicion++;
        }
    }

static async Task RealizarTirada()
{
    try
    {
        List<int[]> resultadosApi = new List<int[]>();
        
        for (int i = 0; i < 10; i++)
        {
            var response = await client.GetStringAsync("https://www.randomnumberapi.com/api/v1.0/random?min=1&max=3&count=3");
            
            // Procesamiento más robusto de la respuesta
            var numeros = response.Trim()
                                .TrimStart('[')
                                .TrimEnd(']')
                                .Split(',')
                                .Select(s => {
                                    if (int.TryParse(s.Trim(), out int num))
                                        return num;
                                    return 1; // Valor por defecto si falla el parseo
                                })
                                .ToArray();
            
            // Asegurarnos de que siempre tenemos 3 números
            if (numeros.Length != 3)
            {
                numeros = new int[] {1, 2, 3}; // Valores por defecto
            }
            
            resultadosApi.Add(numeros);
            
            // Mostrar animación
            Console.Write("\r[ ");
            foreach (var num in numeros)
            {
                string simbolo = num switch
                {
                    1 => "R2D2",
                    2 => "C3PO",
                    3 => "BB8",
                    _ => "R2D2"
                };
                Console.Write($"{simbolo} ] [ ");
            }
            
            // Delay variable
            int delay = new Random().Next(100, 400);
            await Task.Delay(delay);
        }
        
        // Usar el último resultado para el cálculo final
        var numerosFinales = resultadosApi.Last();
        string[] simbolosFinales = numerosFinales.Select(num => num switch
        {
            1 => "R2D2",
            2 => "C3PO",
            3 => "BB8",
            _ => "R2D2"
        }).ToArray();
        
        Console.WriteLine();
        ProcesarResultado(simbolosFinales);
    }
    catch (HttpRequestException httpEx)
    {
        Console.WriteLine($"\nError de conexión: {httpEx.Message}");
        Console.WriteLine("Usando valores aleatorios locales...");
        Random random = new Random();
        string[] simbolosDefault = Enumerable.Range(0, 3)
            .Select(_ => random.Next(1, 4))
            .Select(num => num switch
            {
                1 => "R2D2",
                2 => "C3PO",
                3 => "BB8",
                _ => "R2D2"
            }).ToArray();
        ProcesarResultado(simbolosDefault);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"\nError inesperado: {ex.Message}");
        // Usar valores por defecto en caso de error
        Console.WriteLine("Usando valores por defecto...");
        string[] simbolosDefault = new string[] {"R2D2", "C3PO", "BB8"};
        ProcesarResultado(simbolosDefault);
    }
}
    static void ProcesarResultado(string[] simbolos)
    {
        var grupos = from s in simbolos
                     group s by s into g
                     select g;

        int coincidencias = (from g in grupos
                            select g.Count())
                           .Max();

        foreach (var modelo in simbolos)
        {
            if (!modelosIds.ContainsKey(modelo))
                modelosIds[modelo] = 0;
            modelosIds[modelo]++;

            Robot robot = modelo switch
            {
                "R2D2" => new R2D2(modelosIds[modelo]),
                "C3PO" => new C3PO(modelosIds[modelo]),
                "BB8" => new BB8(modelosIds[modelo]),
                _ => new R2D2(modelosIds["R2D2"])
            };

            produccion.AgregarOrden(robot);
        }

        if (coincidencias == 3)
        {
            puntosTotales += 10;
            Console.WriteLine("¡TRIPLE! +10 puntos");
        }
        else if (coincidencias == 2)
        {
            puntosTotales += 5;
            Console.WriteLine("¡DOBLE! +5 puntos");
        }
    }

    static void FinalizarJuego()
    {
        Console.WriteLine("\n--- FIN DEL JUEGO ---");
        Console.WriteLine($"PUNTOS POR COMBINACIONES: {puntosTotales}");
        Console.WriteLine($"PUNTOS POR ROBOTS: {produccion.TotalPuntos()}");
        Console.WriteLine($"PUNTUACIÓN TOTAL: {puntosTotales + produccion.TotalPuntos()}");

        produccion.MostrarEstadisticas();

        Console.Write("\nIntroduce tu nombre para guardar la puntuación: ");
        string nombre = Console.ReadLine();

        string registro = $"{nombre},{puntosTotales + produccion.TotalPuntos()},{DateTime.Now:yyyy-MM-dd}\n";
        File.AppendAllText("puntuaciones.txt", registro);

        if (File.Exists("puntuaciones.txt"))
        {
            var top3 = (from linea in File.ReadAllLines("puntuaciones.txt")
                       let partes = linea.Split(',')
                       where partes.Length == 3
                       orderby int.Parse(partes[1]) descending
                       select new
                       {
                           Nombre = partes[0],
                           Puntos = int.Parse(partes[1]),
                           Fecha = partes[2]
                       }).Take(3);

            Console.WriteLine("\nTOP 3 PUNTUACIONES:");
            int posicion = 1;
            foreach (var item in top3)
            {
                Console.WriteLine($"{posicion}. {item.Nombre} - {item.Puntos} puntos ({item.Fecha})");
                posicion++;
            }
        }
    }
}