using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace MyZAMETKI.Models
{
    class Explorer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<string> MainDiskName { get; set; } = new ObservableCollection<string>();

        public Explorer()
        {
            string temp = Directory.GetCurrentDirectory().ToString()+"\\Notes";
        }
    }

    public class DirectoryViewModel 
    {
        public string DirectoryName { get; }
        public DirectoryViewModel(string directoryName)
        {
            DirectoryName = directoryName;
        }
    }

    public class FileViewModel 
    {

    }

}
