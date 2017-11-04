using System;
using System.IO;

namespace BaseClassLibrary.FileSystemWatcher {
    public class FileSystemWatcherDemo {
        public static void Main() {
            //Demonstrates the FileSystemWatcher class
            System.IO.FileSystemWatcher fileWatcher = new System.IO.FileSystemWatcher();
            fileWatcher.Path = @"..\..\BaseClassLibrary\FileSystemWatcher\WatchFolder";
            // Check changes in LastAccess/LastWrite times
            // Check for renaming of directories/files. 
            fileWatcher.NotifyFilter = (System.IO.NotifyFilters.LastAccess |
               System.IO.NotifyFilters.LastWrite |
               System.IO.NotifyFilters.FileName |
               System.IO.NotifyFilters.DirectoryName);
            // determine which files to watch for
            fileWatcher.Filter = "*.xml";

            // Add event handlers for change events.
            fileWatcher.Changed += new FileSystemEventHandler(fileWatcher_Change);
            fileWatcher.Created += new FileSystemEventHandler(fileWatcher_Change);
            fileWatcher.Deleted += new FileSystemEventHandler(fileWatcher_Change);

            // Start watching...this must be set to true
            fileWatcher.EnableRaisingEvents = true;
            Console.WriteLine("Watching for changes....");

            Console.ReadLine();
        }

        public static void fileWatcher_Change(object source, FileSystemEventArgs e) {
            Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
        }

    }
}
