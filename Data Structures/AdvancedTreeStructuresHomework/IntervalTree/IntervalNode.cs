namespace IntervalTree
{
    using System;

    public class IntervalNode<T> : RedBlackTree<Interval<T>>.RedBlackNode, IComparable<IntervalNode<T>> 
        where T : struct, IComparable<T>
    {
        public IntervalNode(Interval<T> interval) 
            : base(interval)
        {
        }

        public Interval<T> Interval { get; set; }

        public T MaxEndValue { get; set; }

        public int CompareTo(IntervalNode<T> other)
        {
            return this.Interval.CompareTo(other.Interval);
        }
    }
}
