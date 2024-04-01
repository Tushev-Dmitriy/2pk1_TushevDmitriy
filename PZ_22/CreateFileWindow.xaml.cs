using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PZ_22
{
    public partial class CreateFileWindow : Window
    {
        private string dataFolderPath = "data";
        public string FileName
        {
            get => fileNameTextBox.Text;
        }
        public CreateFileWindow(Window owner)
        {
            this.Owner = owner;
            InitializeComponent();
        }
        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(FileName))
            {
                string filePath = System.IO.Path.Combine(dataFolderPath, FileName);

                if (File.Exists(filePath))
                {
                    MessageBox.Show("Файл уже существует");
                }
                else
                {
                    FileManager.CreateFile(FileName);
                    this.DialogResult = true;
                }
            }
            else
            {
                MessageBox.Show("Введите имя файла");
            }
        }
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
