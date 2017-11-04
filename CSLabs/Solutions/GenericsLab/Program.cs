using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Diagnostics;

namespace GenericsLab
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dev Team
            Person p1 = new Person("John", "Doe", 35);
            Person p2 = new Person("Jane", "Doe", 34);
            Person p3 = new Person("Ted", "Newton", 4);

            //Create generic list of Person
            List<Person> devTeam = new List<Person>();
            devTeam.Add(p1);
            devTeam.Add(p2);
            devTeam.Add(p3);            
            
            //Manager Team
            Manager m1 = new Manager("Joe", "Manager", 45);
            Manager m2 = new Manager("Joanna", "Jones", 35);
            Manager m3 = new Manager("Susan", "Abrams", 56);
            
            //Create generic list of Person
            List<Person> mgrTeam = new List<Person>();
            mgrTeam.Add(m1);
            mgrTeam.Add(m2);
            mgrTeam.Add(m3);

            Dictionary<string, List<Person>> teams = 
                new Dictionary<string, List<Person>>();
            teams.Add("Dev Team", devTeam);
            teams.Add("Manager Team", mgrTeam);

            foreach (string key in teams.Keys)
            {
                Console.WriteLine(key + " Members");
                //Access List<Person> associated with key
                foreach (Person p in teams[key])
                {
                    Console.WriteLine(p.GetFullName());
                }
                Console.WriteLine(Environment.NewLine);
            }

            List<Person> devs;
            //Find Dev Team key
            if (teams.TryGetValue("Dev Team", out devs))
            {
                Console.WriteLine("Found Dev Team key.  Team has " + 
                    devs.Count.ToString() + " members.");
            }

            GenericStack<int> stack = new GenericStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            int i = 0;
            while ((i = stack.Pop()) != 0) {
                Console.WriteLine("Popped value " + i.ToString());
            }

            Console.ReadLine();

        }
    }
}
