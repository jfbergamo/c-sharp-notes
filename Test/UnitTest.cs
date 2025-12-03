using System.Runtime.CompilerServices;

public class UnitTest<T> : List<Tuple<T, T>>
{
    private int test_n; 

    public UnitTest() : base()
    {
        test_n = 0;
    }

    public bool TestOne(Tuple<T,T> test)
    {
        this.test_n++;
        if (test.Item1?.Equals(test.Item2) ?? true)
        {
            return true;
        }
        else
        {
            Console.Error.WriteLine($"ERRORE: Test numero {this.test_n} fallito! Atteso: {test.Item1?.ToString() ?? "null"}, ottenuto {test.Item2?.ToString() ?? "null"}.");
            return false;
        }
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

    public void ResetCount()
    {
        test_n = 0;
    }
}