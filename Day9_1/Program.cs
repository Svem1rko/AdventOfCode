using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9
{
    class Program
    {
        static void Main(string[] args)
        {
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(projectFolder, @"input.txt");

            var line = File.ReadAllText(fileName).ToCharArray();

            int level = 1;
            bool garbage = false;
            bool ignor = false;
            int result = 0;
            int group = 0;
            int garbageSize = 0;

            foreach (var character in line)
            {
                if (ignor)
                {
                    ignor = false;
                }
                else if (character == '<' && !garbage)
                {
                    garbage = true;
                }
                else if (character == '>')
                {
                    garbage = false;
                }
                else if (character == '!' && garbage)
                {
                    ignor = true;
                }
                else if (character == '{' && !garbage)
                {
                    result += level++;
                    group++;
                }
                else if (character == '}' && !garbage)
                {
                    group--;
                    if (group > 0)
                    {
                        level--;
                    }
                }
                else if (garbage)
                {
                    garbageSize++;
                }
            }

            Console.WriteLine("Part one : " + result);
            Console.WriteLine("Part two: " + garbageSize);
            Console.ReadLine();
        }
    }
}
