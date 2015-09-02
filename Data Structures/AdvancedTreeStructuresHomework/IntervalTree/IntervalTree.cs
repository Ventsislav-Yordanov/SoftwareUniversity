namespace IntervalTree
{
    using System;

    public class IntervalTree<T> : RedBlackTree<IntervalNode<T>> where T : struct, IComparable<T>
    {
        // Because of the way the Red-Black Tree (RBT) is implemented, I am using "nodes of nodes":
        // each node in the RBT contains an interval node (as its value).
        // So, this is a node-ception :D
        public IntervalTree()
            : base()
        {
        }

        public void Insert(Interval<T> interval)
        {
            var insertNode = this.Insert(new IntervalNode<T>(interval));
            T maxValue = GetMaxValue(interval, insertNode);
            insertNode.NodeValue.MaxEndValue = maxValue;
            while (insertNode.ParentNode != null)
            {
                T maxParentValue = GetMaxValue(insertNode.ParentNode.NodeValue.Interval, insertNode.ParentNode);
                insertNode.ParentNode.NodeValue.MaxEndValue = maxParentValue;
                insertNode = insertNode.ParentNode;
            }
        }

        public IntervalNode<T> Search(Interval<T> interval)
        {
            var currentNode = this.RootNode;
            while (currentNode != null && (!interval.Overlaps(currentNode.NodeValue.Interval)))
            {
                if (currentNode.LeftNode != null && interval.Start.CompareTo(currentNode.LeftNode.NodeValue.MaxEndValue) <= 0)
                {
                    currentNode = currentNode.LeftNode;
                }
                else
                {
                    currentNode = currentNode.RightNode;
                }
            }

            if (currentNode != null)
            {
                return currentNode.NodeValue;
            }
            else
            {
                return null;
            }
        }

        private static T GetMaxValue(Interval<T> interval, RedBlackNode insertNode)
        {
            var maxValue = interval.End;
            if (insertNode.LeftNode != null)
            {
                var leftMaxValue = insertNode.LeftNode.NodeValue.MaxEndValue;
                if (leftMaxValue.CompareTo(maxValue) > 0)
                {
                    maxValue = leftMaxValue;
                }
            }

            if (insertNode.RightNode != null)
            {
                var rightMaxValue = insertNode.RightNode.NodeValue.MaxEndValue;
                if (rightMaxValue.CompareTo(maxValue) > 0)
                {
                    maxValue = rightMaxValue;
                }
            }

            return maxValue;
        }
    }
}
