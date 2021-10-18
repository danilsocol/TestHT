using System;
using System.Collections.Generic;
using System.Threading;

namespace HanoiTowers
{
    class Program
    {

        static void Main(string[] args)
        {
            Town[] towns = new Town[3];
            towns[0] = new Town();
            towns[1] = new Town();
            towns[2] = new Town();
            for (int i = 5; i >= 1; i--)
            {
                towns[0].sizeDisks.Add(i);
            }
            MoveDisks1(towns, towns[0], towns[1], towns[2], 5);

            DrawTown(towns);
        }
        static void Check(Town start, Town end)
        {
            if (start.sizeDisks.Count >= 2)
            {
                if (start.sizeDisks[0] < start.sizeDisks[1])
                {
                    Console.Clear();
                    Console.WriteLine("Error");
                    Thread.Sleep(1000000);
                }

            }
            if (end.sizeDisks.Count >= 2)
            {
                if (end.sizeDisks[0] < end.sizeDisks[1])
                {
                    Console.Clear();
                    Console.WriteLine("Error");
                    Thread.Sleep(1000000);
                }
            }
        }
        private static void MoveDisks1(Town[] towns,Town start, Town temp, Town end, int disks)
        {
            Check(start, end);

            if (disks > 1)
            {
                MoveDisks1(towns,start, end, temp, disks - 1); // вызов рокировки башен для того чтоб понять с какой на какую башню стоит начать 
            }

           Check(start, end);
            end.sizeDisks.Add(start.sizeDisks[start.sizeDisks.Count - 1]); // переброска с 1 башни к другой
            start.sizeDisks.RemoveAt(start.sizeDisks.Count - 1);
            Console.Clear();
            DrawTown(towns);
            Console.WriteLine();
            Thread.Sleep(700);

            
            if (disks > 1)
            {
                MoveDisks1(towns, temp, start, end, disks - 1); // метод где меняем стартовую и вспомогательную или вспомогательную и конечную
            }                                                       //для переброски более крупного круга в конец конечной башни



        }

        private static void DrawTown(Town[] towns)
        {
            for (int i = 0; i < towns.Length; i++)
            {
                for (int j = 0; j < towns[i].sizeDisks.Count; j++)
                {
                    Console.Write($"{towns[i].sizeDisks[j]} ");
                }
                Console.WriteLine();
            }
        }
    }

    class Town
    {
        public List<int> sizeDisks = new List<int>();
        public int x { get; set; }
        public int countDisk { get; set; } = 0;
    }
}
