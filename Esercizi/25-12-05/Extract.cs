using System.Data;

namespace Esercizi
{
    public class Extract
    {
        public static void main(string[] args)
        {
            var u = new UnitTest<string>();

            u.Add(
                ArrayToString(ExtractValues(new int[] {2, 4, 6, 8})),
                ArrayToString(new int[] {2, 4, 6, 8})
            );
            u.Add(
                ArrayToString(ExtractValues(new int[] {2, 4, 5, 6, 8})),
                ArrayToString(new int[] {2, 4, 6, 8})
            );
            u.Add(
                ArrayToString(ExtractValues(new int[] {1, 3, 5, 7, 9})),
                ArrayToString(new int[] {})
            );
            u.Add(
                ArrayToString(ExtractValues(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10})),
                ArrayToString(new int[] {2, 4, 6, 8, 10})
            );

            if (u.TestAll()) Console.WriteLine("Test superati.");
        }

        static int[] ExtractValues(int[] values, int n = 2)
        {
            int count = 0;
            foreach (int value in values) if (value % n == 0) count++;

            int[] result = new int[count];
            count = 0;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] % n == 0) result[count++] = values[i];
            }
            
            return result;
        }

        static string ArrayToString(int[] array)
        {
            string result = "[ ";
            for (int i = 0; i < array.Length; i++)
            {
                if (i != 0) result += ", ";
                result += array[i];
            }
            result += " ]";
            return result;
        }
    }
}