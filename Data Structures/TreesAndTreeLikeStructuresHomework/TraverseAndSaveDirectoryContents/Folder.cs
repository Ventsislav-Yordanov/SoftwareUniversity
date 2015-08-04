using System.Collections.Generic;
namespace TraverseAndSaveDirectoryContents
{
    public class Folder
    {
        private long? size;

        public Folder(string name)
        {
            this.Name = name;
            this.Files = new List<File>();
            this.ChildFolders = new List<Folder>();
        }

        public string Name { get; set; }

        public List<File> Files { get; set; }

        public List<Folder> ChildFolders { get; set; }

        public long? Size
        {
            get
            {
                if (this.size != null)
                {
                    return this.size;
                }
                else
                {
                    this.size = 0;
                    foreach (var childFolder in this.ChildFolders)
                    {
                        this.size += childFolder.Size;
                    }

                    foreach (var file in this.Files)
                    {
                        this.size += file.Size;
                    }

                    return this.size;
                }
            }
        }
    }
}
