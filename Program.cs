public class Program
{
    static void Main()
    {
        string path = Path.Combine(Directory.GetCurrentDirectory(), "provinhaBarbadinha.txt");
        string[] palindromo = new string[] { "gloriosa", "bondade", "passam" };
        int palindromoIndex = 0;

        using (StreamReader sr = new StreamReader(path))
        {
            string linha;
            while ((linha = sr.ReadLine()) != null)
            {
                string resultado = DeTeusPulosDecrypt(linha);
                resultado = resultado.Replace('@', '\n');
                string[] words = resultado.Split(' ');

                for (int i = 0; i < words.Length; i++)
                {
                    if (EhPalindromo(words[i]) && palindromoIndex < palindromo.Length)
                    {
                        words[i] = palindromo[palindromoIndex++];
                    }
                }

                resultado = string.Join(" ", words);
                Console.WriteLine(resultado);
            }
        }
    }

    static string DeTeusPulosDecrypt(string ciphertext)
    {
        char[] decryptedChars = new char[ciphertext.Length];

        for (int i = 0; i < ciphertext.Length; i++)
        {
            if (i % 5 == 0)
            {
                decryptedChars[i] = (char)(ciphertext[i]-8);
            }
            else
            {
                decryptedChars[i] = (char)(ciphertext[i]-16);
            }
        }

        return new string(decryptedChars);
    }

    static bool EhPalindromo(string word)
    {
        if (word.Length <= 1)
        {
            return false;
        }

        int min = 0;
        int max = word.Length - 1;
        while (true)
        {
            if (min > max)
            {
                return true;
            }
            char a = word[min];
            char b = word[max];
            if (a != b)
            {
                return false;
            }
            min++;
            max--;
        }
    }
}
