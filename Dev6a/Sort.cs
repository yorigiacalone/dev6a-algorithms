using System;

namespace Dev6a
{
    public class Sort
    {
        public void insertion(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; i++)
            {
                int key = arr[i];
                int j = i - 1;
                
                // move elements of arr [0..i-1]
                // that are greater than the key
                // to one position ahead of
                // their current position
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
        }
        
        public void insertionReverse<T>(T[] array) where T : IComparable
        {
            for (int i = 1; i < array.Length; i++)
            {
                T key = array[i];
                int j = i - 1;

                while (j >= 0 && array[j].CompareTo(key) < 0)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = key;
            }
        }

        static public void BubbleSort<T>(T[] array) where T : IComparable
        {
          var somethingChanged = true;
          while (somethingChanged)
          {
            somethingChanged = false;
            for (int i = 0; i < array.Length - 1; i++)
            {
              if (array[i].CompareTo(array[i + 1]) > 0)
              {
                var temp = array[i + 1];
                array[i + 1] = array[i];
                array[i] = temp;
                somethingChanged = true;
              }
            }
          }
        }

        /*static void mergeSort(int[] array, int l, int r)
        {
            //If the value of element l isnt smaller than the value of element r, the array has only one element left and it is considered already sorted:
            //An array is considered unsorted if it has 2 or more element, the left hand element being bigger than the right hand element.
            if (l < r)
            {
                //We compute the middle of the array.
                int m = (l + r) / 2;
                //We merge sort the left half of the array. This call will then sort the left half of that left half, etc etc until only 1 element remains of that half.
                mergeSort(array, l, m);
                //The same goes for the right half; we call merge sort on that half, which will call merge sort on the half of that half, etc.
                mergeSort(array, m + 1, r);
                //Finally:

                merge(array, l, m, r);
            }
        }*/

        /*static void merge<T>(T[] array, int low, int middle, int high)
        {
            //This number represents the end of the left half.
            int n1 = middle - low + 1;
            //This number represents the end of the right half.
            int n2 = high - middle;
            //We create a new array, the size of n1 + 1
            T[] leftpart = new T[n1 + 1];
            //We create a new array, the size of n2 + 1
            T[] rightpart = new T[n2 + 1];

            int i, j;
            
            //We loop through the left half.
            for (i = 0 ; i < n1; i++)
            {
                //We put all of the left hand side elements of the original parameter-array into our new leftArray, 
                //stopping at the end of n1(which is equal to the middle of the param-array)
                leftpart[i] = array[low + i];
            }
            //We loop through the right half.
            for (j = 0; j < n2; j++)
            {
                //We fill the new rightarray with the right half of our param array, just like we did earlier.
                rightpart[j] = array[middle + j + 1];
            }
            
            //We create placeholders for the (now) first elements of our left- and rightarrays. I declared them as i2 and j2 because i and j are already declared
            //in the child scope of the 2 previous for-loops.
            i = 0; 
            j = 0;
            //We loop through the length of the entire original array.
            for (int k = low; k <= high; k++)
            {
                //If the value of the first element of the rightarray is bigger than or equal to the value of the first element of the left array:
                if (leftpart[i].Equals(rightpart[j]))
                {
                    //The element in param-array that we are currently iterating on is set to the first element of leftArray.
                    //We do this to make sure the array is sorted from small to larger; leftArray[i2] turned out to be smaller than rightArray[j2], so we set array[k] to that (smaller) value and loop again.
                    array[k] = leftpart[i];
                    //i2 is incremented, so in the next loop we will be looking at the second element of the leftarray versus the first element of the rightarray.
                    i++;
                }
                //If the value of the first element of the leftarray is bigger than or equal to the value of the first element of the left array:
                else
                {
                    //The element in param-array that we are currently iterating on is set to the first element of rightArray.
                    //We do this to make sure the array is sorted from small to larger; rightArray[j2] turned out to be smaller than leftArray[i2], so we set array[k] to that (smaller) value and loop again.
                    array[k] = rightpart[j];
                    //j2 is incremented, so in the next loop we will be looking at the second element of the leftarray versus the first element of the rightarray.
                    j++;
                }
            }
        }*/
        
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
