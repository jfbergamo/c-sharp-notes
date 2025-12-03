public class Null
{
    public static void main(string[] args)
    {
        var u = new UnitTest<double?>();
        u.Add(
            PeggioreTraIscritti(
                new double[]{-3, -5, -1.5, 6, 12, 4},
                new bool[]{true, true, false, true, false, true}
            ),
            -5
        );
        u.Add(
            PeggioreTraIscritti(
                new double[]{-3, -5, -1.5, 6, 12, 4},
                new bool[]{false, false, false, false, false, false}
            ),
            null
        );
        if (u.TestAll()) Console.WriteLine("Tutti i test sono andati a buon fine!");
    }

    static double? PeggioreTraIscritti(double[] punteggi, bool[] iscritto)
    {
        double? min = null;
        
        for (int i = 0; i < punteggi.Length; i++)
        {
            if (iscritto[i] && (min == null || punteggi[i] < min)) min = punteggi[i];
        }
        
        return min;
    }
}