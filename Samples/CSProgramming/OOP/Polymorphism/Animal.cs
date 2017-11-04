using System;
namespace OOP.Polymorphism {
    public abstract class Animal {
        public void Speak(string message) {
            Console.WriteLine("Animal says: " + message);
        }
    }
}
