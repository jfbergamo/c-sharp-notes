public class MCD
{
    public static void main(string[] args)
    {
        var u = new UnitTest<int>();
        u.Add(mcd(12, 6), 6);
        u.Add(mcd(24, 18), 6);
        u.Add(mcd(13, 7), 1);
        u.Add(mcd(200, 10), 10);
        u.Add(mcd(24042, 246), 6);
        if (u.TestAll()) Console.WriteLine("Tutti i test sono stati passati!");
    }

    public static int mcd(int a, int b)
    {
        if (a % b == 0) return b;
        return mcd(b, a % b);
    }
}