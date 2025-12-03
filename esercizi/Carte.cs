public class Carte
{
    // * Data una stringa, indicare se la carta è valida
    // * Data una carta, indicare la sua carta successiva, se non c'è null
    // * Mescola un mazzo di carte

    struct Carta
    {
        public char seed;
        public char value;

        public override string ToString()
        {
            return $"{seed}{value}";
        }
    }

    string seeds = "CQFP";
    string values = "RCF765432A";

    public static void main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}