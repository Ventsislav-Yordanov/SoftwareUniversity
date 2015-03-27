namespace MountainsCodeFirst
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Mountain
    {
        public Mountain()
        {
            this.Countries = new HashSet<Country>();
            this.Peaks = new HashSet<Peak>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Peak> Peaks { get; set; }

        public virtual ICollection<Country> Countries { get; set; }
    }
}
