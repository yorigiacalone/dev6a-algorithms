using System;
using System.ComponentModel;

namespace Dev6a
{
    public class TreeNode<T> where T : IComparable
    {
        public TreeNode<T> leftChild;
        public TreeNode<T> rightChild;
        /*public TreeNode<T> parent;*/
        public T value { get; set; }

        public TreeNode(T value,/*TreeNode<T> parent, */ TreeNode<T> left, TreeNode<T> right) {
            this.value = value;
            /*this.parent = parent;*/
            this.leftChild = left;
            this.rightChild = right;
        }
        public static void Insert<T>(BSTree<T> tree, T value) where T : IComparable {
            if (tree.root == null) {
                tree.root = new TreeNode<T>(value, null, null);
                return;
            } 
            else
                InsertStartingFrom(tree.root, value);
        }
        
        public static string PreOrderTraversal<T>(TreeNode<T> currNode) where T : IComparable
        {
            if (currNode == null)
                return "";

            string s = currNode.value.ToString() + " ";
            s += PreOrderTraversal(currNode.leftChild);
            s += PreOrderTraversal(currNode.rightChild);

            return s;
        }
        
        public static string InOrderTraversal<T>(TreeNode<T> currNode) where T : IComparable
        {
            if (currNode == null)
                return "";

            string s = "";
            s += InOrderTraversal(currNode.leftChild);
            s += currNode.value.ToString() + " ";
            s += InOrderTraversal(currNode.rightChild);

            return s;
        }
        
        public static string PostOrderTraversal<T>(TreeNode<T> currNode) where T : IComparable
        {
            if (currNode == null)
                return "";

            string s = "";
            s += PostOrderTraversal(currNode.leftChild);
            s += PostOrderTraversal(currNode.rightChild);
            s += currNode.value.ToString() + " ";

            return s;
        }
        
        public static TreeNode<T> Search<T>(BSTree<T> tree, T value) where T : IComparable
        {
            return SearchStartingFrom(tree.root, value);
        }

        protected static TreeNode<T> SearchStartingFrom<T>(TreeNode<T> node, T value) where T : IComparable
        {
            if (node == null) // node does not exist
                return null;

            if (node.value.CompareTo(value) == 0) // value in the node is the same we are looking for
                return node;

            if (node.value.CompareTo(value) < 0) // value in the node is smaller than the one we are looking for
                return SearchStartingFrom(node.rightChild, value);

            return SearchStartingFrom(node.leftChild, value);
        }
        public static void InsertStartingFrom<T>(TreeNode<T> node, T value)  where T : IComparable
        {
            if (node.value.CompareTo(value) < 0) // the value to insert is greater than the value of the node
            {
                if (node.rightChild == null) // is the child empty (and thus we can insert in the child)?
                {
                    node.rightChild = new TreeNode<T>(value, null, null);
                }
                else
                {
                    InsertStartingFrom(node.rightChild, value);
                }
            }
            else if (node.value.CompareTo(value) > 0) // the value to insert is smaller than the value of the node
            {
                if (node.leftChild == null) // is the child empty (and thus we can insert in the child)?
                {
                    node.leftChild = new TreeNode<T>(value, null, null);;
                }
                else
                {
                    InsertStartingFrom(node.leftChild, value);
                }
            }
        }
        
        /*public static void DeleteValue<T>(BSTree<T> tree, T value) where T : IComparable
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
        }*/
    }

    public class BSTree<T> where T : IComparable
    {
        public TreeNode<T> root { get; set; }
    }
}