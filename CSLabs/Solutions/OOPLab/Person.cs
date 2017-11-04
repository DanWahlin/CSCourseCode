using System;
using System.Collections.Generic;
using System.Text;

namespace OOPLab
{
    public class Person
    {
        private string _FirstName;
        private string _LastName;
        private int _Age;

        public Person()
        {

        }

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }


        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                _FirstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                _LastName = value;
            }
        }

        public int Age
        {
            get
            {
                return _Age;
            }
            set
            {
                _Age = value;
            }
        }
        

        public virtual string GetFullName()
        {
            if (!String.IsNullOrEmpty(FirstName) &&
                !String.IsNullOrEmpty(LastName))
            {
                return String.Concat(FirstName, " ", LastName);
            }
            else
            {
                return "None Specified";
            }
        }

        public void DoWork(int hours)
        {
            for (int i = 1; i <= hours; i++)
            {
                Console.WriteLine(String.Concat("Person worked ",
                    i.ToString(), " hours"));
            }
        }

        public void DoWork(int hours, int breakTime)
        {
            for (int i = 1; i <= hours; i++)
            {
                Console.WriteLine(String.Concat("Person worked ",
                  i.ToString(), " hours"));
                if (i % breakTime == 0)
                {
                    Console.WriteLine("\tTaking a short break.");
                }
            }
        }
    }
}
