namespace BubbleSortExample {
    using System;
    public class BubbleSort {
        public static void Sort<T> (T[] array) where T : IComparable<T> {
            for (int i = 0; i < array.Length; i++) {
                for (int j = 0; j < array.Length - 1; j++) {
                    if (array[j].CompareTo (array[j + 1]) > 0)
                        SWAP (array, j, j + 1);
                }
            }
        }

        private static void SWAP<T> (T[] array, int i, int j) {
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}