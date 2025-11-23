public class IsValidDate
{
    public static void main(string[] args)
    {
        bool success = true;

        if (!TestValidDate(1,1,1970, true)) success = false;
        if (!TestValidDate(32,1,2025, false)) success = false;
        if (!TestValidDate(-1,13,2025, false)) success = false;
        if (!TestValidDate(29,2,2023, false)) success = false;
        if (!TestValidDate(29,2,2024, true)) success = false;
        if (!TestValidDate(30,2,2024, false)) success = false;
        if (!TestValidDate(29,2,2100, false)) success = false;
        if (!TestValidDate(29,2,2400, true)) success = false;
        if (!TestValidDate(15,5,1599, false)) success = false;
        if (!TestValidDate(22,9,3000, false)) success = false;
        if (!TestValidDate(31,9,2026, false)) success = false;
        if (!TestValidDate(31,11,2026, false)) success = false;

        Console.WriteLine("{0}utti i test sono stati conclusi con successo.", success ? "T" : "Non t");
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

    static bool TestValidDate(int d, int m, int y, bool res)
    {
        bool test = ValidDate(d, m , y);
        if (test != res)
        {
            Console.Error.WriteLine("Test fallito: ValidDate({0}, {1}, {2}). Atteso {3}, ottenuto {4}.", d, m, y, res, test);
            return false;
        }
        return true;
    }
}