﻿using System;
using System.Linq;

namespace SelectionSortExample
{
    class Program
    {
        private static Random rand = new Random();
        static void Main(string[] args)
        {
            System.Console.WriteLine("Selection Sort");
            int max = rand.Next(10, 20);
            int[] arrays = new int[max];
            Init_Array_Values(arrays);
            System.Console.WriteLine($"Original Array<{max}> : \t{string.Join("|", arrays)}");
            Selection_Sort.Sort(arrays);
            System.Console.WriteLine($"After Array<{max}> : \t{string.Join("|", arrays)}");
        }

        private static void Init_Array_Values(int[] arrays)
        {
            for(int i = 0; i < arrays.Length; i++) {
                arrays[i] = rand.Next(0, 100);
            }
        }
    }
}
