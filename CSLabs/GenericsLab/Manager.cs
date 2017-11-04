using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsLab
{
    public class Manager : Person
    {

        public Manager() {}

        public Manager(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public override string GetFullName()
        {
            return String.Concat("Manager: ", base.GetFullName());
        }

        //Hide base class DoWork() method
        new public void DoWork(int hours, int breakTime)
        {
            int k = hours * 2;
            for (int i = 1; i <= k; i++)
            {
                Console.WriteLine(String.Concat(
                        "Manager worked ", i.ToString(),
                        " hours"));
                if (i % (breakTime / 2) == 0)
                {
                    Console.WriteLine("\tTaking a short break.");
                }
            }
        }
    }
}
