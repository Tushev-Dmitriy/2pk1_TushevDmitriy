namespace PZ_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Алгебраическая прогрессия: a=1, d=2
             * Геометрическая прогрессия: b=6, q=-5
             * Числа из третьей задачи: a=64, b=54
             * Четвертая задача: рекурсия возведения в степень
             */

            int n, x; //переменные для двух первых задач
            Console.WriteLine("Первая задача");
            Console.Write("Введите число n: ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"{n}-й член прогрессии равен " + Progress(n)); //вызов первого метода
            Console.WriteLine(" ");
            Console.WriteLine("Вторая задача");
            Console.Write("Введите число x: ");
            x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"{x}-й член прогрессии равен " + Progress1(x)); //вызов вторго метода
            Console.WriteLine(" ");
            int y = 64; //переменная для третьей задачи
            int z = 54; //переменная для третьей задачи
            Console.WriteLine("Третья задача");
            Console.WriteLine("Первое число равно " + y);
            Console.WriteLine("Второе число равно " + z);
            Compare(y, z); //вызов третьего метода
            int a, b; //переменные для четвертой задачи
            Console.WriteLine(" ");
            Console.WriteLine("Четвертая задача");
            Console.Write("Введите число a: ");
            a = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите число b: ");
            b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(Power(a, b)); //вызов четвертого метода

        }
        static int Progress(int n) //алгебраическая прогрессия
        {
            int ans = 0; //переменная ответа
            if (n == 1) //если 1 - вывод а
            {
                return 1;
            }
            else //иначе
            {
                ans = Progress(n - 1); //рекурсия прогрессии
                ans = ans + 2; //член прогрессии + d=2
            }
            return ans;
        }
        static int Progress1(int x) //геометрическая прогрессия
        {
            int ans = 0; //переменная ответа
            if (x == 1) //если 1 - вывод b=6
            {
                return 6;
            }
            else //иначе
            {
                ans = Progress1(x - 1); //рекурсия прогрессии
                ans = ans * -5; //член прогресси * q=-5
            }
            return ans;
        }

        static int Compare(int y, int z) //сравнение чисел
        {
            if (y + 1 == z) //если перменные равны
            {
                return z; //возвращает b=54
            }
            else
            {
                Console.WriteLine(y); //вывод чисел в порядке убывания
                y = Compare(y - 1, z); //рекурсия вычитания из большего числа
                y = y - 1;
            }
            return y;
        }
        static int Power(int a, int b) //рекурсивное возведение в степень
        {
            if (b == 0) //если степень равна 0 - ответ 1
            {
                return 1;
            }
            else //иначе
            {
                return a * Power(a, b - 1); //рекурсия а * Power(a, b-1)
            }
        }
    }
}