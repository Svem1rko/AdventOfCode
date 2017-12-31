using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(projectFolder, @"input.txt");

            var line = File.ReadAllText(fileName).ToCharArray();

            int sum = 0;

            for (int i = 0; i < line.Length - 1; i++)
            {
                if (line[i] == line[i + 1])
                    sum += line[i] - 48;
            }
            if (line[line.Length - 1] == line[0])
            {
                sum += line[0] - 48;
            }

            var jump = line.Length / 2;
            var sum2 = 0;

            for (int i = 0; i < line.Length; i++)
            {
                int index = (i + jump) % line.Length;
                if (line[i] == line[index])
                {
                    sum2 += line[i] - 48;
                }
            }

            Console.WriteLine("Part one: " + sum);
            Console.WriteLine("Part two: " + sum2);
            Console.ReadLine();
        }
    }
}
