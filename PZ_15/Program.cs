namespace PZ_15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь до папки");
            string path = Console.ReadLine(); //Сохранение пути до папки
            //string path = "files"; Проверка работоспосбоности программы через папку files в директории проекта
            //string path = "files1"; Проверка работы приложения с пустой папкой
            //string path = "files2"; Проверка работы приложения с несуществующей папкой

            if (Directory.Exists(path)) //Проверка существования папки
            {
                Console.WriteLine("Файлы");
                string[] files = Directory.GetFiles(path); //Массив строк из файлов папки
                if (files.Length == 0) //Если длинна массива 0 - файлов нет
                {
                    Console.WriteLine("Файлов нет");
                }
                else //иначе
                {
                    foreach (string file in files) //вывод всех путей из массива
                    {
                        Console.WriteLine(file);
                    }
                    Console.WriteLine(" ");
                    for (int i = 0; i < files.Length; i++) //цикл for для перебора массива
                    {
                        if (files[i].EndsWith(".txt")) //проверка каждого файла на .txt в конце
                        {
                            File.Delete(files[i]); //удаление, если это текстовый документ
                        }
                    }
                    Console.WriteLine("Папка после удаления файлов .txt");
                    string[] newfiles = Directory.GetFiles(path); //массив строк из оставшихся файлов папки
                    foreach (string file in newfiles) //вывод всех путей из массива
                    {
                        Console.WriteLine(file);
                    }
                }
            }
            else //Иначе вывод, что папки нет
            {
                Console.WriteLine("Данной папки не существует");
            }
        }
    }
}