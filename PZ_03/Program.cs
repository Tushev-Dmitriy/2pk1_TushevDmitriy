int slots = 10; //Создание переменной с количеством слотов регистрации
bool[] availability = new bool[slots]; //Создание массива доступности
string[] names = new string[slots]; //Создание массива имен
string[] numbers = new string[slots]; //Создание массива номеров

for (int check = 0; check < slots;) //Проверка доступности слотов
{
    Console.WriteLine("Выберите время записи:"); //Регистрация
    for (int i = 0; i < slots;) //Цикл с выводом всех времён
        {
        int slotNumber = i + 1;
        int s_time = 8 + i;
        int e_time = s_time + 1;

        if (!availability[i]) //Проверка доступности
        {
            Console.WriteLine($"{slotNumber}) {s_time}.00 - {e_time}.00 Свободно");
            }
        else
            {
            Console.WriteLine($"{slotNumber}) {s_time}.00 - {e_time}.00 Занято ({names[i]}, {numbers[i]})");
            }
        i++;
        }

    int choice = int.Parse(Console.ReadLine()); //Создание переменной выбора пользователя
    int index; //Создание переменной индекса слота в массиве

    switch (choice) //Выбор времени из расписания
    {
        case 1:
            index = choice - 1; //Высчитывание индекса в массиве
            if (!availability[index])
            {
                Console.WriteLine("Введите свое имя:"); //Ввод имени
                names[index] = Console.ReadLine();
                Console.WriteLine("Введите свой номер телефона:"); //Ввод времени
                numbers[index] = Console.ReadLine();
                availability[index] = true; //Доступность слота во времени
            }
            else
            {
                Console.WriteLine("Этот слот уже занят. Пожалуйста, выберите другой. (нажмите enter)"); //Если слот недоступен
                Console.ReadLine();
            }
            break;

        case 2: //Аналогичное повторение действий для других значений
            index = choice - 1;
            if (!availability[index])
            {
                Console.WriteLine("Введите свое имя:");
                names[index] = Console.ReadLine();
                Console.WriteLine("Введите свой номер телефона:");
                numbers[index] = Console.ReadLine();
                availability[index] = true;
            }
            else
            {
                Console.WriteLine("Этот слот уже занят. Пожалуйста, выберите другой. (нажмите enter)");
                Console.ReadLine();
            }
            break;

        case 3: //Аналогичное повторение действий для других значений
            index = choice - 1;
            if (!availability[index])
            {
                Console.WriteLine("Введите свое имя:");
                names[index] = Console.ReadLine();
                Console.WriteLine("Введите свой номер телефона:");
                numbers[index] = Console.ReadLine();
                availability[index] = true;
            }
            else
            {
                Console.WriteLine("Этот слот уже занят. Пожалуйста, выберите другой. (нажмите enter)");
                Console.ReadLine();
            }
            break;

        case 4: //Аналогичное повторение действий для других значений
            index = choice - 1;
            if (!availability[index])
            {
                Console.WriteLine("Введите свое имя:");
                names[index] = Console.ReadLine();
                Console.WriteLine("Введите свой номер телефона:");
                numbers[index] = Console.ReadLine();
                availability[index] = true;
            }
            else
            {
                Console.WriteLine("Этот слот уже занят. Пожалуйста, выберите другой. (нажмите enter)");
                Console.ReadLine();
            }
            break;

        case 5: //Аналогичное повторение действий для других значений
            index = choice - 1;
            if (!availability[index])
            {
                Console.WriteLine("Введите свое имя:");
                names[index] = Console.ReadLine();
                Console.WriteLine("Введите свой номер телефона:");
                numbers[index] = Console.ReadLine();
                availability[index] = true;
            }
            else
            {
                Console.WriteLine("Этот слот уже занят. Пожалуйста, выберите другой. (нажмите enter)");
                Console.ReadLine();
            }
            break;

        case 6: //Аналогичное повторение действий для других значений
            index = choice - 1;
            if (!availability[index])
            {
                Console.WriteLine("Введите свое имя:");
                names[index] = Console.ReadLine();
                Console.WriteLine("Введите свой номер телефона:");
                numbers[index] = Console.ReadLine();
                availability[index] = true;
            }
            else
            {
                Console.WriteLine("Этот слот уже занят. Пожалуйста, выберите другой. (нажмите enter)");
                Console.ReadLine();
            }
            break;

        case 7: //Аналогичное повторение действий для других значений
            index = choice - 1;
            if (!availability[index])
            {
                Console.WriteLine("Введите свое имя:");
                names[index] = Console.ReadLine();
                Console.WriteLine("Введите свой номер телефона:");
                numbers[index] = Console.ReadLine();
                availability[index] = true;
            }
            else
            {
                Console.WriteLine("Этот слот уже занят. Пожалуйста, выберите другой. (нажмите enter)");
                Console.ReadLine();
            }
            break;

        case 8: //Аналогичное повторение действий для других значений
            index = choice - 1;
            if (!availability[index])
            {
                Console.WriteLine("Введите свое имя:");
                names[index] = Console.ReadLine();
                Console.WriteLine("Введите свой номер телефона:");
                numbers[index] = Console.ReadLine();
                availability[index] = true;
            }
            else
            {
                Console.WriteLine("Этот слот уже занят. Пожалуйста, выберите другой. (нажмите enter)");
                Console.ReadLine();
            }
            break;

        case 9: //Аналогичное повторение действий для других значений
            index = choice - 1;
            if (!availability[index])
            {
                Console.WriteLine("Введите свое имя:");
                names[index] = Console.ReadLine();
                Console.WriteLine("Введите свой номер телефона:");
                numbers[index] = Console.ReadLine();
                availability[index] = true;
            }
            else
            {
                Console.WriteLine("Этот слот уже занят. Пожалуйста, выберите другой. (нажмите enter)");
                Console.ReadLine();
            }
            break;

        case 10: //Аналогичное повторение действий для других значений
            index = choice - 1;
            if (!availability[index])
            {
                Console.WriteLine("Введите свое имя:");
                names[index] = Console.ReadLine();
                Console.WriteLine("Введите свой номер телефона:");
                numbers[index] = Console.ReadLine();
                availability[index] = true;
            }
            else
            {
                Console.WriteLine("Этот слот уже занят. Пожалуйста, выберите другой. (нажмите enter)");
                Console.ReadLine();
            }
            break;

        default: //Если case не сработал
            Console.WriteLine("Вы выбрали неправильное время. Повторите ещё раз. (нажмите enter)");
            Console.ReadLine();
            break;
    }

    check++; //Увеличение переменной check
    Console.Clear(); //Очищение консоли для удобства
}