using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2_c
{
    public class File : FileSystem
    {
        public override FileSystemType Type => FileSystemType.File;

        private long _size;

        public override long Size => _size;

        public override string GetTypeDescription()
        {
            return "File";
        }

        public File(string name, long size)
        {
            Name = name;
            _size = size;
        }
    }

    public enum FileSystemType
    {
        Folder,
        File
    }
}
