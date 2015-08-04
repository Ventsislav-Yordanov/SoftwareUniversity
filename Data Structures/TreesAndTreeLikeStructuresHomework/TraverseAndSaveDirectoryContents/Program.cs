namespace TraverseAndSaveDirectoryContents
{
    using System;
    using System.IO;

    class Program
    {
        private const string startFolder = "C:\\Users\\Venciity\\Desktop\\homeworks";

        static void Main()
        {
            var folder = new Folder(startFolder);
            RecursiveDirectorySearch(folder);
            Console.WriteLine(folder.Size);

            foreach (var directory in folder.ChildFolders)
            {
                Console.WriteLine(directory.Name);
            }
        }

        static void RecursiveDirectorySearch(Folder folder)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(folder.Name);
            foreach (var fileInfo in directoryInfo.GetFiles())
            {
                folder.Files.Add(new File(fileInfo.FullName, fileInfo.Length));
            }

            foreach (var subDirectory in directoryInfo.GetDirectories())
            {
                var newFolder = new Folder(subDirectory.FullName);
                folder.ChildFolders.Add(newFolder);
                RecursiveDirectorySearch(newFolder);
            }
        }
    }
}
