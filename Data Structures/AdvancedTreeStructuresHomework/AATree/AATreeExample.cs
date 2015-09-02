namespace AATree
{
    using System;
    using System.Linq;

    public class AATreeExample
    {
        public static void Main()
        {
            var tree = new AATree<int, int>();

            // To see our tree example, visit this link: http://web.eecs.umich.edu/~sugih/courses/eecs281/f11/lectures/12-AAtrees+Treaps.pdf
            // I use the numbers as keys, and the indexes in the array as values
            // (the values don't really matter for this example)
            var numbers = new[] { 30, 15, 5, 20, 10, 70, 50, 85, 35, 60, 80, 90, 40, 55, 65 };
            for (int i = 0; i < numbers.Length; i++)
            {
                tree.Add(numbers[i], i);
            }

            Console.WriteLine("After insertion:");
            DisplayTree(tree.Root, string.Empty);

            // Delete random half of the nodes in the tree
            var numbersToDelete = numbers
                .OrderBy(n => Guid.NewGuid())
                .ToArray();
            for (int i = 0; i < numbersToDelete.Length / 2; i++)
            {
                tree.Delete(numbersToDelete[i]);
                // Console.WriteLine("Deleted node {0}", numbersToDelete[i]);
                // DisplayTree(tree.Root, string.Empty);
            }

            Console.WriteLine("After deletion:");
            DisplayTree(tree.Root, string.Empty);
        }

        private static void DisplayTree(Node<int, int> node, string indent)
        {
            Console.WriteLine(indent + node.Key + " (level:" + node.Level + ")");
            if (node.LeftChild.Level != 0)
            {
                DisplayTree(node.LeftChild, indent + "  ");
            }

            if (node.RightChild.Level != 0)
            {
                DisplayTree(node.RightChild, indent + "  ");
            }
        }
    }
}
