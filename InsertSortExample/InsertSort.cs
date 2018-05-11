namespace InsertSortExample {
    using System;
    public class InsertSort {
        public static void Sort<T> (T[] array) where T : IComparable<T> {
            for (int i = 1; i < array.Length; i++) {
                int j = i;
                while (j > 0 && array[j].CompareTo (array[j - 1]) < 0) {
                    SWAP (array, j, j - 1);
                    j--;
                }
            }
        }

        private static void SWAP<T> (T[] array, int first, int second) {
            T temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }
    }
}