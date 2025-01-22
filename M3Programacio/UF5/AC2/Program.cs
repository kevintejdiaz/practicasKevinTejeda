using System.Text.RegularExpressions;
class Program
{
    static void Main(string[] args)
    {
        string texto = @"Los correos electrónicos son una forma común de comunicación en la era digital. 
                        Un correo electrónico consta de varias partes, como el remitente, el destinatario, 
                        el asunto y el cuerpo del mensaje. Algunos ejemplos de direcciones de correo 
                        electrónico son: usuario@gmail.com, contacto@empresa.es y teléfono 987654321 o 9876543210. 
                        En el ámbito de la programación, las expresiones regulares son útiles para validar y buscar 
                        patrones en direcciones de correo electrónico. 
                        Las expresiones regulares se pueden utilizar en muchos lenguajes de programación, 
                        incluyendo Python, JavaScript y Java.";

        // 1. Palabras que contienen la letra "e"
        MatchCollection wordsWithE = Regex.Matches(texto, @"\b\w*e\w*\b");
        foreach (Match match in wordsWithE)
        {
            Console.WriteLine(match.Value);
        }

        // 2. Palabras que terminan con la sílaba "dad"
        MatchCollection wordsEndingInDad = Regex.Matches(texto, @"\b\w*dad\b");
        foreach (Match match in wordsEndingInDad)
        {
            Console.WriteLine(match.Value);
        }

        // 3. Apariciones de la palabra "lenguajes"
        MatchCollection languageMatches = Regex.Matches(texto, @"\blenguajes\b");
        foreach (Match match in languageMatches)
        {
            Console.WriteLine(match.Value);
        }

        // 4. Palabras que inician con "s" y terminan con "n"
        MatchCollection wordsStartingSAndEndingN = Regex.Matches(texto, @"\bs\w*n\b");
        foreach (Match match in wordsStartingSAndEndingN)
        {
            Console.WriteLine(match.Value);
        }

        // 5. Números de teléfono con formato "9876543210"
        MatchCollection phoneNumbers = Regex.Matches(texto, @"\b\d{10}\b");
        foreach (Match match in phoneNumbers)
        {
            Console.WriteLine(match.Value);
        }

        // 6. Direcciones de correo electrónico que terminan en ".es"
        MatchCollection emailsWithEs = Regex.Matches(texto, @"\b[A-Za-z0-9._%+-]+@[^@\s]+\.es\b");
        foreach (Match match in emailsWithEs)
        {
            Console.WriteLine(match.Value);
        }

        // 7. Palabras que inician con "a" y tienen al menos 5 caracteres
        MatchCollection wordsStartingAWithMinLength = Regex.Matches(texto, @"\ba\w{4,}\b");
        foreach (Match match in wordsStartingAWithMinLength)
        {
            Console.WriteLine(match.Value);
        }

        // 8. Palabras compuestas únicamente por letras minúsculas
        MatchCollection lowercaseWords = Regex.Matches(texto, @"\b[a-z]+\b");
        foreach (Match match in lowercaseWords)
        {
            Console.WriteLine(match.Value);
        }

        // 9. Sustituir "Python" por "C#"
        string replacedText = Regex.Replace(texto, @"\bPython\b", "C#");
        Console.WriteLine(replacedText);
    }
}
