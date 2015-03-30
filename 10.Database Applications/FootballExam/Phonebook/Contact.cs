using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Phonebook
{
    public class Contact
    {
        public Contact()
        {
            this.Emails = new HashSet<Email>();
            this.Phones = new HashSet<Phone>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Position { get; set; }

        public string Company { get; set; }

        public virtual ICollection<Email> Emails { get; set; }

        public virtual ICollection<Phone> Phones { get; set; }

        public string Url { get; set; }

        public string Notes { get; set; }
    }
}
