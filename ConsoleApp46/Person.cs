using System;

namespace ConsoleApp46
{
    internal class Person
    {
        private int _maxHP = 100;
        private int _HP = 100;
        private int _coin = 0;
        private string _name;
        private int _trees = 0;

        private int _strenght = 1; //сила
        private int _perception = 1; //восприятие
        private int _maxEndurance = 5; //выносливость
        private int _endurance = 5; //выносливость
        private int _charisma = 1; //харизма
        private int _intelligence = 1; //интеллект
        private int _agility = 1; //ловкость
        private int _luck = 1; //удача

        public Person(int _HP = 100, string Name = "Враг")
        {
            _name = Name;
            this._HP = _HP;
        }

        static public void GetHp(Person Hero, int hp) => Hero._HP += hp;

        static public void GetMaxHp(Person Hero, int hp) => Hero._maxHP += hp;

        static public void GetCoins(Person Hero, int coins) => Hero._coin += coins;

        static public void GetTrees(Person Hero, int count) => Hero._trees += count;


        static public void GetStrenght(Person Hero) => Hero._strenght++;

        static public void GetPerception(Person Hero) => Hero._perception++;

        static public void GetMaxEndurance(Person Hero) => Hero._maxEndurance += 5;

        static public void GetEndurance(Person Hero) => Hero._endurance++;

        static public void GetCharisma(Person Hero) => Hero._charisma++;

        static public void GetIntelligence(Person Hero) => Hero._intelligence++;

        static public void GetAgility(Person Hero) => Hero._agility++;

        static public void GetLuck(Person Hero) => Hero._luck++;


        static public void SpendEndurance(Person Hero) => Hero._endurance--;


        static public void EnemyBattling(Person Enemy, Person Hero, int Shot) => Enemy._HP -= Shot * Hero._strenght;

        static public void HeroBattling(Person Hero, int Shot, int LevelWorld)
        {
            if (Hero._HP - (Shot + LevelWorld * 5) <= Hero._HP)
                Hero._HP -= Shot + LevelWorld * 5;
        }


        static public int ReturnHp(Person p) => p._HP;

        static public int ReturnMaxHp(Person p) => p._maxHP;

        static public int ReturnCoins(Person p) => p._coin;

        static public int ReturnTrees(Person p) => p._trees;

        static public int ReturnStrenght(Person p) => p._strenght;

        static public int ReturnPerception(Person p) => p._perception;

        static public int ReturnEndurance(Person p) => p._endurance;

        static public int ReturnMaxEndurance(Person p) => p._maxEndurance;

        static public int ReturnCharisma(Person p) => p._charisma;

        static public int ReturnIntelligence(Person p) => p._intelligence;

        static public int ReturnAgility(Person p) => p._agility;

        static public int ReturnLuck(Person p) => p._luck;

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
            Console.WriteLine($"Восприятие = {Hero._perception}");
            Console.WriteLine($"Выносливость = {Hero._endurance}");
            Console.WriteLine($"Харизма = {Hero._charisma}");
            Console.WriteLine($"Интеллект = {Hero._intelligence}");
            Console.WriteLine($"Ловкость = {Hero._agility}");
            Console.WriteLine($"Удача = {Hero._luck}");
            Console.WriteLine($"Уровень мира = {Map.LevelWorld}");
            Console.WriteLine($"Убитых врагов = {Map.KilledEnemys}");
            Console.WriteLine($"Дерево = {Hero._trees}");
            Console.WriteLine($"До портала в новый мир = {Map.LevelWorld * 5 - Map.KilledEnemys}");
        }
    }
}