using System;
using UnityEngine;

public class DoubleLinkedList<T> where T:IComparable<T>
{
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }
        public Node<T> Previous { get; set; }

        public Node(T value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }
    }

    int count = 0;
    Node<T> head = null;
    Node<T> tail = null;

    public int Count => count;

    public void InsertAtStart(T value)
    {
        Node<T> newNode = new Node<T>(value);
        if (head == null)
        {
            head = tail = newNode;
        }
        else
        {
            newNode.Next = head;
            head.Previous = newNode;
            head = newNode;
        }
        count++;
    }

    public void InsertAtEnd(T value)
    {
        Node<T> newNode = new Node<T>(value);
        if (tail == null)
        {
            head = tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            newNode.Previous = tail;
            tail = newNode;
        }
        count++;
    }

    public void InsertAtPosition(int position, T value)
    {
        if (position < 0 || position > count)
        {
            Console.WriteLine("Posición fuera de rango.");
            return;
        }
        else if (position == 0)
        {
            InsertAtStart(value);
            return;
        }
        else if (position == count)
        {
            InsertAtEnd(value);
            return;
        }
        else
        {
            Node<T> newNode = new Node<T>(value);
            Node<T> current = head;
            for (int i = 0; i < position - 1; i++)
            {
                current = current.Next;
            }

            newNode.Previous = current;
            newNode.Next = current.Next;

            if (current.Next != null)
                current.Next.Previous = newNode;

            current.Next = newNode;
            count++;
        }
    }

    public T GetValueAtStart()
    {
        if (head == null) throw new InvalidOperationException("La lista está vacía.");
        return head.Value;
    }

    public T GetValueAtEnd()
    {
        if (tail == null) throw new InvalidOperationException("La lista está vacía.");
        return tail.Value;
    }

    public T GetAtPosition(int position)
    {
        if (position < 0 || position >= count)
        {
            throw new ArgumentOutOfRangeException("La posición está fuera de rango.");
        }

        Node<T> current = head;
        for (int i = 0; i < position; i++)
        {
            current = current.Next;
        }

        return current.Value;
    }

    public void ModifyAtStart(T newValue)
    {
        if (head == null) throw new InvalidOperationException("La lista está vacía.");
        head.Value = newValue;
    }

    public void ModifyAtEnd(T newValue)
    {
        if (tail == null) throw new InvalidOperationException("La lista está vacía.");
        tail.Value = newValue;
    }

    public void ModifyAtPosition(int position, T newValue)
    {
        if (position < 0 || position >= count)
        {
            throw new ArgumentOutOfRangeException("La posición está fuera de rango.");
        }

        Node<T> current = head;
        for (int i = 0; i < position; i++)
        {
            current = current.Next;
        }

        current.Value = newValue;
    }

    public bool Remove(T value)
    {
        Node<T> current = head;

        while (current != null)
        {
            if (current.Value.Equals(value))
            {
                if (current.Previous != null)
                    current.Previous.Next = current.Next;
                else
                    head = current.Next;

                if (current.Next != null)
                    current.Next.Previous = current.Previous;
                else
                    tail = current.Previous;

                count--;
                return true;
            }

            current = current.Next;
        }

        return false;
    }

    public void Print()
    {
        Node<T> current = head;
        while (current != null)
        {
            Debug.Log(current.Value);
            current = current.Next;
        }
    }

    public void PrintReverse()
    {
        Node<T> current = tail;
        while (current != null)
        {
            Console.Write(current.Value + " <-> ");
            current = current.Previous;
        }
        Console.WriteLine("null");
    }


    public void InsertOrdered(T value)
    {
        Node<T> newNode = new Node<T>(value);

        if (head == null)
        {
            head = tail = newNode;
        }
        else
        {
            Node<T> current = head;
            if (current.Value.CompareTo(value) > 0)
            {
                newNode.Next = head;
                head.Previous = newNode;
                head = newNode;
            }
            else
            {
                while (current.Next != null && current.Next.Value.CompareTo(value) < 0)
                {
                    current = current.Next;
                }
                if (current.Next == null)
                {
                    current.Next = newNode;
                    newNode.Previous = current;
                    tail = newNode;
                }
                else
                {
                    newNode.Previous = current;
                    newNode.Next = current.Next;
                    current.Next.Previous = newNode;
                    current.Next = newNode;
                }
            }
        }

        count++;
    }
}
