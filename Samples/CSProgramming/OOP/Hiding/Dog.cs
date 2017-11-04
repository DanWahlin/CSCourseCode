using System;
namespace OOP.Hiding {
    public class Dog : Animal {
        new public void Speak(string message) {
            Console.WriteLine("Dog hides Animal's Speak: " + message);
        }
    }
}
