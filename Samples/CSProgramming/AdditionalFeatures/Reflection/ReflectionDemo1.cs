using System;
using System.Reflection;

namespace AdditionalFeatures.Reflection {
    public class ReflectionDemo1 {
        public static void Main() {
            Type perType = Type.GetType("AdditionalFeatures.Reflection.Person");
            if (perType == null) return;

           System.DateTime birth  = System.DateTime.Parse("04/13/1960");
           Console.WriteLine("Getting Person fields...");
			foreach (PropertyInfo prop in perType.GetProperties()) {
				Console.WriteLine(prop.Name);
			}

            Console.WriteLine("\r\nGetting Person methods...");
			foreach (MethodInfo method in perType.GetMethods()) {
				Console.WriteLine(method.Name);
				if (method.Name == "CalculateAge") {
					Console.WriteLine("\r\n" + "Invoking static method...");
					object result = perType.InvokeMember(method.Name,
						BindingFlags.InvokeMethod, null,null,new object[]{birth});
					Console.WriteLine("Age: " + result.ToString());
				}
			}

            Console.ReadLine();
        }
    }
}
