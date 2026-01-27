namespace Esercizi
{
    public class Fibonacci
    {
        public static void main(string[] args)
        {
            int limit = 500;
            // FibNumbers(limit);
            // Console.WriteLine(FibAB(limit));
            Dragon(limit);
        }

        static void FibNumbers(int limit)
        {
            int a = 0; 
            int b = 1;

            while (a <= limit)
            {
                Console.WriteLine(a);

                int c = a;
                a += b;
                b = c;
            }
        }

        static string FibAB(int limit, char a = 'A', char b = 'B')
        {
            string result = $"{a}";
            while (result.Length <= limit)
            {
                // result += fib;
                // Console.WriteLine(fib);
                string c = "";
                for (int i = 0; i < result.Length; i++)
                {
                    if (result[i] == a) c += $"{a}{b}";
                    if (result[i] == b) c+= a;
                }
                result = c;
            }
            // Console.WriteLine(result);
            return result;
        }

        static void Dragon(int limit)
        {
            string result = FibAB(limit, 'R', 'L');
            Console.WriteLine(result);
            Console.WriteLine("Recati su https://snap.berkeley.edu/ e inserisci ./dragon.xml");
        }
    }
}