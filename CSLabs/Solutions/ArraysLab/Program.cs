using System;
using System.Collections.Generic;
using System.Text;

namespace ArraysLab
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] names = new string[5];
            names[0] = "John";
            names[1] = "Dave";
            names[2] = "Susie";
            names[3] = "Thomas";
            names[4] = "Danny";

            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine(names[i]);
            }

            Console.WriteLine(Environment.NewLine);

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
            
            Console.WriteLine(Environment.NewLine);

            string[] namesCopy = new string[names.Length];
            names.CopyTo(namesCopy, 0);

            for (int i = namesCopy.GetUpperBound(0);i >= 0; i--)
            {
                Console.WriteLine(namesCopy[i]);
            }

            Console.WriteLine(Environment.NewLine);
            Array.Reverse(namesCopy);
            foreach (string name in namesCopy)
            {
                Console.WriteLine(name);
            }

            Console.ReadLine();

        }
    }
}
