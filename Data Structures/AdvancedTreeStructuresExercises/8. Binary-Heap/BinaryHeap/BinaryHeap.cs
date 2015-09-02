using System;
using System.Collections.Generic;
using System.Linq;

public class BinaryHeap<T> where T : IComparable<T>
{
    private const int RootIndex = 0;

    private List<T> heap;

    public BinaryHeap()
    {
        this.heap = new List<T>();
    }

    public BinaryHeap(T[] elements)
    {
        this.heap = elements.ToList();
        for (int i = this.Count / 2; i >= 0; i--)
        {
            this.HeapifyDown(i);
        }
    }

    public int Count
    {
        get
        {
            return this.heap.Count;
        }
    }

    public T ExtractMax()
    {
        var root = this.PeekMax();
        int lastIndex = this.Count - 1;
        this.heap[RootIndex] = this.heap[lastIndex];
        this.heap.RemoveAt(lastIndex);
        if (this.Count > 0)
        {
            this.HeapifyDown(RootIndex);
        }

        return root;
    }

    public T PeekMax()
    {
        var root = this.heap[RootIndex];
        return root;
    }

    public void Insert(T node)
    {
        this.heap.Add(node);
        this.HeapifyUp(this.Count - 1);
    }

    private void HeapifyDown(int index)
    {
        int leftChildIndex = 2 * index + 1;
        int rightChildIndex = 2 * index + 2;
        int largestIndex = index;
        if (leftChildIndex < this.Count && this.heap[largestIndex].CompareTo(this.heap[leftChildIndex]) < 0)
        {
            largestIndex = leftChildIndex;
        }

        if (rightChildIndex < this.Count && this.heap[largestIndex].CompareTo(this.heap[rightChildIndex]) < 0)
        {
            largestIndex = rightChildIndex;
        }

        if (largestIndex != index)
        {
            this.Swap(index, largestIndex);
            this.HeapifyDown(largestIndex);
        }
    }

    private void HeapifyUp(int index)
    {
        int parentIndex = (index - 1) / 2;
        if (index > RootIndex && this.heap[parentIndex].CompareTo(this.heap[index]) < 0)
        {
            this.Swap(index, parentIndex);
            this.HeapifyUp(parentIndex);
        }
    }

    private void Swap(int firstIndex, int secondIndex)
    {
        var swapValue = this.heap[firstIndex];
        this.heap[firstIndex] = this.heap[secondIndex];
        this.heap[secondIndex] = swapValue;
    }
}
