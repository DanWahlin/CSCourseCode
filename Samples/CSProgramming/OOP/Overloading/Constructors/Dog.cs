using System;
namespace OOP.Overloading.Constructors {
    public class Dog : Animal {

        private int _Age;
        private string _Name;

        //Default parameterless constructor
        public Dog() {
            Console.WriteLine("Dog Constructor called.");
        }

        //Overloaded constructor which accepts to parameters
        public Dog(int age, string name) {
            _Age = age;
            _Name = name;
            Console.WriteLine("Second Animal Constructor Called. " +
               "Values = {0} and {1}", age.ToString(), name);
        }

    }
}
