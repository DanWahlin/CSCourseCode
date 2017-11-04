using System;
namespace OOP.Hiding {
    public class AnimalTest {

        public static void Main() {
            //Create Cat and Dog classes
            Cat myCat = new Cat();
            Dog myDog = new Dog();

            //All Animal Speak() methods are shadowed (hidden)
            myCat.Speak("Meow");
            myDog.Speak("Woof");

            Console.ReadLine();

        }

    }
}
