using System;

namespace Dev6a
{
    public class SortTest
    {
        public void Insertion<T>(T[] arr, T value) where T : IComparable
        {
            for (int i = 1; i < arr.Length; i++)
            {
                T key = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j].CompareTo(key) > 0)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = key;
            }
        }
        
        public void InsertionReversed<T>(T[] arr, T value) where T : IComparable
        {
            for (int i = 1; i < arr.Length; i++)
            {
                T key = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j].CompareTo(key) < 0)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = key;
            }
        }

        static public void MergeSort<T>(T[] array, int low, int high) where T : IComparable
        {
            if (low < high)
            {
                var middle = (low + high) / 2;
                MergeSort<T>(array, low, middle);
                MergeSort<T>(array, middle + 1, high);
                Merge<T>(array, low, middle, high);
            }
        }

        static public void Merge<T>(T[] array, int low, int middle, int high) where T : IComparable
        {
            var lengthPart1 = middle - low + 1;
            var lengthPart2 = high - middle;
            T[] part1 = new T[lengthPart1];
            T[] part2 = new T[lengthPart2];
            for (int index = 0; index < lengthPart1; index++)
                part1[index] = array[low + index];
            for (int index = 0; index < lengthPart2; index++)
                part2[index] = array[middle + 1 + index];
            var i = 0;
            var j = 0;
            for (int k = low; k <= high; k++)
            {
                if (i < lengthPart1 && j < lengthPart2)
                {
                    if (part1[i].CompareTo(part2[j]) <= 0)
                    {
                        array[k] = part1[i];
                        i = i + 1;
                    }
                    else
                    {
                        array[k] = part2[j];
                        j = j + 1;
                    }
                }
                else if (i >= lengthPart1)
                {
                    array[k] = part2[j];
                    j = j + 1;
                }
                else
                {
                    array[k] = part1[i];
                    i = i + 1;
                }
            }
        }

        
        
    }
}