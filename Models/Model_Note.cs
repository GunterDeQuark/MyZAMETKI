using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MyZAMETKI.Models
{
    class Model_Note : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _text;
        public string Text
        {
            get { return _text; }
            set
            {
                if (_text == value)
                    return;
                _text = value;
                OnPropertyChanged("Text");
            }
        }
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                if (_title == value)
                    return;
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        public string PATH { get ; set; }


        //Construction
        public BindingList<Model_Note> Notes { get;  } = new BindingList<Model_Note>();
        public Model_Note(string titleLoad, string PathLoad)
        {
            Title = titleLoad;
            PATH = PathLoad;
            Text = "";
            Notes.Add(this);
        }

        public Model_Note()
        {
        }
    }
}
