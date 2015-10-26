namespace BreakCycles
{
    using System.Collections.Generic;

    public class Node<T>
    {
        public Node(T value)
        {
            this.Value = value;
            this.Neighbours = new List<Node<T>>();
        }

        public T Value { get; set; }

        public List<Node<T>> Neighbours { get; set; }
    }
}
