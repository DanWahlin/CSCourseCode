using System;
namespace OOP.Overloading.Constructors {
    public class AnimalTest {

        public static void Main() {

            Dog myDog = new Dog();
            myDog.Speak("Woof...Woof");
            myDog.Speak("Woof", 10);

            Dog myDog2 = new Dog(10, "Rover");
            myDog2.Speak("Woof..Woof from Dog2");
            myDog2.Speak("Woof from Dog2", 99);

            Console.ReadLine();

        }

    }
}
