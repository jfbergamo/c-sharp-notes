namespace Esercizi
{
    public class Triangoli
    {
        public static void main(string[] args)
        {
            var u = new UnitTest<bool>();

            Console.WriteLine("Test di base.");
            u.Add(ValidTriangle(12,6,6), false);
            u.Add(ValidTriangle(1,2,3), false);
            u.Add(ValidTriangle(0,7,25), false);
            u.Add(ValidTriangle(12,12,6), true);
            u.Add(ValidTriangle(7,7,7), true);
            if (u.TestAll()) Console.WriteLine("Test superati.");

            u.Reset();
            Console.WriteLine("Casi validi (triangoli corretti).");
            u.Add(ValidTriangle(3, 4, 5), true);          // triangolo scaleno classico
            u.Add(ValidTriangle(5, 5, 5), true);          // triangolo equilatero
            u.Add(ValidTriangle(5, 5, 8), true);          // triangolo isoscele valido
            u.Add(ValidTriangle(7, 10, 12), true);        // scaleno valido
            u.Add(ValidTriangle(2.5, 3.5, 4.5), true);    // con numeri decimali
            if (u.TestAll()) Console.WriteLine("Test superati.");
            
            u.Reset();
            Console.WriteLine("Casi non validi (violazione disuguaglianza triangolare).");
            u.Add(ValidTriangle(1, 2, 3), false);          // somma di due lati = terzo
            u.Add(ValidTriangle(1, 1, 2), false);          // caso limite
            u.Add(ValidTriangle(2, 3, 6), false);          // somma di due < terzo
            u.Add(ValidTriangle(5, 1, 1), false);
            if (u.TestAll()) Console.WriteLine("Test superati.");
            
            u.Reset();
            Console.WriteLine("Casi non validi (valori non ammessi).");
            u.Add(ValidTriangle(0, 4, 5), false);          // lato zero
            u.Add(ValidTriangle(-1, 4, 5), false);         // lato negativo
            u.Add(ValidTriangle(3, -4, 5), false);
            u.Add(ValidTriangle(3, 4, -5), false);
            u.Add(ValidTriangle(0, 0, 0), false);
            if (u.TestAll()) Console.WriteLine("Test superati.");

            u.Reset();
            Console.WriteLine("Edge cases (robustezza).");
            u.Add(ValidTriangle(0.0001, 0.0001, 0.0001), true);   // triangolo molto piccolo
            u.Add(ValidTriangle(1e9, 1e9, 1e9), true);            // numeri molto grandi
            u.Add(ValidTriangle(1e-9, 1e-9, 2e-9), false);        // limite floating point
            if (u.TestAll()) Console.WriteLine("Test superati.");

        }

        static bool ValidTriangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0) return false;

            double p = (a+b+c)/2.0; // semiperimetro
            double d = p*(p-a)*(p-b)*(p-c); // delta
            // float A = Math.Sqrt(d); // se d < 0 è fuori dal dominio di sqrt
            return d > 0; // > 0 e non >= 0 perché sqrt(0) = 0 e 
                        // un triangolo non può avere area = 0
        }
    }
}