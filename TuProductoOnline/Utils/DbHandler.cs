using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuProductoOnline.Utils
{
    public class DbHandler
    {
        private static string separator = ";";
        //Funcion para Escribir un archivo CSV a traves de un directorio
        public static void EscribirCSV(String fileName, List<String> values)
        {
            String route = @"" + fileName;
            StringBuilder salida = new StringBuilder();

            salida.AppendLine(string.Join(separator, values));

            File.AppendAllText(route, salida.ToString());
        }

        public static List<List<string>> LeerCSV(String fileName)
        {
            var reader = new StreamReader(File.OpenRead(@"" + fileName));
            List<List<String>> list = new List<List<string>>();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var lineValues = line.Split(separator.ToCharArray()[0]);
                List<string> values = lineValues.ToList();
                list.Add(values);
            }

            reader.Close();
            return list;
        }
    }
}
