public class Triangoli
{
    public static void main(string[] args)
    {
        bool success = true;

        // TODO: aggiungere dei test

        if (!TestValidTriangle(12,6,6, false)) success = false;
        if (!TestValidTriangle(1,2,3, false)) success = false;
        if (!TestValidTriangle(0,7,25, false)) success = false;
        if (!TestValidTriangle(12,12,6, true)) success = false;
        if (!TestValidTriangle(7,7,7, true)) success = false;

        Console.WriteLine("{0}utti i test sono stati conclusi con successo.", success ? "T" : "Non t");

    }

    static bool ValidTriangle(int a, int b, int c)
    {
        float p = (a+b+c)/2.0f;
        float d = p*(p-a)*(p-b)*(p-c);
        // float A = Math.Sqrt(d); // se d < 0 è fuori dal dominio di sqrt
        return d > 0; // > 0 e non >= 0 perché sqrt(0) = 0 e 
                     // un triangolo non può avere area = 0
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