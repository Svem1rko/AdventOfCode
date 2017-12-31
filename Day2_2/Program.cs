using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    class Day2_2
    {
        static void Main(string[] args)
        {

            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(projectFolder, @"input.txt");

            string[] lines = File.ReadAllLines(fileName);

            var suma = 0;

            foreach (string line in lines)
            {
                var sNumbers = line.Split('\t');

                var numbers = sNumbers.Select(s => Int32.Parse(s)).ToArray();

                var div1 = 0;
                var div2 = 0;

                for (int i = 0; i < numbers.Length; i++)
                {
                    for (int j = i + 1; j < numbers.Length; j++)
                    {
                        if (numbers[i] % numbers[j] == 0 || numbers[j] % numbers[i] == 0)
                        {
                            div1 = numbers[i];
                            div2 = numbers[j];
                            break;
                        }
                    }
                }

                if (div2 > div1)
                {
                    var temp = div1;
                    div1 = div2;
                    div2 = temp;
                }

                suma += div1 / div2;

            }

            Console.WriteLine(suma);
            Console.ReadLine();
        }
    }
}
