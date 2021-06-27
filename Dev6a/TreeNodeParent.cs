/*using System;

namespace Dev6a
{
    public class TreeNode<T> where T : IComparable
    {
        public TreeNode<T> leftChild;
        public TreeNode<T> rightChild;
        public TreeNode<T> parent;
        public T value { get; set; }

        public TreeNode(T value, TreeNode<T> parent, TreeNode<T> left, TreeNode<T> right)
        {
            this.value = value;
            this.parent = parent;
            this.leftChild = left;
            this.rightChild = right;
        }
    }

    public class BSTree<T> where T : IComparable
    {
        public TreeNode<T> root { get; set; }
    }

    public class Program
    {
        public static void Insert<T>(BSTree<T> tree, T value) where T : IComparable         {             if (tree.root == null)             {                 tree.root = new TreeNode<T>(value, null, null, null);                 return;             }             else                 InsertStartingFrom(tree.root, value);         }          public static void InsertStartingFrom<T>(TreeNode<T> node, T value) where T : IComparable         {             if (node.value.CompareTo(value) < 0)             {                 if (node.rightChild == null)                 {                     node.rightChild = new TreeNode<T>(value, node, null, null);                 }                 else                 {                     InsertStartingFrom(node.rightChild, value);                 }             }             else if (node.value.CompareTo(value) > 0)             {                 if (node.leftChild == null)                 {                     node.leftChild = new TreeNode<T>(value, node, null, null);                 }                 else                 {                     InsertStartingFrom(node.leftChild, value);                 }             }         }          private static TreeNode<T> searchStartingFrom<T>(TreeNode<T> node, T value) where T : IComparable         {             if (node == null)                 return null;              if (node.value.CompareTo(value) == 0)                 return node;              if (node.value.CompareTo(value) < 0)                 return searchStartingFrom(node.rightChild, value);              return searchStartingFrom(node.leftChild, value);         }

        public static void DeleteValue<T>(BSTree<T> tree, T value) where T : IComparable
        {
            // special case if the value to delete is in the root (and the root has 0 children or 1 child)
            if (tree.root.value.CompareTo(value) == 0)
            {
                // there are no children:
                if (tree.root.leftChild == null && tree.root.rightChild == null)
                {
                    tree.root = null;
                    return;
                }
                // there is only left child, the right does not exist
                else if (tree.root.leftChild != null && tree.root.rightChild == null)
                {
                    tree.root = tree.root.leftChild;
                    tree.root.parent = null;
                    return;
                }
                // there is only right child, the left does not exist
                else if (tree.root.leftChild == null && tree.root.rightChild != null)
                {
                    tree.root = tree.root.rightChild;
                    tree.root.parent = null;
                    return;
                }
            }

            // all other cases. Find first the node corresponding to the value we want to delete
            TreeNode<T> nodeToDelete = searchStartingFrom(tree.root, value);
            // actually perform the deletion
            delete(tree, nodeToDelete);
        }

        private static void delete<T>(BSTree<T> tree, TreeNode<T> nodeToDelete) where T : IComparable
        {

            // CASE 1 : LEAF
            if (nodeToDelete.leftChild == null && nodeToDelete.rightChild == null)
            {
                var parent = nodeToDelete.parent;

                if (isLeftChild(nodeToDelete, parent))
                    parent.leftChild = null;
                else
                    parent.rightChild = null;

                return;
            }

            // CASE 2 : ONE CHILD
            if (nodeToDelete.leftChild == null || nodeToDelete.rightChild == null)
            {
                var parent = nodeToDelete.parent;

                if (nodeToDelete.leftChild != null)
                {
                    if (isLeftChild(nodeToDelete, parent))
                        parent.leftChild = nodeToDelete.leftChild;
                    else
                        parent.rightChild = nodeToDelete.leftChild;
                    nodeToDelete.leftChild.parent = parent;
                }
                else
                {
                    if (isLeftChild(nodeToDelete, parent))
                        parent.leftChild = nodeToDelete.rightChild;
                    else
                        parent.rightChild = nodeToDelete.rightChild;
                    nodeToDelete.rightChild.parent = parent;
                }

                return;
            }

            // CASE 3 : TWO CHILDREN

            // find inordersucc == smallest element of right subtree
            var inOrdSucc = findInOrderSucc(nodeToDelete);

            // copy value to nodeToDelete
            nodeToDelete.value = inOrdSucc.value;

            // call recursively delete on inordersucc 
            delete(tree, inOrdSucc);
        }

        // this methods finds the in order successor of the node given as parameter
        private static TreeNode<T> findInOrderSucc<T>(TreeNode<T> node) where T : IComparable
        {
            var currNode = node.rightChild;
            while (currNode.leftChild != null)
                currNode = currNode.leftChild;

            return currNode;
        }

        // this methods checks if the node given as first parameter is the left child of the node given as second parameter ("parent"). Remember to do a comparison based on the values of the nodes.
        private static bool isLeftChild<T>(TreeNode<T> node, TreeNode<T> parent) where T : IComparable
        {
            return parent.leftChild != null && parent.leftChild.value.CompareTo(node.value) == 0;
        }

        public static void Main(string[] args)
        {
            var tree = new BSTree<int>();
            Insert<int>(tree, 10);
            Insert<int>(tree, 5);
            Insert<int>(tree, 12);
            Insert<int>(tree, 3);
            Insert<int>(tree, 8);
            Insert<int>(tree, 11);
            Insert<int>(tree, 15);
            Insert<int>(tree, 1);
            DeleteValue(tree, 8);
            DeleteValue(tree, 5);
            DeleteValue(tree, 12);
            DeleteValue(tree, 10);
        }
    }
}*/