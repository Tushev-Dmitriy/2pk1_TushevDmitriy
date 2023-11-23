using static System.Net.Mime.MediaTypeNames;

namespace PZ_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Дан произвольный текст, содержащий в себе числа. Вывести числа (не цифры) в
            консоль.
            Пример:
            “данный текст является примером содержания чисел:200 2000 305, 77”
            Вывод: 200 2000 305 77*/

            Console.WriteLine("Введите строку:");
            string str = Console.ReadLine();
            string str2 = "";

            foreach (char number in str) //Проход по символам в строке
            {
                if (Char.IsDigit(number)) //Проверка на цифру данного символа
                {
                    str2 += number; //Если цифра - добавляем к строке
                }
                else
                {
                    if (str2.Length > 0) //Если не цифра - проверяем есть ли числа в строке
                    {
                        Console.Write($"{str2} "); //Если строка не пустая - выводим
                        str2 = ""; //Снова делаем строку пустой
                    }
                }
            }
            if (str2.Length > 0) //Проверка числа в конце текста
            {
                Console.Write($"{str2} ");
            } 
        }
    }
}