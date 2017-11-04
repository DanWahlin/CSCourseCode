using System;
namespace OOP.Inheritance {
	public class AnimalTest {

		public static void Main() {
			Cat myCat = new Cat();
			myCat.Speak("Meow");

			Dog myDog = new Dog();
			myDog.Speak("Woof");
			Console.ReadLine();
		}

	}
}
