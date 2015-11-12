namespace ProcessorScheduling
{
    using System;
    using System.Linq;

    public class ProcessorSchedulingExample
    {
        public static void Main()
        {
            int tasksCount = int.Parse(Console.ReadLine().Split(':')[1]);
            var tasks = new Task[tasksCount];
            for (int i = 0; i < tasksCount; i++)
            {
                var taskInfo = Console.ReadLine()
                    .Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                var newTask = new Task(i + 1, taskInfo[0], taskInfo[1]);
                tasks[i] = newTask;
            }

            tasks = tasks.OrderByDescending(t => t.Value).ToArray();
            int largestDeadLine = tasks.OrderByDescending(t => t.Deadline).Select(t => t.Deadline).First();
            var selectedtasks = new Task[largestDeadLine];
            int totalValue = 0;
            for (int i = 0; i < largestDeadLine; i++)
            {
                selectedtasks[i] = tasks[i];
                totalValue += tasks[i].Value;
            }

            selectedtasks = selectedtasks
                .OrderBy(t => t.Deadline)
                .ThenByDescending(t => t.Value)
                .ToArray();

            Console.Write("Optimal schedule: ");
            Console.WriteLine(string.Join(" -> ", selectedtasks.Select(t => t.TaskNumber)));
            Console.WriteLine($"Total value: {totalValue}");
        }
    }
}
