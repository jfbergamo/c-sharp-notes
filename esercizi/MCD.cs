public class MCD
{
    public static void main(string[] args)
    {
        bool success = true;
        if (!testMCD(12, 6, 6)) success = false;
        if (!testMCD(24, 18, 6)) success = false;
        if (!testMCD(13, 7, 1)) success = false;
        if (!testMCD(200, 10, 10)) success = false;
        if (!testMCD(24042, 246, 6)) success = false;
        Console.WriteLine(success);
    }

    // public static int mcd(int a, int b)
    // {
    //     while (a % b != 0)
    //     {
    //         int mod = a % b;
    //         a = b;
    //         b = mod;
    //     }
    //     return b;
    // }
    public static int mcd(int a, int b)
    {
        if (a % b == 0) return b;
        return mcd(b, a % b);
    }

    public static bool testMCD(int a, int b, int res)
    {
        int test = mcd(a, b);
        if (test != res)
        {
            Console.Error.WriteLine("Test mcd({0}, {1}) fallito! Atteso: {2}, ottenuto {3}", a, b, res, test);
            return false;
        }
        return true;
    }
}