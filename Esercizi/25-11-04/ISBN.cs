namespace Esercizi 
{
    public class ISBN {

        private const int ISBN_LENGTH = 13;

        static void Interactive()
        {
            while (true)
            {
                Console.WriteLine("Ciao! Inserisci un codice:");
                Console.Write("> ");
                string code = Console.ReadLine() ?? "";

                Console.WriteLine("Il codice {0}è un ISBN.", IsValidISBN(code) ? "" : "NON ");

                Console.Write("Vuoi controllare un altro codice? [S/N]: ");
                if (Console.ReadLine()?.ToLower() != "s") break;
            }
            return;
        }

        public static void main(string[] args)
        {
            bool interactive = false;

            if (interactive) {Interactive(); return; }

            var u = new UnitTest<bool>();

            u.Add(IsValidISBN("9788849293371"), true);
            u.Add(IsValidISBN("1"), false);
            u.Add(IsValidISBN("12"), false);
            u.Add(IsValidISBN("123"), false);
            u.Add(IsValidISBN("1234"), false);
            u.Add(IsValidISBN("12345"), false);
            u.Add(IsValidISBN("123456"), false);
            u.Add(IsValidISBN("1234567"), false);
            u.Add(IsValidISBN("12345678"), false);
            u.Add(IsValidISBN("123456789"), false);
            u.Add(IsValidISBN("1234567891"), false);
            u.Add(IsValidISBN("12345678912"), false);
            u.Add(IsValidISBN("123456789125"), false);
            u.Add(IsValidISBN("1234567891256"), false);
            u.Add(IsValidISBN("abcdefghijklm"), false);

            if (u.TestAll()) Console.WriteLine("Test superati.");

            return;
        }
        
        static bool IsValidISBN(string code) {
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
    }
}