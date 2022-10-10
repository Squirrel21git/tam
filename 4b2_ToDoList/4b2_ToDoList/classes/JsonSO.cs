using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _4b2_ToDoList.classes
{
    internal class JsonSO
    {
        public void SaveToJson(object item, string filename)
        {
            var json = JsonConvert.SerializeObject(item);

            File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ToDoList.txt"), json);
        }
    }
}
