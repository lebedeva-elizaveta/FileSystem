using System.IO;

namespace task2_c
{
    public class FileViewModel : FileSystemViewModel
    {
        public FileViewModel(string name, long size)
        {
            Name = name;
            Size = size;
            ItemType = "File";
        }

        public FileViewModel(FileInfo fileInfo)
        {
            Name = fileInfo.Name;
            Size = fileInfo.Length;
            ItemType = "File";
        }
    }
}
