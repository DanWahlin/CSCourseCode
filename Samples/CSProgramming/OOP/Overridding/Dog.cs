using System;
namespace OOP.Overridding {
    public class Dog : Animal {
        public override void Speak(string message) {
            //By using the keyword base you can call the be class's
            //public members
            base.Speak(message + " (Dog)");
        }
    }
}
