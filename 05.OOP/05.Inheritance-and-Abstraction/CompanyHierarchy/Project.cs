namespace CompanyHierarchy
{
    using System;
    public class Project : IProject
    {
        private string name;
        private DateTime startDate;
        private ProjectState state;
        private string details;

        public Project(string name, DateTime startDate, ProjectState state, string details)
        {
            this.Name = name;
            this.StartDate = startDate;
            this.State = state;
            this.Details = details;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be null!");
                }

                this.name = value;
            }
        }

        public DateTime StartDate
        {
            get { return this.startDate; }
            set { this.startDate = value; }
        }

        public ProjectState State
        {
            get { return this.state; }
            set { this.state = value; }
        }

        public string Details
        {
            get { return this.details; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("details cannot be null!");
                }

                this.details = value;
            }
        }

        public void CloseProject()
        {
            if (this.State == ProjectState.Open)
            {
                this.State = ProjectState.Closed;
            }
        }

        public override string ToString()
        {
            return string.Format(
                "Project: {0}, start date: {1:dd.MM.yyyy}, State: {2}, Details: {3}",
                this.Name,
                this.StartDate,
                this.State,
                this.Details);
        }
    }
}
