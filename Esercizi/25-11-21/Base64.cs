using System.Text;

namespace Esercizi
{
    public class Base64
    {
        public static void main(string[] args)
        {
            string encode = Base64Encode(Encoding.ASCII.GetBytes("GATTO"));
            Console.WriteLine(encode);
            byte[] decode = Base64Decode(encode);
            Console.WriteLine(Encoding.ASCII.GetString(decode));
        }

        static string Base64Encode(byte[] word)
        {
            string res = "";
            int octets = 3;
            int sextets = 4;

            for (int i = 0; i < word.Length; i += octets)
            {
                // STEP 1: Suddividere il flusso di dati in ottetti da 3 byte

                int blanks = 0;
                int stream = 0;

                for (int j = 0; j < octets; j++)
                {
                    if (i + j >= word.Length) blanks++;
                    else stream |= word[i + j] << (8 * (octets - j - 1));
                }

                // STEP 2: Trasformare i 3 ottetti in 4 sestetti

                for (int j = 0; j < sextets; j++)
                {
                    if (j >= sextets - blanks)
                    {
                        res += '=';
                        continue;
                    }

                    // STEP 4: Codificare ogni sestetto
                    byte sextet = (byte)(stream >> (6 * (sextets - j - 1)) & 0b111111);
                    // A–Z  (0–25)
                    if (0 <= sextet && sextet <= 25)
                    {
                        res += (char)(sextet + 'A');
                    }
                    // a–z  (26–51)
                    else if (26 <= sextet && sextet <= 51)
                    {
                        res += (char)(sextet - 26 + 'a');
                    }
                    // 0–9  (52–61)
                    else if (52 <= sextet && sextet <= 61)
                    {
                        res += (char)(sextet - 52 + '0');
                    }
                    // +    (62)
                    else if (sextet == 62)
                    {
                        res += '+';
                    }
                    // /    (63)
                    else if (sextet == 63)
                    {
                        res += '/';
                    }
                    else
                    {
                        throw new Exception("Unreachable");
                    }
                }
            }

            return res;
        }

        static byte[] Base64Decode(string word)
        {
            List<byte> bytes = new List<byte>();
            int sextets = 4;
            int octets = 3;

            // STEP 1: dividere la parola in gruppi da 4 sestetti
            for (int i = 0; i < word.Length; i += sextets)
            {
                int stream = 0;
                int blanks = 0;
                for (int j = 0; j < sextets; j++)
                {
                    // STEP 2: decodificare ogni sestetto

                    byte sextet = (byte)word[i + j];
                    byte x;

                    // A–Z  (0–25)
                    if ('A' <= sextet && sextet <= 'Z')
                    {
                        x = (byte)(sextet - 'A');
                    }
                    // a–z  (26–51)
                    else if ('a' <= sextet && sextet <= 'z')
                    {
                        x = (byte)(sextet - 'a' + 26);
                    }
                    // 0–9  (52–61)
                    else if ('0' <= sextet && sextet <= '9')
                    {
                        x = (byte)(sextet - '0' + 52);
                    }
                    // +    (62)
                    else if (sextet == '+')
                    {
                        x = 62;
                    }
                    // /    (63)
                    else if (sextet == '/')
                    {
                        x = 63;
                    }
                    else if (sextet == '=')
                    {
                        x = 0;
                        blanks++;
                    }
                    else
                    {
                        throw new Exception($"Unreachable, {(char)sextet}");
                    }
                    stream |= x << (6 * (sextets - j - 1));
                }

                // STEP 3 e 4: trasformare i 4 sestetti in 3 otteti e salvare il loro valore
                for (int j = 0; j < octets; j++)
                {
                    byte octet = (byte)(stream >> (8 * (octets - j - 1)));
                    bytes.Add(octet);
                }

                // STEP 5: rimuovere gli spazi bianchi rappresentati da =
                for (; blanks > 0; blanks--) bytes.RemoveAt(bytes.Count - 1);
            }

            return bytes.ToArray();
        }

        // Metodo di debug per stampare i byte in binario
        static void PrintBinary(byte bits, int pad = 8)
        {
            string res = Convert.ToString(bits, 2);
            while (res.Length < pad) res = '0' + res;
            Console.WriteLine(res);
        }
    }
}