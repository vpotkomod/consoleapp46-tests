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
            Map.Array(map);
            while (p.HP > 0)
            {
                Console.Clear();
                switch (udlr.Key)
                {
                    case ConsoleKey.W: //вверх
                        if (Map.GetIvent(p, map, 11))
                            Map.UpArray(map);
                        else
                            Map.GetMap(map);
                        last = udlr;
                        break;
                    case ConsoleKey.S: //вниз
                        if (Map.GetIvent(p, map, 13))
                            Map.DownArray(map);
                        else
                            Map.GetMap(map);
                        last = udlr;
                        break;
                    case ConsoleKey.A: //влево
                        if (Map.GetIvent(p, map, 12, 11))
                            Map.LeftArray(map);
                        else
                            Map.GetMap(map);
                        last = udlr;
                        break;
                    case ConsoleKey.D: //вправо
                        if (Map.GetIvent(p, map, 12, 13))
                            Map.RightArray(map);
                        else
                            Map.GetMap(map);
                        last = udlr;
                        break;
                    case ConsoleKey.E: //вырубка деревьев
                        Map.Deforestation(map, last);
                        Map.GetMap(map);
                        break;
                    case ConsoleKey.Q: //переплыть водоем
                        Map.Swimming(map, last, p);
                        Map.GetMap(map);
                        break;
                    default:
                        Map.GetMap(map);
                        break;
                }
                Person.GetCharacter(p);
                udlr = Console.ReadKey();
            }
            Console.Clear();
            Console.WriteLine("Ты проиграл!");
            Console.ReadLine();
        }
    }
}
