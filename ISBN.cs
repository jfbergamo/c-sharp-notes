public class ISBN {

    private const int ISBN_LENGTH = 13;

    private static bool isValidISBN(string code) {
        if (code.Length != ISBN_LENGTH) return false;
        int[] digits;
        try {
            digits = code.ToCharArray().Select(x => int.Parse(x.ToString())).ToArray();
        } catch (FormatException) {
            return false;
        }

        int sum = 0;
        for (int i = 0; i < digits.Length; i++) {
            int n = digits[i];
            if ((i + 1) % 2 == 0) n *= 3;
            sum += n;
        }

        return sum % 10 == 0;
    }

    public static void main(string[] args)
    {
        while (true) {
            Console.WriteLine("Ciao! Inserisci un codice:");
            Console.Write("> ");
            string code = Console.ReadLine() ?? "";

            Console.WriteLine("Il codice {0}è un ISBN.", isValidISBN(code) ? "" : "NON ");

            Console.Write("Vuoi controllare un altro codice? [S/N]: ");
            if (Console.ReadLine()?.ToLower() != "s") break;
        }
    }
}