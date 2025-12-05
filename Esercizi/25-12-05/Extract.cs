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
            u.Add(
                ArrayToString(ExtractValuesX(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}, x => x % 2 == 0)),
                ArrayToString(new int[] {2, 4, 6, 8, 10})
            );
            u.Add(
                ArrayToString(ExtractValues(new int[] {2, 4, 6, 8, 10}, 1)),
                ArrayToString(new int[] {2, 4, 6, 8, 10})
            );

            Func<int, bool> filter = (x) => x == 7;

            u.Add(
                ArrayToString(ExtractValuesX(new int[] {2, 4, 6, 8, 10}, filter)),
                ArrayToString(new int[] {})
            );
            u.Add(
                ArrayToString(ExtractValuesX(new int[] {7, 2, 4, 7, 6, 8, 7, 10}, filter)),
                ArrayToString(new int[] {7, 7, 7})
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
        
        static int[] ExtractValuesX(int[] values, Func<int, bool> filter)
        {
            int count = 0;
            foreach (int value in values) if (filter(value)) count++;

            int[] result = new int[count];
            count = 0;
            for (int i = 0; i < values.Length; i++)
            {
                if (filter(values[i])) result[count++] = values[i];
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