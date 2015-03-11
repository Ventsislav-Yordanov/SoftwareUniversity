namespace StudentSystem.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using StudentSystem.Entities.Attributes;

    public class Homework
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Homework's content is required", ErrorMessageResourceName = "Homework Content")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Homework's content type is required", ErrorMessageResourceName = "Homework ContentType")]
        public ContentType ContentType { get; set; }

        [Required(ErrorMessage = "Homework's DateSubmitted is required", ErrorMessageResourceName = "Homework DateSubmitted")]
        [PassedDate(ErrorMessage = "Homework's DateSubmitted should be one in the past.", ErrorMessageResourceName = "Homework DateSubmitted")]
        public DateTime DateSubmitted { get; set; }

        public int StudentId { get; set; }

        public virtual Student Student { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
