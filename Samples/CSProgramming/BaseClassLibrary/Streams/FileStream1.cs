using System;
using System.IO;

namespace BaseClassLibrary.Streams {
    public class FileStream1 {
        static void Main() {
            //Demonstrates reading a file with the FileStream class
            string path  = @"..\..\BaseClassLibrary\Streams\Files\HelloWorld.txt";
            FileStream fStream = new FileStream(path, FileMode.Open);
            int bufflen = 500;
            byte[] buffer = new byte[bufflen];  //stream will write to buffer

			while (fStream.Read(buffer, 0, bufflen) != 0) { //Keep reading bytes into buffer
				char[] chars = System.Text.ASCIIEncoding.ASCII.GetChars(buffer);
				string newString = new String(chars, 0, chars.Length);
				Console.WriteLine(newString);
			}

            fStream.Close();
            Console.ReadLine();

        }

    }
}
