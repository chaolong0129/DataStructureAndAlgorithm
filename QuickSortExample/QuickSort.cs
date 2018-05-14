namespace QuickSortExample {
    using System;
    public class QuickSort {
        public static void Sort<T> (T[] array) where T : IComparable<T> {
            Sort (array, 0, array.Length - 1);
        }

        private static T[] Sort<T> (T[] array, int lower, int upper) where T : IComparable<T> {
            if (lower >= upper)
                return array;

            int p = Partition (array, lower, upper);
            Sort (array, lower, p);
            Sort (array, p + 1, upper);

            return array;
        }

        private static int Partition<T> (T[] array, int lower, int upper) where T : IComparable<T> {
            int i = lower;
            int j = upper;
            T pivot = array[(lower + upper) / 2];

            do {
                while (array[i].CompareTo (pivot) < 0) i++;
                while (array[j].CompareTo (pivot) > 0) j--;
                if (i >= j) break;
                SWAP (array, i, j);
            } while (i <= j);

            return j;
        }

        private static void SWAP<T> (T[] array, int i, int j) {
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}