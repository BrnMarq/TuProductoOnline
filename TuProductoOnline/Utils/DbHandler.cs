using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuProductoOnline.Consts;

namespace TuProductoOnline.Utils
{
    public class DbHandler
    {
        private static string separator = ";";

        public static char GetCharSeparator()
        {
            return separator.ToCharArray()[0];
        }
        //Funcion para Escribir un archivo CSV a traves de un directorio
        public static void EscribirCSV(String fileName, List<String> values)
        {
            String route = @"" + fileName;
            StringBuilder salida = new StringBuilder();

            salida.AppendLine(string.Join(separator, values));

            File.AppendAllText(route, salida.ToString());
        }

        public static void EditCSV(String fileName, string id, List<String> values)
        {
            String route = @"" + fileName;
            StringBuilder salida = new StringBuilder();
            List<String> lines = new List<String>();

            using (StreamReader reader = new StreamReader(route))
            {
                String line;

                while ((line = reader.ReadLine()) != null)
                {
                    String[] split = line.Split(GetCharSeparator());
                    if (split[0].Contains(id))
                        line = String.Join(separator, values);

                    lines.Add(line);
                }
            }

            using (StreamWriter writer = new StreamWriter(route, false))
            {
                foreach (String line in lines)
                    writer.WriteLine(line);
            }
        }

        public static List<List<string>> LeerCSV(String fileName)
        {

            bool fileExists = File.Exists(@"" + fileName);
            if (!fileExists) EscribirCSV(fileName, new List<string>());

            var reader = new StreamReader(File.OpenRead(@"" + fileName));
            List<List<String>> list = new List<List<string>>();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var lineValues = line.Split(GetCharSeparator());
                List<string> values = lineValues.ToList();
                list.Add(values);
            }

            reader.Close();
            return list;
        }
        public static int GetNewId(string fileName)
        {
            if (!File.Exists(@"" + fileName))
            {
                List<string> value = new List<string> { "1" };
                DbHandler.EscribirCSV(fileName, value);
                return 1;
            }

            int prevId = int.Parse(DbHandler.LeerCSV(fileName)[0][0]);
            int newId = prevId + 1;
            List<string> values = new List<string> { newId.ToString() };
            DbHandler.EditCSV(fileName, prevId.ToString(), values);
            return newId;
        }
    }
}
