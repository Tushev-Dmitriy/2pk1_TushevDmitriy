int check = 1;
bool availabilaty = true;
while (check <= 10)
{
    Console.WriteLine("Выберите время записи:");

    bool availabilaty1 = true;
    int i = 8;
    int z = 1;
    while (i < 18)
    {
        Console.WriteLine($"{z}) {i}.00 - {i + 1}.00" + $" Свободно: {availabilaty}");
        Console.WriteLine($"{z}) {i}.00 - {i + 1}.00" + $" Свободно: {availabilaty1}");
        i++; z++;
    }
    int time = int.Parse(Console.ReadLine());
    string name = "test";
    string number = "123";
    if (time <= 10)
    {
        switch (time)
        {
            case 1:
                Console.WriteLine("Введите свое имя:");
                name = Console.ReadLine();
                Console.WriteLine("Введите свой номер телефона:");
                number = Console.ReadLine();
                availabilaty1 = false;
                break;
            case 2:
                Console.WriteLine("Введите свое имя:");
                name = Console.ReadLine();
                Console.WriteLine("Введите свой номер телефона:");
                number = Console.ReadLine();
                bool availabilaty2 = false;
                break;
            case 3:
                Console.WriteLine("Введите свое имя:");
                name = Console.ReadLine();
                Console.WriteLine("Введите свой номер телефона:");
                number = Console.ReadLine();
                bool availabilaty3 = false;
                break;
            case 4:
                Console.WriteLine("Введите свое имя:");
                name = Console.ReadLine();
                Console.WriteLine("Введите свой номер телефона:");
                number = Console.ReadLine();
                bool availabilaty4 = false;
                break;
            case 5:
                Console.WriteLine("Введите свое имя:");
                name = Console.ReadLine();
                Console.WriteLine("Введите свой номер телефона:");
                number = Console.ReadLine();
                bool availabilaty5 = false;
                break;
            case 6:
                Console.WriteLine("Введите свое имя:");
                name = Console.ReadLine();
                Console.WriteLine("Введите свой номер телефона:");
                number = Console.ReadLine();
                bool availabilaty6 = false;
                break;
            case 7:
                Console.WriteLine("Введите свое имя:");
                name = Console.ReadLine();
                Console.WriteLine("Введите свой номер телефона:");
                number = Console.ReadLine();
                bool availabilaty7 = false;
                break;
            case 8:
                Console.WriteLine("Введите свое имя:");
                name = Console.ReadLine();
                Console.WriteLine("Введите свой номер телефона:");
                number = Console.ReadLine();
                bool availabilaty8 = false;
                break;
            case 9:
                Console.WriteLine("Введите свое имя:");
                name = Console.ReadLine();
                Console.WriteLine("Введите свой номер телефона:");
                number = Console.ReadLine();
                bool availabilaty9 = false;
                break;
            case 10:
                Console.WriteLine("Введите свое имя:");
                name = Console.ReadLine();
                Console.WriteLine("Введите свой номер телефона:");
                number = Console.ReadLine();
                bool availabilaty10 = false;
                break;
        }
    }
    else
    {
        Console.WriteLine("Вы выбрали неправильное время. Повторите ещё раз");
    }
    check++;
    Console.Clear();
}