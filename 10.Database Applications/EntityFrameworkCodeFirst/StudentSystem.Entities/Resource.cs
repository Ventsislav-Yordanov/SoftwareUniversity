namespace StudentSystem.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Resource
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Resource's name is required", ErrorMessageResourceName = "Resource name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Resource's TypeOfResource is required", ErrorMessageResourceName = "Resource TypeOfResource")]
        public TypeOfResource TypeOfResource { get; set; }

        [Required(ErrorMessage = "Resource's Link is required", ErrorMessageResourceName = "Resource Link")]
        public string Link { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
