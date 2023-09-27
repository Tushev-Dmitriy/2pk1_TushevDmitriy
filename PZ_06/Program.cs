int n = 20;
int[] array = new int[n]; // Создание массива
Random rnd = new Random();

for (int i = 0; i < array.Length; i++) //Заполнение массива случайными числами от -15 до 14
{
    array[i] = rnd.Next(-15, 15);
}

int max = array[0]; 
foreach (int num in array) //Поиск максимального значения
{
    if (num > max)
    {
        max = num;
    }
}

int count = 0;
foreach (int num in array)
{
    if (Math.Abs(num) > Math.Abs(max)) //Поиск элементов, которые больше по модулю, чем максимальное число
    {
        count++;
    }
}

Console.WriteLine("Массив:"); //Вывод массива
for (int i = 0; i <= n-1; i++)
{
    Console.Write($"{array[i]} ");
}
Console.WriteLine();

Console.WriteLine($"Максимальный элемент: {max}"); //Вывод максимального числа
Console.WriteLine($"Количество элементов по модулю больших, чем максимальный: {count}"); //Вывод чисел, которые по модулю больше, чем максимальное