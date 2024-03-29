using System;

namespace ConsoleApp46
{
    /// <summary>
    ///  игровая карта
    /// </summary>
    internal class Map
    {
        /// <summary>
        ///  уровень мира
        /// </summary>
        static public int LevelWorld = 1;
        /// <summary>
        ///  наличие портала
        /// </summary>
        static public bool NewWorld = false;
        /// <summary>
        ///  убитые враги
        /// </summary>
        static public int KilledEnemys = 0;
        /// <summary>
        ///  рандом
        /// </summary>
        static Random rnd = new Random();

        /// <summary>
        ///  отрисовка карты
        /// </summary>
        /// <param name="map">карта</param>
        static public void GetMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {

                    if (i == map.GetLength(0) / 2 & j == map.GetLength(0) / 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write('P' + " ");
                    }
                    else
                    {
                        if (map[i, j] == '0')
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        else if (map[i, j] == 'o')
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
        /// <summary>
        ///  передвижение врагов
        /// </summary>
        /// <param name="_map">карта</param>
        /// <param name="p">персонаж</param>
        /// <param name="last">последняя нажатая стрелочка</param>
        static public void MoveEnemy(ref char[,] _map, Person p, ConsoleKeyInfo last)
        {
            char[,] newMap = new char[_map.GetLength(0), _map.GetLength(1)];
            Array.Copy(_map, newMap, _map.Length);

            for (int i = 0; i < _map.GetLength(0); i++)
                for (int j = 0; j < _map.GetLength(1); j++)
                    if (_map[i, j] == 'o')
                    {
                        int direction = rnd.Next(4);

                        int newX = i, newY = j;
                        switch (direction)
                        {
                            case 0:
                                if (newX < _map.GetLength(0) - 1)
                                    newX += 1;
                                break;
                            case 1:
                                if (newX > 0)
                                    newX -= 1;
                                break;
                            case 2:
                                if (newY < _map.GetLength(1) - 1)
                                    newY += 1;
                                break;
                            case 3:
                                if (newY > 0)
                                    newY -= 1;
                                break;
                        }

                        if (newMap[newX, newY] == '.' || (newX == 12 & newY == 12))
                        {
                            if (newX == 12 & newY == 12)
                                GetIvent(p, newMap, i, j);
                            else
                                newMap[newX, newY] = 'o';
                            newMap[i, j] = '.';
                        }
                    }


            Array.Copy(newMap, _map, _map.Length);
        }
        /// <summary>
        ///  генерация карты
        /// </summary>
        /// <param name="map">карта</param>
        static public void Generating(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    int count = rnd.Next(100);

                    map[i, j] = '.';
                    if (count < 2) //враг
                        map[i, j] = 'o';
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
        /// <summary>
        ///  проверка на генерацию портала
        /// </summary>
        /// <param name="map">карта</param>
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
        /// <summary>
        ///  проверка на взаимодействие с игровой картой
        /// </summary>
        /// <param name="Hero">персонаж</param>
        /// <param name="map">карта</param>
        /// <param name="A">строка</param>
        /// <param name="B">столбец</param>
        static public bool GetIvent(Person Hero, char[,] map, int A, int B)
        {
            char key = map[A, B];

            switch (key)
            {
                case 'o':
                    new Battle(Hero);
                    if (Person.ReturnMaxEndurance(Hero) > Person.ReturnEndurance(Hero))
                        Person.GetEndurance(Hero);
                    return true;
                case (char)3:
                    new Heart(Hero);
                    if (Person.ReturnMaxEndurance(Hero) > Person.ReturnEndurance(Hero))
                        Person.GetEndurance(Hero);
                    return true;
                case '0':
                    new Portal(Hero, map);
                    return true;
                case (char)19:
                    new Forge(Hero);
                    return false;
                case (char)0177:
                    return false;
                case 'Ф':
                    return false;
                case 'O':
                    return false;
                case '.':
                    return true;
                default:
                    return false;
            }
        }
    }
}