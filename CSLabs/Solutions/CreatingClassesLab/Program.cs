using System;
using System.Collections.Generic;
using System.Text;

namespace CreatingClassesLab
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();
            //Set property values
            p.Age = 35;
            p.FirstName = "John";
            p.LastName = "Doe";

            //Get property values
            Console.WriteLine(p.Age.ToString());
            Console.WriteLine(p.FirstName);
            Console.WriteLine(p.LastName);

            //Call methods
            Console.WriteLine(p.GetFullName());
            p.DoWork(25);

            Console.ReadLine();

        }
    }
}
