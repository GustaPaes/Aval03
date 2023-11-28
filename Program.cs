public class Program
{
    static void Main()
    {
        string path = Path.Combine(Directory.GetCurrentDirectory(), "provinhaBarbadinha.txt");
        string[] replacements = new string[] { "gloriosa", "bondade", "passam" };
        int replacementIndex = 0;

        using (StreamReader sr = new StreamReader(path))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                string decryptedText = DeTeusPulosDecrypt(line);
                decryptedText = decryptedText.Replace('@', '\n');
                string[] words = decryptedText.Split(' ');

                for (int i = 0; i < words.Length; i++)
                {
                    if (IsPalindrome(words[i]) && replacementIndex < replacements.Length)
                    {
                        words[i] = replacements[replacementIndex++];
                    }
                }

                decryptedText = string.Join(" ", words);
                Console.WriteLine(decryptedText);
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

    static bool IsPalindrome(string word)
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
