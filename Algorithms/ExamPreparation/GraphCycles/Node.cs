namespace GraphCycles
{
    using System;

    public class Node : IComparable<Node>
    {
        public Node(int child, int subChild, int subSubChild)
        {
            this.Child = child;
            this.SubChild = subChild;
            this.SubSubChild = subSubChild;
        }

        public int Child { get; set; }

        public int SubChild { get; set; }

        public int SubSubChild { get; set; }

        public int CompareTo(Node other)
        {
            int result = this.Child.CompareTo(other.Child);
            if (result == 0)
            {
                result = this.SubChild.CompareTo(other.SubChild);
            }

            if (result == 0)
            {
                result = this.SubSubChild.CompareTo(other.SubSubChild);
            }

            return result;
        }
    }
}
