using System;
using System.IO;
using System.Configuration;
using System.Windows.Forms;

namespace Utilities
{
    public class fileIO
    {
        public void createFolder()
        {
            // Creación de la carpeta Raiz
            string folderName = ConfigurationManager.AppSettings["folderPath"].ToString();

            // Se crea una subcarpeta con la fecha del día
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string pathString = System.IO.Path.Combine(folderName, date);
            
            // Se crea el nuevo directorio especificado
            System.IO.Directory.CreateDirectory(pathString);

            // Se crea un nombre de archivo para escribir el log y se agrega el nombre a la ruta
            string fileName = DateTime.Now.ToString("MM-dd-yy_Hmm") + ".txt";
            pathString = System.IO.Path.Combine(pathString, fileName);

            if (!System.IO.File.Exists(pathString))
            {
                //System.IO.FileStream fs = System.IO.File.Create(pathString);
                System.IO.StreamWriter file = new System.IO.StreamWriter(pathString);
                file.Close();
                writeFileHeader(pathString);

                // Guardando la ruta del archivo
                ConfigurationManager.AppSettings.Set("filePath", pathString);

            }
            else
            {
                Console.WriteLine("File \"{0}\" already exists.", fileName);
                return;
            }
        }

        private void writeFileHeader(string path)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("===============================================================================================");
                sw.WriteLine("                      Fecha de ejecución de la app: " + DateTime.Now);
                sw.WriteLine("===============================================================================================");
            }
        }
    }
}
