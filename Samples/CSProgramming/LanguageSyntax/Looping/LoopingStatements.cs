using System;

namespace LanguageSyntax.Looping {
	public class LoopingStatements {

		public static void Main() {
			//Create array
			string[] names = new string[]{"Harry", "Tom", "John"};
			for (int i = 0; i < names.Length; i++) {
				if (names[i].ToUpper() == "TOM") {
					Console.WriteLine("Tom w found");
					break;
				}
			}

			Console.WriteLine("");
			//Fill array dynamically
			string[] dynamicArray = new string[5];
			Console.WriteLine("Upperbound of dynamicArray is: " +
				dynamicArray.GetUpperBound(0).ToString());

			for (int i = 0;i<dynamicArray.Length;i++) {
				dynamicArray[i] = "Name" + i.ToString();
			}

			foreach (string name in dynamicArray) {
				Console.WriteLine(name);
			}
			Console.Read();
		}


	}
}
