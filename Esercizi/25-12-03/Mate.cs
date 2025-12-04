namespace Esercizi
{
    public class Mate
    {
        public static void main(string[] args)
        {
            var u = new UnitTest<double>();

            Console.WriteLine("TEST NUMERI NATURALI");

            u.Add(Sqrt(1), 1);
            u.Add(Sqrt(4), 2);
            u.Add(Sqrt(9), 3);
            u.Add(Sqrt(16), 4);
            u.Add(Sqrt(25), 5);
            u.Add(Sqrt(36), 6);
            u.Add(Sqrt(49), 7);
            u.Add(Sqrt(64), 8);
            u.Add(Sqrt(81), 9);
            u.Add(Sqrt(100), 10);

            if (u.TestAll()) Console.WriteLine("Test superati.");

            u.Reset();
            Console.WriteLine("TEST SPECIALI");
            u.Add(Sqrt(0.04), double.NaN);
            u.Add(Sqrt(4.5), 2.1213203436);
            if (u.TestAll()) Console.WriteLine("Test superati.");
        }

        static double Sqrt(double x)
        {
            // TODO: farla andare
            if (x < 1) return double.NaN;
            if (x == 1) return 1;

            double l = 0;
            double r = x;
            double avg = (l + r) / 2;

            while (Math.Abs(avg*avg - x) > 1e-15)
            {
                if (avg*avg > x)
                {
                    r = avg;
                }
                else if (avg*avg < x)
                {
                    l = avg;
                }
                avg = (l + r) / 2;
                Console.WriteLine(avg*avg);
            }

            return avg;
        }
    }
}