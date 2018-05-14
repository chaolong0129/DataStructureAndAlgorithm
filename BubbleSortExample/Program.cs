using System;

namespace BubbleSortExample
{
    class Program
    {
        private static Random rand = new Random();
        static void Main(string[] args)
        {
            System.Console.WriteLine ("Bubble Sort");
            int max = rand.Next (10, 20);
            int[] arrays = new int[max];
            Init_Array_Values (arrays);
            System.Console.WriteLine ($"Original Array<{max}> : \t{string.Join("|", arrays)}");
            BubbleSort.Sort (arrays);
            System.Console.WriteLine ($"After Array<{max}> : \t{string.Join("|", arrays)}");

            Init_Array_Values(arrays);
            System.Console.WriteLine ($"Original Array<{max}> : \t{string.Join("|", arrays)}");
            BubbleSort.Sort2 (arrays);
            System.Console.WriteLine ($"After Array<{max}> : \t{string.Join("|", arrays)}");
        }

        private static void Init_Array_Values (int[] arrays) {
            for (int i = 0; i < arrays.Length; i++) {
                arrays[i] = rand.Next (0, 100);
            }
        }
    }
}
