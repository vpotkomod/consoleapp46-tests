using ConsoleApp129;
using System;

namespace ConsoleApp46
{
    /// <summary>
    ///  действие на карте
    /// </summary>
    abstract class Action
    {
        /// <summary>
        ///  действие на карте
        /// </summary>
        /// <param name="map">персонаж</param>
        /// <param name="last">последняя нажатая кнопка</param>
        public Action(char[,] map, ConsoleKeyInfo last) { }
        /// <summary>
        ///  проверка на нажатую кнопку
        /// </summary>
        /// <param name="last">последняя нажатая кнопка</param>
        /// <param name="i">строка</param>
        /// <param name="j">столбец</param>
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
    /// <summary>
    ///  вырубка деревьев
    /// </summary>
    internal class Deforestation : Action
    {
        /// <summary>
        ///  вырубка деревьев
        /// </summary>
        /// <param name="map">персонаж</param>
        /// <param name="last">последняя нажатая кнопка</param>
        /// <param name="Hero">персонаж</param>
        public Deforestation(char[,] map, ConsoleKeyInfo last, Person Hero) : base(map, last)
        {
            int i = 0, j = 0;
            SwitchCasing(last, ref i, ref j);
            if (map[map.GetLength(0) / 2 + i, map.GetLength(0) / 2 + j] == 'Ф')
            {
                map[map.GetLength(0) / 2 + i, map.GetLength(0) / 2 + j] = '.';
                Person.GetTrees(Hero, Person.ReturnAgility(Hero));
            }
            else
                throw new MyException("Это не дерево!");
        }
    }
    /// <summary>
    ///  переплытие водоема
    /// </summary>
    internal class Swimming : Action
    {
        /// <summary>
        ///  переплытие водоема
        /// </summary>
        /// <param name="map">персонаж</param>
        /// <param name="last">последняя нажатая кнопка</param>
        /// <param name="p">персонаж</param>
        public Swimming(char[,] map, ConsoleKeyInfo last, Person p) : base(map, last)
        {
            if (Person.ReturnEndurance(p) > 0)
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
            else
                throw new MyException("Не хватает выносливости!");
        }
    }

    internal class GetCharacter : Action
    {
        public GetCharacter(char[,] map, ConsoleKeyInfo last, Person p) : base(map, last)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Характеристики:");
            Console.ResetColor();
            Console.WriteLine($"Сила = {Person.ReturnStrenght(p)}");
            Console.WriteLine($"Восприятие = {Person.ReturnPerception(p)}");
            Console.WriteLine($"Выносливость = {Person.ReturnEndurance(p)}");
            Console.WriteLine($"Харизма = {Person.ReturnCharisma(p)}");
            Console.WriteLine($"Интеллект = {Person.ReturnIntelligence(p)}");
            Console.WriteLine($"Ловкость = {Person.ReturnAgility(p)}");
            Console.WriteLine($"Удача = {Person.ReturnLuck(p)}");
        }
    }
}