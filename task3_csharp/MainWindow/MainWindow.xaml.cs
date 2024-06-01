using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace task2_c
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (DataContext is MainViewModel viewModel)
            {
                if (e.NewValue != null)
                {
                    viewModel.FirstSelectedItem = e.NewValue as FileSystemViewModel;
                    viewModel.SecondSelectedItem = FindSelectedFolder(viewModel.FirstSelectedItem);

                    if (viewModel.FirstSelectedItem is FileViewModel file)
                    {
                        viewModel.SelectedItemSize = file.Size;
                    }
                    else if (viewModel.FirstSelectedItem is FolderViewModel folder)
                    {
                        viewModel.SelectedItemSize = GetFolderSize(folder);
                    }
                }
            }
        }

        private long GetFolderSize(FolderViewModel folder)
        {
            long size = 0;
            foreach (var item in folder.Items)
            {
                if (item is FileViewModel file)
                {
                    size += file.Size;
                }
                else if (item is FolderViewModel subfolder)
                {
                    size += GetFolderSize(subfolder);
                }
            }
            return size;
        }

        private FolderViewModel FindSelectedFolder(object selectedItem)
        {
            if (selectedItem is FolderViewModel folder)
            {
                return folder;
            }
            else return null;
        }

        private void RemovePlaceholderText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text == "Введите путь к сборке")
            {
                textBox.Text = "";
                textBox.Foreground = System.Windows.Media.Brushes.Black;
            }
        }

        private void AddPlaceholderText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "Введите путь к сборке";
                textBox.Foreground = System.Windows.Media.Brushes.Gray;
            }
        }
    }
}
