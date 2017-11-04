using System;
namespace Interfaces {
	public class Car : IDrive {
		public void TurnLeft() {
			Console.WriteLine("Car is turning left...");
		}
		public void TurnRight() {
		    Console.WriteLine("Car is turning right...");
		}
		public void GoStraight() {
			Console.WriteLine("Car is going straight...");
		}
		public void GoBackwards() {
			Console.WriteLine("Car is going backwards...");
		}
	}
}