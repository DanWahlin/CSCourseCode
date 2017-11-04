using System;
namespace OOP.Overloading {
    public class AnimalTest {

        public static void Main() {
            Dog myDog = new Dog();
            myDog.Speak("Woof...Woof");
            myDog.Speak("Woof", 10);

            Console.ReadLine();
        }

    }
}
