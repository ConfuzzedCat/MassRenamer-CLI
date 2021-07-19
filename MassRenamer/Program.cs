using System;
using System.IO;

namespace MassRenamer
{
    class Program
    {
        static void Main(string[] args)
        {
            String suffix;
            String fileType;
            string path = Directory.GetCurrentDirectory();

            Console.WriteLine("Type the suffix. Like this '_AA' or 'AA'");
            suffix = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Type the filetype. Like this 'png'");
            fileType = Console.ReadLine();
            Console.Clear();

            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (var files in dir.EnumerateFiles($"*.{fileType}"))
            {
                string filename = files.Name;               
                int index = filename.IndexOf($".{fileType}");
                string tempFile = (index < 0)
                    ? filename
                    : filename.Remove(index, fileType.Length);
                string renamedFile = tempFile + suffix +"."+ fileType;
                File.Move(filename, renamedFile);
                Console.WriteLine(renamedFile);
            }
            Console.ReadLine();
        }
    }
}
