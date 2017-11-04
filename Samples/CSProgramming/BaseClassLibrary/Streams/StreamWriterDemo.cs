using System;
using System.IO;

namespace BaseClassLibrary.Streams {
    public class StreamWriterDemo {
        static void Main() {
            //Demonstrates writing to a file with
            //FileStream and StreamWriter classes
            string path = @"..\..\BaseClassLibrary\Streams\Files\HelloWorld.txt";
            FileStream fStream = new FileStream(path, FileMode.Append);
            StreamWriter writer = new StreamWriter(fStream);

            //Write to file
            Console.WriteLine("Writing to file");
            writer.WriteLine("\r\nNew String written by StreamWriter");

            writer.Close();

            //Read from file now
            fStream = new FileStream(path, FileMode.Open);
            StreamReader reader = new StreamReader(fStream);
            Console.WriteLine("");
            Console.WriteLine("Reading from file");
			while (reader.Peek() != -1) {
				Console.WriteLine(reader.ReadLine());
			}

            //Always close streams
            reader.Close();
            Console.ReadLine();
        }
    }
}
