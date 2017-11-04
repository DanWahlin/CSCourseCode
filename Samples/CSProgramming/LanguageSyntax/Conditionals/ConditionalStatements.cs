using System;

namespace LanguageSyntax.Conditionals {
	public class ConditionalStatements {

		public static void Main() {
			//Get total by calling GetTotalSale() method
			double total = GetTotalSale();
			string shipping = "Shipping is $";
			if (total >= 100.0 && total <= 1000) {
				Console.WriteLine(shipping + Convert.ToString(total * .2));
			}
			else if (total >= 1000) {
				Console.WriteLine(shipping + " free!");
			}
			else if (total < 100) {
				Console.WriteLine(shipping + Convert.ToString(total * .9));
			}
			else {
				Console.WriteLine("We don't ship to your address.");
			}
			Console.Read();
		}

		private static double GetTotalSale() {
			return 99;
		}
	}
}
