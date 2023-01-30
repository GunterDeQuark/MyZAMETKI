using MyZAMETKI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Documents;

namespace MyZAMETKI.Services
{
    class FileIOService
    {
        private readonly string PATH;

        public FileIOService(string path)
        {
            PATH = path;
        }

        public BindingList<Model_Task> LoadData()
        {
            var fileExists = File.Exists(PATH);
            if (!fileExists)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<Model_Task>();
            }
            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<Model_Task>>(fileText);
            }
        }

        

        //Load Notes Info
        public BindingList<Model_Note> LoadDataNotes()
        {
            if (!Directory.Exists(PATH))
            {
                Directory.CreateDirectory(PATH);
            }
            var directiryInfo = new DirectoryInfo(PATH);
            /*return*/
            string[] allnotes = Directory.GetFiles(PATH);//, ".rtf", SearchOption.TopDirectoryOnly);

            Model_Note model = new Model_Note();
            foreach (string item in allnotes)
            {
                Model_Note a = new Model_Note(Path.GetFileName(item), item );
                //FileStream fileStream = new FileStream(item, FileMode.Open);
            model.Notes.Add(a);
            }
            return model.Notes;

        }


        public void SaveData(object DataList)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(DataList);
                writer.Write(output);
            }
        }
    }
}
