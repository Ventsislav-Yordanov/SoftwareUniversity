namespace OrderedSet
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class BinarySearchTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        public BinarySearchTree(T value)
        {
            this.Value = value;
        }

        public T Value { get; private set; }

        public BinarySearchTree<T> Parent { get; set; }

        public BinarySearchTree<T> LeftChild { get; set; }

        public BinarySearchTree<T> RightChild { get; set; }

        public void Add(T element)
        {
            int compareResult = element.CompareTo(this.Value);
            if (compareResult < 0)
            {
                if (this.LeftChild != null)
                {
                    this.LeftChild.Add(element);
                }
                else
                {
                    this.LeftChild = new BinarySearchTree<T>(element) { Parent = this };
                }
            }
            else if (compareResult > 0)
            {
                if (this.RightChild != null)
                {
                    this.RightChild.Add(element);
                }
                else
                {
                    this.RightChild = new BinarySearchTree<T>(element) { Parent = this };
                }
            }
        }

        public bool Contains(T element)
        {
            foreach (var node in this)
            {
                if (node.CompareTo(element) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        // Thanks to MSDN :)
        public void Remove(T element)
        {
            var node = this.Find(element);

            // CASE 1: If current has no right child, then current's left child becomes
            // the node pointed to by the parent
            if (node.RightChild == null)
            {
                if (node.Parent == null)
                {
                    node = node.LeftChild;
                }
                else
                {
                    var compareResult = node.Parent.Value.CompareTo(node.Value);
                    if (compareResult > 0)
                    {
                        // parent.Value > current.Value, so make current's left child a left child of parent
                        node.Parent.LeftChild = node.LeftChild;
                    }
                    else if (compareResult < 0)
                    {
                        // parent.Value < current.Value, so make current's left child a right child of parent
                        node.Parent.RightChild = node.LeftChild;
                    }
                }
            }
            // CASE 2: If current's right child has no left child, then current's right child
            // replaces current in the tree
            else if (node.RightChild.LeftChild == null)
            {
                node.RightChild.LeftChild = node.LeftChild;

                var compareResult = node.Parent.Value.CompareTo(node.Value);
                if (compareResult > 0)
                {
                    // parent.Value > current.Value, so make current's right child a left child of parent
                    node.Parent.LeftChild = node.RightChild;
                }
                else if (compareResult < 0)
                {
                    // parent.Value < current.Value, so make current's right child a right child of parent
                    node.Parent.RightChild = node.RightChild;
                }
            }
            // CASE 3: If current's right child has a left child, replace current with current's
            //          right child's left-most descendent
            else
            {
                // We first need to find the right node's left-most child
                BinarySearchTree<T> leftmost = node.RightChild.LeftChild,
                    leftmostParent = node.RightChild;
                while (leftmost.LeftChild != null)
                {
                    leftmostParent = leftmost;
                    leftmost = leftmost.LeftChild;
                }

                // the parent's left subtree becomes the leftmost's right subtree
                leftmostParent.LeftChild = leftmost.RightChild;

                // assign leftmost's left and right to current's left and right children
                leftmost.LeftChild = node.LeftChild;
                leftmost.RightChild = node.RightChild;
                var compareResult = node.Parent.Value.CompareTo(node.Value);
                if (compareResult > 0)
                {
                    // parent.Value > current.Value, so make leftmost a left child of parent
                    node.Parent.LeftChild = leftmost;
                }
                else if (compareResult < 0)
                {
                    // parent.Value < current.Value, so make leftmost a right child of parent
                    node.Parent.RightChild = leftmost;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (this.LeftChild != null)
            {
                foreach (var child in this.LeftChild)
                {
                    yield return child;
                }
            }

            yield return this.Value;

            if (this.RightChild != null)
            {
                foreach (var child in this.RightChild)
                {
                    yield return child;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private BinarySearchTree<T> Find(T element)
        {
            var compareResult = element.CompareTo(this.Value);
            if (compareResult == 0)
            {
                return this;
            }
            else if (compareResult < 0 && this.LeftChild != null)
            {
                return this.LeftChild.Find(element);
            }
            else if (compareResult > 0 && this.RightChild != null)
            {
                return this.RightChild.Find(element);
            }

            throw new ArgumentException("There is no such element in the tree.");
        }
    }
}