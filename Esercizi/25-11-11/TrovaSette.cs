namespace Esercizi
{
    public class TrovaSette
    {
        public static bool hasSeven(int n)
        {
            int x = n;
            int mod;
            while (x > 0)
            {
                mod = x % 10;
                if (mod == 7) return true;
                x /= 10;
            }
            return false;
        }

        public static void main(string[] args)
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 7 == 0 && hasSeven(i))
                    Console.WriteLine("BEM");
                else if (hasSeven(i))
                    Console.WriteLine("BAM");
                else if (i % 7 == 0)
                    Console.WriteLine("BOOM");
                else
                    Console.WriteLine(i);
            }
            Console.WriteLine("Addio, stronzi");
        }
    }
}