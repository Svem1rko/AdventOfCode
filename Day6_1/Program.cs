using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {

            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(projectFolder, @"input.txt");

            string[] lines = File.ReadAllLines(fileName);

            var numbers = lines[0].Split('\t').Select(n => Int32.Parse(n)).ToArray();

            HashSet<string> set = new HashSet<string>();
            set.Add(PretvoriUString(numbers));

            string duplic;

            while (true)
            {
                var max = numbers[0];
                var maxIndex = 0;

                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] > max)
                    {
                        max = numbers[i];
                        maxIndex = i;
                    }
                }

                var blocks = numbers[maxIndex];
                numbers[maxIndex] = 0;

                while (blocks > 0)
                {
                    maxIndex = (maxIndex + 1) % numbers.Length;
                    numbers[maxIndex]++;
                    blocks--;
                }

                if (!set.Add(PretvoriUString(numbers)))
                {
                    duplic = PretvoriUString(numbers);
                    break;
                }
            }

            var count = 0;
            int index = 0;
            foreach (string s in set)
            {
                if (s.Equals(duplic))
                {
                    index = count;
                    break;
                }
                count++;


            }

            Console.WriteLine($"1) {set.Count}");
            Console.WriteLine($"2) {set.Count - index}");

            Console.ReadLine();
        }

        private static string PretvoriUString(int[] numbers)
        {
            string result = "";

            for (int i = 0; i < numbers.Length; i++)
                result += numbers[i].ToString();

            return result;
        }
    }
}
