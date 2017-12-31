using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Day4_1
{
    class Program
    {
        static void Main(string[] args)
        {

            HashSet<string> set;

            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(projectFolder, @"input.txt");

            string[] lines = File.ReadAllLines(fileName);

            var valid = 0;

            foreach (string line in lines )
            {
                set = new HashSet<string>();

                var words = line.Split(' ');

                foreach (string word in words)
                {
                    set.Add(word);
                }

                if (set.Count == words.Length)
                    valid++;


            }

            Console.WriteLine(valid);
            Console.ReadLine();
        }
    }
}
