using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQLab
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Customer> custs = new List<Customer>
            {
                new Customer {Age = 7, FirstName="John", LastName="Doe", City="New York"},
                new Customer {Age = 10, FirstName="Jane", LastName="Doe2", City="New York"},
                new Customer {Age = 50, FirstName="Dave", LastName="Doe", City="New York"},
                new Customer {Age = 60, FirstName="Tina", LastName="Doe", City="Phoenix"},
                new Customer {Age = 45, FirstName="George", LastName="Doe", City="Seattle"}, 
            };
            var filteredCusts = from c in custs
                                where c.City == "New York" && c.FirstName.StartsWith("J")
                                orderby c.LastName
                                select c;
            //var filteredCusts = custs.Where(c => c.City == "New York" && c.LastName.StartsWith("J"))
            //                    .OrderBy(c => c.FirstName);
            foreach (var item in filteredCusts)
            {
                Console.WriteLine(item.FirstName);
            }
            Console.Read();
        }
    }

    public class Customer
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
    }
}
