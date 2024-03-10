using System;

namespace ConsoleApp46
{
    public class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person(100, "Герой");
            int def = 25;
            char[,] v = new char[def, def];
            ConsoleKeyInfo udlr = new ConsoleKeyInfo();
            Map.Array(v);
            while (p.HP > 0)
            {
                Console.Clear();
                switch (udlr.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (Map.GetIvent(p, v, 11))
                            Map.UpArray(v);
                        break;
                    case ConsoleKey.DownArrow:
                        if (Map.GetIvent(p, v, 13))
                            Map.DownArray(v);
                        break;
                    case ConsoleKey.LeftArrow:
                        if (Map.GetIvent(p, v, 12, 11))
                            Map.LeftArray(v);
                        break;
                    case ConsoleKey.RightArrow:
                        if (Map.GetIvent(p, v, 12, 13))
                            Map.RightArray(v);
                        break;
                    default:
                        break;
                }
                Map.GetMap(v);
                Person.GetCharacter(p);
                udlr = Console.ReadKey();
            }
            Console.Clear();
            Console.WriteLine("Проигрыш!");
            Console.ReadLine();
        }
    }
}


