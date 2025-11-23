using System.Text;

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

        for (int i = 0; i < word.Length; i += sextets)
        {
            int stream = 0;
            int blanks = 0;
            for (int j = 0; j < sextets; j++)
            {
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

            for (int j = 0; j < octets; j++)
            {
                byte octet = (byte)(stream >> (8 * (octets - j - 1)));
                bytes.Add(octet);
            }

            for (; blanks > 0; blanks--) bytes.RemoveAt(bytes.Count - 1);
        }

        return bytes.ToArray();
    }

    static void PrintBinary(byte bits, int pad = 8)
    {
        string res = Convert.ToString(bits, 2);
        while (res.Length < pad) res = '0' + res;
        Console.WriteLine(res);
    }

    // static int OctetsToInt(byte[] octets)
    // {
    //     Debug.Assert(octets.Length == 3);
    //     // int n = (octets[0] << 16) | (octets[1] << 8) | octets[2];
    //     int n = 0;
    //     for (int i = 0; i < octets.Length; i++)
    //     {
    //         n |= octets[i] << (8 * (octets.Length - i - 1));
    //     }
    //     // Console.WriteLine(Convert.ToString(n, 2));
    //     return n;
    // }
}