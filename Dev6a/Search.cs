using System;

namespace Dev6a
{
    public class Search
    {
        public static int sequentialSearch<T>(T[] list, T value) where T : IComparable
        {
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i].Equals(value))
                    return i;
            }
            return -1;
        }

        /*public static int binarySearch(int val, int[] a)
        {
            int low = 0;
            int high = a.Length - 1;

            while (low <= high)
            {
                int middle = (low + high) / 2;
                if (val < a[middle])
                    high = middle - 1;
                else if (val > a[middle])
                    low = middle + 1;
                else
                    return middle;
            }
            
            return -1;
        }
        */

        /*public static int binaryRecSearch(int[] a, int low, int high, int val)
        {
            if (low > high)
                return -1;
            int middle = (low + high) / 2;

            if (a[middle] > val)
                return binaryRecSearch(a, low, middle - 1, val);
            else if (a[middle] < val)
                return binaryRecSearch(a, middle + 1, high, val);
            else
                return middle;
        }*/

        public static int binarySearchRec<T>(T[] a, int low, int high, T v) where T : IComparable
        {
            if (low > high)
                return -1;
            
            int middle = (low + high) / 2;
            int res = v.CompareTo(a[middle]);

            if (res == 0)
                return middle;
            else if (res > 0)
                return binarySearchRec(a, middle + 1, high, v);
            else
                return binarySearchRec(a, low, middle - 1, v);
        }
    }
}