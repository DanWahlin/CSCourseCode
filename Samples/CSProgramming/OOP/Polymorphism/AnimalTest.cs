using System;
namespace OOP.Polymorphism {
    public class AnimalTest {

        public static void Main() {
            //Create Cat and Dog classes
            Cat cat = new Cat();
            Dog dog = new Dog();

            //Call inherited Speak() method

            ZooKeeper.FeedAnimal(cat);
            ZooKeeper.FeedAnimal(dog);

            Console.ReadLine();

        }

    }
}
