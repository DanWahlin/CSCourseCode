using System;

namespace BaseClassLibrary.StringBuilder {
    public class StringBuilderDemo {
        public static void Main() {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            string bigString  = String.Empty;

			for (int i=0;i<=20;i++) {
				sb.Append("Number: ");
				sb.Append(i.ToString());
				sb.Append("\r\n");
			}
			Console.WriteLine(sb.ToString());
			Console.WriteLine("");

			Console.ReadLine();
        }
    }
}
