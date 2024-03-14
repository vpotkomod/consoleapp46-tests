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
                Person.HeroBattling(Hero, Shot - Person.ReturnPerception(Hero) * 5, Map.LevelWorld);
            }
            if (Person.ReturnHp(Enemy) < Person.ReturnHp(Hero))
                Person.GetCoins(Hero, rnd.Next(0, 20 + 5 * Person.ReturnLuck(Hero)));
            Map.KilledEnemys++;
        }
    }

    internal class Heart : Ivent
    {
        public Heart(Person Hero) : base(Hero)
        {
            Person.GetHp(Hero, 10 * Map.LevelWorld + 2 * Person.ReturnCharisma(Hero));
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
            Map.Generating(mas);
        }
    }

    internal class Forge : Ivent
    {
        public Forge(Person Hero) : base(Hero)
        {
            int price = 250 / (1 * Person.ReturnCharisma(Hero));
            int treePrice = 5 * Person.ReturnIntelligence(Hero);
            Console.WriteLine($"1. Улучшить силу за {price}\n2. Продать дерево за {treePrice}\n3. Улучшить воспритие за {price}");
            Console.WriteLine($"4. Улучшить выносливость за {price}\n5. Улучшить харизму за {price}");
            Console.WriteLine($"6. Улучшить интеллект за {price}\n7. Улучшить ловкость за {price}\n8. Улучшить удачу за {price}");


            Console.WriteLine("Для выхода нажмите Enter");
            Console.WriteLine($" деньги {Person.ReturnCoins(Hero)}\n дерево {Person.ReturnTrees(Hero)}");

            ConsoleKey key;
            while ((key = Console.ReadKey().Key) != ConsoleKey.Enter)
                try
                {
                    switch (key)
                    {
                        case ConsoleKey.D1:
                            if (Person.ReturnCoins(Hero) >= price)
                            {
                                Person.GetStrenght(Hero);
                                Person.GetCoins(Hero, -price);
                                Console.WriteLine($"\n Сила увеличена, Текущая сила = {Person.ReturnStrenght(Hero)}");
                                Console.WriteLine($" деньги {Person.ReturnCoins(Hero)}\n дерево {Person.ReturnTrees(Hero)}");
                            }
                            else
                                throw new MyException("\nНедостаточно деняк");
                            break;
                        case ConsoleKey.D2:
                            if (Person.ReturnTrees(Hero) > 0)
                            {
                                Person.GetCoins(Hero, treePrice);
                                Person.GetTrees(Hero, -1);
                                Console.WriteLine($"\n 1 дерево продано");
                                Console.WriteLine($" деньги {Person.ReturnCoins(Hero)}\n дерево {Person.ReturnTrees(Hero)}");
                            }
                            else
                                throw new MyException("\nНедостаточно дерева");
                            break;
                        case ConsoleKey.D3:
                            if (Person.ReturnCoins(Hero) >= price)
                            {
                                Person.GetPerception(Hero);
                                Person.GetCoins(Hero, -price);
                                Console.WriteLine($"\n Восприятие увеличено, Текущее восприятие = {Person.ReturnPerception(Hero)}");
                                Console.WriteLine($" деньги {Person.ReturnCoins(Hero)}\n дерево {Person.ReturnTrees(Hero)}");
                            }
                            else
                                throw new MyException("\nНедостаточно деняк");
                            break;
                        case ConsoleKey.D4:
                            if (Person.ReturnCoins(Hero) >= price)
                            {
                                Person.GetMaxEndurance(Hero);
                                Person.GetCoins(Hero, -price);
                                Console.WriteLine($"\n Выносливость увеличена, Текущая выносливость = {Person.ReturnEndurance(Hero)}");
                                Console.WriteLine($" деньги {Person.ReturnCoins(Hero)}\n дерево {Person.ReturnTrees(Hero)}");
                            }
                            else
                                throw new MyException("\nНедостаточно деняк");
                            break;
                        case ConsoleKey.D5:
                            if (Person.ReturnCoins(Hero) >= price)
                            {
                                Person.GetCharisma(Hero);
                                Person.GetCoins(Hero, -price);
                                Console.WriteLine($"\n Харизма увеличена, Текущая харизма = {Person.ReturnCharisma(Hero)}");
                                Console.WriteLine($" деньги {Person.ReturnCoins(Hero)}\n дерево {Person.ReturnTrees(Hero)}");
                            }
                            else
                                throw new MyException("\nНедостаточно деняк");
                            break;
                        case ConsoleKey.D6:
                            if (Person.ReturnCoins(Hero) >= price)
                            {
                                Person.GetIntelligence(Hero);
                                Person.GetCoins(Hero, -price);
                                Console.WriteLine($"\n Интеллект увеличен, Текущий интеллект = {Person.ReturnIntelligence(Hero)}");
                                Console.WriteLine($" деньги {Person.ReturnCoins(Hero)}\n дерево {Person.ReturnTrees(Hero)}");
                            }
                            else
                                throw new MyException("\nНедостаточно деняк");
                            break;
                        case ConsoleKey.D7:
                            if (Person.ReturnCoins(Hero) >= price)
                            {
                                Person.GetAgility(Hero);
                                Person.GetCoins(Hero, -price);
                                Console.WriteLine($"\n Ловкость увеличена, Текущая ловкость = {Person.ReturnAgility(Hero)}");
                                Console.WriteLine($" деньги {Person.ReturnCoins(Hero)}\n дерево {Person.ReturnTrees(Hero)}");
                            }
                            else
                                throw new MyException("\nНедостаточно деняк");
                            break;
                        case ConsoleKey.D8:
                            if (Person.ReturnCoins(Hero) >= price)
                            {
                                Person.GetLuck(Hero);
                                Person.GetCoins(Hero, -price);
                                Console.WriteLine($"\n Удача увеличена, Текущая удача = {Person.ReturnLuck(Hero)}");
                                Console.WriteLine($" деньги {Person.ReturnCoins(Hero)}\n дерево {Person.ReturnTrees(Hero)}");
                            }
                            else
                                throw new MyException("\nНедостаточно деняк");
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