namespace IntervalTree
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class RedBlackTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        public RedBlackNode Insert(T value)
        {
            if (_rootNode == null)
            {

                // In this case we are inserting the root node.
                var node = new RedBlackNode(value)
                {
                    ParentNode = null,
                    Color = NodeColor.Black
                };
                _rootNode = node;
                _nodeCount++;
                return node;
            }
            else
            {
                // The root already exists, so traverse the tree to figure out 
                // where to put the node.
                return InsertNode(value, _rootNode);
            }
        }

        public bool Contains(T value)
        {
            if (IsEmpty)
                return false;

            var current = _rootNode;
            while (current != null)
            {
                switch (value.CompareTo(current.NodeValue))
                {
                    case -1:
                        current = current.LeftNode;
                        break;
                    case 1:
                        current = current.RightNode;
                        break;
                    default:
                        return true;
                }
            }

            // The item wasn't found.
            return false;
        }

        private RedBlackNode InsertNode(T value, RedBlackNode current)
        {
            RedBlackNode node = null;
            if (value.CompareTo(current.NodeValue) < 0)
            {
                if (current.LeftNode == null)
                {
                    node = new RedBlackNode(value)
                    {
                        Color = NodeColor.Red,
                        ParentNode = current,
                    };
                    current.LeftNode = node;
                    _nodeCount++;
                }
                else
                {
                    return InsertNode(value, current.LeftNode);
                }
            }
            else if (value.CompareTo(current.NodeValue) > 0)
            {
                if (current.RightNode == null)
                {
                    node = new RedBlackNode(value)
                    {
                        Color = NodeColor.Red,
                        ParentNode = current,
                    };
                    current.RightNode = node;
                    _nodeCount++;
                }
                else
                {
                    return InsertNode(value, current.RightNode);
                }
            }

            // Make sure we didn't violate the rules of a red/black tree.
            CheckNode(current);

            // Automatically make sure the root node is black. 
            _rootNode.Color = NodeColor.Black;
            return node;
        }

        private void CheckNode(RedBlackNode current)
        {
            if (current == null)
                return;

            if (current.Color != NodeColor.Red) return;

            var uncleNode = GetSiblingNode(current);
            if (uncleNode != null && uncleNode.Color == NodeColor.Red)
            {
                // Switch colors and then check grandparent.
                uncleNode.Color = NodeColor.Black;
                current.Color = NodeColor.Black;
                current.ParentNode.Color = NodeColor.Red;

                // We don't have to check the root node, 
                // I'm just going to turn it black.
                if (current.ParentNode.ParentNode != null
                    && current.ParentNode.ParentNode.NodeValue.CompareTo(_rootNode.NodeValue) != 0)
                {
                    var node = current.ParentNode.ParentNode;
                    CheckNode(node);
                }
            }
            else
            {
                var redChild =
                    (current.LeftNode != null && current.LeftNode.Color == NodeColor.Red)
                    ? Direction.Left
                    : Direction.Right;

                // Need to rotate, figure out the node and direction for the rotation.
                // There are 4 scenarios here, left child of right parent, 
                // left child of left parent, right child of right parent, 
                // right child of left parent
                if (redChild == Direction.Left)
                {
                    if (current.ParentDirection == Direction.Right)
                    {
                        RotateLeftChildRightParent(current);
                    }
                    else
                    {
                        RotateLeftChildLeftParent(current);
                    }
                }
                else
                {
                    // Only do this if the right child is red, 
                    // otherwise no rotation is needed.
                    if (current.RightNode.Color == NodeColor.Red)
                    {
                        if (current.ParentDirection == Direction.Right)
                        {
                            RotateRightChildRightParent(current);
                        }
                        else
                        {
                            RotateRightChildLeftParent(current);
                        }
                    }
                }
            }
        }

        private static RedBlackNode GetSiblingNode(RedBlackNode current)
        {
            if (current == null || current.ParentNode == null)
            {
                return null;
            }

            if (current.ParentNode.LeftNode != null &&
                current.ParentNode.LeftNode.NodeValue.CompareTo(current.NodeValue) == 0)
            {
                return current.ParentNode.RightNode;
            }

            return current.ParentNode.LeftNode;
        }

        private void FixChildColors(RedBlackNode current)
        {
            // If a node is red, both children must be black,switch if necessary.
            if (current.Color == NodeColor.Red)
            {
                if (current.LeftNode != null
                    && current.LeftNode.Color == NodeColor.Black)
                {
                    current.LeftNode.Color = NodeColor.Red;
                    current.Color = NodeColor.Black;
                }
                else if (current.RightNode != null
                            && current.RightNode.Color == NodeColor.Black)
                {
                    current.RightNode.Color = NodeColor.Red;
                    current.Color = NodeColor.Black;
                }
            }
        }

        private void RotateRightChildRightParent(RedBlackNode current)
        {
            // Don't rotate on the root.
            if (current.IsRoot)
            {
                return;
            }

            var tmpNode = current.RightNode.LeftNode;
            current.RightNode.ParentNode = current.ParentNode;
            current.ParentNode.LeftNode = current.RightNode;
            current.ParentNode = current.RightNode;
            current.RightNode.LeftNode = current;

            if (tmpNode != null)
            {
                current.RightNode = tmpNode;
                tmpNode.ParentNode = current;
            }
            else
            {
                current.RightNode = tmpNode;
            }

            // The new node to check is the parent node.
            var newCurrent = current.ParentNode;
            CheckNode(newCurrent);
        }

        private void RotateLeftChildLeftParent(RedBlackNode current)
        {
            // Don't rotate on the root.
            if (current.IsRoot)
            {
                return;
            }

            var tmpNode = current.LeftNode.RightNode;
            current.LeftNode.ParentNode = current.ParentNode;
            current.ParentNode.RightNode = current.LeftNode;
            current.ParentNode = current.LeftNode;
            current.LeftNode.RightNode = current;

            if (tmpNode != null)
            {
                current.LeftNode = tmpNode;
                tmpNode.ParentNode = current;
            }
            else
            {
                current.LeftNode = tmpNode;
            }

            // The new node to check is the parent node.
            var newCurrent = current.ParentNode;
            CheckNode(newCurrent);
        }

        private void RotateLeftChildRightParent(RedBlackNode current)
        {
            // Don't rotate on the root.
            if (current.IsRoot)
                return;

            if (current.RightNode != null)
            {
                current.ParentNode.LeftNode = current.RightNode;
                current.RightNode.ParentNode = current.ParentNode;
            }
            else
            {
                current.ParentNode.LeftNode = current.RightNode;
            }

            var tempNode = current.ParentNode.ParentNode;
            current.RightNode = current.ParentNode;
            current.ParentNode.ParentNode = current;

            if (tempNode == null)
            {
                _rootNode = current;
                current.ParentNode = null;
            }
            else
            {
                current.ParentNode = tempNode;

                // Make sure we have the pointer from the parent.
                if (tempNode.NodeValue.CompareTo(current.NodeValue) > 0)
                {
                    tempNode.LeftNode = current;
                }
                else
                {
                    tempNode.RightNode = current;
                }
            }

            FixChildColors(current);

            // The new node to check is the parent node.
            var newCurrent = current.ParentNode;
            CheckNode(newCurrent);
        }

        private void RotateRightChildLeftParent(RedBlackNode current)
        {
            // Don't rotate on the root.
            if (current.IsRoot)
                return;

            if (current.LeftNode != null)
            {
                current.ParentNode.RightNode = current.LeftNode;
                current.LeftNode.ParentNode = current.ParentNode;
            }
            else
            {
                current.ParentNode.RightNode = current.LeftNode;
            }

            var tmpNode = current.ParentNode.ParentNode;
            current.LeftNode = current.ParentNode;
            current.ParentNode.ParentNode = current;

            if (tmpNode == null)
            {
                _rootNode = current;
                current.ParentNode = null;
            }
            else
            {
                current.ParentNode = tmpNode;

                // Make sure we have the pointer from the parent.
                if (tmpNode.NodeValue.CompareTo(current.NodeValue) > 0)
                {
                    tmpNode.LeftNode = current;
                }
                else
                {
                    tmpNode.RightNode = current;
                }
            }

            FixChildColors(current);

            // The new node to check is the parent node.
            var newCurrent = current.ParentNode;
            CheckNode(newCurrent);
        }

        public enum Direction
        {
            Left = 0,
            Right = 1
        }

        public enum NodeColor
        {
            Red = 0,
            Black = 1
        }

        public class RedBlackNode
        {
            private readonly T _nodeValue;
            private RedBlackNode _parentNode;
            private RedBlackNode _leftNode;
            private RedBlackNode _rightNode;

            public NodeColor Color { get; set; }

            public Direction ParentDirection
            {
                get
                {
                    if (ParentNode == null ||
                        NodeValue.CompareTo(ParentNode.NodeValue) > 0)
                    {
                        return Direction.Left;
                    }

                    return Direction.Right;
                }
            }

            public T NodeValue
            {
                get { return _nodeValue; }
            }

            public RedBlackNode ParentNode
            {
                get { return _parentNode; }
                set { _parentNode = value; }
            }

            public RedBlackNode LeftNode
            {
                get { return _leftNode; }
                set { _leftNode = value; }
            }

            public RedBlackNode RightNode
            {
                get { return _rightNode; }
                set { _rightNode = value; }
            }

            public bool IsRoot
            {
                get { return (_parentNode == null); }
            }

            public bool IsLeaf
            {
                get { return (_leftNode == null && _rightNode == null); }
            }


            public RedBlackNode(T nodeValue)
                : this(nodeValue, null, null)
            {
            }

            public RedBlackNode(T nodeValue,
                RedBlackNode left, RedBlackNode right)
            {
                _nodeValue = nodeValue;
                Color = NodeColor.Red;
                _leftNode = left;
                _rightNode = right;
                _parentNode = null;
            }

            public override string ToString()
            {
                return _nodeValue.ToString();
            }
        }

        private RedBlackNode _rootNode;
        private int _nodeCount;

        public RedBlackNode RootNode
        {
            get { return _rootNode; }
        }

        public int NodeCount
        {
            get { return _nodeCount; }
        }

        public bool IsEmpty
        {
            get { return (_rootNode == null); }
        }

        public T MinValue
        {
            get
            {
                // I could have returned default(T) here, 
                // but I don't like that for integer trees. 
                // (returns a 0, which could be misleading)
                if (IsEmpty)
                {
                    throw new Exception("Error: Cannot determine minimum value of an empty tree");
                }

                // You can get the min value by traversing left from the root 
                // until you can't any more.
                var node = _rootNode;
                while (node.LeftNode != null)
                {
                    node = node.LeftNode;
                }

                return node.NodeValue;
            }
        }

        public T MaxValue
        {
            get
            {
                // I could have returned default(T) here, 
                // but I don't like that for integer trees. 
                // (returns a 0, which could be misleading)
                if (IsEmpty)
                {
                    throw new Exception("Error: Cannot determine maximum value of an empty tree");
                }

                // You can get the max value by traversing right from the root 
                // until you can't any more.
                var node = _rootNode;
                while (node.RightNode != null)
                {
                    node = node.RightNode;
                }

                return node.NodeValue;
            }
        }

        public RedBlackTree()
        {
            _rootNode = null;
        }

        private static IEnumerable<T> InOrderTraversal(RedBlackNode node)
        {
            if (node.LeftNode != null)
            {
                foreach (T nodeVal in InOrderTraversal(node.LeftNode))
                {
                    yield return nodeVal;
                }
            }

            yield return node.NodeValue;

            if (node.RightNode != null)
            {
                foreach (T nodeVal in InOrderTraversal(node.RightNode))
                {
                    yield return nodeVal;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T val in InOrderTraversal(_rootNode))
            {
                yield return val;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

}