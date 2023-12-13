namespace PZ_16
{
    internal class Program
    {
        static int mapSize = 25;
        static char[,] map = new char[mapSize, mapSize];

        static int playerY = mapSize / 2;
        static int playerX = mapSize / 2;

        static int centerX = (Console.WindowWidth / 2) - 15;
        static int centerY = Console.WindowHeight / 2;

        static byte enemies = 1;
        static byte buffs = 5;
        static int health = 5;

        static int playerHP = 50;
        static int playerStrong = 10;
        static int playerStepCount = 0;

        static bool hasBuff = false;
        static int buffStep = 0;
        static int savedBuffStep = 0;
        static bool savedHasBuff = false;

        static string lastAction = "Начало игры";

        static int bossHP = 100;
        static int bossStrong = 39;
        static bool bossSpawned = false;

        static int enemyHP = 30;
        static int enemyStrong = 5;
        static void Main(string[] args)
        {
            Console.Title = "Game";
            StartGame();
        }

        static void GenerationMap()
        {
            Random random = new Random();
            //создание пустой карты
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (j == mapSize - 1)
                    {
                        Console.SetCursorPosition(i, j);
                        map[i, j] = '_';
                    }
                    else
                    {
                        map[i, j] = '_';
                    }
                }
            }

            map[playerY, playerX] = 'P';

            int x;
            int y;

            while (enemies > 0)
            {
                x = random.Next(0, mapSize);
                y = random.Next(0, mapSize);


                if (map[x, y] == '_')
                {
                    map[x, y] = 'E';
                    enemies--;
                }
            }
            while (buffs > 0)
            {
                x = random.Next(0, mapSize);
                y = random.Next(0, mapSize);

                if (map[x, y] == '_')
                {
                    map[x, y] = 'B';
                    buffs--;
                }
            }

            while (health > 0)
            {
                x = random.Next(0, mapSize);
                y = random.Next(0, mapSize);

                if (map[x, y] == '_')
                {
                    map[x, y] = 'H';
                    health--;
                }
            }

            UpdateMap();
        }

        static void Move()
        {
            int playerOldY;
            int playerOldX;


            while (true)
            {
                playerOldX = playerX;
                playerOldY = playerY;

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:
                        playerX--;
                        playerStepCount++;
                        break;
                    case ConsoleKey.DownArrow:
                        playerX++;
                        playerStepCount++;
                        break;
                    case ConsoleKey.LeftArrow:
                        playerY--;
                        playerStepCount++;
                        break;
                    case ConsoleKey.RightArrow:
                        playerY++;
                        playerStepCount++;
                        break;
                    case ConsoleKey.Escape:
                        SaveGame();
                        Console.Clear();
                        PrintCenteredText("yИгра сохранена", centerY);
                        PrintCenteredText("Нажмите Enter для выхода из игры", centerY + 1);
                        Console.ReadLine();
                        return;
                }

                if (playerX < 0) playerX = 0;
                if (playerX >= mapSize) playerX = mapSize - 1;
                if (playerY < 0) playerY = 0;
                if (playerY >= mapSize) playerY = mapSize - 1;

                Console.CursorVisible = false;

                map[playerOldY, playerOldX] = '_';
                Console.SetCursorPosition(playerOldY, playerOldX);
                Console.Write('_');

                map[playerY, playerX] = 'P';
                Console.SetCursorPosition(playerY, playerX);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write('P');
                Console.ResetColor();

                BuffUp();
                AidUp();
                Fight();
                WinGame();

                int x, y;
                Console.SetCursorPosition(0, 25);
                Console.WriteLine("Здоровье: " + playerHP + "  ");
                Console.WriteLine("Сила: " + playerStrong + "  ");
                GetPlayerPosition(out x, out y);
                Console.WriteLine($"x = {x}, y = {y}" + "  ");
                Console.WriteLine("Сделано шагов: " + playerStepCount + "  ");

                Console.SetCursorPosition(mapSize + 5, mapSize / 2);
                Console.Write("Последнее действие: " + lastAction);
            }
        }

        static void UpdateMap()
        {
            Console.Clear();
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    switch (map[i, j])
                    {
                        case 'P':
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case 'E':
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case 'B':
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;
                        case 'H':
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case 'A':
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Gray;
                            break;
                    }

                    Console.Write(map[i, j]);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        static void BuffUp()
        {
            if (!hasBuff && map[playerX, playerY] == 'B')
            {
                hasBuff = true;
                buffStep = playerStepCount;
                playerStrong *= 2;
                map[playerX, playerY] = '_';
                lastAction = "Поднят бафф                            ";
            }
            if (hasBuff && buffStep == playerStepCount - 20)
            {
                hasBuff = false;
                playerStrong = 10;
                lastAction = "Бафф закончился                        ";
            }
        }

        static void AidUp()
        {
            if (map[playerX, playerY] == 'H')
            {
                playerHP = 50;
                map[playerX, playerY] = '_';
                lastAction = "Поднята аптечка                        ";
            }
        }

        static void Fight()
        {
            if (map[playerX, playerY] == 'E')
            {
                int playerDamage = playerStrong;
                int enemyDamage = enemyStrong;

                while (playerHP > 0 && enemyHP > 0)
                {
                    playerHP -= enemyDamage;
                    enemyHP -= playerDamage;

                    if (playerHP <= 0)
                    {
                        lastAction = "Вы проиграли битву с боссом. Здоровье: 0";
                        Console.Clear();
                        PrintCenteredText("Game Over", centerY);
                        Console.SetCursorPosition(centerX, centerY + 1);
                        Console.WriteLine("Нажмите Enter для выхода из игры");

                        ConsoleKeyInfo keyInfo;
                        do
                        {
                            keyInfo = Console.ReadKey();
                        } while (keyInfo.Key != ConsoleKey.Enter);

                        StartGame();
                    }

                    if (enemyHP <= 0)
                    {
                        map[playerX, playerY] = '_';
                        Console.SetCursorPosition(playerY, playerX);
                        Console.Write('_');
                        Console.SetCursorPosition(playerY, playerX);
                        Console.Write('P');
                        lastAction = "Вы победили врага и потеряли " + (50 - playerHP) + " хп   ";
                    }
                    else
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            Console.SetCursorPosition(playerY, playerX);
                            Console.Write('1');
                            Thread.Sleep(100);
                            Console.SetCursorPosition(playerY, playerX);
                            Console.Write('0');
                            Thread.Sleep(100);
                        }
                        Console.Write('_');
                    }
                }
                enemyHP = 30;
            }
        }
        static void GetPlayerPosition(out int x, out int y)
        {
            x = playerX;
            y = playerY;
        }

        static void WinGame()
        {
            bool enemiesLeft = false;

            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (map[i, j] == 'E')
                    {
                        enemiesLeft = true;
                        break;
                    }
                }

                if (enemiesLeft)
                {
                    break;
                }
            }

            if (!enemiesLeft)
            {
                if (!bossSpawned)
                {
                    bossSpawned = true;
                    playerStrong = 100;

                    Random random = new Random();
                    int x, y;
                    x = random.Next(0, mapSize);
                    y = random.Next(0, mapSize);

                    lastAction = "Появление босса. Босс HP: 100, Урон: 39";

                    for (int i = 0; i < mapSize; i++)
                    {
                        for (int j = 0; j < mapSize; j++)
                        {
                            if (j == mapSize - 1)
                            {
                                Console.SetCursorPosition(i, j);
                                map[i, j] = '_';
                            }
                            else
                            {
                                map[i, j] = '_';
                            }
                        }
                    }

                    map[playerX, playerY] = 'P';
                    map[x, y] = 'A';

                    Console.SetCursorPosition(x, y);
                    Console.Write('A');

                    UpdateMap();
                }
                else if (bossSpawned && map[playerX, playerY] == 'A')
                {
                    playerHP -= bossStrong;
                    bossHP -= playerStrong;

                    if (playerHP <= 0)
                    {
                        Console.Clear();
                        PrintCenteredText("Game Over", centerY);
                        PrintCenteredText("Вы проиграли бой. Здоровье: 0", centerY + 1);
                        PrintCenteredText("Нажмите Enter для выхода из игры", centerY + 2);

                        ConsoleKeyInfo keyInfo;
                        do
                        {
                            keyInfo = Console.ReadKey();
                        } while (keyInfo.Key != ConsoleKey.Enter);

                        Environment.Exit(0);
                    }

                    if (bossHP <= 0)
                    {
                        Console.Clear();
                        PrintCenteredText("Игра пройдена", centerY);
                        PrintCenteredText("Вы победили босса", centerY + 1);
                        PrintCenteredText("Нажмите Enter для выхода из игры", centerY + 2);

                        ConsoleKeyInfo keyInfo;
                        do
                        {
                            keyInfo = Console.ReadKey();
                        } while (keyInfo.Key != ConsoleKey.Enter);

                        Environment.Exit(0);
                    }
                }
            }
        }

        static void StartGame()
        {
            Console.SetCursorPosition(centerX, centerY);
            PrintCenteredText("N - начать новую игру", centerY);
            PrintCenteredText("        L - загрузить последнее сохранение        ", centerY + 1);
            PrintCenteredText("       Escape - выйти из игры        ", centerY + 2);

            bossSpawned = false;

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.N:
                    GenerationMap();
                    Move();
                    break;
                case ConsoleKey.L:
                    LoadGame();
                    Move();
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
            }
        }
        static void PrintCenteredText(string text, int y)
        {
            int centerX = Console.WindowWidth / 2 - text.Length / 2;
            Console.SetCursorPosition(centerX, y);
            Console.WriteLine(text);
        }

        static void SaveGame()
        {
            string path = "save.txt";
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine($"playerX={playerX}");
                writer.WriteLine($"playerY={playerY}");
                writer.WriteLine($"playerHP={playerHP}");
                writer.WriteLine($"playerStrong={playerStrong}");
                writer.WriteLine($"playerStepCount={playerStepCount}");
                writer.WriteLine($"enemyHP={enemyHP}");
                writer.WriteLine($"hasBuff={hasBuff}");
                writer.WriteLine($"buffStep={buffStep}");

                for (int i = 0; i < mapSize; i++)
                {
                    for (int j = 0; j < mapSize; j++)
                    {
                        if (map[i, j] == 'P')
                        {
                            map[i, j] = '_';
                        }
                        writer.Write(map[i, j]);
                    }
                    writer.WriteLine();
                }
            }
        }

        static void LoadGame()
        {
            string path = "save.txt";

            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);

                if (lines.Length >= mapSize)
                {
                    if (int.TryParse(lines[0].Split('=')[1], out int loadedPlayerX) &&
                    int.TryParse(lines[1].Split('=')[1], out int loadedPlayerY) &&
                    int.TryParse(lines[2].Split('=')[1], out int loadedPlayerHP) &&
                    int.TryParse(lines[3].Split('=')[1], out int loadedPlayerStrong) &&
                    int.TryParse(lines[4].Split('=')[1], out int loadedPlayerStepCount) &&
                    int.TryParse(lines[5].Split('=')[1], out int loadedEnemyHP) &&
                    bool.TryParse(lines[6].Split('=')[1], out bool loadedHasBuff) &&
                    int.TryParse(lines[7].Split('=')[1], out int loadedBuffStep))
                    {
                        playerX = loadedPlayerX;
                        playerY = loadedPlayerY;
                        playerHP = loadedPlayerHP;
                        playerStrong = loadedPlayerStrong;
                        playerStepCount = loadedPlayerStepCount;
                        enemyHP = loadedEnemyHP;
                        hasBuff = loadedHasBuff;
                        buffStep = loadedBuffStep;

                        bossSpawned = false;

                        for (int i = 0; i < mapSize; i++)
                        {
                            for (int j = 0; j < mapSize; j++)
                            {
                                map[i, j] = '_';
                            }
                        }

                        for (int i = 0; i < mapSize; i++)
                        {
                            for (int j = 0; j < mapSize; j++)
                            {
                                map[i, j] = lines[i + 8][j];
                            }
                        }

                        map[playerX, playerY] = 'P';

                        Console.Clear();
                        UpdateMap();
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка чтения файла сохранения.");
                }
            }
            else
            {
                Console.WriteLine("Файл сохранения не найден.");
            }
        }
    }
}