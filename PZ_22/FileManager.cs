using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace PZ_22
{
    public static class FileManager
    {
        private static string dataFolderPath = "data";

        public static void CreateFile(string fileName)
        {
            string filePath = Path.Combine(dataFolderPath, fileName);
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
        }

        public static void SaveFile(string fileName, string content)
        {
            string filePath = Path.Combine(dataFolderPath, fileName);
            File.WriteAllText(filePath, content);
        }

        public static string OpenFile(string fileName)
        {
            string filePath = Path.Combine(dataFolderPath, fileName);
            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath);
            }
            else
            {
                return null;
            }
        }

        public static void DeleteFile(string fileName)
        {
            string filePath = Path.Combine(dataFolderPath, fileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
