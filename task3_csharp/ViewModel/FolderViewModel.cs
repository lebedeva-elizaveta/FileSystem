using System.Collections.ObjectModel;

namespace task2_c
{
    public class FolderViewModel : FileSystemViewModel
    {
        private ObservableCollection<FileSystemViewModel> _items = new ObservableCollection<FileSystemViewModel>();
        public ObservableCollection<FileSystemViewModel> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        public FolderViewModel()
        {
            ItemType = "Folder";
        }

        public void AddItem(FileSystemViewModel item)
        {
            item.ParentFolder = this;
            Items.Add(item);
        }

        public void RemoveItem(FileSystemViewModel item)
        {
            Items.Remove(item);
        }

        public bool IsAncestorOf(FolderViewModel folder)
        {
            if (folder.ParentFolder == null)
                return false;

            if (folder.ParentFolder == this)
                return true;

            return IsAncestorOf(folder.ParentFolder);
        }
    }
}
