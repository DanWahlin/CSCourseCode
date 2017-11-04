
using System;
using System.Diagnostics;
using System.Reflection;


namespace AdditionalFeatures.ReflectionGenerics
{
	class ReflectionClient
	{
		static void Main(string[] args)
		{
         LinkedList<int,string> list = new LinkedList<int,string>();
         Type boundedType = list.GetType();

         Trace.WriteLine(boundedType.ToString());

         //Writes 'LinkedList[System.Int32,System.String]'
         Debug.Assert(boundedType.IsGenericType);

         Type[] parameters = boundedType.GetGenericArguments();

         Debug.Assert(parameters.Length == 2);
         Debug.Assert(parameters[0] == typeof( int));
         Debug.Assert(parameters[1] == typeof( string));

         Type unboundedType = boundedType.GetGenericTypeDefinition();
         Debug.Assert(unboundedType == typeof(LinkedList<,>));

         Trace.WriteLine(unboundedType.ToString());
         //Writes 'LinkedList`2[K,T]'
      }
	}
}
