public class UnitTest<T>
{
    private int count;

    public UnitTest()
    {
        count = 0;
    }

    public bool TestOne(Test<T> test)
    {
        count++;
        if (test.Provided?.Equals(test.Expected) ?? true)
        {
            return true;
        }
        else
        {
            Console.Error.WriteLine($"ERRORE: Test numero {count} fallito! Atteso: {test.Expected}, ottenuto {test.Provided}.");
            return false;
        }
    }

    public bool TestAll(Test<T>[] tests)
    {
        bool success = true;
        foreach (Test<T> test in tests)
        {
            if (!TestOne(test)) success = false;
        }
        return success;
    }

    public void ResetCount()
    {
        count = 0;
    }
}