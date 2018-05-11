using System;

namespace SelectionSortExample {
    public class Selection_Sort {
        public static void Sort<T> (T[] array) where T : IComparable<T> {
            for (int i = 0; i < array.Length; i++) {
                int minIndex = i;
                T minValue = array[i];
                for (int j = i + 1; j <= array.Length - 1; j++) {
                    if (array[j].CompareTo (minValue) < 0) {
                        minIndex = j;
                        minValue = array[j];
                    }
                }
                SWAP (array, i, minIndex);
            }
        }

        private static void SWAP<T> (T[] array, int first, int second) {
            T tmp = array[first];
            array[first] = array[second];
            array[second] = tmp;
        }
    }
}