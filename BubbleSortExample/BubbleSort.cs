namespace BubbleSortExample
{
    using System;
    public class BubbleSort
    {
        public static void Sort<T>(T[] array) where T : IComparable<T>
        {
            for (int i = 0; i < array.Length; i++) {
                for (int j = 0; j < array.Length; j++) {
                    if (array[i].CompareTo(array[j]) < 0)
                        SWAP(array, i, j);
                }
            }
        }

        private static void SWAP<T>(T[] array, int i, int j)
        {
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}