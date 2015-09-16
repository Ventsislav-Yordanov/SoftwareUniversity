using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class FirstLastList<T> : IFirstLastList<T>
    where T : IComparable<T>
{
    private LinkedList<T> elements;
    private OrderedBag<LinkedListNode<T>> minBag;
    private OrderedBag<LinkedListNode<T>> maxBag;

    public FirstLastList()
    {
        this.elements = new LinkedList<T>();
        this.minBag = new OrderedBag<LinkedListNode<T>>((x, y) => x.Value.CompareTo(y.Value));
        this.maxBag = new OrderedBag<LinkedListNode<T>>((x, y) => -x.Value.CompareTo(y.Value));
    }

    public void Add(T newElement)
    {
        var node = this.elements.AddLast(newElement);
        this.minBag.Add(node);
        this.maxBag.Add(node);
    }

    public int Count
    {
        get
        {
            return this.elements.Count;
        }
    }

    public IEnumerable<T> First(int count)
    {
        this.ValidateCount(count);
        var firstElements = this.elements.Take(count);
        return firstElements;
    }

    public IEnumerable<T> Last(int count)
    {
        this.ValidateCount(count);
        var lastElements = this.elements.Reverse().Take(count);
        return lastElements;
    }

    public IEnumerable<T> Min(int count)
    {
        this.ValidateCount(count);
        var minElements = this.minBag.Take(count).Select(e => e.Value);
        return minElements;
    }

    public IEnumerable<T> Max(int count)
    {
        this.ValidateCount(count);
        var maxElements = this.maxBag.Take(count).Select(e => e.Value);
        return maxElements;
    }

    public int RemoveAll(T element)
    {
        var node = new LinkedListNode<T>(element);
        var elementsToRemove = this.minBag.Range(node, true, node, true);
        foreach (var elementToRemove in elementsToRemove)
        {
            this.elements.Remove(elementToRemove);
        }

        int count = this.minBag.RemoveAllCopies(node);
        this.maxBag.RemoveAllCopies(node);
        return count;
    }

    public void Clear()
    {
        this.elements.Clear();
        this.minBag.Clear();
        this.maxBag.Clear();
    }

    private void ValidateCount(int count)
    {
        if (count > this.Count)
        {
            throw new ArgumentOutOfRangeException();
        }
    }
}