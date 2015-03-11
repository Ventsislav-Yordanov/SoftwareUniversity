namespace StudentSystem.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Course
    {
        public ICollection<Student> students;
        public ICollection<Resource> resources;
        public ICollection<Homework> homeworks;

        public Course()
        {
            this.students = new HashSet<Student>();
            this.resources = new HashSet<Resource>();
            this.homeworks = new HashSet<Homework>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Course's name is required", ErrorMessageResourceName = "Course name")]
        [MinLength(2, ErrorMessage = "Course name should be at least 2 characters", ErrorMessageResourceName = "Course name")]
        [MaxLength(150, ErrorMessage = "Course name should be between 2 and 150 characters", ErrorMessageResourceName = "Course name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Course's description is required", ErrorMessageResourceName = "Course description")]
        [MinLength(20, ErrorMessage = "Course description should be at least 20 characters", ErrorMessageResourceName = "Course description")]
        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Course's price is required", ErrorMessageResourceName = "Course price")]
        public decimal Price { get; set; }

        public virtual ICollection<Student> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }

        public virtual ICollection<Resource> Resources
        {
            get { return this.resources; }
            set { this.resources = value; }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get { return this.homeworks; }
            set { this.homeworks = value; }
        }
    }
}
