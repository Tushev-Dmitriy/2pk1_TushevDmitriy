namespace PZ_09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Вводится строка. Определить, присутствует ли в ней комментарий и вывести текст без него.
            Комментарием считать:
            • Однострочный – начиная с // и до конца строки
            • Многострочный – начиная с /* и заканчивая . После него может следовать полезный
            текст, который так же нужно вывести*/

            Console.WriteLine("Введите строку:");
            string stroka = Console.ReadLine();

            //Поиск однострочного комментария
            int s_comment = stroka.IndexOf("//");
            if (s_comment != -1) //если комментарий находится
            {
                stroka = stroka.Substring(0, s_comment); //Перезаписвыем строку без комментария
            }

            // Удаление многострочных комментариев
            int m_comment = stroka.IndexOf("/*"); //индекс первого вхождения
            int m_comment1 = stroka.IndexOf("*/"); //индекс второго вхождения

            while (m_comment != -1 && m_comment1 != -1) //пока находится многострочный комментарий
            {
                stroka = stroka.Remove(m_comment, m_comment1 - m_comment + 2); //удаление из строки комментария по индексам
                m_comment = stroka.IndexOf("/*");
                m_comment1 = stroka.IndexOf("*/");
            }

            Console.WriteLine("Результат:");
            Console.WriteLine(stroka); //вывод строки без комментария
        }
    }
}