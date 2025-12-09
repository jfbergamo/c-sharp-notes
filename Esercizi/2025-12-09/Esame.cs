namespace Esercizi
{
    public class Esame
    {
        public static void main(string[] args)
        {
            {
                var u = new UnitTest<double>();

                Console.WriteLine("Media array interi");
                
                u.Add(Average(new int[] {3,4,5}), 4.0);
                u.Add(Average(new int[] {3,4}), 3.5);

                if (u.TestAll()) Console.WriteLine("Test superati");

                u.Reset();
                Console.WriteLine("Valore Pi Greco");

                u.Add(Leibniz(200), 3.136592684838816);
                u.Add(Leibniz(1000), 3.140592653839794);

                if (u.TestAll()) Console.WriteLine("Test superati");
            }
            {
                var u = new UnitTest<int>();

                Console.WriteLine("Incrementi percentuali");

                u.Add(CountIncrements(0.2), 4);
                u.Add(CountIncrements(0.12), 7);
                u.Add(CountIncrements(0.05), 15);
                u.Add(CountIncrements(0.02), 36);

                if (u.TestAll()) Console.WriteLine("Test superati");
            }
        }

        static double Average(int [] values)
        {
            int somma = 0;
            for (int i = 0; i < values.Length; i++)
            {
                somma += values[i];
            }

            return (double)somma/values.Length;
        }

        static double Leibniz(int count = 200)
        {
            int denom = 1;
            double pi = 0;
            double x = 1.0;

            for (int i = 0; i < count; i++)
            {
                pi += x * 1.0 / denom;
                denom += 2;
                x *= -1;
            }

            pi *= 4;

            return pi;
        }

        static int CountIncrements(double rate)
        {
            int count = 0;
            double x = 1;
            while (x < 2.0)
            {
                count++;
                x *= (1 + rate);
            }
            return count;
        }
    }
}