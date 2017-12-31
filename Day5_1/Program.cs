using System;
using System.Collections;
using System.IO;

namespace Day5_1
{
    class Program
    {
        static void Main(string[] args)
        {

            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(projectFolder, @"input.txt");

            string[] lines = File.ReadAllLines(fileName);

            int[] jumps = new int[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                jumps[i] = Int32.Parse(lines[i]);
            }

            var index = 0;
            var count = 0;

            while (index < jumps.Length)
            {
                var temp = index;
                index += jumps[index];
                if (index > jumps.Length)
                    break;
                jumps[temp]++;
                count++;
            }

            Console.WriteLine(count);
            Console.ReadLine();
        }
    }
}
