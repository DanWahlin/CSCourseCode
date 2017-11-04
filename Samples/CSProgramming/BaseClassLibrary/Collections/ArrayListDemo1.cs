using System;
using System.Collections;

namespace BaseClassLibrary.Collections
{
	public class ArrayListDemo1 {
		public static void Main() {
			ArrayList namesList = new ArrayList();
			namesList.Add("Fred");
			namesList.Add("Val");
			namesList.Add("Ted");

			//Iterate through ArrayList
			IEnumerator enumerator = namesList.GetEnumerator();
			while (enumerator.MoveNext()) {
				Console.WriteLine(enumerator.Current);
			}
			Console.WriteLine("");

			//Iterate using foreach
			foreach (object name in namesList) {
				Console.WriteLine(name);
			}

			Console.ReadLine();
		}
    }
}