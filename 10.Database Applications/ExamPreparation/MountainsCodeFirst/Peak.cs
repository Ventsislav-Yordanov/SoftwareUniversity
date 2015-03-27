namespace MountainsCodeFirst
{
    using System.ComponentModel.DataAnnotations;

    public class Peak
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public int Elevation { get; set; }

        public int MountainId { get; set; }

        public virtual Mountain Mountain { get; set; }
    }
}
