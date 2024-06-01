using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace task2_c
{
    public abstract class FileSystemViewModel : INotifyPropertyChanged
    {
        private FolderViewModel _parentFolder;
        public FolderViewModel ParentFolder
        {
            get { return _parentFolder; }
            set
            {
                _parentFolder = value;
                OnPropertyChanged(nameof(ParentFolder));
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private string _path;
        public string Path
        {
            get { return _path; }
            set
            {
                _path = value;
                OnPropertyChanged();
            }
        }

        private long _size;
        public long Size
        {
            get { return _size; }
            set
            {
                _size = value;
                OnPropertyChanged();
            }
        }

        public string ItemType { get; protected set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
