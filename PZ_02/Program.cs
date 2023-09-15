int y; double x; //Создание переменных

double s; double t; //Создание переменных

Console.Write("Введите значение y:");
y = int.Parse(Console.ReadLine()); //Ввод переменных пользователем

Console.Write("Введите значение x:");
x = double.Parse(Console.ReadLine()); //Ввод переменных пользователем

if (y < 2) //Если y < 2
{
    s = (y - y * Math.Pow(x, 2)) / (x + 1); //Выполняется это условие
}
else // Иначе
{
    s = -10.6 * x * y; //Выполняется это условие
}

if (s <= 0) //Если y < 2
{
    t = y * s + Math.Sin(x) + y; //Выполняется это условие
}
else // Иначе
{
    t = s - Math.Pow(Math.Cos(s / x), 2); //Выполняется это условие
}

int v = (int)(2 * y * x + 3 * y * s - s * t); //Финальное действие
Console.WriteLine("Результат: " + v); //Вывод результата