using System;
using System.Collections.Generic;
using System.Text;

namespace InterfacesLab
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person("John", "Dover", 35);
            Person p3 = new Person("Ted", "Newton", 4);            
            Person p2 = new Person("Jane", "Doe", 34);

            Console.WriteLine("Sorting Array by LastName " +
                "(IComparable<Person>)...");
            Person[] personArray = new Person[] { p1, p2, p3 };
            Array.Sort(personArray);
            foreach (Person p in personArray) {
                Console.WriteLine("LastName = " + p.LastName);
            }            
            Console.WriteLine(Environment.NewLine);
            
            PeopleList people = new PeopleList();
            people.AddPerson(p1);
            people.AddPerson(p2);
            people.AddPerson(p3);

            Console.WriteLine("Sorting PeopleList by Age " +
                "(IComparer<Person>)...");
            people.SortByAge();
            foreach (Person p in people) {
                Console.WriteLine("Age = " + p.Age.ToString());
            }
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Sorting PeopleList by LastName " +
                "(IComparer<Person>)...");
            people.SortByLastName();
            foreach (Person p in people)
            {
                Console.WriteLine("LastName = " + p.LastName);
            }

            Console.ReadLine();
        }
    }
}
