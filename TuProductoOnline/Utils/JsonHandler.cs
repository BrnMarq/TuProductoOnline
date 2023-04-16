using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using TuProductoOnline.Models;

namespace TuProductoOnline.Utils
{
    public static class JsonHandler
    {
        public static List<Bill> openJsonFile()
        {
            string fileContent = string.Empty;
            List<Bill> returnBooks = null;

            using (OpenFileDialog openJson = new OpenFileDialog())
            {
                openJson.InitialDirectory = @"c:\";
                openJson.Filter = "JSON files  (*.json)|*.json";
                openJson.RestoreDirectory = true;

                if (openJson.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openJson.FileName;
                    var fileStream = openJson.OpenFile();
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }

            try
            {
                returnBooks = JsonSerializer.Deserialize<List<Bill>>(fileContent);
            }
            catch (JsonException e)
            {
                returnBooks = null; 
            }

            return returnBooks;
        }

        public static void saveJsonFile(List<Bill> stockBooks)
        {
            string jsonString = JsonSerializer.Serialize(stockBooks);
            SaveFileDialog saveJson = new SaveFileDialog();

            saveJson.InitialDirectory = @"c:\";
            saveJson.Filter = "JSON files  (*.json)|*.json";
            saveJson.RestoreDirectory = true;

            if (saveJson.ShowDialog() == DialogResult.OK)
            {
                using (Stream streamJson = File.Open(saveJson.FileName, FileMode.CreateNew))
                {
                    using (StreamWriter writeJson = new StreamWriter(streamJson))
                    {
                        writeJson.Write(jsonString);
                    }
                }
            }
        }
    }
}
