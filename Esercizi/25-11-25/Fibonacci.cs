namespace Esercizi
{
    public class Fibonacci
    {
        public static void main(string[] args)
        {
            int limit = 5000;
            FibNumbers(limit);
            FibAB(limit, 'R', 'L');
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

        static void FibAB(int limit, char a = 'A', char b = 'B')
        {
            string result = $"{a}";
            while (result.Length <= limit)
            {
                Console.WriteLine(result);
                string c = "";
                for (int i = 0; i < result.Length; i++)
                {
                    if (result[i] == a) c += $"{a}{b}";
                    if (result[i] == b) c+= a;
                }
                result = c;
            }
            // Console.WriteLine(result);
        }

        static string Directions(int limit)
        {
            // TODO: farlo
            // https://lab.tissino.it/dragon.xml
            // https://snap.berkeley.edu/
            return "";
        }
    }
}