using System;

namespace ConsoleApp46
{
    /// <summary>
    ///  объект карты "персонаж"
    /// </summary>
    internal class Person
    {
        /// <summary>
        ///  макс здоровье
        /// </summary>
        private int _maxHP = 100;
        /// <summary>
        ///  здоровье
        /// </summary>
        private int _HP = 100;
        /// <summary>
        ///  деньги
        /// </summary>
        private int _coin = 0;
        /// <summary>
        ///  имя
        /// </summary>
        private string _name;
        /// <summary>
        ///  количество вырубленных деревьев
        /// </summary>
        private int _trees = 0;

        /// <summary>
        ///  сила
        /// </summary>
        private int _strenght = 1; 
        /// <summary>
        ///  восприятие
        /// </summary>
        private int _perception = 1; 
        /// <summary>
        ///  максимальная выносливость
        /// </summary>
        private int _maxEndurance = 5; 
        /// <summary>
        ///  выносливость
        /// </summary>
        private int _endurance = 5;
        /// <summary>
        ///  харизма
        /// </summary>
        private int _charisma = 1;
        /// <summary>
        ///  интеллект
        /// </summary>
        private int _intelligence = 1; 
        /// <summary>
        ///  ловкость
        /// </summary>
        private int _agility = 1;
        /// <summary>
        ///  удача
        /// </summary>
        private int _luck = 1;
        /// <summary>
        ///  создает персонажа
        /// </summary>
        /// <param name="_HP">здоровье</param>
        /// <param name="Name">имя</param>
        public Person(int _HP = 100, string Name = "Враг")
        {
            _name = Name;
            this._HP = _HP;
        }
        /// <summary>
        ///  изменение здоровья
        /// </summary>
        /// <param name="Hero">персонаж</param>
        /// <param name="hp">здоровье</param>
        static public void GetHp(Person Hero, int hp) => Hero._HP += hp;
        /// <summary>
        ///  изменение макс здоровья
        /// </summary>
        /// <param name="Hero">персонаж</param>
        /// <param name="hp">здоровье</param>
        static public void GetMaxHp(Person Hero, int hp) => Hero._maxHP += hp;
        /// <summary>
        ///  изменение денег
        /// </summary>
        /// <param name="Hero">персонаж</param>
        /// <param name="coins">деньги</param>
        static public void GetCoins(Person Hero, int coins) => Hero._coin += coins;
        /// <summary>
        ///  изменение вырубленных деревьев
        /// </summary>
        /// <param name="Hero">персонаж</param>
        /// <param name="count">деревья</param>
        static public void GetTrees(Person Hero, int count) => Hero._trees += count;

        /// <summary>
        ///  изменение силы
        /// </summary>
        /// <param name="Hero">персонаж</param>
        static public void GetStrenght(Person Hero) => Hero._strenght++;
        /// <summary>
        ///  изменение восприятия
        /// </summary>
        /// <param name="Hero">персонаж</param>
        static public void GetPerception(Person Hero) => Hero._perception++;
        /// <summary>
        ///  изменение макс выносливости
        /// </summary>
        /// <param name="Hero">персонаж</param>
        static public void GetMaxEndurance(Person Hero) => Hero._maxEndurance += 5;
        /// <summary>
        ///  изменение выносливости
        /// </summary>
        /// <param name="Hero">персонаж</param>
        static public void GetEndurance(Person Hero) => Hero._endurance++;
        /// <summary>
        ///  изменение харизмы
        /// </summary>
        /// <param name="Hero">персонаж</param>
        static public void GetCharisma(Person Hero) => Hero._charisma++;
        /// <summary>
        ///  изменение интеллекта
        /// </summary>
        /// <param name="Hero">персонаж</param>
        static public void GetIntelligence(Person Hero) => Hero._intelligence++;
        /// <summary>
        ///  изменение ловкости
        /// </summary>
        /// <param name="Hero">персонаж</param>
        static public void GetAgility(Person Hero) => Hero._agility++;
        /// <summary>
        ///  изменение удачи
        /// </summary>
        /// <param name="Hero">персонаж</param>
        static public void GetLuck(Person Hero) => Hero._luck++;

