namespace naughy_or_nice
{
    internal class Program
    {
        static int vowels (string name)
        {
            int vowels = 0;
            name = name.ToLower();
            char[] vow = {'a','e','i','o','u'};
            foreach (char vowel in vow)
            {
                foreach (char letter in name)
                {
                    if (letter  == vowel)
                    {
                        vowels++;
                    }
                }
            }
            return vowels;
        }

        static void Main(string[] args)
        {
            string name = "Lang Milton";
            string firstname = name.Split(" ")[0];
            string surname = name.Split(" ")[1];
            int vowelscore = vowels(name);
            Console.WriteLine(vowelscore);
            int lengthscore = surname.Length;
            Console.WriteLine(lengthscore);
            Console.WriteLine(surname);
            Console.WriteLine(firstname);



        }
    }
}
