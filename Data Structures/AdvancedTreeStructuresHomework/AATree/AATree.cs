namespace AATree
{
    using System;

    public class AATree<TKey, TValue> where TKey : IComparable<TKey>
    {
        private Node<TKey, TValue> root;
        private Node<TKey, TValue> sentinel;
        private Node<TKey, TValue> deletedNode;

        public AATree()
        {
            this.root = this.sentinel = new Node<TKey, TValue>();
            this.deletedNode = null;
        }

        public Node<TKey, TValue> Root
        {
            get
            {
                return this.root;
            }
        }

        public bool Insert(ref Node<TKey, TValue> node, TKey key, TValue value)
        {
            if (node == this.sentinel)
            {
                node = new Node<TKey, TValue>(key, value, this.sentinel);
                return true;
            }

            int compareResult = key.CompareTo(node.Key);
            if (compareResult < 0)
            {
                if (!this.Insert(ref node.LeftChild, key, value))
                {
                    return false;
                }
            }
            else if (compareResult > 0)
            {
                if (!this.Insert(ref node.RightChild, key, value))
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            this.Skew(ref node);
            this.Split(ref node);

            return true;
        }

        public bool Add(TKey key, TValue value)
        {
            return this.Insert(ref this.root, key, value);
        }

        public bool Delete(ref Node<TKey, TValue> node, TKey key)
        {
            if (node == this.sentinel)
            {
                bool hasDeletedNode = this.deletedNode != null;
                return hasDeletedNode;
            }

            int compareResult = key.CompareTo(node.Key);
            if (compareResult < 0)
            {
                if (!this.Delete(ref node.LeftChild, key))
                {
                    return false;
                }
            }
            else
            {
                if (compareResult == 0)
                {
                    this.deletedNode = node;
                }

                if (!this.Delete(ref node.RightChild, key))
                {
                    return false;
                }
            }

            if (this.deletedNode != null)
            {
                this.deletedNode.Key = node.Key;
                this.deletedNode.Value = node.Value;
                this.deletedNode = null;
                node = node.RightChild;
            }
            else if (node.LeftChild.Level < node.Level - 1
                || node.RightChild.Level < node.Level - 1)
            {
                node.Level--;
                if (node.RightChild.Level > node.Level)
                {
                    node.RightChild.Level = node.Level;
                }

                this.Skew(ref node);
                this.Skew(ref node.RightChild);
                this.Skew(ref node.RightChild.RightChild);
                this.Split(ref node);
                this.Split(ref node.RightChild);
            }

            return true;
        }

        public bool Delete(TKey key)
        {
            return this.Delete(ref this.root, key);
        }

        private void Skew(ref Node<TKey, TValue> node)
        {
            if (node.Level == node.LeftChild.Level)
            {
                // Right rotation
                var leftChild = node.LeftChild;
                node.LeftChild = leftChild.RightChild;
                leftChild.RightChild = node;
                node = leftChild;
            }
        }

        private void Split(ref Node<TKey, TValue> node)
        {
            if (node.Level == node.RightChild.RightChild.Level)
            {
                // Left rotation
                var rightChild = node.RightChild;
                node.RightChild = rightChild.LeftChild;
                rightChild.LeftChild = node;
                node = rightChild;
                rightChild.Level++;
            }
        }
    }
}
