using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2_c
{
    public abstract class FileSystem
    {
        public string Name { get; set; }
        public FileSystem ParentFolder { get; set; }

        public abstract FileSystemType Type { get; }
        public abstract long Size { get; }

        public string Location
        {
            get
            {
                if (ParentFolder == null)
                    return "Root";
                else
                    return $"{ParentFolder.Location}/{Name}";
            }
        }

        public abstract string GetTypeDescription();

        public static void Copy(FileSystem element, Folder destinationFolder)
        {
            if (destinationFolder.Elements.Any(e => e.Name == element.Name))
            {
                Console.WriteLine($"Failed to copy {element.Name} to {destinationFolder.Name}: Destination folder already contains an element with the same name.");
                return;
            }

            FileSystem copy = null;
            if (element is File file)
            {
                copy = new File(file.Name, file.Size);
            }
            else if (element is Folder folder)
            {
                var newFolder = new Folder { Name = folder.Name };
                foreach (var childElement in folder.Elements)
                {
                    Copy(childElement, newFolder);
                }
                copy = newFolder;
            }

            destinationFolder.AddElement(copy);

            Console.WriteLine($"Copied {element.Name} to {destinationFolder.Name}.");
        }

        public static void Move(FileSystem element, Folder destinationFolder)
        {
            if (destinationFolder.Elements.Any(e => e.Name == element.Name))
            {
                Console.WriteLine($"Failed to move {element.Name} to {destinationFolder.Name}: Destination folder already contains an element with the same name.");
                return;
            }

            if (element.ParentFolder == destinationFolder)
            {
                Console.WriteLine($"{element.Name} is already in {destinationFolder.Name}.");
                return;
            }

            if (element.ParentFolder != null)
            {
                var sourceFolder = (Folder)element.ParentFolder;
                sourceFolder.RemoveElement(element);
            }

            destinationFolder.AddElement(element);

            Console.WriteLine($"Moved {element.Name} to {destinationFolder.Name}.");
        }
    }
}
