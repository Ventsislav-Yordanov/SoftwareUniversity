namespace IntervalTree
{
    using System;

    public class Interval<T> : IComparable<Interval<T>> where T : struct, IComparable<T>
    {
        public Interval(T start, T end)
        {
            CheckIntervalValidity(start, end);

            this.Start = start;
            this.End = end;
        }

        public T Start { get; set; }

        public T End { get; set; }

        public bool Contains(Interval<T> interval)
        {
            bool startsBeforeInterval = this.Start.CompareTo(interval.Start) <= 0;
            bool endsAfterInterval = this.End.CompareTo(interval.End) >= 0;
            return startsBeforeInterval && endsAfterInterval;
        }

        public bool Contains(T value)
        {
            bool valueIsAfterStart = this.Start.CompareTo(value) <= 0;
            bool valueIsBeforeEnd = this.End.CompareTo(value) >= 0;
            return valueIsAfterStart && valueIsBeforeEnd;
        }

        public bool Overlaps(Interval<T> interval)
        {
            bool overlapsStart = this.Start.CompareTo(interval.End) <= 0;
            bool overlapsEnd = this.End.CompareTo(interval.Start) >= 0;
            return overlapsStart && overlapsEnd;
        }

        public int CompareTo(Interval<T> other)
        {
            if (this.Start.CompareTo(other.Start) < 0)
            {
                return -1;
            }
            else if (this.Start.CompareTo(other.Start) > 0)
            {
                return 1;
            }
            else if (this.End.CompareTo(other.End) < 0)
            {
                return 1;
            }
            else if (this.End.CompareTo(other.End) > 0)
            {
                return -1;
            }

            return 0;
        }

        private static void CheckIntervalValidity(T start, T end)
        {
            if (start.CompareTo(end) > 0)
            {
                throw new ArgumentException("The start of the interval must be before its end.");
            }
        }
    }
}
