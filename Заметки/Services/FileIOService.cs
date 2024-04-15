using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Заметки.Models;

namespace Заметки.Services
{
    class FileIOService
    {
        private readonly string PATH;

        public FileIOService (string path)
        {
            PATH = path;
        }
        public BindingList<NotesModel> LoadData()
        {
            var fileExists = File.Exists(PATH); // проверка на существование файла
            if (!fileExists)
            {
                File.CreateText(PATH).Dispose(); // создадим, если нет
                return new BindingList<NotesModel>();
            }
            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<NotesModel>>(fileText);
            }
        }

        public void SaveData(object notData)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(notData);
                writer.Write(output);
            }
        }
    }
}
