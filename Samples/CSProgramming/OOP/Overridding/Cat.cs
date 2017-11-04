using System;
namespace OOP.Overridding {
    public class Cat : Animal {
        public override void Speak(string message) {
            Console.WriteLine("Cat says: " + message);
        }
    }
}
