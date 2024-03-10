using System;

namespace ConsoleApp46
{
    internal class Map
    {
        static public int LevelWorld = 1;
        static public bool NewWorld = false;
        static public int KilledEnemys = 0;
        static Random rnd = new Random();

        static public void GetMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (i == map.GetLength(0) / 2 & j == map.GetLength(0) / 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write((char)2 + " ");
                    }
                    else
                    {
                        if (map[i, j] == '0')
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        else if (map[i, j] == (char)1)
                            Console.ForegroundColor = ConsoleColor.Red;
                        else if (map[i, j] == (char)3)
                            Console.ForegroundColor = ConsoleColor.Magenta;
                        else if (map[i, j] == (char)19)
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                        else if (map[i, j] == (char)0177)
                            Console.ForegroundColor = ConsoleColor.Gray;
                        else if (map[i, j] == 'Ф')
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                        else if (map[i, j] == 'O')
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write(map[i, j] + " ");
                    }
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

        static public void Array(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    int count = rnd.Next(100);

                    map[i, j] = '.';
                    if (count < 2) //враг
                        map[i, j] = (char)1;
                    else if (count >= 98) //сердце
                        map[i, j] = (char)3;
                    else if (count >= 10 && count < 20) //стена
                    {
                        int X = i;
                        int Y = j;
                        for (int t = 0; t < 10; t++)
                        {
                            map[X++, Y++] = (char)0177;
                            if (X > map.GetLength(0) - 1 || Y > map.GetLength(1) - 1)
                                break;
                        }
                    }
                    else if (count >= 20 && count < 30) //дерево
                    {
                        int X = i;
                        int Y = j;
                        for (int t = 0; t < 10; t++)
                        {
                            map[X++, Y++] = 'Ф';
                            if (X > map.GetLength(0) - 1 || Y > map.GetLength(1) - 1)
                                break;
                        }
                    }
                    else if (count >= 30 && count < 35) //водоем
                    {
                        bool water = false;
                        if (i != 0 & j != 0 & i != map.GetLength(0) - 1 & j != map.GetLength(1) - 1)
                            for (int x = -1; x < 2; x++)
                                for (int y = -1; y < 2; y++)
                                    if (map[i + x, j + y] == 'O')
                                        water = true;
                        if (!water)
                            map[i, j] = 'O';
                    }
                    if (LevelWorld > 1)
                        map[map.GetLength(0) / 4, map.GetLength(1) / 2] = (char)19;
                }
        }
       
        static public bool Win(char[,] map)
        {
            if (KilledEnemys == 5 * LevelWorld & !NewWorld)
            {
                map[10, 10] = '0';
                NewWorld = true;
                return true;
            }
            else 
                return false; 
        }

        static public bool GetIvent(Person Hero, char[,] map, int A, int B)
        {
            char key = map[A, B];

            switch (key)
            {
                case (char)1:
                    new Battle(Hero);
                    break;
                case (char)3:
                    new Heart(Hero);
                    break;
                case '0':
                    new Portal(Hero, map);
                    break;
                case (char)19:
                    new Forge(Hero);
                    return false;
                case (char)0177:
                    return false;
                case 'Ф':
                    return false;
                case 'O':
                    return false;
                default:
                    break;
            }
            return true;
        }
    }
}