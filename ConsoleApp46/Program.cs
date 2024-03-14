using ConsoleApp129;
using System;

namespace ConsoleApp46
{
    public class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person(100, "Герой");
            int def = 25;
            char[,] map = new char[def, def];
            ConsoleKeyInfo udlr = new ConsoleKeyInfo();
            ConsoleKeyInfo last = new ConsoleKeyInfo();
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
                    default:
                        break;
                }
                Map.MoveEnemy(ref map, p, last);
                Map.Win(map);
                Map.GetMap(map);
                Person.GetCharacter(p);
                udlr = Console.ReadKey();
            }
            Console.Clear();
            Console.WriteLine("Ты проиграл!");
            Console.ReadLine();
        }

        static void CheckMoving(Person Hero, ref char[,] map, int A, int B, ConsoleKeyInfo udlr, ref ConsoleKeyInfo last)
        {
            if (Map.GetIvent(Hero, map, A, B))
                new Movement(ref map, udlr);
            last = udlr;
        }
    }
}