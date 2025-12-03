using System.Runtime.CompilerServices;

public class UnitTest<T> : List<Test<T>>
{
    private int test_n;

    public UnitTest() : base()
    {
        test_n = 0;
    }

    public bool TestOne(Test<T> test)
    {
        this.test_n++;
        if (test.Provided?.Equals(test.Expected) ?? true)
        {
            return true;
        }
        else
        {
            Console.Error.WriteLine($"ERRORE: Test numero {this.test_n} fallito! Atteso: {test.Expected?.ToString() ?? "null"}, ottenuto {test.Provided?.ToString() ?? "null"}.");
            return false;
        }
    }

    public void Add(T provided, T expected)
    {
        Add(new Test<T>(provided, expected));
    }

    public bool TestAll()
    {
        bool success = true;
        foreach (Test<T> test in this)
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