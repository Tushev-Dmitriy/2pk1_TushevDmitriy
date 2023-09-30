Random rnd = new Random();

double[,] array = new double[5, 5]; //Создание массива

double min = double.MaxValue;

for (int i = 0; i < 5; i++) //Заполнение массива
{
    for (int j = 0; j < 5; j++)
    {
        array[i, j] = rnd.Next(-5, 5);
        if (array[i, j] < min) min = array[i, j];
        Console.Write(array[i, j] + "\t");
    }
    Console.WriteLine();
}

double sum = 0; //Нахождение суммы положительных элементов матрицы
foreach (double element in array)
{
    if (element > 0)
    {
        sum += element;
    }
}

double result = min * sum; //Вычислениие произведения минимального элемента на сумму положительных элементов

Console.WriteLine("Произведение минимального элемента матрицы на сумму положительных элементов: " + result);