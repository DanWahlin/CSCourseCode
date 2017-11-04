using System;
namespace OOP.Hiding {
    public class Cat : Animal {
        new public void Speak(string message) {
            Console.WriteLine("Cat hides Animal's Speak: " + message);
        }
    }
}
