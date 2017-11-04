using System;
namespace OOP.Abstraction {
	//abstract keyword marks class  "Abstract"
	public abstract class Animal {

		public void Speak(string message) {
			Console.WriteLine("Animal says: " + message);
		}

	}
}