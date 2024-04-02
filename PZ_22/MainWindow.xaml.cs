using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.WebRequestMethods;

namespace PZ_22
{
    public partial class MainWindow : Window
    {
        private string filename = "";
        private string dataFolderPath = "data";
        private string pastFileName = "";
        private bool isFileSaved = true;
        public MainWindow()
        {
            InitializeComponent();
            if (!Directory.Exists(dataFolderPath))
            {
                Directory.CreateDirectory(dataFolderPath);
            }
            RefreshFilesList();
            UpdateStatusBar();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;
            MessageBox.Show(menuItem.Header.ToString());
        }

        private void CreateFileMenuItem_Click(object sender, RoutedEventArgs e)
        {
            CreateFileWindow fileCreate = new CreateFileWindow(this);

            if (fileCreate.ShowDialog() == true)
            {
                filename = fileCreate.FileName;
            }
            if (filename != "")
            {
                FileManager.CreateFile(filename);
                notesList.Items.Add(filename);
                RefreshFilesList();
            }
            filename = "";
        }

        private void filesListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string fileName = (string)notesList.SelectedItem;

            if (fileName != null)
            {
                if (!string.IsNullOrEmpty(pastFileName))
                {
                    string currentContent = new TextRange(primeBox.Document.ContentStart, primeBox.Document.ContentEnd).Text;
                    FileManager.SaveFile(pastFileName, currentContent);
                }

                primeBox.Document = new FlowDocument();

                string fileContent = FileManager.OpenFile(fileName);
                if (fileContent != null)
                {
                    new TextRange(primeBox.Document.ContentStart, primeBox.Document.ContentEnd).Text = fileContent;
                    pastFileName = fileName;
                }

                isFileSaved = true;
                UpdateStatusBar();
            }
        }

        private void DeleteFileMenuItem_Click(object sender, EventArgs e)
        {
            string fileName = (string)notesList.SelectedItem;
            FileManager.DeleteFile(fileName);
            RefreshFilesList();
            primeBox.Document = new FlowDocument();
        }

        private void RefreshFilesList()
        {
            notesList.Items.Clear();
            string[] files = Directory.GetFiles(dataFolderPath);
            foreach (string file in files)
            {
                string fileName = System.IO.Path.GetFileName(file);
                notesList.Items.Add(fileName);
            }
        }

        private void DeleteAllFileMenuItem_Click(object sender, RoutedEventArgs e)
        {
            string[] files = Directory.GetFiles(dataFolderPath);
            foreach (string file in files)
            {
                string fileName = System.IO.Path.GetFileName(file);
                FileManager.DeleteFile(fileName);
            }
            primeBox.Document = new FlowDocument();
            notesList.Items.Clear();
            pastFileName = "";
        }

        private void UpdateStatusBar()
        {
            if (isFileSaved)
            {
                FileSaveOrNo.Text = "Save";
            }
            else
            {
                FileSaveOrNo.Text = "Require save";
            }

            string fileName = (string)notesList.SelectedItem;
            if (!string.IsNullOrEmpty(fileName))
            {
                string filePath = System.IO.Path.Combine(dataFolderPath, fileName);
                if (System.IO.File.Exists(filePath))
                {
                    DateTime creationTime = System.IO.File.GetCreationTime(filePath);
                    DateTime lastWriteTime = System.IO.File.GetLastWriteTime(filePath);
                    FileDateTimeTextBlock.Text = lastWriteTime.ToString();

                    long fileSizeInBytes = new FileInfo(filePath).Length;
                    FileSizeTextBlock.Text = $"Size: {fileSizeInBytes} bytes";
                }
            }
        }

        private void TextChangeInTextBox(object sender, TextChangedEventArgs e)
        {
            isFileSaved = false;
            UpdateStatusBar();
            UpdateCursorPosition();
        }

        private void UpdateCursorPosition()
        {
            TextPointer caretPosition = primeBox.CaretPosition;

            if (caretPosition != null)
            {
                TextPointer lineStartPosition = caretPosition.GetLineStartPosition(0);
                int line = 1;
                int column = lineStartPosition.GetOffsetToPosition(caretPosition);

                while (lineStartPosition != null)
                {
                    if (lineStartPosition.GetOffsetToPosition(caretPosition) >= 0)
                    {
                        break;
                    }
                }

                TextPointer navigator = caretPosition.GetLineStartPosition(-1);
                while (navigator != null)
                {
                    line++;
                    navigator = navigator.GetLineStartPosition(-1);
                }

                CursorPositionTextBlock.Text = $"Line: {line}, Column: {column}";
            }
        }

        private void CursorPositionUpdate(object sender, KeyEventArgs e)
        {
            UpdateCursorPosition();
        }

        private void CursorPositionUpdate(object sender, RoutedEventArgs e)
        {
            UpdateCursorPosition();
        }
    }
}