public class Triangoli
{
    public static void main(string[] args)
    {
        bool success = true;

        if (!TestValidTriangle(12,6,6, true)) success = false;
        if (!TestValidTriangle(1,2,3, true)) success = false;
        if (!TestValidTriangle(0,7,25, true)) success = false;

        Console.WriteLine("{0}utti i test sono stati conclusi con successo.", success ? "T" : "Non t");

    }

    static bool ValidTriangle(int a, int b, int c)
    {
        float p = (a+b+c)/2.0f;
        float d = p*(p-a)*(p-b)*(p-c);
        return d > 0;
    }

    static bool TestValidTriangle(int a, int b, int c, bool res)
    {
        bool test = ValidTriangle(a, b, c);
        if (test != res)
        {
            Console.Error.WriteLine("Test fallito: ValidTraingle({0}, {1}, {2}). Atteso {3}, ottenuto {4}.", a, b, c, res, test);
            return false;
        }
        return true;
    }
}