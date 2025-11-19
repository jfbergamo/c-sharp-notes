using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

public class ArrayVari
{
    public static void main(string[] args)
    {
        Console.WriteLine("------------------------------------------");
        ContaGiorni(5);
        Console.WriteLine("------------------------------------------");
        int[] a = {7, 14, 21, 28, 35, 42, 49, 56, 63, 70};
        int[] b = {8, 16, 24, 32, 40, 48, 56, 64, 72, 80, 88};
        int[] c = {10, 20, 30, 40, 50, 60, 70, 80, 90, 100};
        PrintArray(MergeSortedX(new int[][] {a, b, c}));
        Console.WriteLine("------------------------------------------");
        Console.WriteLine(Avg(new int[] {30, 31}));
        Console.WriteLine("------------------------------------------");
        // 67 -> 01000011
        Console.WriteLine(FromBools(new bool[] {false, true, false, false, false, false, true, true}));
    }

    static void ContaGiorni(int anni)
    {
        int[] giorni = {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
        string[] mesi = {"Gennaio", "Febbraio", "Marzo", "Aprile", "Maggio", "Giugno", "Luglio", "Agosto", "Settembre", "Ottobre", "Novembre", "Dicembre"};
        
        Debug.Assert(giorni.Length == mesi.Length);

        int size = giorni.Length;
        for (int i = 0; i < size*anni; ++i)
        {
            Console.WriteLine($"{mesi[i % size]} ha {giorni[i % size]} giorni.");
        }
    }

    static void PrintArray(int[] xs)
    {
        foreach (int x in xs)
        {
            Console.WriteLine(x);
        }
    }

    static int[] MergeSorted(int[] a, int[] b)
    {
        int[] merge = new int[a.Length + b.Length];
        for (int size = 0, i = 0, j = 0; size < merge.Length; size++)
        {
            if (i >= a.Length)
            {
                merge[size] = b[j++];
                continue;
            }
            if (j >= b.Length)
            {
                merge[size] = a[i++];
                continue;
            }
            if (a[i] <= b[j])
                merge[size] = a[i++];
            else
                merge[size] = b[j++];
        }
        return merge;
    }

    static int[] MergeSortedX(int[][] arrays)
    {
        int[] merge = new int[0];
        foreach (int[] array in arrays)
        {
            merge = MergeSorted(merge, array);
        }
        return merge;
    }

    static double Avg(int[] xs)
    {
        int sum = 0;
        foreach (int x in xs)
        {
            sum += x;
        }
        return (double)(sum) / xs.Length;
    }

    static int FromBools(bool[] bits)
    {
        Debug.Assert(bits.Length == 8);
        int n = 0;
        int pow = 1;
        for (int i = bits.Length - 1; i >= 0; i--)
        {
            if (bits[i]) n += pow;
            pow *= 2;
        }        
        return n;
    }
}