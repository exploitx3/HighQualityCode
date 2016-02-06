namespace Other
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;

    public class TraversalMain
    {
        static void Main()
        {
            var traverser = new DirectoryTraverser(Environment.CurrentDirectory);

            var children = traverser.GetChildDirectories();
            foreach (var child in children)
            {
                Console.WriteLine(child);
            }

            Console.WriteLine(traverser.CurrentDirectory);
                
            Console.WriteLine(Environment.OSVersion);
            Console.WriteLine(Environment.MachineName);
            Console.WriteLine(Environment.UserName);
            foreach (var arg in Environment.GetCommandLineArgs())
            {
                Console.WriteLine(arg);
            }
            foreach (var arg in Environment.GetLogicalDrives())
            {
                Console.WriteLine(arg);
            }
            Console.WriteLine(Environment.GetCommandLineArgs());
            Console.WriteLine(Environment.GetLogicalDrives());

        }
    }

    public class DirectoryTraverser
    {
        public DirectoryTraverser(string directory)
        {
            this.CurrentDirectory = directory;
        }

        public string CurrentDirectory { get; set; }

        public IEnumerable<string> GetChildDirectories()
        {
            var directories = Directory.GetDirectories(this.CurrentDirectory);

            var directoryNames = new List<string>(directories.Length);
            foreach (var directory in directories)
            {
                int lastBackSlash = directory.LastIndexOf("\\");
                string directoryName = directory.Substring(lastBackSlash + 1);

                directoryNames.Add(directoryName);
            }

            directoryNames.Sort();

            return directoryNames;
        }
    }
}
