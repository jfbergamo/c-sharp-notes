public class ArrayOrdered
{
    public static void main(string[] args)
    {
        Console.WriteLine(IsOrdered(new int[] { 1, 3, 6, 7 }) == true);
        Console.WriteLine(IsOrdered(new int[] { -5, -3, 6, 7 }) == true);
        Console.WriteLine(IsOrdered(new int[] { 1, 6, 6, 7 }) == true);
        Console.WriteLine(IsOrdered(new int[] { 1 }) == true);
        Console.WriteLine(IsOrdered(new int[] { 1, 0, 15, 3 }) == false);
        Console.WriteLine(IsOrdered(new int[] { 15, 3, 1, 0 }, true) == true);
        Console.WriteLine(IsOrdered(new int[] { 1, 3, 6, 7 }, true) == false);
        Console.WriteLine(IsOrdered(new int[] { }) == true);
    }

    static bool IsOrdered(int[] v, bool descending = false)
    {
        for (int i = 0; i < v.Length - 1; i++)
        {
            if (v[i] == v[i + 1]) continue;
            if (v[i] > v[i + 1] != descending) return false;
        }

        return true;
    }
}