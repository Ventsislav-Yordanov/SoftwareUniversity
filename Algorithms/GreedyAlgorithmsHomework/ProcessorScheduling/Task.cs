namespace ProcessorScheduling
{
    public class Task
    {
        public Task(int taskNumber, int value, int deadline)
        {
            this.Value = value;
            this.Deadline = deadline;
            this.TaskNumber = taskNumber;
        }

        public int TaskNumber { get; set; }

        public int Value { get; set; }

        public int Deadline { get; set; }
    }
}
