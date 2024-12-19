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
        static void Main(string[] args)
        {
            (string Name, int score)[] niceList;
            niceList = new (string Name, int score)[50];
            (string Name, int score)[] naughtyList;
            naughtyList = new (string Name, int score)[50];
            //bool again = true;
            Console.WriteLine("Santas list");

            //do
            int numOfNice = 0;
            int numOfNaughty = 0;
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Enter the name");
                string name = Console.ReadLine();
                string firstname = name.Split(" ")[0];
                string surname = name.Split(" ")[1];
                int niceScore = (santa(name) + surname.Length + vowels(name) + evenNum(surname, firstname));
                Console.WriteLine("Nice score " + niceScore);
                int naughtyScore = (grinch(name) + firstname.Length + afterM(name) + oddNum(surname, firstname));
                Console.WriteLine("Naughty score " + naughtyScore);
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
                
                //Console.WriteLine("do you want to put in another name\nY/N");
                //string againInput= Console.ReadLine();
                //if (againInput == "N"|| againInput == "n")
                //{
                //    again = false;
                //}
            }//while (again);
            //for (int i = 0; i < niceList.Length; i++)
            //{
            //    if (niceList[i].Name != null)
            //    {
            //        Console.WriteLine(niceList[i].Name);
            //    }
            //}
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
        }
    }
}
