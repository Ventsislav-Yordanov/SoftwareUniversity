namespace AATree
{
    public class Node<TKey, TValue>
    {
        internal Node<TKey, TValue> LeftChild;
        internal Node<TKey, TValue> RightChild;

        internal Node()
        {
            this.Level = 0;
            this.LeftChild = this;
            this.RightChild = this;
        }

        internal Node(TKey key, TValue value, Node<TKey, TValue> sentinel)
        {
            this.Level = 1;
            this.Key = key;
            this.Value = value;
            this.LeftChild = sentinel;
            this.RightChild = sentinel;
        }

        internal int Level { get; set; }

        internal TKey Key { get; set; }

        internal TValue Value { get; set; }
    }
}
