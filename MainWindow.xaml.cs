using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MyZAMETKI.Models;
using MyZAMETKI.Services;

namespace MyZAMETKI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly string PATH_Todo = $"{Environment.CurrentDirectory}\\todoDataList.json";
        private readonly string PATH_Notes = $"{Environment.CurrentDirectory}\\Notes";

        private BindingList<Model_Task> _todoDataList;
        private BindingList<Model_Note> _noteDataList;
        private FileIOService _fileIOService_toDo;
        private FileIOService _fileIOService_notes;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Task
            _fileIOService_toDo = new FileIOService(PATH_Todo);
            try
            {
                _todoDataList = _fileIOService_toDo.LoadData();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                this.Close();
            }
            if(_todoDataList == null)
            {
                _todoDataList = new BindingList<Model_Task>()
                {
                    new Model_Task(){ Text = "Привет"}
                };
            }
            dgTodoList.ItemsSource = _todoDataList;
            _todoDataList.ListChanged += _todoDataList_ListChanged;

            //
            //Note
            _fileIOService_notes = new FileIOService(PATH_Notes);
            //_noteDataList = _fileIOService_notes.LoadDataNotes();
            _noteDataList =_fileIOService_notes.LoadDataNotes();
            lbNotesList.ItemsSource = _noteDataList;
            notebookList.ItemsSource = _noteDataList;
            //

        }
        void LDN()
        {
            _fileIOService_notes = new FileIOService(PATH_Notes);
            _noteDataList = _fileIOService_notes.LoadDataNotes();
            lbNotesList.ItemsSource = _noteDataList;
            notebookList.ItemsSource = _noteDataList;
        }

        private void _todoDataList_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged)
            {
                try
                {
                    _fileIOService_toDo.SaveData(sender);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    this.Close();
                }
            }
        }

        private void eventsListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NoteWindow noteWindow = new NoteWindow(this);
            noteWindow.Owner = this;
            noteWindow.Title = (((Model_Note)lbNotesList.SelectedItem).Title).ToString();
            noteWindow.ShowDialog();

        }

        private void Create_New_Click(object sender, RoutedEventArgs e)
        {
            Create_Note_Name create_Note_Name = new Create_Note_Name();
            if (create_Note_Name.ShowDialog() == true)
            {
                if (create_Note_Name.note_Name != null && File.Exists(PATH_Notes + "\\" + create_Note_Name.note_Name + ".rtf") != true)
                {
                    MessageBox.Show("Nice");

                    using (FileStream fileStream = new FileStream((PATH_Notes + "\\" + create_Note_Name.note_Name + ".rtf"), FileMode.Create))
                    {
                        FlowDocument doc = new FlowDocument();
                        TextRange range = new TextRange(doc.ContentStart, doc.ContentEnd);
                        range.Save(fileStream, DataFormats.Rtf);
                    }

                    //File.Create(PATH_Notes + "\\" + create_Note_Name.note_Name + ".rtf");
                    LDN();

                }
                else
                    MessageBox.Show("No Nice(");

            }
        }
    }
}
