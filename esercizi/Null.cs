public class Null
{
    public static void main(string[] args)
    {
        double[] punteggi = {-3, -5, -1.5, 6, 12, 4};
        bool[] iscritto = {true, true, false, true, false, true};
        Console.WriteLine(PeggioreTraIscritti(punteggi, iscritto));
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