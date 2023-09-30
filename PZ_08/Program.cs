int firstLength = 10; //Создание переменной первого измерения
int[][] array = new int[firstLength][]; //Создание ступенчатого массива


Random random = new Random();
for (int i = 0; i < firstLength; i++) 
{
    int secondLength = random.Next(5, 11); //Создание переменной вторго измерения
    array[i] = new int[secondLength];
    for (int j = 0; j < secondLength; j++)
    {
        array[i][j] = random.Next(1, 101); //Заполнение массива числами от 1 до 100
    }
}

Console.WriteLine("Зубчатый массив");
foreach (int[] row in array)
{
    Console.WriteLine(string.Join(" ", row));
}

Console.WriteLine("\nОдномерный массив");

int[] array1 = new int[firstLength]; //Создание одномерного массива

for (int i = 0; i < firstLength; i++) //Заполнение одномерного массива последниими элементами каждой строки
{
    int lastIndex = array[i].Length - 1;
    array1[i] = array[i][lastIndex];
}

Console.WriteLine(string.Join(" ", array1)); //Вывод массива

Console.WriteLine("\nОдномерный массив максимальных значений");

int[] arrayMax = new int[firstLength]; //Создание одномерного массива с максимальными значениями
for (int i = 0; i < firstLength; i++) //Заполнение массива максимальным значниями из ступенчатого массива
{
    arrayMax[i] = array[i].Max();
}

Console.WriteLine(string.Join(" ", arrayMax)); //Вывод массива 


for (int i = 0; i < firstLength; i++) //Изменение первого и последнего значения массива
{
    int maxIndex = Array.IndexOf(array[i], arrayMax[i]); //Поиск максимального значения в массиве одномерных чисел
    int t = array[i][0]; //Переменная t, которая сохраняет в себе первый элемент
    array[i][0] = array[i][maxIndex]; //Замена первого элемента на максимальный
    array[i][maxIndex] = t; //Замена максимального элемента на первый
}

Console.WriteLine("\nЗубчатый массив с изменением первого и максимального элемента");
foreach (int[] row in array)
{
    Console.WriteLine(string.Join(" ", row)); //Вывод обновленного массива
}

for (int i = 0; i < firstLength; i++)//Реверс строк массива
{
    Array.Reverse(array[i]);
}

Console.WriteLine("\nЗубчатый массив с реверсом элементов");
foreach (int[] row in array)
{
    Console.WriteLine(string.Join(" ", row)); //Вывод обновленного массива
}

Console.WriteLine();

int z = 1;
while (z < array.Length)
{
    foreach (int[] row in array) //Нахождение среднего значения каждой строки зубчатого массива
    {
        double avg = Math.Round(row.Average(), 2);
        Console.WriteLine($"Среднее значение строки {z}: {avg}");
        z++;
    }
}