using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent2022
{
    public static class Day3
    {
        public static void Run()
        {
            Console.WriteLine("Day 3");
            var lines = File.ReadAllLines("Day3Input.txt");
            int runningTotal = 0;
                   
            foreach (var line in lines)
            {
                char? badChar = null;

                int half = line.Length / 2;
                string fHalf = line.Substring(0, half);
                string sHalf = line.Substring(half);

                foreach (var c in fHalf.ToCharArray())
                {
                    if (sHalf.Contains(c))
                    {
                        badChar = c;
                    }
                }

                //var a = fHalf.ToCharArray().First(c => sHalf.Contains(c));

                Console.WriteLine("BADCHAR = " + badChar);
                runningTotal += TextToNumber(badChar.ToString()); ;
            }           

            Console.WriteLine(runningTotal);
        }

        public static void Run2()
        {
            Console.WriteLine("Day 3 P 2");
            var lines = File.ReadAllLines("Day3Input.txt");
            int runningTotal = 0;

            for (int i = 0; i < lines.Length; i = i + 3)
            {
                string? line = lines[i];
                string? line2 = lines[i + 1];
                string? line3 = lines[i + 2];
                runningTotal += NewMethod(line, line2, line3);
            }
            Console.WriteLine(runningTotal);
        }

        private static int NewMethod(string line, string line2, string line3)
        {
            var cl1 = line.ToCharArray();
            var cl2 = line2.ToCharArray();
            var cl3 = line3.ToCharArray();

            foreach (var item1 in cl1)
            {
                foreach (var item2 in cl2)
                {
                    foreach (var item3 in cl3)
                    {
                        if (item1 == item2 && item2 == item3)
                        {
                            return TextToNumber(item1.ToString());
                        }
                    }
                }
            }
            return 0;
        }

        static int TextToNumber(string text)
        {
            if (text == text.ToUpper())
            {
                return ((int)text.ToCharArray()[0] % 32) + 26;
            }
            return (int)text.ToCharArray()[0] % 32;
        }
    }
}
