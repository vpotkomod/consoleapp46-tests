using System;

namespace ConsoleApp46
{
    internal class Person
    {
        private int _maxHP = 100;
        private int _HP = 100;
        private int _strenght = 1;
        private int _coin = 0;
        private string _name;
        private int _trees = 0;

        public Person(int _HP = 100, string Name = "Враг")
        {
            _name = Name;
            this._HP = _HP;
        }

        static public void GetHp(Person Hero, int hp) => Hero._HP += hp;

        static public void GetMaxHp(Person Hero, int hp) => Hero._maxHP += hp;

        static public void GetCoins(Person Hero, int coins) => Hero._coin += coins;

        static public void GetStrenght(Person Hero) => Hero._strenght++;

        static public void GetTrees(Person Hero, int count) => Hero._trees += count;


        static public void EnemyBattling(Person Enemy, Person Hero, int Shot) => Enemy._HP -= Shot * Hero._strenght;

        static public void HeroBattling(Person Hero, int Shot, int LevelWorld) => Hero._HP -= Shot + LevelWorld * 5;


        static public int ReturnHp(Person p) => p._HP;

        static public int ReturnMaxHp(Person p) => p._maxHP;

        static public int ReturnCoins(Person p) => p._coin;

        static public int ReturnStrenght(Person p) => p._strenght;

        static public int ReturnTrees(Person p) => p._trees;


        static public void GetCharacter(Person Hero)
        {
            Console.WriteLine($"Имя героя = {Hero._name}");
            if (Hero._HP > 0)
                Console.WriteLine($"Здоровье = {Hero._HP}");
            else
                Console.WriteLine($"Здоровье = 0");
            Console.WriteLine($"MAX Здоровье = {Hero._maxHP}");
            Console.WriteLine($"Деняк = {Hero._coin}");
            Console.WriteLine($"Сила = {Hero._strenght}");
            Console.WriteLine($"Уровень мира = {Map.LevelWorld}");
            Console.WriteLine($"Убитых врагов = {Map.KilledEnemys}");
            Console.WriteLine($"Дерево = {Hero._trees}");
            Console.WriteLine($"До портала в новый мир = {Map.LevelWorld * 5 - Map.KilledEnemys}");
        }
    }
}