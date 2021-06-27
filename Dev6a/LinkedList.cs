using System;

namespace Dev6a
{
    public class Node<T> where T : IComparable
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }

        public Node(T value, Node<T> next)
        {
            this.Value = value;
            this.Next = next;
        }
    }

    public class LinkedList<T> where T : IComparable
    {
        public Node<T> start;

        public LinkedList()
        {
            start = null;
        }

        public LinkedList(Node<T> node)
        {
            start = node;
        }

        public Node<T> Search(T value)
        {
            Node<T> curr = start;
            while (curr != null && curr.Value.CompareTo(value) != 0)
                curr = curr.Next;

            return curr;
        }
    }

    public class SortedLinkedList<T> where T : IComparable
    {
        public Node<T> start;

        public SortedLinkedList()
        {
            start = null;
        }

        public SortedLinkedList(Node<T> node)
        {
            start = node;
        }
        
        public void Insert(T value)
        {
            if (start == null || start.Value.CompareTo(value) >= 0)
            {
                start = new Node<T>(value, start);
                return;
            }

            Node<T> curr = start;
            while (curr.Next != null && curr.Next.Value.CompareTo(value) < 0)
                curr = curr.Next;
            curr.Next = new Node<T>(value, curr.Next);
        }
        
        public bool Delete(T value)
        {
            // it's not the start value, neither is it next since start.Next.Value is a smaller value than the one to be deleted
            if (start == null) return false;
            
            if (start.Next.Value.Equals(value))
            {
                start = start.Next;
                return true;
            }

            Node<T> curr = start;
            while (curr != null)
            {
                if (curr.Next.Value.Equals(value))
                {
                    curr.Next = curr.Next.Next;
                    return true;
                }
                curr = curr.Next;
            }

            return false;
        }

        public string Traverse()
        {
            string ret = "";
            Node<T> current = start;

            while (current != null)
            {
                ret += current.Value + ", ";
                current = current.Next;
            }

            return ret;

        }
    }

    public class DoublyLinkedNode<T>
    {
        public T Value { get; set; }
        public DoublyLinkedNode<T> Next { get; set; }
        public DoublyLinkedNode<T> Prev { get; set; }

        public DoublyLinkedNode(T value, DoublyLinkedNode<T> prev, DoublyLinkedNode<T> next)
        {
            this.Value = value;
            this.Next = next;
            this.Prev = prev;
        }
    }

    public class DoublyLinkedList<T>
    {
        public DoublyLinkedNode<T> First { get; set; }
        public DoublyLinkedNode<T> Last { get; set; }

        public DoublyLinkedList()
        {
            First = Last = null;
        }

        public DoublyLinkedNode<T> Search(T value)
        {
            DoublyLinkedNode<T> curr = First;

            while (curr != null && !curr.Value.Equals(value))
            {
                curr = curr.Next;
            }
            return curr;
        }
        
        public void InsertAfter(DoublyLinkedNode<T> node, T value)
        {
            DoublyLinkedNode<T> newNode = new DoublyLinkedNode<T>(value, node, node.Next);
            node.Next = newNode;

            if (Last == node) // check if node was the last one
                Last = newNode;
            else
                newNode.Next.Prev = newNode;
        }
        
        public void InsertBefore(DoublyLinkedNode<T> node, T value)
        {
            DoublyLinkedNode<T> newNode = new DoublyLinkedNode<T>(value, node.Prev, node);
            node.Prev = newNode;
            if (First == node) // check if node was the first one
                First = newNode;
            else
                newNode.Prev.Next = newNode;
        }
        
        public void InsertBeginning(T value)
        {
            DoublyLinkedNode<T> newNode = new DoublyLinkedNode<T>(value, null, First);
            if (First != null) // check First
                First.Prev = newNode;
            First = newNode;

            if (Last == null) // check Last
                Last = newNode;
        }
        
        public void InsertLast(T value)
        {
            DoublyLinkedNode<T> newNode = new DoublyLinkedNode<T>(value, Last, null);
            if (Last != null) // last node is not null
                Last.Next = newNode;
            Last = newNode;
            if (First == null) // first node is null
                First = newNode;
        }
        
        public void Remove(DoublyLinkedNode<T> node)
        {
            if (node.Prev != null) // check Prev
                node.Prev.Next = node.Next;
            if (node.Next != null) // check Next
                node.Next.Prev = node.Prev;
            if (First == node) // check First
                First = node.Next;
            if (Last == node) // check Last
                Last = node.Prev;
        }
        
    }
}