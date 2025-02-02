using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        TestValidator("Email", ValidarEmail, new[]
        {
            ("usuario@dominio.com"),
            ("nombre.apellido@sub.dominio.co.uk"),
            ("user@domain"),  // Falta TLD
            ("@dominio.com")  // Sin parte local
        });

        TestValidator("Teléfono", ValidarTelefono, new[]
        {
            ("123-456-7890"),
            ("111-222-3333"),
            ("12-345-6789"),   // Formato incorrecto
            ("1234567890")     // Sin guiones
        });

        TestValidator("Fecha", ValidarFecha, new[]
        {
            ("29/02/2024"),
            ("31/12/2023"),
            ("32/13/2023"),    // Mes/día inválido
            ("1/1/23")         // Año corto
        });

        TestValidator("IPv4", ValidarIPv4, new[]
        {
            ("192.168.1.1"),
            ("255.255.255.255"),
            ("256.0.0.0"),     // Octeto >255
            ("192.168.1")      // Faltan octetos
        });

        TestValidator("Código Postal", ValidarCodigoPostal, new[]
        {
            ("12345"),
            ("98765"),
            ("1234"),          // 4 dígitos
            ("ABCDE")          // Letras
        });

        TestValidator("Solo Letras", ValidarSoloLetras, new[]
        {
            ("Hola"),
            ("HELLO"),
            ("H0la"),          // Contiene número
            ("Hola!")          // Carácter especial
        });

        TestValidator("Entero Positivo", ValidarEnteroPositivo, new[]
        {
            ("123"),
            ("999999"),
            ("-123"),          // Negativo
            ("12.34")          // Decimal
        });

        TestValidator("URL", ValidarURL, new[]
        {
            ("http://www.ejemplo.com/"),
            ("https://sub.dominio.com/path?q=123"),
            ("www.ejemplo.com"),// Protocolo opcional
            ("ftp://dominio.com") // Protocolo no soportado
        });

        TestValidator("Color Hexadecimal", ValidarHexColor, new[]
        {
            ("#A3C1D7"),
            ("#FFF"),
            ("A3C1D7"),        // Falta #
            ("#GHIJKL")        // Caracteres inválidos
        });

        TestValidator("Decimal", ValidarDecimal, new[]
        {
            ("12.23"),
            ("0.5"),
            ("123"),           // Sin punto
            ("12.3.4")         // Múltiples puntos
        });
    }

    static void TestValidator(string nombre, Func<string, bool> validador, string[] casos)
    {
        Console.WriteLine($"\n** Validando {nombre} **");
        foreach (var caso in casos)
        {
            bool resultado = validador(caso);
            string estado = resultado ? "✅" : "❌";
            Console.WriteLine($"{estado} Input: '{caso}' | Obtenido: {resultado}");
        }
    }

    public static bool ValidarEmail(string email) => Regex.IsMatch(email, @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$");
    public static bool ValidarTelefono(string telefono) => Regex.IsMatch(telefono, @"^\d{3}-\d{3}-\d{4}$");
    public static bool ValidarFecha(string fecha) => Regex.IsMatch(fecha, @"^(0?[1-9]|[12][0-9]|3[01])/(0?[1-9]|1[0-2])/\d{4}$");
    public static bool ValidarIPv4(string ip) => Regex.IsMatch(ip, @"^(25[0-5]|2[0-4]\d|1\d{2}|[1-9]?\d)(\.(25[0-5]|2[0-4]\d|1\d{2}|[1-9]?\d)){3}$");
    public static bool ValidarCodigoPostal(string codigo) => Regex.IsMatch(codigo, @"^\d{5}$");
    public static bool ValidarSoloLetras(string palabra) => Regex.IsMatch(palabra, @"^[a-zA-Z]+$");
    public static bool ValidarEnteroPositivo(string numero) => Regex.IsMatch(numero, @"^\d+$");
    public static bool ValidarURL(string url) => Regex.IsMatch(url, @"^(https?://)?([\w-]+\.)+[\w-]+(/[\w-./?%&=]*)?$", RegexOptions.IgnoreCase);
    public static bool ValidarHexColor(string color) => Regex.IsMatch(color, @"^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$");
    public static bool ValidarDecimal(string numero) => Regex.IsMatch(numero, @"^\d+\.\d+$");
}
