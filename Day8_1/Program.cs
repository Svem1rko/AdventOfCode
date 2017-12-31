using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    class Program
    {
        static void Main(string[] args)
        {
            string projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = Path.Combine(projectFolder, @"input.txt");

            string[] lines = File.ReadAllLines(fileName);

            HashSet<Register> registers = new HashSet<Register>();

            int max = 0;

            foreach (string s in lines)
            {
                string[] line = s.Split(' ');

                var registar = new Register(line[0]);

                registers.Add(registar);

                var a = registers.First(r => r.Name.Equals(line[0]));

                if (Condition(registers, line[4], line[5], line[6]))
                {
                    if (line[1].Equals("inc"))
                    {
                        a.Value += Int32.Parse(line[2]);
                    }
                    else
                    {
                        a.Value -= Int32.Parse(line[2]);
                    }
                }

                if (a.Value > max)
                {
                    max = a.Value;
                }

                registers.Remove(a);

                registers.Add(a);
            }

            Console.WriteLine("Part one :" + registers.Max(r => r.Value));
            Console.WriteLine("Part two: " + max);
            Console.ReadLine();
        }

        private static bool Condition(HashSet<Register> registers, string register, string condition, string value)
        {
            var a = registers.FirstOrDefault(r => r.Name.Equals(register));

            if (a == null)
            {
                a = new Register(register);
            }

            if (condition.Equals(">"))
            {
                return a.Value > Int32.Parse(value);
            }

            else if (condition.Equals("<"))
            {
                return a.Value < Int32.Parse(value);
            }

            else if (condition.Equals(">="))
            {
                return a.Value >= Int32.Parse(value);
            }

            else if (condition.Equals("<="))
            {
                return a.Value <= Int32.Parse(value);
            }

            else if (condition.Equals("=="))
            {
                return a.Value == Int32.Parse(value);
            }

            else if (condition.Equals("!="))
            {
                return a.Value != Int32.Parse(value);
            }

            return false;
        }
    }

    class Register
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public Register(string name)
        {
            Name = name;
            Value = 0;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Register register))
            {
                return false;
            }

            return register.Name.Equals(Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
