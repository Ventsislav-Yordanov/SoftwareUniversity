using System;
using System.Collections;
using System.Collections.Generic;

public class DoublyLinkedList<T> : IEnumerable<T>
{
    public class ListNode<T>
    {
        public T Value { get; private set; }

        public ListNode<T> NextNode { get; set; }

        public ListNode<T> PrevNode { get; set; }

        public ListNode(T value)
        {
            this.Value = value;
        }
    }

    private ListNode<T> head;
    private ListNode<T> tail;

    public int Count { get; private set; }

    public void AddFirst(T element)
    {
        var newElement = new ListNode<T>(element);

        if (this.Count == 0)
        {
            this.head = this.tail = newElement;
        }
        else
        {
            newElement.NextNode = this.head;
            this.head.PrevNode = newElement;
            this.head = newElement;
        }

        this.Count++;
    }

    public void AddLast(T element)
    {
        var newElement = new ListNode<T>(element);

        if (this.Count == 0)
        {
            this.head = this.tail = newElement;
        }
        else
        {
            newElement.PrevNode = this.tail;
            this.tail.NextNode = newElement;
            this.tail = newElement;
        }
        
        this.Count++;
    }

    public T RemoveFirst()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Cannot remove element from empty list.");
        }
        else
        {
            var firstElement = this.head;

            if (this.Count == 1)
            {
                this.head = this.tail = null;
            }
            else
            {
                this.head = this.head.NextNode;
            }

            this.Count--;
            return firstElement.Value;
        }
    }

    public T RemoveLast()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("Cannot remove element from empty list.");
        }
        else
        {
            var lastElement = this.tail;

            if (this.Count == 1)
            {
                this.head = this.tail = null;
            }
            else
            {
                this.tail = this.tail.PrevNode;
                this.tail.NextNode = null;
            }

            this.Count--;
            return lastElement.Value;
        }
    }

    public void ForEach(Action<T> action)
    {
        var currentElement = this.head;
        while (currentElement != null)
        {
            action(currentElement.Value);
            currentElement = currentElement.NextNode;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        var currentElement = this.head;
        while (currentElement != null)
        {
            yield return currentElement.Value;
            currentElement = currentElement.NextNode;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public T[] ToArray()
    {
        var array = new T[this.Count];
        int index = 0;

        var currentElement = this.head;
        while (currentElement != null)
        {
            array[index] = currentElement.Value;
            index++;
            currentElement = currentElement.NextNode;
        }

        return array;
    }
}


class Example
{
    static void Main()
    {
        var list = new DoublyLinkedList<int>();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.AddLast(5);
        list.AddFirst(3);
        list.AddFirst(2);
        list.AddLast(10);
        Console.WriteLine("Count = {0}", list.Count);

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveFirst();
        list.RemoveLast();
        list.RemoveFirst();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveLast();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");
    }
}
