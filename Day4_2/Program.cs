using System;
using System.Collections.Generic;
using System.IO;

namespace Day4_2
{
    class Program
    {
        static void Main(string[] args)
        {

            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(projectFolder, @"input.txt");

            string[] lines = File.ReadAllLines(fileName);

            var valid = 0;

            foreach (string line in lines)
            {
                var words = line.Split(' ');

                var notAnagrams = true;

                for (int i = 0; i < words.Length - 1 && notAnagrams; i++)
                {
                    for (int j = i + 1; j < words.Length && notAnagrams; j++)
                    {
                        if (isAnagram(words[i], words[j]))
                            notAnagrams = false;
                    }
                }

                if (notAnagrams)
                    valid++;
            }

            Console.WriteLine(valid);
            Console.ReadLine();
        }

        private static bool isAnagram(string s, string s1)
        {
            if (s.Length != s1.Length)
                return false;

            var c1 = s.ToCharArray();
            var c2 = s1.ToCharArray();

            var index = 0;

            do
            {
                var c = c1[index++];
                var count1 = 0;
                var count2 = 0;

                for (int i = 0; i < c1.Length; i++)
                {
                    if (c1[i] == c)
                        count1++;
                }

                for (int j = 0; j < c2.Length; j++)
                {
                    if (c2[j] == c)
                        count2++;
                }

                if (count1 != count2)
                    return false;

            } while (index < c1.Length);

            return true;
        }
    }
}
