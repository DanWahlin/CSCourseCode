using System;
namespace OOP.Inheritance {
	public abstract class Animal {
		//Not inherited because private
		private int Legs  = 4;

		public void Speak(string message) {
			Console.WriteLine("Animal says: " + message);
		}

	}
}
