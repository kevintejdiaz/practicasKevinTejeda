using System;
using System.IO;

internal class Program
{
    private static void Main(string[] args)
    {
        // A)

        // try
        // {
        //     int num1, num2, resultado;

        //     Console.WriteLine("Introduce el primer número:");
        //     num1 = int.Parse(Console.ReadLine());

        //     Console.WriteLine("Introduce el segundo número:");
        //     num2 = int.Parse(Console.ReadLine());

        //     resultado = Dividir(num1, num2);
        //     Console.WriteLine("El resultado de la división es: " + resultado);
        // }
        // catch (FormatException)
        // {
        //     Console.WriteLine("Por favor, introduce un valor numérico.");
        // }
        // catch (DivideByZeroException)
        // {
        //     Console.WriteLine("No se puede dividir entre cero.");
        // }

        // B)

        // try
        // {
        //     Console.WriteLine("Introduce un número:");
        //     int input = Convert.ToInt32(Console.ReadLine());

        //     if (input > 0)
        //     {
        //         Console.WriteLine("El número introducido es positivo.");
        //     }
        //     else
        //     {
        //         Console.WriteLine("El número introducido no es positivo.");
        //     }
        // }
        // catch (FormatException)
        // {
        //     Console.WriteLine("Introduce un valor numérico válido.");
        // }

        // C) Lectura de archivo con manejo de excepciones
        // Console.WriteLine("Navegando por los archivos del Desktop.");

        // try
        //         {
        //             Console.WriteLine("Introduce el nombre del archivo al que quieres acceder:");
        //             string directorio = Console.ReadLine();

        //             string desktop = Path.Combine("C:\\Users\\kevin\\Desktop", directorio);

        //             string contenido = File.ReadAllText(desktop);

        //             Console.WriteLine("El contenido del archivo:");
        //             Console.WriteLine(contenido);
        //         }
        //         catch (FileNotFoundException)
        //         {
        //             Console.WriteLine("El archivo especificado no existe.");
        //         }
        //         catch (DirectoryNotFoundException)
        //         {
        //             Console.WriteLine("La ruta especificada no corresponde a un archivo o directorio válido.");
        //         }
        //         catch (UnauthorizedAccessException)
        //         {
        //             Console.WriteLine("No tienes permisos para acceder a este archivo.");
        //         }
       


        // D
    // try
    //     {
    //         Console.WriteLine("Introduce un numero entero:");
    //         int numero = int.Parse(Console.ReadLine());

    //         if (numero < 0 || numero > 1000)
    //         {
    //             throw new ArgumentOutOfRangeException(nameof(numero), "El numero debe estar entre 0 y 1000.");
    //         }

    //         Console.WriteLine($"Número válido ingresado: {numero}");
    //     }
    //     catch (Exception ex)
    //     {
    //         Console.WriteLine($"Ocurrió un error inesperado: {ex.Message}");
    //     }



        //E

        // try
        // {
        //     int[] numeros = { 10, 20, 30, 40, 50 };

        //     double promedio = Promedio(numeros);

        //     Console.WriteLine($"El promedio de los nums es de : {promedio}");
        // }
        // catch (IndexOutOfRangeException ex)
        // {
        //     Console.WriteLine($"Se intento acceder a un indice fuera del rango: {ex.Message}");
        // }
        // catch (Exception ex)
        // {
        //     Console.WriteLine(ex.Message);
        // }

        //F

        //  try
        // {
        //     Console.WriteLine("Introduce un numero entero: ");
        //     string input = Console.ReadLine();

        //     int numero = int.Parse(input);

        //     Console.WriteLine($"El numero ingresado es: {numero}");
        // }
        // catch (FormatException ex)
        // {
        //     Console.WriteLine($"Error: {ex.Message}");
        // }
        // catch (Exception ex)
        // {
        //     Console.WriteLine(ex.Message);
        // }


        //G





        //H

        // try
        // {   
        //     Console.WriteLine("Introduce el numerador:");
        //     int numerador = int.Parse(Console.ReadLine());

        //     Console.WriteLine("Introduce el denominador:");
        //     int denominador = int.Parse(Console.ReadLine());

        //     int resultado = Dividir(numerador, denominador);
        //     Console.WriteLine($"El resultado es: {resultado}");
        // }
        // catch (DivideByZeroException)
        // {
        //     Console.WriteLine("No se puede dividir entre cero.");
        // }
        // catch (Exception ex)
        // {
        //     Console.WriteLine(ex.Message);
        // }


        //I

        // try
        // {
        //     Console.WriteLine("Introduce un numero para calcular su raiz cuadrada:");
        //     double numero = double.Parse(Console.ReadLine());

        //     double resultado = CalcularRaizCuadrada(numero);
        //     Console.WriteLine($"La raiz cuadrada de {numero} es: {resultado}");
        // }
        // catch (ArgumentOutOfRangeException)
        // {
        //     Console.WriteLine(" No se puede calcular la raiz cuadrada de un negativo.");
        // }
        // catch (Exception ex)
        // {
        //     Console.WriteLine(ex.Message);
        // }


        //J

     try
        {
            Console.WriteLine("Introduce una frase para pasarla a MAYUS");
            string input = Console.ReadLine();

            string resultado = ConvertirAMayusculas(input);

            Console.WriteLine($"La cadena convertida es: {resultado}");
        }
        catch (NullReferenceException)
        {
            Console.WriteLine("La cadena que has proporcionado esta vacia");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }


    }

    private static int Dividir(int a, int b)
    {
        return a / b;
    }


    private static double Promedio (int[] nums)
    {
        int suma = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            suma += nums[i];
        }
        return (double)suma / nums.Length;    
    }

    private static double CalcularRaizCuadrada(double numero)
    {
        return Math.Sqrt(numero);
    }

    
    private static string ConvertirAMayusculas(string cadena)
    {
        return cadena.ToUpper();
    }
    
    
}
