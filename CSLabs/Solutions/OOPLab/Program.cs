using System;
using System.Collections.Generic;
using System.Text;

namespace OOPLab
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create new person
            Person person = new Person("Doe", "John", 35);

            //Get property values
            Console.WriteLine(person.Age.ToString());
            Console.WriteLine(person.FirstName);
            Console.WriteLine(person.LastName);

            //Call methods
            Console.WriteLine(person.GetFullName());
            person.DoWork(25, 4);

            Console.WriteLine(Environment.NewLine);
            Manager mgr = new Manager();
            mgr.FirstName = "Jane";
            mgr.LastName = "Doe";
            mgr.Age = 35;


            //Call overridden method
            Console.WriteLine(mgr.GetFullName());

            //Call shadow method
            mgr.DoWork(20, 4);

            Console.ReadLine();
        }
    }
}
