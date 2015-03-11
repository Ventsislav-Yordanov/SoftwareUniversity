namespace StudentSystem.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using StudentSystem.Entities.Attributes;

    public class Student
    {
        private ICollection<Course> courses;
        private ICollection<Homework> homeworks;

        public Student()
        {
            this.courses = new HashSet<Course>();
            this.homeworks = new HashSet<Homework>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Student's name is required", ErrorMessageResourceName = "Student name")]
        [MinLength(2, ErrorMessage = "Student name should be at least 2 characters", ErrorMessageResourceName = "Student name")]
        [MaxLength(30, ErrorMessage = "Student name should be between 2 and 30 characters", ErrorMessageResourceName = "Student name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Student's phone number is required", ErrorMessageResourceName = "Student phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Student's registartion date is required", ErrorMessageResourceName = "Student registartion date")]
        public DateTime RegistrationDate { get; set; }

        [Required(ErrorMessage = "Student's birthday date is required", ErrorMessageResourceName = "Student birthday")]
        [PassedDate(ErrorMessage = "Student's birthday date should be one in the past", ErrorMessageResourceName = "Student birthday")]
        public DateTime BirthDay { get; set; }

        public virtual ICollection<Course> Courses 
        {
            get { return this.courses; }
            set { this.courses = value; }
        }

        public virtual ICollection<Homework> Homeworks
        {
            get { return this.homeworks; }
            set { this.homeworks = value; }
        }
    }
}
