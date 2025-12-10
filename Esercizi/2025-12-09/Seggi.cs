// Bergamasco Jacopo, Catanzaro Fabio, Loggia Alex, Tomasella Francesco

namespace Esercizi
{
    public class Seggi
    {

        // Strutture dati interne: Jacopo Bergamasco & Alex Loggia
        public class Voto
        {
            public int Voti {set; get;}
            public string Partito {set; get;}
            public Voto(string partito, int voti) { Partito = partito; Voti = voti; }
        }

        public class Seggio
        {
            public string Partito { get; set; }
            public int Seggi { get; set; }
            public Seggio(string partito, int seggi) { Partito = partito; Seggi = seggi; }
            public override string ToString() => $"{{ Partito: `{Partito}`, Seggi: {Seggi} }}";
        }

        // Per switchare da Modalità Interattiva a Modalità Test,
        // modificare la linea commentata
        public static void main(string[] args)
        {
            // DoInteractive(); // Avvia in modalità interattiva
            DoUnitTesting(); // Avvia in modalità Unit Testing
        }

        // Modalità interattiva: Fabio Catanzaro & Francesco Tomasella
        static void DoInteractive()
        {
            var voti = new List<Voto>();
            
            string continua = "";
            do
            {
                Console.Write($"Inserisci il nome del partito e i voti che hanno ottenuto: ");
                string partito = Console.ReadLine() ?? "null";
                
                Console.Write("> ");
                int n_voti = int.Parse(Console.ReadLine() ?? "0");

                Voto voto = new Voto(partito, n_voti);
                voti.Add(voto);
                
                Console.WriteLine($"Devi inserire altri partiti? (`si` per continuare) ");
                continua = Console.ReadLine()?.ToLower() ?? "null";
            }
            while (continua == "si");

            Seggio[] seggi = ContaSeggi(voti.ToArray(), voti.Count).ToArray(); 

            Console.WriteLine("Lista dei seggi vinti dai partiti:");

            for (int i = 0; i < seggi.Length; i++)
            {
                Console.WriteLine($"    {seggi[i].ToString()}");
            }
        }

        // Unit Testing: Jacopo Bergamasco
        static void DoUnitTesting()
        {
            int count = 0;
            bool success = true;

            Console.WriteLine("Avvio test...");

            if (
                !Test(SeggioArrayToString(ContaSeggi(new Voto[]
                    {
                        new Voto("p1", 5000),
                        new Voto("p2", 4500),
                        new Voto("p3", 3800),
                        new Voto("p4", 2000),
                        new Voto("p5", 1000)
                    }, 
                    8)), 
                    "[ { Partito: `p1`, Seggi: 3 }, { Partito: `p2`, Seggi: 2 }, { Partito: `p3`, Seggi: 2 }, { Partito: `p4`, Seggi: 1 } ]", 
                    ref count
                )
            ) success = false;

            if (
                !Test(SeggioArrayToString(ContaSeggi(new Voto[]
                    {
                        new Voto("p1", 1000),
                        new Voto("p2", 4500),
                        new Voto("p3", 5800),
                        new Voto("p4", 2000),
                        new Voto("p5", 1000)
                    }, 
                    8)), 
                    "[ { Partito: `p3`, Seggi: 4 }, { Partito: `p2`, Seggi: 3 }, { Partito: `p4`, Seggi: 1 } ]", 
                    ref count
                )
            ) success = false;

            if (
                !Test(SeggioArrayToString(ContaSeggi(new Voto[]
                    {
                        new Voto("p1", 2000),
                        new Voto("p2", 0),
                        new Voto("p3", 3800),
                        new Voto("p4", 2000),
                        new Voto("p5", 6000)
                    }, 
                    8)), 
                    "[ { Partito: `p5`, Seggi: 4 }, { Partito: `p3`, Seggi: 2 }, { Partito: `p1`, Seggi: 1 }, { Partito: `p4`, Seggi: 1 } ]", 
                    ref count
                )
            ) success = false;

            if (
                !Test(SeggioArrayToString(ContaSeggi(new Voto[]
                    {
                        new Voto("p1", 2800),
                        new Voto("p2", 2800),
                        new Voto("p3", 3800),
                        new Voto("p4", 2000),
                        new Voto("p5", 1000)
                    }, 
                    8)), 
                    "[ { Partito: `p3`, Seggi: 3 }, { Partito: `p1`, Seggi: 2 }, { Partito: `p2`, Seggi: 2 }, { Partito: `p4`, Seggi: 1 } ]", 
                    ref count
                )
            ) success = false;

            if (
                !Test(SeggioArrayToString(ContaSeggi(new Voto[]
                    {
                        new Voto("p1", 42),
                        new Voto("p2", 0),
                        new Voto("p3", 42),
                        new Voto("p4", 1000),
                        new Voto("p5", 42)
                    }, 
                    8)), 
                    "[ { Partito: `p4`, Seggi: 8 } ]", 
                    ref count
                )
            ) success = false;


            if (success) Console.WriteLine("Tutti i test sono stati superati.");
        }

        // Logica principale: Alex Loggia
        public static Seggio[] ContaSeggi(Voto[] partiti, int nSeggi)
        {
            var colonne = new List<Voto[]>();
            colonne.Add(partiti);

            for(int s = 0; s < nSeggi - 1; s++)
            {
                var colonna = new Voto[partiti.Count()];
                for (int i = 0; i < colonna.Length; i++)
                {
                    colonna[i] = new Voto(colonne.First()[i].Partito, colonne.First()[i].Voti / (s + 2));
                }
                colonne.Add(colonna);
            }
            List<Voto> ordinato = colonne.SelectMany(x => x).OrderByDescending(x => x.Voti).ToList();
            
            List<Seggio> seggi = new List<Seggio>();

            for(int i = 0; i < nSeggi; i++)
            {
                int indexSeggio;
                if ((indexSeggio = seggi.FindIndex(x => x.Partito == ordinato[i].Partito)) != -1)
                {
                    seggi[indexSeggio].Seggi = seggi[indexSeggio].Seggi + 1;
                }
                else
                {
                    seggi.Add(new Seggio(ordinato[i].Partito, 1));
                }
            }
            return seggi.ToArray();
        }

        // Formattazione risultato in stringa: Jacopo Bergamasco
        static string SeggioArrayToString(Seggio[] seggi)
        {
            string result = "[ ";
            for (int i = 0; i < seggi.Length; i++)
            {
                if (i != 0) result += ", ";
                result += seggi[i].ToString();
            }
            result += " ]";
            return result;
        }

        // Metodo di confronto per Unit Test: Jacopo Bergamasco
        static bool Test(string provided, string expected, ref int count)
        {
            count++;
            if (provided != expected)
            {
                Console.WriteLine($"Test {count} fallito! Ottenuto, {provided}, atteso {expected}.");
                return false;
            }
            return true;
        }
    }
}