using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyZAMETKI
{
    /// <summary>
    /// Interaction logic for Create_Note_Name.xaml
    /// </summary>
    public partial class Create_Note_Name : Window
    {
        public Create_Note_Name()
        {
            InitializeComponent();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        public string note_Name
        {
            get { return createnoteBox.Text; }
        }
    }
}
