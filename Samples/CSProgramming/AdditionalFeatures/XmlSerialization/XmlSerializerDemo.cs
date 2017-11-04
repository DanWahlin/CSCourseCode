using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace AdditionalFeatures.XmlSerialization
{
	public class XmlSerializerDemo {
		public static void Main() {
			//Create new instance of HelloWorld
			HelloWorld world = new HelloWorld();
			world.Greeting = "Hi There";

			//Serialize
			Serialize(world);
            Console.WriteLine("Serialized HelloWorld type.");

			//Deserialize
			HelloWorld newWorld = Deserialize();
			Console.WriteLine("Deserialized HelloWorld type.  Greeting property value is " + newWorld.Greeting);
			Console.ReadLine();

		}

		public static void Serialize(HelloWorld world) {
			//Serialize world object
			StreamWriter writer = null;
			XmlSerializer serializer = null;
			try {
                writer = File.CreateText(@"..\..\AdditionalFeatures - Additional Features\XmlSerialization\helloworld.xml");
				serializer = new XmlSerializer(typeof(HelloWorld));
				serializer.Serialize(writer, world);
			} finally {
				if (writer != null) {
					writer.Close();
				}
			}
		}

		public static HelloWorld Deserialize() {
			StreamReader reader = null;
			XmlSerializer serializer = null;
			HelloWorld world = null;
			try {
				reader = new StreamReader(@"..\..\AdditionalFeatures - Additional Features\XmlSerialization\helloworld.xml");
				serializer = new XmlSerializer(typeof(HelloWorld));
				world = (HelloWorld)serializer.Deserialize(reader);
				return world;
			} finally {
				if (reader != null) {
					reader.Close();
				}
			}

		}
	}
}