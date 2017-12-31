using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    class Day2_1
    {
        static void Main(string[] args)
        {
            var sum = 0;

            do
            {
                var input = Console.ReadLine();

                if (input.Equals("KRAJ"))
                    break;

                var sNumbers = input.Split(' ');

                var numbers = sNumbers.Select(s => Int32.Parse(s)).ToArray();

                var min = numbers.Min();
                var max = numbers.Max();

                sum += max - min;

            } while (true);

            Console.WriteLine(sum);
            Console.ReadLine();
        }
    }
}
