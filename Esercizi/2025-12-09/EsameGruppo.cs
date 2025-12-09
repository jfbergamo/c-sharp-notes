namespace Esercizi
{
    using Voto = Tuple<string, int>;
    using Seggio = Tuple<string, int>;

    public class EsameGruppo
    {    
        public static void main(string[] args)
        {
            string fine = "";
            var voti = new List<Voto>();
            int n_seggi;
            while (fine != "si")
            {
                Console.WriteLine($"Inserisci il nome del partito e i voti che hanno ottenuto: ");
                Voto voto = new Voto(Console.ReadLine()??"null", int.Parse(Console.ReadLine()??"0"));
                voti.Add(voto);
                Console.WriteLine($"Devi inserire altri partiti: (si per continuare) ");
                fine = Console.ReadLine() ?? "null";
                fine = fine.ToLower();
            }
            Console.WriteLine($"Inserisci il numero di seggi disponibili: ");
            n_seggi = int.Parse(Console.ReadLine() ?? "0");
            // Seggio[] seggi = ContaSeggi(voti.ToArray(), n_seggi); 
            string[] seggi = ContaSeggi(voti.ToArray(), n_seggi).ToArray(); 

            // foreach (Seggio seggio in seggi)
            // {
                // Console.WriteLine($"Il partito {seggio.Item1} ha preso {seggio.Item2} voti");
            // }

            foreach (string seggio in seggi)
            {
                Console.WriteLine(seggio);
            }
        }


        static List<String> ContaSeggi(Voto[] voti, int n_seggi)
        {
            var x = new List<Voto[]>();
            var seggi = new List<String>();
            x.Add(voti);

            while (n_seggi > 0)
            {
                Voto[] colonna = new Voto[voti.Length];
                //crea una colonna
                for (int i = 0; i < voti.Length; i++)
                {
                    colonna[i] = new Voto(x.Last()[i].Item1, x.Last()[i].Item2 / (i + 2));
                }

                int nMax = colonna.Select(x => x.Item2).Max();
                for (int i = 0;i < voti.Length;i++)
                {
                    if (x.Last()[i].Item2 > nMax)
                    {
                        seggi.Add(new String(x.Last()[i].Item1));
                        n_seggi--;
                    }
                }
                x.Add(colonna);
            }
            return seggi;
        }

        static int FindPartito(List<Seggio> seggi, string partito)
        {
            for (int i = 0; i < seggi.Count; i++)
            {
                if (seggi[i].Item1 == partito) return i;
            }
            return -1;
        }
    }
}