using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BaseClassLibrary.Streams
{
    class ReadAllTextDemo
    {
        public static void Main()
        {
            string path = @"..\..\BaseClassLibrary\Streams\Files\HelloWorld.txt";
            string contents = File.ReadAllText(path);
            Console.Write(contents);
            Console.ReadLine();
        }
    }
}
