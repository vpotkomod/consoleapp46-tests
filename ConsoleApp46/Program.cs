using ConsoleApp129;
using System;

namespace ConsoleApp46
{
    /// <summary>
    ///  входная точка программы
    /// </summary>
    public class Program
    {
        /// <summary>
        ///  начинает и инициализирует игровой процесс
        /// </summary>
        static void Main(string[] args)
        {
            Person p = new Person(100, "Герой");
            int def = 25;
            char[,] map = new char[def, def];
            ConsoleKeyInfo udlr = new ConsoleKeyInfo();
            ConsoleKeyInfo last = new ConsoleKeyInfo();
            bool getCharacter = false;
            bool getCharacteristic = false;
            Map.Generating(map);
            while (Person.ReturnHp(p) > 0)
            {
                Console.Clear();
                switch (udlr.Key)
                {
                    case ConsoleKey.W: //вверх
                        CheckMoving(p, ref map, 11, 12, udlr, ref last);
                        break;
                    case ConsoleKey.S: //вниз
                        CheckMoving(p, ref map, 13, 12, udlr, ref last);
                        break;
                    case ConsoleKey.A: //влево
                        CheckMoving(p, ref map, 12, 11, udlr, ref last);
                        break;
                    case ConsoleKey.D: //вправо
                        CheckMoving(p, ref map, 12, 13, udlr, ref last);
                        break;
                    case ConsoleKey.E: //вырубка деревьев
                        try
                        {
                            new Deforestation(map, last, p);
                        }
                        catch (MyException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case ConsoleKey.Q: //переплыть водоем
                        try
                        {
                            new Swimming(map, last, p);
                            Person.SpendEndurance(p);
                        }
                        catch (MyException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case ConsoleKey.R:
                        if (!getCharacteristic)
                            getCharacter = !getCharacter;
                        break;
                    case ConsoleKey.T:
                        if (!getCharacter)
                            getCharacteristic = !getCharacteristic;
                        break;
                    default:
                        break;
                }
                Map.MoveEnemy(ref map, p, last);
                Map.Win(map);
                if (getCharacter & !getCharacteristic)
                    new GetCharacter(p);
                if (getCharacteristic & !getCharacter)
                    new GetCharacteristic(map, last);
                Map.GetMap(map);
                Person.GetCharacter(p);
                udlr = Console.ReadKey();
            }
            Console.Clear();
            Console.WriteLine("Ты проиграл!");
            Console.ReadLine();
        }

        /// <summary>
        ///  проверяет возможность передвижения
        /// </summary>
        /// <param name="Hero">персонаж</param>
        /// <param name="map">карта</param>
        /// <param name="A">строка</param>
        /// <param name="B">столбец</param>
        /// <param name="udlr">стрелочка</param>
        /// <param name="last">последняя нажатая кнопка</param>
        static void CheckMoving(Person Hero, ref char[,] map, int A, int B, ConsoleKeyInfo udlr, ref ConsoleKeyInfo last)
        {
            if (Map.GetIvent(Hero, map, A, B))
                new Movement(ref map, udlr);
            last = udlr;
        }
    }
}