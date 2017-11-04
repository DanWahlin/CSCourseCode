using System;
using System.Reflection;

namespace AdditionalFeatures.Reflection {
    public class ReflectionDemo2 {
        public static void Main() {
            Assembly assem = Assembly.LoadFrom(@"..\..\bin\debug\CSProgramming.exe");

            //Interate through all types in assembly
            Console.WriteLine("\r\nGetting all assembly types...");
            foreach (Type t in assem.GetTypes()) {
				Console.WriteLine(t.FullName);
			}

            Console.ReadLine();
        }
    }
}
