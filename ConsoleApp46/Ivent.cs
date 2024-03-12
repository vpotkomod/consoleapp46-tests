using ConsoleApp129;
using System;

namespace ConsoleApp46
{
    abstract class Ivent
    {
        public Ivent(Person Hero) { }
    }

    internal class Battle : Ivent
    {
        public Battle(Person Hero) : base(Hero)
        {
            Person Enemy = new Person(Map.LevelWorld * 10);
            Random rnd = new Random();

            while (Person.ReturnHp(Enemy) > 0 && Person.ReturnHp(Hero) > 0)
            {
                int Shot = rnd.Next(10);
                Person.EnemyBattling(Enemy, Hero, Shot);
                Shot = rnd.Next(10);
                Person.HeroBattling(Hero, Shot, Map.LevelWorld);
            }
            if (Person.ReturnHp(Enemy) < Person.ReturnHp(Hero))
                Person.GetCoins(Hero, rnd.Next(0, 20));
            Map.KilledEnemys++;
        }
    }

    internal class Heart : Ivent
    {
        public Heart(Person Hero) : base(Hero)
        {
            Person.GetHp(Hero, 10 * Map.LevelWorld);
            if (Person.ReturnHp(Hero) - 10 * Map.LevelWorld == Person.ReturnMaxHp(Hero))
                Person.GetMaxHp(Hero, 10 * Map.LevelWorld);
            else if (Person.ReturnHp(Hero) > Person.ReturnMaxHp(Hero))
                while (Person.ReturnHp(Hero) != Person.ReturnMaxHp(Hero))
                    Person.GetMaxHp(Hero, 1);
        }
    }

    internal class Portal : Ivent
    {
        public Portal(Person Hero, char[,] mas) : base(Hero)
        {
            Map.LevelWorld++;
            Map.KilledEnemys = 0;
            Map.NewWorld = false;
            Person.GetCoins(Hero, 100);
            if (Person.ReturnHp(Hero) > Person.ReturnMaxHp(Hero))
                while (Person.ReturnHp(Hero) != Person.ReturnMaxHp(Hero))
                    Person.GetMaxHp(Hero, 1);
            else
                while (Person.ReturnHp(Hero) != Person.ReturnMaxHp(Hero))
                    Person.GetHp(Hero, 1);
            Map.Array(mas);
        }
    }

    internal class Forge : Ivent
    {
        public Forge(Person Hero) : base(Hero)
        {
            Console.WriteLine("1. Улучшить силу за 250\n2. Продать дерево за 5");
            Console.WriteLine("Для выхода нажмите Enter");
            Console.WriteLine($" деньги {Person.ReturnCoins(Hero)}\n дерево {Person.ReturnTrees(Hero)}");

            ConsoleKey key;
            while ((key = Console.ReadKey().Key) != ConsoleKey.Enter)
                try
                {
                    switch (key)
                    {
                        case ConsoleKey.D1:
                            if (Person.ReturnCoins(Hero) >= 250)
                            {
                                Person.GetStrenght(Hero);
                                Person.GetCoins(Hero, -250);
                                Console.WriteLine($"\nСила увеличена, Текущая сила = {Person.ReturnStrenght(Hero)}");
                                Console.WriteLine($" деньги {Person.ReturnCoins(Hero)}\n дерево {Person.ReturnTrees(Hero)}");
                            }
                            else
                                throw new MyException("\nНедостаточно деняк");
                            break;
                        case ConsoleKey.D2:
                            if (Person.ReturnTrees(Hero) > 0)
                            {
                                Person.GetCoins(Hero, 5);
                                Person.GetTrees(Hero, -1);
                                Console.WriteLine($"\n1 дерево продано");
                                Console.WriteLine($" деньги {Person.ReturnCoins(Hero)}\n дерево {Person.ReturnTrees(Hero)}");
                            }
                            else
                                throw new MyException("\nНедостаточно дерева");
                            break;
                    }
                }
                catch (Exception e) 
                {
                    Console.WriteLine(e.Message);
                }
        }
    }
}