        /// <summary>
        ///  трата выносливости
        /// </summary>
        /// <param name="Hero">персонаж</param>
        static public void SpendEndurance(Person Hero) => Hero._endurance--;

        /// <summary>
        ///  нанесение ударов врагу
        /// </summary>
        /// <param name="Enemy">враг</param>
        /// <param name="Hero">персонаж</param>
        /// <param name="Shot">урон</param>
        static public void EnemyBattling(Person Enemy, Person Hero, int Shot) => Enemy._HP -= Shot * Hero._strenght;
        /// <summary>
        ///  нанесение ударов герою
        /// </summary>
        /// <param name="Hero">персонаж</param>
        /// <param name="Shot">урон</param>
        /// <param name="LevelWorld">уровень мира</param>
        static public void HeroBattling(Person Hero, int Shot, int LevelWorld)
        {
            if (Hero._HP - (Shot + LevelWorld * 5) <= Hero._HP)
                Hero._HP -= Shot + LevelWorld * 5;
        }

        /// <summary>
        ///  возвращает хп
        /// </summary>
        /// <returns>хп/returns>
        static public int ReturnHp(Person p) => p._HP;
        /// <summary>
        ///  возвращает макс хп
        /// </summary>
        /// <returns>макс хп/returns>
        static public int ReturnMaxHp(Person p) => p._maxHP;
        /// <summary>
        ///  возвращает деньги
        /// </summary>
        /// <returns>деньги/returns>
        static public int ReturnCoins(Person p) => p._coin;
        /// <summary>
        ///  возвращает деревья
        /// </summary>
        /// <returns>деревья/returns>
        static public int ReturnTrees(Person p) => p._trees;
        /// <summary>
        ///  возвращает силу
        /// </summary>
        /// <returns>сила/returns>
        static public int ReturnStrenght(Person p) => p._strenght;
        /// <summary>
        ///  возвращает восприятие
        /// </summary>
        /// <returns>восприятие/returns>
        static public int ReturnPerception(Person p) => p._perception;
        /// <summary>
        ///  возвращает выносливость
        /// </summary>
        /// <returns>выносливость/returns>
        static public int ReturnEndurance(Person p) => p._endurance;
        /// <summary>
        ///  возвращает макс выносливость
        /// </summary>
        /// <returns>макс выносливость/returns>
        static public int ReturnMaxEndurance(Person p) => p._maxEndurance;
        /// <summary>
        ///  возвращает харизму
        /// </summary>
        /// <returns>харизма/returns>
        static public int ReturnCharisma(Person p) => p._charisma;
        /// <summary>
        ///  возвращает интеллект
        /// </summary>
        /// <returns>интеллект/returns>
        static public int ReturnIntelligence(Person p) => p._intelligence;
        /// <summary>
        ///  возвращает ловкость
        /// </summary>
        /// <returns>ловкость/returns>
        static public int ReturnAgility(Person p) => p._agility;
        /// <summary>
        ///  возвращает удачу
        /// </summary>
        /// <returns>удача/returns>
        static public int ReturnLuck(Person p) => p._luck;
        /// <summary>
        ///  возвращает характеристики героя
        /// </summary>
        /// <param name="Hero">персонаж</param>
        static public void GetCharacter(Person Hero)
        {
            Console.WriteLine($"Имя героя = {Hero._name}");
            if (Hero._HP > 0)
                Console.WriteLine($"Здоровье = {Hero._HP}");
            else
                Console.WriteLine($"Здоровье = 0");
            Console.WriteLine($"MAX Здоровье = {Hero._maxHP}");
            Console.WriteLine($"Деняк = {Hero._coin}");
            Console.WriteLine($"Уровень мира = {Map.LevelWorld}");
            Console.WriteLine($"Убитых врагов = {Map.KilledEnemys}");
            Console.WriteLine($"Дерево = {Hero._trees}");
            Console.WriteLine($"До портала в новый мир = {Map.LevelWorld * 5 - Map.KilledEnemys}");
        }
    }
}