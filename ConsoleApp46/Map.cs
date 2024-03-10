using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp46
{
    internal class Map
    {
        static public int levelWorld = 1;
        static Random rnd = new Random();
        
        static public void GetMap(char[,] mas)
        {
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    if (i == mas.GetLength(0)/ 2 & j == mas.GetLength(0) / 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write((char)2 + " ");
                        Console.ResetColor();
                    }
                    else if (mas[i, j] == '0')
                    { 
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(mas[i, j] + " ");
                        Console.ResetColor();
                    }
                    else if(mas[i, j] == (char)1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(mas[i, j] + " ");
                        Console.ResetColor();
                    }
                    else if(mas[i, j] == (char)3)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write(mas[i, j] + " ");
                        Console.ResetColor();
                    }
                    else if (mas[i, j] == (char)19)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(mas[i, j] + " ");
                        Console.ResetColor();
                    }
                    else if (mas[i, j] == (char)0177)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(mas[i, j] + " ");
                        Console.ResetColor();
                    }
                    else if (mas[i, j] == 'Ф')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write(mas[i, j] + " ");
                        Console.ResetColor();
                    }
                    else if (mas[i, j] == 'O')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write(mas[i, j] + " ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(mas[i, j] + " ");
                    }
                }
                Console.WriteLine();
            }
        }
        static public void Array(char[,] mas)
        {
            Random rnd = new Random();
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    int count = rnd.Next(100);

                    mas[i, j] = '.';
                    if (count < 2) //враг
                    {
                        mas[i, j] = (char)1;
                    }
                    else if (count >= 98) //сердце
                    {
                        mas[i, j] = (char)3;
                    }
                    else if (count >= 10 && count < 20) //стена
                    {
                        int X = i;
                        int Y = j;
                        for (int t = 0; t < 10; t++)
                        {
                            mas[X++, Y++] = (char)0177;
                            if (X > mas.GetLength(0) - 1 || Y > mas.GetLength(1) - 1)
                                break;
                        }
                    }
                    else if (count >= 20 && count < 30) //дерево
                    {
                        int X = i;
                        int Y = j;
                        for (int t = 0; t < 10; t++)
                        {
                            mas[X++, Y++] = 'Ф';
                            if (X > mas.GetLength(0) - 1 || Y > mas.GetLength(1) - 1)
                                break;
                        }
                    }
                    else if (count >= 30 && count < 35) //водоем
                    {
                        bool water = false;
                        if (i != 0 & j != 0 & i != mas.GetLength(0)-1 & j != mas.GetLength(1)-1)
                            for (int x = -1; x <2; x++)
                                for (int y = -1; y < 2; y++)
                                    if (mas[i + x, j + y] == 'O')
                                        water = true;
                        if (!water)
                            mas[i, j] = 'O';
                    }
                    if (levelWorld > 1)
                    {
                        mas[mas.GetLength(0) / 4, mas.GetLength(1) / 2] = (char)19;
                    }
                }
            }
        }
        static public void UpArray(char[,] mas)
        {
            char[] temp = new char[mas.GetLength(0)];


            for (int i = (mas.GetLength(0)-1); i >= 0; i--)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    if(i == (mas.GetLength(0) - 1))
                    {
                         temp[j] = mas[i,j];
                    }
                    else if (i == 0)
                    {
                        mas[i,j] = temp[j];
                    }
                    if (i != 0 )
                    {
                        mas[i,j] = mas[i-1,j];
                    }
                    if (i == (mas.GetLength(0) - 1) / 2 && j == (mas.GetLength(1) - 1) / 2)
                    {
                        mas[i, j] = (char)2;
                    }
                    if(i == (mas.GetLength(0) - 1) / 2 && j == (mas.GetLength(1) - 1) / 2)
                    {
                        mas[i +1, j] = '.';
                    }
                }
            }

            GetMap(mas);
            Win(mas);


        }
        static public void DownArray(char[,] mas)
        {
            char[] temp = new char[mas.GetLength(0)];


            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    if (i == 0)
                    {
                        temp[j] = mas[i, j];
                    }
                    else if (i == (mas.GetLength(0)-1))
                    {
                        mas[i, j] = temp[j];
                    }
                    if (i != (mas.GetLength(0)-1))
                    {
                        mas[i, j] = mas[i + 1, j];
                    }

                    if (i == (mas.GetLength(0) - 1) / 2 && j == (mas.GetLength(1) - 1) / 2)
                    {
                        mas[i, j] = (char)2;
                    }
                    if (i == (mas.GetLength(0) - 1) / 2 && j == (mas.GetLength(1) - 1) / 2)
                    {
                        mas[i - 1, j] = '.';
                    }

                }
            }
            GetMap(mas);
            Win(mas);
        }
        static public void LeftArray(char[,] mas)
        {
            char[] temp = new char[mas.GetLength(1)];

            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = (mas.GetLength(1)-1); j >=0; j--)
                {
                    if (j == (mas.GetLength(1)-1))
                    {
                        temp[i] = mas[i, j];
                    }
                    else if (j == 0)
                    {
                        mas[i, j] = temp[i];
                    }
                    if (j != 0)
                    {
                        mas[i, j] = mas[i, j-1];
                    }
                    if (i == (mas.GetLength(0) - 1) / 2 && j == (mas.GetLength(1) - 1) / 2)
                    {
                        mas[i, j] = (char)2;
                    }
                    if (i == (mas.GetLength(0) - 1) / 2 && j == (mas.GetLength(1) - 1) / 2)
                    {
                        mas[i , j+1] = '.';
                    }

                }
            }
            GetMap(mas);
            Win(mas);
        }
        static public void RightArray(char[,] mas)
        {
            char[] temp = new char[mas.GetLength(1)];

            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    if (j == 0)
                    {
                        temp[i] = mas[i, j];
                    }
                    else if (j == (mas.GetLength(1) - 1))
                    {
                        mas[i, j] = temp[i];
                    }
                    if (j != (mas.GetLength(1) - 1))
                    {
                        mas[i, j] = mas[i, j + 1];
                    }
                    if (i == (mas.GetLength(0) - 1) / 2 && j == (mas.GetLength(1) - 1) / 2)
                    {
                        mas[i, j] = (char)2;
                    }
                    if (i == (mas.GetLength(0) - 1) / 2 && j == (mas.GetLength(1) - 1) / 2)
                    {
                        mas[i, j-1] = '.';
                    }

                }
            }
            GetMap(mas);
            Win(mas);
        }
        static bool Win(char[,] mas)
        {
            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    if (mas[i,j] == (char)1 || mas[i, j] == '0')
                    {
                        return false;
                    }
                }
            }
            
            mas[10, 10] = '0';

            return true;
        }

        static void Batle(Person Hero, char[,]mas)
        {
            Person Enemy = new Person(Map.levelWorld*10);
            Random rnd  = new Random();

            while(Enemy.HP > 0 && Hero.HP > 0)
            {
                int Shot = rnd.Next(10);
                Enemy.HP -= Shot + Hero.Strenght;
                Shot = rnd.Next(10);
                Hero.HP -= Shot + levelWorld * 5;
            }
            if (Enemy.HP < Hero.HP)
            {
                Hero.coin += rnd.Next(100);
            }
        }
        static void Heart(Person Hero, char[,] mas)
        {
            Hero.HP += 10;
            if (Hero.HP - 10 == Hero.MaxHP)
                Hero.MaxHP += 10;
            else if (Hero.HP > Hero.MaxHP)
                Hero.MaxHP = Hero.HP;

        }
        static void Portal(Person Hero, char[,] mas)
        {
            for (int i = 0; i < mas.GetLength(0); i++)
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    if (mas[i, j] == (char)3)
                        Hero.coin += 100;
                }
            Hero.HP = Hero.MaxHP;
            Array(mas);
        }
        static void Forge(Person Hero)
        {
            Console.WriteLine("1. Улучшить силу на 2");
            Console.WriteLine("Для выхода нажмите Enter");
            Console.WriteLine($"Оставшиеся деньги {Hero.coin}");

            ConsoleKey key;
            while ((key = Console.ReadKey().Key) != ConsoleKey.Enter)
                switch (key)
                {
                    case ConsoleKey.NumPad1:
                        if (Hero.coin > 250)
                        {
                            Hero.Strenght += 2;
                            Hero.coin -= 250;
                            Console.WriteLine($"Сила увеличена на 2, Текущая сила = {Hero.Strenght}");
                            Console.WriteLine($"Оставшиеся деньги {Hero.coin}");
                        }
                        else
                            Console.WriteLine("Недостаточно деняк");
                        break;
                }
        }
        static public void Deforestation(char[,]map, ConsoleKeyInfo last)
        {
            int i = 0, j = 0;
            SwitchCasing(last, ref i, ref j);
            if (map[map.GetLength(0) / 2 + i, map.GetLength(0) / 2 + j] == 'Ф')
                map[map.GetLength(0) / 2 + i, map.GetLength(0) / 2 + j] = '.';
        }
        static public void Swimming(char[,] map, ConsoleKeyInfo last, Person p)
        {
            int i = 0, j = 0;
            SwitchCasing(last, ref i, ref j);
            if (map[12 + i, 12 + j] == 'O')
                switch (last.Key)
                {
                    case ConsoleKey.W:
                        if (GetIvent(p, map, 10))
                        {
                            UpArray(map);
                            UpArray(map);
                            map[13, 12] = 'O';
                        }
                        break;
                    case ConsoleKey.S:
                        if (GetIvent(p, map, 14))
                        {
                            DownArray(map);
                            DownArray(map);
                            map[11, 12] = 'O';
                        }
                        break;
                    case ConsoleKey.A:
                        if (GetIvent(p, map, 12, 10))
                        {
                            LeftArray(map);
                            LeftArray(map);
                            map[12, 13] = 'O';
                        }
                        break;
                    case ConsoleKey.D:
                        if (GetIvent(p, map, 12, 14))
                        {
                            RightArray(map);
                            RightArray(map);
                            map[12, 11] = 'O';
                        }
                        break;
                    default:
                        break;
                }
            Console.Clear();
        }
        static void SwitchCasing(ConsoleKeyInfo last, ref int i, ref int j)
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
        static public bool GetIvent(Person Hero, char[,] mas, int A = 12, int B = 12)
        {
            char key = mas[A, B];

            switch (key)
            {
                case (char)1:
                    Batle(Hero, mas);
                    break;
                case (char)3:
                    Heart(Hero, mas);
                    break;
                case '0':
                    levelWorld++;
                    Portal(Hero, mas);
                    break;
                case (char)19:
                    Forge(Hero);
                    break;
                case (char)0177:
                    return false;
                case 'Ф':
                    return false;
                case 'O':
                    return false;
                default:
                    break;
            }
            return true;

        }

    }
}
