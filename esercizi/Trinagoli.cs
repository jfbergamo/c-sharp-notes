public class Triangoli
{
    public static void main(string[] args)
    {
        var u = new UnitTest<bool>();
        // TODO: aggiungere dei test

        u.Add(ValidTriangle(12,6,6), false);
        u.Add(ValidTriangle(1,2,3), false);
        u.Add(ValidTriangle(0,7,25), false);
        u.Add(ValidTriangle(12,12,6), true);
        u.Add(ValidTriangle(7,7,7), true);

        if (u.TestAll()) Console.WriteLine("Tutti i test superati.");

    }

    static bool ValidTriangle(int a, int b, int c)
    {
        float p = (a+b+c)/2.0f;
        float d = p*(p-a)*(p-b)*(p-c);
        // float A = Math.Sqrt(d); // se d < 0 è fuori dal dominio di sqrt
        return d > 0; // > 0 e non >= 0 perché sqrt(0) = 0 e 
                     // un triangolo non può avere area = 0
    }
}