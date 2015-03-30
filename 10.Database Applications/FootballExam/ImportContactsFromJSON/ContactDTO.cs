using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportContactsFromJSON
{
    public class ContactDTO
    {
        public ContactDTO()
        {
            this.Emails = new string[0];
            this.Phones = new string[0];
        }

        [Required]
        public string Name { get; set; }

        public string Company { get; set; }

        public string Position { get; set; }
        
        public string Site { get; set; }

        public string[] Emails { get; set; }

        public string[] Phones { get; set; }

        public string Notes { get; set; }
    }
}
