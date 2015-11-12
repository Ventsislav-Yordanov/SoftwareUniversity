namespace BestLecturesSchedule
{
    public class Lecture
    {
        public Lecture(string name, int start, int end)
        {
            this.Name = name;
            this.Start = start;
            this.End = end;
        }

        public string Name { get; set; }

        public int Start { get; set; }

        public int End { get; set; }

        public override string ToString()
        {
            return $"{this.Start} - {this.End} -> {this.Name}";
        }
    }
}
