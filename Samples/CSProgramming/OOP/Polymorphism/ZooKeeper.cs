using System;
namespace OOP.Polymorphism {
    public class ZooKeeper {
        public static void FeedAnimal(Animal animal) {
            animal.Speak("Hi from" + animal.GetType().ToString());
        }
    }
}
