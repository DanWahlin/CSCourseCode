using System;
using System.IO;

namespace BaseClassLibrary.DirectoriesFiles {
    public class DirectoriesFilesDemo {
        public static void Main() {
            //Demonstrates using Directory and File classes
            string path = @"..\..\..\CSProgramming";
            string[] directories  = Directory.GetDirectories(path);
			foreach (string dirName in directories) {
				DirectoryInfo dir = new DirectoryInfo(dirName);
				Console.WriteLine(dir.Name);
				string[] files  = Directory.GetFiles(dirName);
				foreach (string fileName in files) {
					FileInfo file = new FileInfo(fileName);
					Console.WriteLine("\t" + file.Name);
				}
			}
            Console.ReadLine();
        }
    }
}
