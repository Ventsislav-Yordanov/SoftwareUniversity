using System;

public class CircularQueue<T>
{
    private const int InitialCapacity = 16;
    private T[] elements;
    private int startIndex = 0;
    private int endIndex = 0;

    public int Count { get; private set; }

    public CircularQueue()
        : this(InitialCapacity)
    {
    }

    public CircularQueue(int capacity)
    {
        this.elements = new T[capacity];
    }

    public void Enqueue(T element)
    {
        if (this.Count >= this.elements.Length)
        {
            this.Grow();
        }

        this.elements[endIndex] = element;
        this.endIndex = (this.endIndex + 1) % this.elements.Length;
        this.Count++;
    }

    public T Dequeue()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        var element = this.elements[this.startIndex];
        this.startIndex = (this.startIndex + 1) % this.elements.Length;
        this.Count--;

        return element;

    }

    public T[] ToArray()
    {
        var resultArray = new T[this.Count];
        CopyAllElementsTo(resultArray);
        return resultArray;
    }

    private void Grow()
    {
        var newElements = new T[this.Count * 2];
        CopyAllElementsTo(newElements);
        this.elements = newElements;
        this.startIndex = 0;
        this.endIndex = this.Count;
    }

    private T[] CopyAllElementsTo(T[] resultArray)
    {
        var sourceIndex = this.startIndex;
        var destinationIndex = 0;
        for (int i = 0; i < this.Count; i++)
        {
            resultArray[destinationIndex] = this.elements[sourceIndex];
            sourceIndex = (sourceIndex + 1) % this.elements.Length;
            destinationIndex++;
        }

        return resultArray;
    }
}


class Example
{
    static void Main()
    {
        var queue = new CircularQueue<int>();

        queue.Enqueue(1);
        queue.Enqueue(2);
        queue.Enqueue(3);
        queue.Enqueue(4);
        queue.Enqueue(5);
        queue.Enqueue(6);

        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        var first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-7);
        queue.Enqueue(-8);
        queue.Enqueue(-9);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        queue.Enqueue(-10);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");

        first = queue.Dequeue();
        Console.WriteLine("First = {0}", first);
        Console.WriteLine("Count = {0}", queue.Count);
        Console.WriteLine(string.Join(", ", queue.ToArray()));
        Console.WriteLine("---------------------------");
    }
}
