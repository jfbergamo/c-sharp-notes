using System.Net.NetworkInformation;
using System.Security.Cryptography;

public class Program
{
    delegate void MainFn(string[] args);
    static Dictionary<string, MainFn> exs = new Dictionary<string, MainFn>();

    public static void Main(string[] args)
    {
        AddEs();
        string ex = (args.Length > 0) ? PopArg(ref args) : "";

        if (exs.TryGetValue(ex, out MainFn? main))
        {
            main(args);
        }
        else if (ex == "all")
        {
            foreach (var e in exs) e.Value(args);
        }
        else
        {
            Console.WriteLine("Esercizi disponibili:");
            Console.WriteLine($" - all (esegue tutti gli esercizi)");
            foreach (string es in exs.Keys)
            {
                Console.WriteLine($" - {es}");
            }
        }
    }

    static void AddEs()
    {
        exs.Add("isbn", Esercizi.ISBN.main);
        exs.Add("trovasette", Esercizi.TrovaSette.main);
        exs.Add("mcd", Esercizi.MCD.main);
        exs.Add("isvaliddate", Esercizi.IsValidDate.main);
        exs.Add("triangoli", Esercizi.Triangoli.main);
        exs.Add("arrayvari", Esercizi.ArrayVari.main);
        exs.Add("base64", Esercizi.Base64.main);
        exs.Add("arrayordered", Esercizi.ArrayOrdered.main);
        exs.Add("fibonacci", Esercizi.Fibonacci.main);
        exs.Add("null", Esercizi.Null.main);
        exs.Add("carte", Esercizi.Carte.main);
        exs.Add("mate", Esercizi.Mate.main);
        exs.Add("extract", Esercizi.Extract.main);
        exs.Add("esame", Esercizi.Esame.main);
        exs.Add("seggi", Esercizi.Seggi.main);        
    }

    static string PopArg(ref string[] args)
    {
        string result = args[0];
        string[] newArgs = new string[args.Length - 1];
        for (int i = 1; i < args.Length; i++)
        {
            newArgs[i - 1] = args[i];
        }
        args = newArgs;
        return result;
    }
}