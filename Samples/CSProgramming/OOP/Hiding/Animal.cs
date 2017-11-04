using System;
namespace OOP.Hiding {
    public abstract class Animal {

        public void Speak(string message) {
            Console.WriteLine("Animal says: " + message);
        }
        public void Speak(string message, int strength) {
            if (strength > 0 && strength < 10) {
				Console.WriteLine("Animal whispers: " + message);
			} else if (strength > 50 && strength < 100) {
				Console.Write("Animal yells: " + message);
			}
        }

    }
}
