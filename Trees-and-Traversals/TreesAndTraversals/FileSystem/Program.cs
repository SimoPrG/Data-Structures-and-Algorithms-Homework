// Write a program to traverse the directory C:\WINDOWS and all its subdirectories recursively and to display
// all files matching the mask *.exe.Use the class System.IO.Directory.

// Define classes File { string name, int size } and Folder { string name, File[] files, Folder[] childFolders }
// and using them build a tree keeping all files and folders on the hard drive starting from C:\WINDOWS.
// Implement a method that calculates the sum of the file sizes in given subtree of the tree and test it accordingly.
// Use recursive DFS traversal.

namespace TreesAndTraversals.FileSystem
{
    using System;

    internal class Program
    {
        public static void Main()
        {
            var path = @"C:\Windows";
            var directory = MyDirectory.GetDirectory(path);

            var executableFiles = directory.GetFilesWithExtension(".exe");
            Console.WriteLine(string.Join(Environment.NewLine, executableFiles));

            Console.WriteLine(path + "size in bytes: " + directory.GetMemorySizeInBytes());
        }
    }
}
