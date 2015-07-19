namespace LinkedStack
{
    class Program
    {
        static void Main()
        {
            LinkedStack<int> linkedStack = new LinkedStack<int>();
            linkedStack.Push(1);
            linkedStack.Push(21);
            linkedStack.Push(13);
            linkedStack.Push(4544);
            linkedStack.Pop();
            var arr = linkedStack.ToArray();
            System.Console.WriteLine();
        }
    }
}
