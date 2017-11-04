using System;
namespace OOP.Overridding {
    public abstract class Animal {
        //Not inherited because private
        private int Legs  = 4;

        public virtual void Speak(string message) {
            Console.WriteLine("Animal says: " + message);
        }

    }
}
