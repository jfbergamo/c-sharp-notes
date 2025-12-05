public class UnitTest<T> : List<Tuple<T, T>>
{
    private int test_n; 

    public UnitTest() : base()
    {
        test_n = 0;
    }

    public bool TestOne(Tuple<T,T> a)
    {
        this.test_n++;
        T provided = a.Item1;
        T expected = a.Item2;

        if (AreEquals(provided, expected))
        {
            return true;
        }
        else
        {
            Console.Error.WriteLine(
                $"ERRORE: Test numero {this.test_n} fallito! " +
                $"Ottenuto {provided?.ToString() ?? "null"}, " +
                $"atteso: {expected?.ToString() ?? "null"}"
            );
            return false;
        }
    }

    static bool AreEquals(T a, T b)
    {
        if (a == null && b == null) return true;
        if (a == null || b == null) return false;
        return a?.Equals(b) ?? UNREACHABLE("AreEquals");
    }

    public void Add(T provided, T expected)
    {
        Add(new Tuple<T, T>(provided, expected));
    }

    public bool TestAll()
    {
        bool success = true;
        foreach (Tuple<T, T> test in this)
        {
            if (!TestOne(test)) success = false;
        }
        return success;
    }

    public void Reset()
    {
        test_n = 0;
        Clear();
    }

    static bool UNREACHABLE(string msg) { Console.Error.WriteLine(msg); Environment.Exit(1); return false; }
}