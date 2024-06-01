using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2_c
{
    public class Folder : FileSystem
    {
        private List<FileSystem> _elements = new List<FileSystem>();

        public IEnumerable<FileSystem> Elements => _elements;

        public override FileSystemType Type => FileSystemType.Folder;

        public override long Size => _elements.Sum(e => e.Size);

        public override string GetTypeDescription()
        {
            return "Folder";
        }

        public void AddElement(FileSystem element)
        {
            _elements.Add(element);
            element.ParentFolder = this;
        }

        public void RemoveElement(FileSystem element)
        {
            _elements.Remove(element);
            element.ParentFolder = null;
        }
    }
}
