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
        //Funcion para Escribir un archivo CSV a traves de un directorio
        public static void EscribirCSV(String fileName, List<String> values)
        {
            String route = @"" + fileName;
            String separator = ",";
            StringBuilder salida = new StringBuilder();

            salida.AppendLine(string.Join(separator, values));

            File.AppendAllText(route, salida.ToString());
        }

        public static string LeerCSV(String fileName)
        {
            var reader = new StreamReader(File.OpenRead(@"" + fileName));
            List<String> lista = new List<string>();
            var linea = reader.ReadLine();
            return linea;
        }
    }
}
