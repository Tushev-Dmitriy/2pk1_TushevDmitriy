﻿//Задание один
int number = -50;

for (int i = 0; i<11; i++) //Цикл с 11 шагами, чтобы захватывалось начало и конец диапозона
{
    Console.Write(number + " ");
    number = number + 5; //Увеличение начального числа на 5
}

Console.WriteLine("\n-----------"); //Разделение заданий
//Задание два
char letter = 'л';
for (int x = 0; x<8; x++) //Цикл с 8 шагами, чтобы вывелась изначальная буква и 7 следующих
{
    Console.Write(letter++ + " ");
}

Console.WriteLine("\n-----------"); //Разделение заданий
//Задание три
for (int m = 0; m < 10; m++) //Цикл с 10 шагами, т. к. по условию необходимо 10 строк
{
    for (int n = 0; n < 4; n++) //Цикл с 4 шагами, т. к. по условию необходимо 4 символа в строке
    {
        Console.Write("#");
    }
    Console.WriteLine();
}

Console.WriteLine("-----------"); //Разделение заданий
//Задание четыре
int num = 14;
int q = 0;
for (int z = 0; z<1000;) //Цикл с перебором всех значений диапозона
{
    if (z % 14 == 0 && z != 0) //Условие для счетчика кратных чисел, также ограничение числа 0
    {
        Console.Write(z + " ");
        q++; //Увеличение данных в переменной
    } else
    {
        q = q + 0;
    }
    z++;
}
Console.WriteLine($"\nУ числа {num} есть {q} кратное число");

Console.WriteLine("-----------"); //Разделение заданий
//Задание пять
for (int i1 = 0, j = 45; j - i1 != 17; i1++, j--) //Цикл с изначальными данными и условием его окончания (разница = 17)
{
    Console.WriteLine(i1 + " и " + j); //Вывод всех значений при переборе
}