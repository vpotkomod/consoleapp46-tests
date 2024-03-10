using System;

namespace ConsoleApp46
{
    internal class Movement
    {
        public Movement(ref char[,] map, ConsoleKeyInfo key)
        {
            char[] temp;
            switch (key.Key)
            {
                case ConsoleKey.W:
                    temp = new char[map.GetLength(0)];
                    for (int i = map.GetLength(0) - 1; i >= 0; i--)
                        for (int j = 0; j < map.GetLength(1); j++)
                            Calculate(i, j, i, j, ref map, ref temp, map.GetLength(0) - 1, 0, (map.GetLength(0) - 1) / 2, (map.GetLength(1) - 1) / 2, -1, 0);
                    break;
                case ConsoleKey.S:
                    temp = new char[map.GetLength(0)];
                    for (int i = 0; i < map.GetLength(0); i++)
                        for (int j = 0; j < map.GetLength(1); j++)
                            Calculate(i, j, i, j, ref map, ref temp, 0, map.GetLength(0) - 1, (map.GetLength(0) - 1) / 2, (map.GetLength(1) - 1) / 2, 1, 0);
                    break;
                case ConsoleKey.A:
                    temp = new char[map.GetLength(1)];
                    for (int i = 0; i < map.GetLength(0); i++)
                        for (int j = map.GetLength(1) - 1; j >= 0; j--)
                            Calculate(j, i, i, j, ref map, ref temp, map.GetLength(1) - 1, 0, (map.GetLength(0) - 1) / 2, (map.GetLength(1) - 1) / 2, 0, -1);
                    break;
                case ConsoleKey.D:
                    temp = new char[map.GetLength(1)];
                    for (int i = 0; i < map.GetLength(0); i++)
                        for (int j = 0; j < map.GetLength(1); j++)
                            Calculate(j, i, i, j, ref map, ref temp, 0, map.GetLength(1) - 1, (map.GetLength(0) - 1) / 2, (map.GetLength(1) - 1) / 2, 0, 1);
                    break;
            }
        }

        private void Calculate(int ij, int ji, int i, int j, ref char[,] map, ref char[] temp, int x1, int x2, int x3, int x4, int x, int y)
        {
            if (ij == x1)
                temp[ji] = map[i, j];
            else if (ij == x2)
                map[i, j] = temp[ji];
            if (ij != x2)
                map[i, j] = map[i + x, j + y];
            if (i == x3 && j == x4)
                map[i, j] = (char)2;
            if (i == x3 && j == x4)
                map[i - x, j - y] = '.';
        }
    }
}