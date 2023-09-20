//Задание один
int number = -50;

for (int i = 0; i<11; i++)
{
    Console.Write(number + " ");
    number = number + 5;
}

Console.WriteLine("\n-----------");
//Задание два
char letter = 'л';
for (int x = 0; x<8; x++)
{
    Console.Write(letter++ + " ");
}

Console.WriteLine("\n-----------");
//Задание три
for (int m = 0; m < 10; m++)
{
    for (int n = 0; n < 4; n++)
    {
        Console.Write("#");
    }
    Console.WriteLine();
}

Console.WriteLine("-----------");
//Задание четыре
int num = 14;
int q = 0;
for (int z = 0; z<1000;)
{
    if (z % 14 == 0 && z != 0)
    {
        Console.Write(z + " ");
        q++;
    } else
    {
        
    }
    z++;
}
Console.WriteLine($"\nУ числа {num} есть {q} кратное число");

Console.WriteLine("-----------");
//Задание пять
for (int i1 = 0, j = 45; j - i1 != 17; i1++, j--)
{
    Console.WriteLine(i1 + " и " + j);
}