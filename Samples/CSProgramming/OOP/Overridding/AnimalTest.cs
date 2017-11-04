using System;
namespace OOP.Overridding {
    public class AnimalTest {

        public static void Main() {

            Cat myCat = new Cat();
            Dog myDog =  new Dog();
            myCat.Speak("Meow");
            myDog.Speak("Woof");

            Console.ReadLine();
        }

    }
}
