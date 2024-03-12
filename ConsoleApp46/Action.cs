using ConsoleApp129;
using System;

namespace ConsoleApp46
{
    abstract class Action
    {
        public Action(char[,] map, ConsoleKeyInfo last) { }

        static public void SwitchCasing(ConsoleKeyInfo last, ref int i, ref int j)
        {
            switch (last.Key)
            {
                case ConsoleKey.W:
                    i--;
                    break;
                case ConsoleKey.S:
                    i++;
                    break;
                case ConsoleKey.A:
                    j--;
                    break;
                case ConsoleKey.D:
                    j++;
                    break;
                default:
                    break;
            }
        }
    }

    internal class Deforestation : Action
    {
        public Deforestation(char[,] map, ConsoleKeyInfo last, Person Hero) : base(map, last)
        {
            int i = 0, j = 0;
            SwitchCasing(last, ref i, ref j);
            if (map[map.GetLength(0) / 2 + i, map.GetLength(0) / 2 + j] == 'Ф')
            {
                map[map.GetLength(0) / 2 + i, map.GetLength(0) / 2 + j] = '.';
                Person.GetTrees(Hero, 1);
            }
            else
                throw new MyException("Это не дерево!");
        }
    }

    internal class Swimming : Action
    {
        public Swimming(char[,] map, ConsoleKeyInfo last, Person p) : base(map, last)
        {
            int i = 0, j = 0;
            SwitchCasing(last, ref i, ref j);
            if (map[12 + i, 12 + j] == 'O')
                switch (last.Key)
                {
                    case ConsoleKey.W:
                        if (Map.GetIvent(p, map, 10, 12))
                        {
                            new Movement(ref map, last);
                            new Movement(ref map, last);

                            map[13, 12] = 'O';
                        }
                        break;
                    case ConsoleKey.S:
                        if (Map.GetIvent(p, map, 14, 12))
                        {
                            new Movement(ref map, last);
                            new Movement(ref map, last);

                            map[11, 12] = 'O';
                        }
                        break;
                    case ConsoleKey.A:
                        if (Map.GetIvent(p, map, 12, 10))
                        {
                            new Movement(ref map, last);
                            new Movement(ref map, last);

                            map[12, 13] = 'O';
                        }
                        break;
                    case ConsoleKey.D:
                        if (Map.GetIvent(p, map, 12, 14))
                        {
                            new Movement(ref map, last);
                            new Movement(ref map, last);

                            map[12, 11] = 'O';
                        }
                        break;
                    default:
                        break;
                }
            else
                throw new MyException("Это не переплыть!");
            Console.Clear();
        }
    }
}