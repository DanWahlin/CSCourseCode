using System;
using System.IO;

namespace BaseClassLibrary.Streams {
    public class StreamReaderDemo {
        static void Main() {
            //Demonstrates reading from a file with
            //FileStream and StreamReader
            string path  = @"..\..\BaseClassLibrary\Streams\Files\HelloWorld.txt";
            FileStream fStream = new FileStream(path, FileMode.Open);
            StreamReader reader = new StreamReader(fStream);
            reader.BaseStream.Seek(0, SeekOrigin.Begin);

            //read line by line
            Console.WriteLine("Reading line by line:");
			while (reader.Peek() > -1) {
				Console.WriteLine(reader.ReadLine());
			}

            //read to end of file
            Console.WriteLine(Environment.NewLine + "Reading entire file:");
            reader.BaseStream.Seek(0, SeekOrigin.Begin); //Reposition to beginning of stream
            string entireFile = reader.ReadToEnd();
            Console.WriteLine(entireFile);

            //Always close streams
            reader.Close();
            Console.ReadLine();

        }
    }
}
