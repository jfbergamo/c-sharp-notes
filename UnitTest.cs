public class UnitTest
{
    public struct Test<T>
    {
        public T provided;
        public T expected;
    }

    private int count;

    public UnitTest()
    {
        count = 0;
    }

    public bool TestOne<T>(Test<T> test)
    {
        count++;
        if (test.provided?.Equals(test.expected) ?? true)
        {
            return true;
        }
        else
        {
            Console.Error.WriteLine($"ERRORE: Test numero {count} fallito! Atteso: {test.expected}, ottenuto {test.provided}.");
            return false;
        }
    }

    public bool TestAll<T>(Test<T>[] tests)
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