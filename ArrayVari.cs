public class ArrayVari
{
    public static void main(string[] args)
    {
        int[] giorniDeiMesi = {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
        ContaGiorni(giorniDeiMesi, 5);
    }

    static void ContaGiorni(int[] giorni, int anni)
    {
        int size = giorni.Length;
        for (int i = 0; i < size*anni; ++i)
        {
            Console.WriteLine($"Il mese {i+1} ha {giorni[i % size]} giorni.");
        }
    }
}