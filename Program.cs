using System.Diagnostics.Metrics;
using System.Runtime.InteropServices;
using System.Threading.Tasks.Sources;
using System.Xml.Linq;
using System.IO;


namespace naughy_or_nice
{
    internal class Program
    {
        static int vowels(string name)
        {
            int vowels = 0;
            name = name.ToLower();
            char[] vow = { 'a', 'e', 'i', 'o', 'u' };
            foreach (char vowel in vow)
            {
                foreach (char letter in name)
                {
                    if (letter == vowel)
                    {
                        vowels++;
                    }
                }
            }
            return vowels;
        }
        static int evenNum(string surname, string firstname)
        {
            if (surname.Length % 2 == 0 && firstname.Length % 2 == 0)
            {
                return 5;
            }
            return 0;
        }
        static int oddNum(string surname, string firstname)
        {
            if (surname.Length % 2 == 1 && firstname.Length % 2 == 1)
            {
                return 5;
            }
            return 0;
        }
        static int santa(string name)
        {
            int score = 0;
            char[] santa = { 's', 'a', 'n', 't' };
            name = name.ToLower();
            foreach (char santaL in santa)
            {
                foreach (char letter in name)
                {
                    if (letter == santaL)
                    {
                        score += 2;
                    }
                }
            }
            return score;
        }
        static int grinch(string name)
        {
            int score = 0;
            char[] grinch = { 'g', 'r', 'i', 'n', 'c', 'h' };
            name = name.ToLower();
            foreach (char grinchl in grinch)
            {
                foreach (char letter in name)
                {
                    if (letter == grinchl)
                    {
                        score += 2;
                    }
                }
            }
            return score;
        }
        static int afterM(string name)
        {
            int score = 0;
            name = name.ToLower();
            char[] alpha = { 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            foreach (char chars in alpha)
            {
                foreach (char letter in name)
                {
                    if (letter == chars)
                    {
                        score++;
                    }
                }
            }
            return score;
        }
        static (string Name, int score)[] naughtyListOrder((string Name, int score)[] naughtyList)
        {
            int n = naughtyList.Length;
            bool swapped = false;
            do
            {
                swapped = false;
                for (int i = 1; i < n; i++)
                {
                    if (naughtyList[i - 1].score > naughtyList[i].score)
                    {
                        (string Name, int score) temp = naughtyList[i - 1];
                        naughtyList[i - 1] = naughtyList[i];
                        naughtyList[i] = temp;
                        swapped = true;
                    }
                }
                n--;
            } while (swapped);
            return naughtyList;
        }
        static (string Name, int score)[] niceListOrder((string Name, int score)[] niceList)
        {
            int n = niceList.Length;
            bool swapped = false;
            do
            {
                swapped = false;
                for (int i = 1; i < n; i++)
                {
                    if (niceList[i - 1].score > niceList[i].score)
                    {
                        (string Name, int score) temp = niceList[i - 1];
                        niceList[i - 1] = niceList[i];
                        niceList[i] = temp;
                        swapped = true;
                    }
                }
                n--;
            } while (swapped);
            return niceList;
        }
        static (string Name, int score)[] percentListOrder((string Name, int score)[] percentList)
        {
            int n = percentList.Length;
            bool swapped = false;
            do
            {
                swapped = false;
                for (int i = 1; i < n; i++)
                {
                    if (percentList[i - 1].score > percentList[i].score)
                    {
                        (string Name, int score) temp = percentList[i - 1];
                        percentList[i - 1] = percentList[i];
                        percentList[i] = temp;
                        swapped = true;
                    }
                }
                n--;
            } while (swapped);
            return percentList;
        }
        static void Main(string[] args)
        {
            (string Name, int score)[] niceList;
            niceList = new (string Name, int score)[50];
            (string Name, int score)[] naughtyList;
            naughtyList = new (string Name, int score)[50];
            (string Name, int score)[] percentList;
            percentList = new (string Name, int score)[50];
            Console.WriteLine("how many names on the list?");
            int nameNum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Santas list");

            int numOfNice = 0;
            int numOfNaughty = 0;
            for (int i = 0; i < nameNum; i++)
            {
                Console.WriteLine("Enter the name");
                string name = Console.ReadLine();
                string firstname = name.Split(" ")[0];
                string surname = name.Split(" ")[1];
                //Console.WriteLine(firstname.Length);
                //Console.WriteLine(surname.Length);
                int niceScore = (santa(name) + surname.Length + vowels(name) + evenNum(surname, firstname));
                Console.WriteLine("Nice score " + niceScore);
                int naughtyScore = (grinch(name) + firstname.Length + afterM(name) + oddNum(surname, firstname));
                Console.WriteLine("Naughty score " + naughtyScore);
                Console.WriteLine("persentage score "+ Convert.ToInt32(Convert.ToDouble(niceScore)/(Convert.ToDouble(niceScore + naughtyScore)) * 100)+ " %");
                if (niceScore > naughtyScore)
                {
                    niceList[numOfNice] = (name, niceScore);
                    numOfNice++;
                }
                else
                {
                    naughtyList[numOfNaughty] = (name, niceScore);
                    numOfNaughty++;
                }
                //niceList[i] = (name, niceScore);
                //naughtyList[i] = (name, niceScore);
                percentList[i] = (name,Convert.ToInt32(Convert.ToDouble(niceScore) / (Convert.ToDouble(niceScore + naughtyScore)) * 100));
                
            }
            Console.WriteLine("the naughty list in order from least to most is as follows");
            naughtyList = naughtyListOrder(naughtyList);
            for (int i = 0; i < naughtyList.Length; i++)
            {
                if (naughtyList[i].Name != null)
                {
                    Console.WriteLine(naughtyList[i].Name);
                }
            }
            Console.WriteLine("the nice list in order from least to most is as follows");
            niceList = niceListOrder(niceList);
            for (int i = 0;i < niceList.Length;i++)
            {
                if (niceList[i].Name != null)
                {
                    Console.WriteLine(niceList[i].Name);
                }
            }
            Console.WriteLine("the persentage nice list in order from least to most is as follows");
            percentList = percentListOrder(percentList);
            for (int i = 0; i < percentList.Length; i++)
            {
                if (percentList[i].Name != null)
                {
                    Console.WriteLine(percentList[i].Name + Convert.ToString(percentList[i].score));
                }
            }
        }
    }
}
