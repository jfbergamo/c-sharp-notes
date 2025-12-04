namespace Esercizi
{
    public class IsValidDate
    {
        public static void main(string[] args)
        {
            var u = new UnitTest<bool>();

            u.Add(ValidDate(01,01,1970), true);
            u.Add(ValidDate(32,01,2025), false);
            u.Add(ValidDate(-1,13,2025), false);
            u.Add(ValidDate(29,02,2023), false);
            u.Add(ValidDate(29,02,2024), true);
            u.Add(ValidDate(30,02,2024), false);
            u.Add(ValidDate(29,02,2100), false);
            u.Add(ValidDate(29,02,2400), true);
            u.Add(ValidDate(15,05,1599), false);
            u.Add(ValidDate(22,09,3000), false);
            u.Add(ValidDate(31,09,2026), false);
            u.Add(ValidDate(31,11,2026), false);

            if (u.TestAll()) Console.WriteLine("Tutti i test sono stati passati.");
        }

        static bool ValidDate(int d, int m, int y)
        {
            if (!(1600 <= y && y <= 2999)) return false;
            if (!(0 < m && m <= 12)) return false;
            if (!(0 < d && d <= 31)) return false;

            if ((m == 4 || m == 6 || m == 9 || m == 11) && d > 30) return false;

            if (m == 2)
            {
                if (d > 29) return false;
                if (!isLeap(y) && d > 28) return false;
            }

            return true;
        }

        static bool isLeap(int y)
        {
            // Anno bisestile:
                // lo è se è divisibile per 4
                // ma non lo è se è divisibile per 100
                // ma lo è se è divisibile per 400
            if (y % 4 == 0)
            {
                if (y % 100 == 0)
                {
                    if (y % 400 == 0) return true;
                    return false;
                }
                return true;
            }
            return false;
        }

    }
}