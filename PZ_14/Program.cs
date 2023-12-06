namespace PZ_14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path_s = "start.txt"; //путь стартового файла
            string path_e = "end.txt"; //путь конечного файла

            using (FileStream file1 = new FileStream(path_s, FileMode.Open, FileAccess.Read)) //поток первого файла
            {
                using (StreamReader reader = new StreamReader(file1)) //поток чтения первого файла
                {
                    using (FileStream file2 = new FileStream(path_e, FileMode.OpenOrCreate, FileAccess.Write)) //поток второго файла
                    {
                        using (StreamWriter writer = new StreamWriter(file2)) //поток записи второго файла
                        {
                            string[] text = reader.ReadToEnd().Split("\n"); //пустой массив текста

                            Console.WriteLine("Текст из файла start.txt");
                            for (int i = 0; i < text.Length; i++)
                            {
                                Console.WriteLine(text[i]); //вывод текста из первого файла
                            }
                            for (int i = 0; i < 30; i++)
                            {
                                Console.Write("-");
                            }
                            Console.WriteLine();

                            Console.WriteLine("Текст без пустых строк");
                            Console.WriteLine(" ");
                            for (int i = 0; i < text.Length; i++)
                            {
                                if (!string.IsNullOrWhiteSpace(text[i])) //если строчка не ноль или пробел - записывается во второй файл
                                {
                                    Console.WriteLine(text[i]); //вывод текста без пустых строк
                                    writer.WriteLine(text[i]); //запись текста без пустых строк
                                }
                            }
                            Console.WriteLine(" ");
                        }
                    }
                }
            }
            Console.WriteLine("Данные записаны в файл end.txt");
        }
    }
}