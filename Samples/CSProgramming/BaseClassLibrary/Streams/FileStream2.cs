using System;
using System.IO;

namespace BaseClassLibrary.Streams {
    public class FileStream2 {
        static void Main() {
            //Demonstrates writing to a file with the FileStream class
            string path = @"..\..\BaseClassLibrary\Streams\Files\HelloWorld.txt";
            FileStream fStream = new FileStream(path, FileMode.Append);

            //Hard way to write to file (see FileReader3.cs for easy way)
            byte[] byteArray = ConvertToByteArray(Environment.NewLine);
            Console.WriteLine("Writing to file..");
            fStream.Write(byteArray, 0, byteArray.Length);
            byteArray = ConvertToByteArray("New String");
            fStream.Write(byteArray, 0, byteArray.Length);

            //Always close streams
            fStream.Close();

            Console.ReadLine();

        }

		public static byte[] ConvertToByteArray(string input) {
			//1.  Convert String to char array
			//2.  Convert char array to byte array
			//3.  Return byte array
			return System.Text.Encoding.ASCII.GetBytes(input.ToCharArray());
		}
    }
}
