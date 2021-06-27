using System;
using System.Collections.Generic;

namespace Dev6a
{
    class Program
    {
        static void printArray(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.Write("\n");
        }
        
        static void Main(string[] args)
        {
            /*
            string binIndex = Search.binarySearchT<T>(pseudoArray, 0, pseudoArray.Length - 1, 3).ToString();

            Console.WriteLine("Binary index: {0}", binIndex);*/
            int[] pseudoArray2 = { 2, 5, 7, 8, 9, 1, 3};
            int seqIndex = Search.sequentialSearch<int>(pseudoArray2, 3);
            Console.WriteLine("Sequential index: {0}", seqIndex);
            
            int[] pseudoArray = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            string binRecIndex = Search.binarySearchRec(pseudoArray, 0, pseudoArray.Length - 1, 5).ToString();
            Console.WriteLine("Binary recursive index: {0}", binRecIndex);

            // insertion
            // bubble
            // merge
            Sort sort = new Sort();
            
            int[] test = { 78, 55, 45, 98, 13 };
            sort.insertion(test);
            printArray(test);
            
            int[] test2 = {78, 55, 45, 98, 13};
            sort.bubble(test2);
            printArray(test2);
            
            int[] test3 = { 78, 55, 45, 98, 13 };
            sort.insertionReverse(test3);
            printArray(test3);
            
            SortedLinkedList<int> list = new SortedLinkedList<int>();
            list.Insert(3);
            list.Insert(7);
            list.Insert(23);
            list.Insert(6);
            
            
            int[] a = new int[] { 1, 3, 7, 8, 5, 6, 9, 12 };
            Sort.Merge(a, 0, 3, a.Length - 1);
            a = new int[] { 4, 6, 9, 1, 5 };
            Sort.Merge(a, 0, 2, a.Length - 1);
            a = new int[] { 3, 4, 6, 8, 9, 1, 2, 3, 5, 10 };
            Sort.Merge(a, 0, 4, a.Length - 1);
            a = new int[] { 2, 3, 7, 1, 8, 5, 6, 12 };
            Sort.Merge(a, 0, 3, a.Length - 1);
            a = new int[] { 5, 2, 3, -7, 1, -8, -5, -6, 12 };
            Sort.Merge(a, 5, 6, 8);
            
            
            var tree = new BSTree<int>();
            TreeNode<int>.Insert<int>(tree, 6);
            TreeNode<int>.Insert<int>(tree, -5);
            TreeNode<int>.Insert<int>(tree, -1);
            TreeNode<int>.Insert<int>(tree, 3);
            TreeNode<int>.Insert<int>(tree, 8);
            TreeNode<int>.Insert<int>(tree, -3);
            TreeNode<int>.Insert<int>(tree, 7);
            TreeNode<int>.Insert<int>(tree, 12);
            var result = TreeNode<int>.PreOrderTraversal<int>(tree.root);

        }
    }
}